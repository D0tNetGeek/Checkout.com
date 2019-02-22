using System.Collections;
using System.Collections.Generic;
using AutoMapper;

namespace Checkout.Extensions
{
    public static class MapperExtensions
    {
        /// <summary>
        /// Automapper wrapper. Maps a source object to destination based on mapping configurations.
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TDestination Map<TDestination>(this object source) where TDestination : class
        {
            return Mapper.Map<TDestination>(source);
        }

        /// <summary>
        /// Automapper wrapper. Maps a source object to destination based on mapping configurations.
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IList<TDestination> MapList<TDestination>(this IEnumerable<object> source)
            where TDestination : class
        {
            return Mapper.Map<IList<TDestination>>(source);
        }

        ///// <summary>
        ///// Automapper wrapper. Maps a source object to destination based on mapping configurations.
        ///// </summary>
        ///// <typeparam name="TDestination"></typeparam>
        ///// <param name="source"></param>
        ///// <returns></returns>
        //public static IList<TDestination> MapList<TDestination>(this IEnumerable<object> source)
        //    where TDestination : class
        //{
        //    var items = source.Map<TDestination>();

        //    return new TDestination(items);
        //}
    }
}

