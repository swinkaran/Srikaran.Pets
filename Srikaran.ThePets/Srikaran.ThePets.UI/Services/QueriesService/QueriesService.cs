using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Srikaran.ThePets.DTO;
using Srikaran.ThePets.DTO.Entities;

namespace Srikaran.ThePets.Services.QueriesService
{
    public class QueriesService : IQueriesService
    {
        private static IList<Owner> AllOwnersWithPets { get; set; }
        private static string Filepath{get; set;}
        
        public QueriesService(string _filePath)
        {
            AllOwnersWithPets = JsonConvert.DeserializeObject<IList<Owner>>(File.ReadAllText(_filePath));
        }

        public async Task<IEnumerable<PetsByOwnersGender>> GetPetsByTypeAsync(string type)
        {
            //read the json file
            // read file into a string and deserialize JSON to a type
            IList<Owner> OwnerWithPets = AllOwnersWithPets.Where(p => p.Pets != null && p.Pets.Count > 0).ToList();
            IList<PetsByOwnersGender> pets = new List<PetsByOwnersGender>();

            pets.Add(new PetsByOwnersGender
            {
                Gender = Enumerations.Gender.Male.ToString(),
                Pets = GetPetsByOwnerGender(Enumerations.Gender.Male.ToString(), type, OwnerWithPets)
            });

            pets.Add(new PetsByOwnersGender
            {
                Gender = Enumerations.Gender.Female.ToString(),
                Pets = GetPetsByOwnerGender(Enumerations.Gender.Female.ToString(), type, OwnerWithPets)
            });

            return pets;
        }

        #region Extensions
        public IList<string> GetPetsByOwnerGender(string gender, string type, IList<Owner> OwnerWithPets)
        {
            IList<string> pets = OwnerWithPets.Where(o => o.Gender.Equals(gender)) // Filter tthe collection by gender
                .SelectMany(s => s.Pets.Where(p => p.Type.Equals(type, StringComparison.CurrentCultureIgnoreCase)).Select(c => c.Name)).ToList();

            return pets.OrderBy(p => p).ToList();
        }
        #endregion
    }
}
