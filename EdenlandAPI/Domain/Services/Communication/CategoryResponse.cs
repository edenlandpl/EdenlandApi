using EdenlandAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Services.Communication
{
    public class CategoryResponse : BaseResponse
    {
        // after save method return name Category if all is OK, and false and message of error if it going wrong
        // Notice that I’ve defined three different constructors for this class:
        //A private one, which is going to pass the success and message parameters to the base class, and also sets the Category property;
        //A constructor that receives only the category as a parameter.This one will create a successful response, calling the private constructor to set the respective properties;
        //A third constructor that only specifies the message.This one will be used to create a failure response.
        public Category Category { get; set; }

        private CategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            Category = category;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public CategoryResponse(Category category) : this(true, string.Empty, category) { }

        // <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CategoryResponse(string message) : this(false, message, null) { }
    }
}
