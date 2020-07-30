using EdenlandAPI.Domain.Models.Beautician;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Resources.Beautician
{
    public class BeauticiansTreatmentsResources
    {
        public int Id { get; set; }
        public int BeauticianId { get; set; }
        public BeauticianModel Beauticians { get; set; }
        public int TreatmentId { get; set; }
        public TreatmentModel Treatments { get; set; }

    }
}
