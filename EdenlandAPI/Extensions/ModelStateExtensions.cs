using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// method that extends the functionality of an already existingclass or interface
namespace EdenlandAPI.Extensions
{
    // we use only one instance - static
    public static class ModelStateExtensions
    {
        // this keyword in front of the parametr declaration tellscompiler to treat it as an extension method
        public static List<string> GetErrorMessage(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors).Select(m => m.ErrorMessage).ToList();
        }
    }
}
