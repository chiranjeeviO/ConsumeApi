using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsumeApi.Models;
using ConsumeApi.Models.APIHelper;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumeApi.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public async Task<ActionResult> Index()
        {
           PetOwnersInputOutput PetOwnerInput = new PetOwnersInputOutput();
            // call the service
            ServiceHelper OwnerService = new ServiceHelper();
            List<PetOwner> data = await OwnerService.GetPetOwners();
            Thread.Sleep(10000);
            var OwnerList = (from owner in data
                                 where owner.pets != null
                                 from pet in owner.pets
                                 where pet.type == "Cat"
                                 orderby pet.name
                                 select new PetOwnerDetail {PetName= pet.name,PetType = pet.type,PetOwnerName = owner.name,PetOwnerGender = owner.gender }
                            ).ToList();

            //group by gender and assign to model
            PetOwnerInput.MalePetOwnerDetails = OwnerList.Where(m=>m.PetOwnerGender =="Male").ToList();
            PetOwnerInput.FemalePetOwnerDetails = OwnerList.Where(m => m.PetOwnerGender == "Female").ToList();

            return View(PetOwnerInput);
        }
    }
}