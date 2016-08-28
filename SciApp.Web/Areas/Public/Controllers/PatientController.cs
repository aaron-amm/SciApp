using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SciHospital.WebApp.Areas.Public.Controllers
{
    public class PatientController : Controller
    {
        private IPatientRepository patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public ActionResult UpdatePatient(int id, string firstName, string lastName, DateTime? dateOfBirth)
        {
            var patient = patientRepository.GetPatient(id);

            patient.FirstName = firstName ?? patient.FirstName;
            patient.LastName = lastName ?? patient.LastName;
            patient.DateOfBirth = dateOfBirth ?? patient.DateOfBirth;

            return View(patient);
        }

    }
}