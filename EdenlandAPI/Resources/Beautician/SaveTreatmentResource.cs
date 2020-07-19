using EdenlandAPI.Domain.Models.Beautician;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Resources.Beautician
{
    public class SaveTreatmentResource
    {
        [Required]
        [MaxLength(120)]
        public string NameTreatment { get; set; }
        public string DescriptionTreatment { get; set; }

        public TimeSpan TimeSpanTreatment { get; set; }
        public double PriceTreatment { get; set; }
        public IList<BeauticiansTreatmentsModel> BeauticiansTreatments { get; set; }
    }
}
