using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using ConsumeApi.Models;

namespace ConsumeApi.Models.APIHelper
{
    public class ServiceHelper
    {
        /// <summary>
        /// GetPetOwners method calls the Api
        /// </summary>
        /// <returns>
        /// List of PetOwner
        /// </returns>
        public async Task<List<PetOwner>> GetPetOwners()
        {
            List<PetOwner> PetOwners = new List<PetOwner>();

            try
            {
                var defaultHandler = new HttpClientHandler { UseDefaultCredentials = true };
                using (var client = new HttpClient(defaultHandler))
                {
                    client.BaseAddress = new Uri("https://agl-developer-test.azurewebsites.net/people.json");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("");
                    response.EnsureSuccessStatusCode();
                    PetOwners = await response.Content.ReadAsAsync<List<PetOwner>>();
                }
               
            }
            catch (Exception ex)
            {
               
            }
            return PetOwners;
        }
    }
}