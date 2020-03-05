using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace ELTPServiceLayer
{
    public static class MapperExtensions
    {
        private static void IgnoreUnmappedProperties(TypeMap map, IMappingExpression expr)
        {
            //string[] propN = map.GetUnmappedPropertyNames();
            foreach (string propName in map.GetUnmappedPropertyNames())
            {

                if (map.SourceType.GetProperty(propName) != null)
                {
                    expr.ForMember(propName, opt => opt.Ignore());
                    //code below doesnt work
                    //expr.ForSourceMember(propName, opt => opt.Ignore());
                }
                // new code below
                if (map.DestinationType.GetProperty(propName) != null)
                {
                    expr.ForMember(propName, opt => opt.Ignore());
                }
            }
        }
        public static void IgnoreUnmapped(this IProfileExpression profile)
        {
            profile.ForAllMaps(IgnoreUnmappedProperties);

        }
    }
}