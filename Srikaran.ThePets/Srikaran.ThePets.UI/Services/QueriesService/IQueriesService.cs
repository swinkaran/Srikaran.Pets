using Srikaran.ThePets.DTO;
using Srikaran.ThePets.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Srikaran.ThePets.Services.QueriesService
{
    public interface IQueriesService
    {
        Task<IEnumerable<PetsByOwnersGender>> GetPetsByTypeAsync(string type);
    }
}
