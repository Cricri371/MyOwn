using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cricri371.Framework.Tools.Linq
{
    /// <summary>
    /// Extension class for Linq 
    /// </summary>
    public static class Ext
    {
        #region Between

        /// <summary>
        /// Betweens the specified key selector. 
        /// </summary>
        /// <typeparam name="TSource"> The type of the t source. </typeparam>
        /// <typeparam name="TKey"> The type of the t key. </typeparam>
        /// <param name="source">      The source. </param>
        /// <param name="keySelector"> The key selector. </param>
        /// <param name="low">         The low. </param>
        /// <param name="high">        The high. </param>
        /// <returns> The list of TSource. </returns>
        public static IQueryable<TSource> Between<TSource, TKey>(
            this IQueryable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector,
            TKey low,
            TKey high)
            where TKey : IComparable<TKey>
        {
            var key = Expression.Invoke(keySelector, keySelector.Parameters);

            var lambda = Expression.Lambda<Func<TSource, bool>>(
                Expression.And(
                    Expression.GreaterThanOrEqual(key, Expression.Constant(low)),
                    Expression.LessThanOrEqual(key, Expression.Constant(high))),
                    keySelector.Parameters);

            return source.Where(lambda);
        }

        #endregion Between

        #region BetweenDates

        /// <summary>
        /// Betweens the dates. 
        /// </summary>
        /// <typeparam name="TSource"> The type of the t source. </typeparam>
        /// <param name="source">               The source. </param>
        /// <param name="lambdaStartDateField"> The lambda start date field. </param>
        /// <param name="lambdaEndDateField">   The lambda end date field. </param>
        /// <param name="targetDate">           The target date. </param>
        /// <returns> The list of TSource. </returns>
        public static IQueryable<TSource> BetweenDates<TSource>(
            this IQueryable<TSource> source,
            Expression<Func<TSource, DateTime>> lambdaStartDateField,
            Expression<Func<TSource, DateTime>> lambdaEndDateField,
            DateTime targetDate)
        {
            var startPropertyName = GetPropertyName(lambdaStartDateField);
            var endPropertyName = GetPropertyName(lambdaEndDateField);

            var parameter = Expression.Parameter(typeof(TSource));

            var lambda = Expression.Lambda<Func<TSource, bool>>(
                Expression.And(
                    Expression.GreaterThanOrEqual(Expression.Constant(targetDate), Expression.Property(parameter, startPropertyName)),
                    Expression.LessThanOrEqual(Expression.Constant(targetDate), Expression.Property(parameter, endPropertyName))),
                    new List<ParameterExpression>() { parameter });

            return source.Where(lambda);
        }

        /// <summary>
        /// Betweens the dates. 
        /// </summary>
        /// <typeparam name="TSource"> The type of the t source. </typeparam>
        /// <param name="source">               The source. </param>
        /// <param name="lambdaStartDateField"> The lambda start date field. </param>
        /// <param name="lambdaEndDateField">   The lambda end date field. </param>
        /// <param name="startDate">            The start date. </param>
        /// <param name="endDate">              The end date. </param>
        /// <returns> The list of TSource. </returns>
        public static IQueryable<TSource> BetweenDates<TSource>(
            this IQueryable<TSource> source,
            Expression<Func<TSource, DateTime>> lambdaStartDateField,
            Expression<Func<TSource, DateTime>> lambdaEndDateField,
            DateTime startDate,
            DateTime endDate)
        {
            var startPropertyName = GetPropertyName(lambdaStartDateField);
            var endPropertyName = GetPropertyName(lambdaEndDateField);

            var parameter = Expression.Parameter(typeof(TSource));

            var periodBigger =
                Expression.And(
                    Expression.GreaterThanOrEqual(Expression.Constant(endDate), Expression.Property(parameter, endPropertyName)),
                        Expression.LessThanOrEqual(Expression.Constant(startDate), Expression.Property(parameter, startPropertyName)));

            var startDateBetweenPeriod =
                Expression.And(
                    Expression.GreaterThanOrEqual(Expression.Constant(endDate), Expression.Property(parameter, startPropertyName)),
                        Expression.LessThanOrEqual(Expression.Constant(endDate), Expression.Property(parameter, endPropertyName)));

            var endDateBetweenPeriod =
                Expression.And(
                    Expression.GreaterThanOrEqual(Expression.Constant(endDate), Expression.Property(parameter, startPropertyName)),
                        Expression.LessThanOrEqual(Expression.Constant(startDate), Expression.Property(parameter, endPropertyName)));

            var lambda = Expression.Lambda<Func<TSource, bool>>(
                Expression.Or(periodBigger, Expression.Or(startDateBetweenPeriod, endDateBetweenPeriod)),
                new List<ParameterExpression>() { parameter });

            return source.Where(lambda);
        }

        #endregion BetweenDates

        #region GetPropertyName

        /// <summary>
        /// Gets the name of the property. 
        /// </summary>
        /// <typeparam name="TSource"> The type of the t source. </typeparam>
        /// <typeparam name="TKey"> The type of the t key. </typeparam>
        /// <param name="lambda"> The lambda. </param>
        /// <returns> The property name in string. </returns>
        private static string GetPropertyName<TSource, TKey>(Expression<Func<TSource, TKey>> lambda)
        {
            return ((MemberExpression)lambda.Body).Member.Name;
        }

        #endregion GetPropertyName
    }
}