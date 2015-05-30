using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDbUserInterface.ServiceInterfaces
{
    public enum FilterTypeCriterion { oneArg, twoArg,resetArgs }
    public interface ILinqExtensionFilterCriterion
    {
        object min { get; }
        object max { get;}
        object only { get;  }
        void Set(object Min, object Max);
        void Set(object Only);
        void Set(ILinqExtensionFilterCriterion criterion);
        void Reset();
        FilterTypeCriterion GetTypeCriterion();
    }
}
