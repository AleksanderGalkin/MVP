using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDbUserInterface.View;

namespace GeoDB.Presenter.Interface
{
    public interface IPresenter
    {
        IPopup GetToolMenu();
    }
}
