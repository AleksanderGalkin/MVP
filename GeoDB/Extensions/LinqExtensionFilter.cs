using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoDB.Model;
using GeoDB.Model.Interface;
using GeoDbUserInterface.ServiceInterfaces;


namespace GeoDB.Extensions
{
    public class LinqExtensionFilterCriterion: ILinqExtensionFilterCriterion
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
        public LinqExtensionFilterCriterion( object Only)
        {
            min = null;
            max = null;
            only = Only;
            _typeCriterion = FilterTypeCriterion.oneArg;
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
    public static class LinqExtensionFilter
    {
        public static IEnumerable<T> FilteredBy<T>(this IEnumerable<T> source, Dictionary<IDGVHeader,ILinqExtensionFilterCriterion> criterion)
        {
            IEnumerable<T> result = source;

            foreach (var i in criterion)
            {
                if (i.Value.GetTypeCriterion() == FilterTypeCriterion.oneArg)
                {
                    result = FilteredByOneArg<T>(result, i);
                }
                else if (i.Value.GetTypeCriterion() == FilterTypeCriterion.twoArg)
                {
                    result = FilteredByTwoArgs<T>(result, i);
                }

            }

            return result;

        }

        private static IEnumerable<T> FilteredByTwoArgs<T>(IEnumerable<T> source, KeyValuePair<IDGVHeader,ILinqExtensionFilterCriterion> criterion)
        {
            var keyType = typeof(T).GetProperty(criterion.Key.fieldName).PropertyType;

            if (keyType == typeof(int) || keyType == typeof(int?))
            {
                var locMin = criterion.Value.min.ToString() != "" ? Convert.ToInt32(criterion.Value.min) : int.MinValue;
                var locMax = criterion.Value.max.ToString() != "" ? Convert.ToInt32(criterion.Value.max) : int.MaxValue;
                return source.Where(x => (Convert.ToInt32(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) >= locMin)
                                        && (Convert.ToInt32(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) <= locMax));
            }
            else if (keyType == typeof(double) || keyType == typeof(double?))
            {
                var locMin = criterion.Value.min.ToString() != "" ? Convert.ToDouble(criterion.Value.min) : double.MinValue;
                var locMax = criterion.Value.max.ToString() != "" ? Convert.ToDouble(criterion.Value.max) : double.MaxValue;
                return source.Where(x => (Convert.ToDouble(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) >= locMin)
                                         && (Convert.ToDouble(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) <= locMax));
            }
            else if (keyType == typeof(DateTime) || keyType == typeof(DateTime?))
            {
                var locMin = criterion.Value.max.ToString() != "" ? Convert.ToDateTime(criterion.Value.min).Date : DateTime.MinValue;
                var locMax = criterion.Value.max.ToString() != "" ? Convert.ToDateTime(criterion.Value.max).Date : DateTime.MaxValue;
                return source.Where(x => (Convert.ToDateTime(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)).Date >= locMin)
                                        && (Convert.ToDateTime(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)).Date <= locMax));
            }
            else if (keyType == typeof(string) )
            {
                var locMin =(string)criterion.Value.min;
                var locMax = (string)criterion.Value.max; 
                return source.Where(x => String.Compare((string)x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null), locMin,true)>=0
                                        && String.Compare((string)x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null), locMax, true) <= 0);
            }
            else
            {
                throw new InvalidOperationException("Only int, double, DateTime, string types allowed in this signature.");
            }

        }

        private static IEnumerable<T> FilteredByOneArg<T>(IEnumerable<T> source, KeyValuePair<IDGVHeader, ILinqExtensionFilterCriterion> criterion)
        {
            var keyType = typeof(T).GetProperty(criterion.Key.fieldName).PropertyType;

            if (keyType == typeof(int) || keyType == typeof(int?))
            {
                var locOnly = Convert.ToInt32(criterion.Value.only);
                return source.Where(x => Convert.ToInt32(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) == locOnly);
            }
            else if (keyType == typeof(double) || keyType == typeof(double?))
            {
                var locOnly = Convert.ToDouble(criterion.Value.only);
                return source.Where(x => Convert.ToDouble(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)) == locOnly);
            }
            else if (keyType == typeof(DateTime) || keyType == typeof(DateTime?))
            {
                var locOnly = Convert.ToDateTime(criterion.Value.only).Date;
                return source.Where(x => Convert.ToDateTime(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)).Date == locOnly);
            }
            else if (keyType == typeof(string))
            {
                var locOnly = Convert.ToString(criterion.Value.only);
                return source.Where(x => Convert.ToString(x.GetType().GetProperty(criterion.Key.fieldName).GetValue(x, null)).Contains(locOnly));
            }
            else
            {
                throw new InvalidOperationException("Only int, double, DateTime, string types allowed in this signature.");
            }

        }
    }
}
