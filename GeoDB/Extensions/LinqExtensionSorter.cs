using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;
using GeoDB.Model.Interface;
using GeoDbUserInterface.ServiceInterfaces;


namespace GeoDB.Extensions
{
    public class LinqExtensionSorterCriterion : ILinqExtensionSorterCriterion
    {
        public IDGVHeader _firstField { get; private set; }
        public SortererTypeCriterion _firstTypeCriterion { get; private set; }
        public IDGVHeader _secondField { get; private set; }
        public SortererTypeCriterion _secondTypeCriterion { get; private set; }

        public LinqExtensionSorterCriterion()
        {

        }
        public void Set(IDGVHeader Field, SortererTypeCriterion TypeCriterion)
        {
            _secondField = _firstField;
            _secondTypeCriterion = _firstTypeCriterion;
            _firstField = Field;
            _firstTypeCriterion = TypeCriterion;
        }
       
    }
    public static class LinqExtensionSorter
    {
        public static IEnumerable<T> SortBy<T>(this IEnumerable<T> source, LinqExtensionSorterCriterion criterion)
        {
            IOrderedEnumerable<T> result;

            if (criterion._firstTypeCriterion == SortererTypeCriterion.Ascending)
            {
                result = source.OrderBy(x => x.GetType().GetProperty(criterion._firstField.fieldName).GetValue(x, null));
            }
            else 
            {
                result = source.OrderByDescending(x => x.GetType().GetProperty(criterion._firstField.fieldName).GetValue(x, null));
            }
            if (criterion._secondField != null)
            {
                if (criterion._secondTypeCriterion == SortererTypeCriterion.Ascending)
                {
                    result = result.ThenBy(x => x.GetType().GetProperty(criterion._secondField.fieldName).GetValue(x, null));
                }
                else
                {
                    result = result.ThenByDescending(x => x.GetType().GetProperty(criterion._secondField.fieldName).GetValue(x, null));
                }
            }
            return result;

        }

    }
}
