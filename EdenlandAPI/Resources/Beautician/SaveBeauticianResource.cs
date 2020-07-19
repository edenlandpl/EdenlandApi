using EdenlandAPI.Domain.Models.Beautician;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Resources.Beautician
{
    public class SaveBeauticianResource
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        public BeauticiansTreatmentsModel BeauticianTreatments { get; set; }
    }
}
