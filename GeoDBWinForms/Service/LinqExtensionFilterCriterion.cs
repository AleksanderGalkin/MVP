using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDbUserInterface.ServiceInterfaces;

namespace GeoDBWinForms.Service
{
    public class LinqExtensionFilterCriterion : ILinqExtensionFilterCriterion
    {

        public object min { get; private set; }
        public object max { get; private set; }
        public object only { get; private set; }
        private FilterTypeCriterion _typeCriterion;
        public LinqExtensionFilterCriterion()
        {
            min = null;
            max = null;
            only = null;
            _typeCriterion = FilterTypeCriterion.resetArgs;
        }
        public LinqExtensionFilterCriterion(object Min, object Max)
        {
            min = Min;
            max = Max;
            only = null;
            _typeCriterion = FilterTypeCriterion.twoArg;
        }
        public LinqExtensionFilterCriterion(object Only)
        {
            min = null;
            max = null;
            only = Only;
            _typeCriterion = FilterTypeCriterion.oneArg;
        }

        public void Set(object Min, object Max)
        {
            min = Min;
            max = Max;
            only = null;
        }
        public void Set(object Only)
        {
            min = null;
            max = null;
            only = Only;
            _typeCriterion = FilterTypeCriterion.oneArg;
        }
        public void Set(ILinqExtensionFilterCriterion criterion)
        {
            this.min = criterion.min;
            this.max = criterion.max;
            this.only = criterion.only;
            this._typeCriterion = criterion.GetTypeCriterion();
        }
        public void Reset()
        {
            min = null;
            max = null;
            only = null;
            _typeCriterion = FilterTypeCriterion.resetArgs;
        }
        public FilterTypeCriterion GetTypeCriterion()
        {
            return _typeCriterion;
        }


    }
}
