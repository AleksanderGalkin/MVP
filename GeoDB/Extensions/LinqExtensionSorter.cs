using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;
using GeoDB.Model.Interface;

namespace GeoDB.Extensions
{
    public class LinqExtensionSorterCriterion
    {
        public enum TypeCriterion { Ascending, Descending }
        public DGVHeader _firstField { get; private set; }
        public TypeCriterion _firstTypeCriterion { get; private set; }
        public DGVHeader _secondField { get; private set; }
        public TypeCriterion _secondTypeCriterion { get; private set; }

        public LinqExtensionSorterCriterion()
        {

        }
        public void Set(DGVHeader Field, TypeCriterion TypeCriterion)
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
   
            if (criterion._firstTypeCriterion == LinqExtensionSorterCriterion.TypeCriterion.Ascending)
            {
                result = source.OrderBy(x => x.GetType().GetProperty(criterion._firstField.fieldName).GetValue(x, null));
            }
            else 
            {
                result = source.OrderByDescending(x => x.GetType().GetProperty(criterion._firstField.fieldName).GetValue(x, null));
            }
            if (criterion._secondField != null)
            {
                if (criterion._secondTypeCriterion == LinqExtensionSorterCriterion.TypeCriterion.Ascending)
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
