using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using testForms;




namespace test
{
    public class Presenter
    {
        private Model _model;
        private IView _view;

        /// <summary>
        /// В конструтор передается конкретный экземпляр представления
        /// и происходит подписка на все нужные события.
        /// <summary>
        public Presenter(IView view)
        {
             _model = new Model();
            _view = view;
            _view.SetDegreeEvent += new EventHandler<EventArgs>(OnSetDegree);

            RefreshView();
        }

        /// <summary>
        /// Обработка события, установка нового значения градусов по Фаренгейту
        /// </summary>
        private void OnSetDegree(object sender, EventArgs e)
        {
            if (_view.isInputDegreeIsCelsius)
            {
                _model.valueCelsius = _view.InputDegree;
            }
            if (_view.isInputDegreeIsFarenheit)
            {
                _model.valueFahrenheit = _view.InputDegree;
            }
            RefreshView();
        }

        /// <summary>
        /// Обновление Представления новыми значениями модели.
        /// По сути Binding (привязка) значений модели к Представлению. 
        /// </summary>
        private void RefreshView()
        {
            _view.Celsius = _model.valueCelsius;
            _view.Farenheit = _model.valueFahrenheit;
        }

        /// <summary>
        /// Обновление Представления новыми значениями модели.
        /// По сути Binding (привязка) значений модели к Представлению. 
        /// </summary>
        public void Show()
        {
            _view.Show();

        }

    }

}
