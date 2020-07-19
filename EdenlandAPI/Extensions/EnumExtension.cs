using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.Threading.Tasks;

namespace EdenlandAPI.Extensions
{
    public static class EnumExtension
    {
        // we defined a generic method - method that can receive more than on type of argument - in this case, represent by the TEnum declaration) that receive a given enum as an argument
        public static string ToDescriptionString<TEnum>(this TEnum @enum)
        {
            // since enum is reserved keyword in C#, e added an @ in front of the parameter's name to make it valid name
            // the first execution step of method is to get type information (the class, interface, enum or struct) of parameter using the GetType method
            FieldInfo info = @enum.GetType().GetField(@enum.ToString());
            // we fins all Description atttributes applied over the enumeration value and stores theis data into array (we can specify multiple attributes for a same property in some cases)
            var attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);

            // here we uses a shorter syntax to check if we have at least one description attribute for the enumeration type.
            // if we have one description, we return the Description value provided by he attribute
            // if not, we return the enumeration a string, using the default casting
            // operator ?. (a null-condition operator) checks if the value is null before accesing its property
            // operator ?? (a null-coalescing operator) tells the application to return the value at left if it's not empty, or the value at right otherwise
            return attributes?[0].Description ?? @enum.ToString();
        }
    }
}
