using EdenlandAPI.Domain.Models.Beautician;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Resources.Beautician
{
    public class BeauticianResources
    {
        public int BeauticianId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<BeauticiansTreatmentsModel> Treatments { get; set; }

        //public BeauticianResources()
        //{
        //    this.Treatments = new Collection<BeauticiansTreatmentsModel>();
        //}
    }
}
