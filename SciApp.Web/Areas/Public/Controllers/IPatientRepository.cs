using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciHospital.WebApp.Areas.Public.Controllers
{
    public interface IPatientRepository
    {
        Patient GetPatient(int id);
    }

    public  class PatientRepository : IPatientRepository
    {
        public Patient GetPatient(int id)
        {
            return new Patient() {Id = id};
        }
    }
}