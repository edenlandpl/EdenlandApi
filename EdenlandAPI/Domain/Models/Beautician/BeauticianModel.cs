using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Models.Beautician
{
    [Table("B_Beautician")]
    public class BeauticianModel
    {        
        [Key]
        public int BeauticianId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<BeauticiansTreatmentsModel> Treatments { get; set; }

        public BeauticianModel()
        {
            this.Treatments = new Collection<BeauticiansTreatmentsModel>();
        }


        // do każdej Kosmetyczki możemy przypisać wiele zabiegów        
        //public List<BeauticianTreatmentsModel> TreatmentsList { get; set; } = new List<BeauticianTreatmentsModel>();
    }
}
