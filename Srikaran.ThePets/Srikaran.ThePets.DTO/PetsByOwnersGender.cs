using System;
using System.Collections.Generic;
using System.Text;

namespace Srikaran.ThePets.DTO
{
    public class PetsByOwnersGender
    {
        public string Gender { get; set; }
        public IList<string> Pets { get; set; }
    }

}
