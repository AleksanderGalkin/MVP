using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDbUserInterface.ServiceInterfaces;
using ClassLibrary1.View;
using GeoDbUserInterface.View;
using FastReport;
using System.Reflection;
using System.IO;
using GeoDB.Model;
using GeoDB.Service.DataAccess.Interface;

namespace GeoDB.Presenter
{
    public class PDrillHoles2PrintSet
    {
        private IBaseService<COLLAR2> _collarModel;
        private IBaseService<ASSAYS2> _assaysModel;
        private IViewDrillHoles2PrintSet _view;

        public event EventHandler<EventArgs> _formClosing;

        private IEnumerable<IGrouping<int,COLLAR2>> selectGroup;
        public PDrillHoles2PrintSet(IBaseService<COLLAR2> CollarModel, IBaseService<ASSAYS2> AssaysModel, IViewDrillHoles2PrintSet View)
        {
            _collarModel = CollarModel;
            _assaysModel = AssaysModel;
            _view = View;

            _view._selectBench +=new EventHandler<EventArgs>(On_view__selectBench);
            _view._clickOk += new EventHandler<EventArgs>(On_view__clickOk);
            _view._formClosing+=new EventHandler<EventArgs>(On_view__formClosing);

            _view.benchList = new List<string>();
            _view.blastList = new List<string>();
            
        }

        public void Show()
        {
            selectGroup =
                from a in _collarModel.Get()
                group a by a.GORIZONT.BENCH_NAME into g
                select g;
            var bench =
                from a in selectGroup
                orderby a.Key
                select a.Key.ToString();
            _view.benchList = bench.ToList();

            _view.Show();
            
        }

        public IView OwnerForm { set { _view.OwnerForm = value; } }
        public IView _MdiParent { set { _view._MdiParent = value; } }

        private void On_view__selectBench(object sender,EventArgs e)
        {
            string bench = _view.bench;
            if (string.IsNullOrEmpty(bench)) return;
            var blast1 =
                (from a in selectGroup
                 where a.Key.ToString() == bench
                 select a).SingleOrDefault();
            var blast =
                (from a in blast1
                 group a by a.RL_EXPLO2.EXPL_LINE_NAME into g
                 orderby g.Key
                 select g.Key)
                .ToList();

            _view.blastList = blast;
        }
        private void On_view__clickOk(object sender,EventArgs e)
        {
            Console.WriteLine("{0},{1}",_view.bench,_view.blast);
            _view.Close();
            Report(_view.bench, _view.blast);

        }
        private void On_view__formClosing(object sender, EventArgs e)
        {
            var ev = _formClosing;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
        }

