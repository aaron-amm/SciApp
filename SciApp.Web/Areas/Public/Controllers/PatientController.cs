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

        private readonly SelectListItem[] availableList =
            new[] {"a", "b", "c", "d"}.Select(e => new SelectListItem() {Value = e, Text = e}).ToArray();

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

        public ActionResult List()
        {
            var viewModel = new ListViewModel
            {
                SelectedList = new []{"a", "b"},
                AvailableList = availableList
            };
            return View(viewModel);

        }

        [HttpPost]
        public ActionResult List(ListViewModel viewModel)
        {
            viewModel.AvailableList = availableList;
            return View(viewModel);

        }



    }

    public  class ListViewModel
    {
        public SelectListItem[] AvailableList { get; set; }
        public  string[] SelectedList { get; set; }

    }
}