using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYCH.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int YearsExperience { get; set; }
        public string PositionSeeking { get; set; }
        public string Email { get; set; }
        //public string Search { get; set; }
    }

    public class ProfileSearch
    {
        public List<Profile> profiles { get; set; }
        public string Search { get; set; }
    }

  
}
