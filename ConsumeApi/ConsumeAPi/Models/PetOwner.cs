using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeApi.Models
{
    public class PetOwner
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public List<Pet> pets { get; set; }
    }
}