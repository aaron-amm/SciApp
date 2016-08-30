using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SciHospital.WebApp.Areas.Public.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }
        public ActionResult Get(int id)
        {
            var patient = patientRepository.GetPatient(id);
            return View(patient);
        }

        public ActionResult UpdatePatient(int id, string firstName, string lastName, DateTime? dateOfBirth)
        {
            var patient = patientRepository.GetPatient(id);

            patient.FirstName = firstName ?? patient.FirstName;
            patient.LastName = lastName ?? patient.LastName;
            patient.DateOfBirth = dateOfBirth ?? patient.DateOfBirth;

            return View(patient);
        }

        public  ActionResult Index()
        {
            return View();
        }
    }
}