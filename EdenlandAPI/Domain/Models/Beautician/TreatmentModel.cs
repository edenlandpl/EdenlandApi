using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Models.Beautician
{
    [Table("B_Treatments")]
    public class TreatmentModel
    {
        [Key]
        public int TreatmentId { get; set; }
        public string NameTreatment { get; set; }
        public string DescriptionTreatment { get; set; }
        public TimeSpan TimeSpanTreatment { get; set; }
        public double PriceTreatment { get; set; }

        public ICollection<BeauticiansTreatmentsModel> Beauticians { get; set; }

        public TreatmentModel()
        {
            this.Beauticians = new Collection<BeauticiansTreatmentsModel>();
        }


        //public IList<BeauticianTreatmentsModel> BeauticiansTreatments { get; set; }

        // klucz obcy dla Beautician
        //public BeauticianModel Beautician { get; set; }
        //public List<BeauticianTreatmentsModel> BeauticiansList { get; set; } = new List<BeauticianTreatmentsModel>();
    }
}
