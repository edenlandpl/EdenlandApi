using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Models.Beautician
{
    [Table("B_ BeauticiansTreatments")]
    public class BeauticiansTreatmentsModel
    {
        [Key]
        public int BeauticianTreatmentId { get; set;}
        public int BeauticianId { get; set; }
        public BeauticianModel Beauticians { get; set; }
        public int TreatmentId { get; set; }
        public TreatmentModel Treatments { get; set; }
    }
}
