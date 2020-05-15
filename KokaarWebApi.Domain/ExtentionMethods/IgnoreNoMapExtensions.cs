using AutoMapper;
using KokaarWepApi.Domain.Attributes;
using System.ComponentModel;

namespace KokaarWepApi.Domain.ExtentionMethods
{
    public static class IgnoreNoMapExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreNoMap<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            foreach (var property in sourceType.GetProperties())
            {
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(sourceType)[property.Name];
                MapIgnoreAttribute attribute = (MapIgnoreAttribute)descriptor.Attributes[typeof(MapIgnoreAttribute)];
                if (attribute != null)
                    expression.ForMember(property.Name, opt => opt.Ignore());
            }
            return expression;
        }

        //public static IMappingExpression<TSource, TDestination> IgnoreNoMap<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        //{
        //    var sourceType = typeof(TSource);
        //    foreach (var property in sourceType.GetProperties())
        //    {
        //        //if (property.Name.Equals("CreationDate") 
        //        //    || property.Name.Equals("CreationUser")
        //        //    || property.Name.Equals("UpdateDate")
        //        //    || property.Name.Equals("UpdateUser")
        //        //    || property.Name.Equals("CurrentUser"))
        //        //    expression.ForMember(property.Name, opt => opt.Ignore());
        //    }
        //    return expression;
        //}
    }
}
