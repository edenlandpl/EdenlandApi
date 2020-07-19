using EdenlandAPI.Domain.Models.Beautician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Services.Communication.Beautician
{
    public class BeauticianResponse : BaseResponse
    {
        public BeauticianModel Beautician { get; set; }

        public BeauticianResponse(bool success, string message, BeauticianModel beautician) : base(success, message)
        {
            Beautician = beautician;
        }

        public BeauticianResponse(BeauticianModel beautician) : this(true, string.Empty, beautician) { }
        public BeauticianResponse(string message) : this(false, message, null) { }
    }
}
