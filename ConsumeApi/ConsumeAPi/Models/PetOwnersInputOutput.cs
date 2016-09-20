using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using FastTrack.Model.StewardsAdministration;
using ConsumeApi.Models;

namespace ConsumeApi.Models
{
    public class PetOwnersInputOutput
    {
        public IList<PetOwnerDetail> MalePetOwnerDetails { get; set; }
        public IList<PetOwnerDetail> FemalePetOwnerDetails { get; set; }
    }    

    public class PetOwnerDetail
    {
        public string PetName { get; set;}

        public string PetOwnerName { get; set; }

        public string PetOwnerGender { get; set; }

        public string PetType { get; set; }
    }
}