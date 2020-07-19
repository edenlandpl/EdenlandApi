using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Services.Communication
{
    public abstract class BaseResponse
    {
        // abstract class, which defines Success property which tell whether request were completed succefully, and Message when have the error
        // if service will grow up, it is not good practise to use base class, better change
        public bool Success { get; set; }
        public string Message { get; set; }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
