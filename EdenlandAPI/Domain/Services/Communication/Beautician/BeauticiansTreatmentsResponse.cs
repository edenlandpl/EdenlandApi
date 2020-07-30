using EdenlandAPI.Domain.Models.Beautician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Services.Communication.Beautician
{
    public class BeauticiansTreatmentsResponse : BaseResponse
    {
        // after save method return name Category if all is OK, and false and message of error if it going wrong
        // Notice that I’ve defined three different constructors for this class:
        //A private one, which is going to pass the success and message parameters to the base class, and also sets the Category property;
        //A constructor that receives only the category as a parameter.This one will create a successful response, calling the private constructor to set the respective properties;
        //A third constructor that only specifies the message.This one will be used to create a failure response.

        public BeauticiansTreatmentsModel BeauticiansTreatments { get; set; }
        public BeauticiansTreatmentsResponse(bool success, string message, BeauticiansTreatmentsModel beauticiansTreatments) : base(success, message)
        {
           BeauticiansTreatments = beauticiansTreatments;
        }
        public BeauticiansTreatmentsResponse(BeauticiansTreatmentsModel beauticiansTreatments) : this(true, string.Empty, beauticiansTreatments) { }
        public BeauticiansTreatmentsResponse(string message) : this(false, message, null) { }
    }
}
