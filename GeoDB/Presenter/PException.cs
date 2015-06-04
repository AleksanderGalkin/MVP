using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDbUserInterface.View;

namespace GeoDB.Presenter
{
    public class PException
    {
        private string _messageText;
        private IViewException _view;

        public PException(String MessageText, IViewException View)
        {
            _messageText = MessageText;
            _view = View;
        }

        public void Show()
        {
            _view.message = _messageText;
            _view.ShowDialog();
        }
    }
}
