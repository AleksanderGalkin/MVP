using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testForms
{
    public interface IView
    {
        /// <summary>
        /// Вывод градусов Фаренгейта
        /// </summary>
        double Farenheit { set; }

        /// <summary>
        /// Вывод градусов Цельсия
        /// </summary>
        double Celsius { set; }

        /// <summary>
        /// Введенное значение - градусы по Фаренгейту
        /// </summary>
        bool isInputDegreeIsFarenheit { get; }

        /// <summary>
        /// Введенное значение - градусы по Цельсию
        /// </summary>
        bool isInputDegreeIsCelsius { get; }

        /// <summary>
        /// Ввод нового значения градусов
        /// </summary>
        double InputDegree { get; }

        void Show();

        /// <summary>
        /// Событие ввода значения градусов
        /// </summary>
        event EventHandler<EventArgs> SetDegreeEvent;

    }

}
