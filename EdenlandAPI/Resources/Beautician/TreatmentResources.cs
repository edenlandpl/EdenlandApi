using EdenlandAPI.Domain.Models.Beautician;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Resources.Beautician
{
    public class TreatmentResources
    {
        public int TreatmentId { get; set; }
        public string NameTreatment { get; set; }
        public string DescriptionTreatment { get; set; }
        public TimeSpan TimeSpanTreatment { get; set; }
        public double PriceTreatment { get; set; }
        public ICollection<BeauticiansTreatmentsModel> Beauticians { get; set; }

        public TreatmentResources()
        {
            this.Beauticians = new Collection<BeauticiansTreatmentsModel>();
        }
    }
}
