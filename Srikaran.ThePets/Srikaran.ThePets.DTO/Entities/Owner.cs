using System;
using System.Collections.Generic;

namespace Srikaran.ThePets.DTO.Entities
{
    public class Owner
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public IList<Pet> Pets { get; set; }
    }

}