        private void Report(string bench, string blast)
        {
            if (string.IsNullOrEmpty(bench)) return;
            bool isAllBenchReport;
            string tTittleText;
            if (string.IsNullOrEmpty(blast))
            {
                isAllBenchReport = true;
                tTittleText = "всему горизонту №"+bench;
            }
            else
            {
                isAllBenchReport = false;
                tTittleText = "горизонту №" + bench+", взрыву №"+blast;
            }
            dynamic samples;
            if (isAllBenchReport)
            {
                samples = from a in _assaysModel.Get()
                          join c in _collarModel.Get()
                          on a.BHID equals c.ID
                          where c.GORIZONT.BENCH_NAME.ToString() == bench
                          select new
                          {
                              id = a.ID,
                              bhid = c.BHID,
                              sample = a.SAMPLE,
                              from_ = a.FROM,
                              to = a.TO,
                              length = a.LENGTH,
                              zblock = a.BLOCK_ZAPASOV != null ? a.BLOCK_ZAPASOV.CATEGORY : "не определено",
                              lito = a.LITOLOGY.ROCK ?? "не определено",
                              rang = a.RANG1 != null ? a.RANG1.TYPE_RANG : "не определено",
                              ves = a.VES_SAMPLE,
                              au = a.Au,
                              au_cut = a.Au_cut,
                              as_ = a.As,
                              sb = a.Sb,
                              s = a.S,
                              ca = a.Ca,
                              fe = a.Fe,
                              ag = a.Ag,
                              c = a.C,
                              end_date = a.END_DATE.ToShortDateString(),
                              blank = a.REESTR_VEDOMOSTEI.BLANK_ID ?? "не определено",
                              journal = a.JOURNAL1.JOURNAL_NAME ?? "не определено",
                              geologist = a.GEOLOGIST1.GEOLOGIST_NAME ?? "не определено",
                              pit = a.PIT,
                              lastUserID = "не определено",
                              lastDT = a.LastDT
                          };
            }
            else
            {
                samples = from a in _assaysModel.Get()
                          join c in _collarModel.Get()
                          on a.BHID equals c.ID
                          where c.GORIZONT.BENCH_NAME.ToString() == bench
                          && c.RL_EXPLO2.EXPL_LINE_NAME == blast
                          select new
                          {
                              id = a.ID,
                              bhid = c.BHID,
                              sample = a.SAMPLE,
                              from_ = a.FROM,
                              to = a.TO,
                              length = a.LENGTH,
                              zblock = a.BLOCK_ZAPASOV != null ? a.BLOCK_ZAPASOV.CATEGORY : "не определено",
                              lito = a.LITOLOGY.ROCK ?? "не определено",
                              rang = a.RANG1 != null ? a.RANG1.TYPE_RANG : "не определено",
                              ves = a.VES_SAMPLE,
                              au = a.Au,
                              au_cut = a.Au_cut,
                              as_ = a.As,
                              sb = a.Sb,
                              s = a.S,
                              ca = a.Ca,
                              fe = a.Fe,
                              ag = a.Ag,
                              c = a.C,
                              end_date = a.END_DATE.ToShortDateString(),
                              blank = a.REESTR_VEDOMOSTEI.BLANK_ID ?? "не определено",
                              journal = a.JOURNAL1.JOURNAL_NAME ?? "не определено",
                              geologist = a.GEOLOGIST1.GEOLOGIST_NAME ?? "не определено",
                              pit = a.PIT,
                              lastUserID = "не определено",
                              lastDT = a.LastDT
                          };
            }
            var report = new Report();

            
            Assembly assem = Assembly.GetExecutingAssembly();
            Stream stream = assem.GetManifestResourceStream("GeoDB.Resources.rptDrillHoles.frx");
            report.Load(stream);
            report.RegisterData(samples, "SAMPLES");
            report.GetDataSource("SAMPLES").Enabled = true;

            FastReport.DataBand band = ((FastReport.DataBand)report.FindObject("Data1"));
            band.DataSource = report.GetDataSource("SAMPLES");


            FastReport.TextObject field;

            field = ((FastReport.TextObject)report.FindObject("tTittle"));
            if (field != null) field.Text = tTittleText;

            field = ((FastReport.TextObject)report.FindObject("Bhid"));
            if (field != null) field.Text = "[SAMPLES.bhid]";
            field = ((FastReport.TextObject)report.FindObject("Sample"));
            if (field != null) field.Text = "[SAMPLES.sample]";
            field = ((FastReport.TextObject)report.FindObject("Length"));
            if (field != null) field.Text = "[SAMPLES.length]";
            field = ((FastReport.TextObject)report.FindObject("Zblock"));
            if (field != null) field.Text = "[SAMPLES.zblock]";
            field = ((FastReport.TextObject)report.FindObject("Rang"));
            if (field != null) field.Text = "[SAMPLES.rang]"; 
            field = ((FastReport.TextObject)report.FindObject("Ves"));
            if (field != null) field.Text = "[SAMPLES.ves]";
            field = ((FastReport.TextObject)report.FindObject("Au"));
            if (field != null) field.Text = "[SAMPLES.au]";
            field = ((FastReport.TextObject)report.FindObject("Au_cut"));
            if (field != null) field.Text = "[SAMPLES.au_cut]";
            field = ((FastReport.TextObject)report.FindObject("Date"));
            if (field != null) field.Text = "[SAMPLES.end_date]";
            field = ((FastReport.TextObject)report.FindObject("Blank"));
            if (field != null) field.Text = "[SAMPLES.blank]";
            field = ((FastReport.TextObject)report.FindObject("Pit"));
            if (field != null) field.Text = "[SAMPLES.pit]";


            report.Show();
        }

    }
}
