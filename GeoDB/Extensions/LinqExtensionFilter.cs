using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;
using GeoDB.Model.Interface;

namespace GeoDB.Extensions
{
    public class LinqExtensionFilterCriterion
    {
        public enum TypeCriterion { oneArg, twoArg }
        public object min { get; private set; }
        public object max { get; private set; }
        public object only { get; private set; }
        private TypeCriterion _typeCriterion;
        public LinqExtensionFilterCriterion(object Min, object Max)
        {
            min = Min;
            max = Max;
            only = null;
            _typeCriterion = TypeCriterion.twoArg;
        }
        public LinqExtensionFilterCriterion( object Only)
        {
            min = null;
            max = null;
            only = Only;
            _typeCriterion = TypeCriterion.oneArg;
        }
        public void Set( object Min, object Max)
        {
            min = Min;
            max = Max;
            only = null;
        }
        public void Set( object Only)
        {
            min = null;
            max = null;
            only = Only;
        }
        public TypeCriterion GetTypeCriterion()
        {
            return _typeCriterion;
        }


    }
    public static class LinqExtensionFilter
    {
        public static IEnumerable<T> FilteredBy<T>(this IEnumerable<T> source, Dictionary<DGVHeader,LinqExtensionFilterCriterion> criterion)
        {
            IEnumerable<T> result = source;

            foreach (var i in criterion)
            {
                if (i.Value.GetTypeCriterion() == LinqExtensionFilterCriterion.TypeCriterion.oneArg)
                {
                    result = FilteredByOneArg<T>(result, i);
                }
                else
                {
                    result = FilteredByTwoArgs<T>(result, i);
                }
            }

            return result;

        }

        private static IEnumerable<T> FilteredByTwoArgs<T>(IEnumerable<T> source, KeyValuePair<DGVHeader,LinqExtensionFilterCriterion> criterion)
        {
            
            if (criterion.Value.min.GetType() == typeof(int) && criterion.Value.max.GetType() == typeof(int))
            {
                return source.Where(x => ((int)(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) >= (int)criterion.Value.min)
                                        && ((int)(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) <= (int)criterion.Value.max));
            }
            else if (criterion.Value.min.GetType() == typeof(double) && criterion.Value.max.GetType() == typeof(double))
            {
                return source.Where(x => ((double)(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) >= (double)criterion.Value.min)
                                         && ((double)(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) <= (double)criterion.Value.max));
            }
            else if (criterion.Value.min.GetType() == typeof(DateTime) && criterion.Value.max.GetType() == typeof(DateTime))
            {
                return source.Where(x => ((DateTime)(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) >= (DateTime)criterion.Value.min)
                                        && ((DateTime)(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) <= (DateTime)criterion.Value.max));
            }
            else
            {
                throw new InvalidOperationException("Only int, double, DateTime types allowed in this signature.");
            }

        }

        private static IEnumerable<T> FilteredByOneArg<T>(IEnumerable<T> source, KeyValuePair<DGVHeader, LinqExtensionFilterCriterion> criterion)
        {


            if (criterion.Value.only.GetType() == typeof(int))
            {
                return source.Where(x => (int)(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) == (int)criterion.Value.only);
            }
            else if (criterion.Value.only.GetType() == typeof(double))
            {
                return source.Where(x => (double)(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) == (double)criterion.Value.only);
            }
            else if (criterion.Value.only.GetType() == typeof(DateTime))
            {
                return source.Where(x => (DateTime)(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) == (DateTime)criterion.Value.only);
            }
            else if (criterion.Value.only.GetType() == typeof(string))
            {
                return source.Where(x => (string)(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) == (string)criterion.Value.only);
            }
            else
            {
                throw new InvalidOperationException("Only int, double, DateTime, string types allowed in this signature.");
            }

        }
    }
}
