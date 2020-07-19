using EdenlandAPI.Domain.Models.Beautician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Services.Communication.Beautician
{
    public class TreatmentResponse : BaseResponse
    {
        public TreatmentModel Treatment { get; set; }

        public TreatmentResponse(bool success, string message, TreatmentModel treatment) : base(success, message)
        {
            Treatment = treatment;
        }

        public TreatmentResponse(TreatmentModel treatment) : this(true, string.Empty, treatment) { }
        public TreatmentResponse(string message) : this(false, message, null) { }
    }
}
