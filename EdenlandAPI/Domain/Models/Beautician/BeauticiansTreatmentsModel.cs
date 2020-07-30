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
        //[Key]
        //[Required]
        //public int Id { get; set; }
        public int BeauticianId { get; set; }

        //[ForeignKey("BeauticianId")]
        public BeauticianModel Beautician { get; set; }
        //[Required]
        public int TreatmentId { get; set; }
        public TreatmentModel Treatment { get; set; }
    }
}
