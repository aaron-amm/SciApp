using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciHospital.WebApp.Areas.Public.Controllers
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}