using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;
using GeoDB.Model.Interface;

namespace GeoDB.View
{
    public interface IBrowseAnyModel<T>
        where T: class,IViewModel, new()
    {
        List<DGVHeader> Header { set;  }
        Dictionary<int, T> Data { set; get; }
        
        int minShowedRow { set; get; }
        int maxShowedRow { set; get; }
        int rowCount { set; get; }

        //void Show();
        //void Close();


        //event EventHandler<EventArgs> openForm;
        event EventHandler<EventArgs> clickCollarList;
        event EventHandler<EventArgs> showPrevScreen;
        event EventHandler<EventArgs> showNextScreen;
        event EventHandler<NumRowEventArgs> showAnyScreen;
        event EventHandler<EventArgs> clickFilters;
        event EventHandler<EventArgs> clickHeader;
        //event EventHandler<EventArgs> clickCloseForm;
        event EventHandler<NumRowEventArgs> setCurrentRow;


    }
}
