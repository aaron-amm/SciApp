using NUnit.Framework;
using Rhino.Mocks;
using SciHospital.WebApp.Areas.Public.Controllers;
using System;
using System.Web.Mvc;

namespace SciApp.Web.Test
{
    [TestFixture]
    public class PatientControllerTest
    {
        IPatientRepository repository;
        PatientController controller;

        [SetUp]
        public void SetUp()
        {
            repository = MockRepository.GenerateMock<IPatientRepository>();
            controller = new PatientController(repository);
        }

        [Test]
        public void UpdatePatient_OnlyNewFirstNameNotNull_PatientFirstNameUpdated()
        {
            var existingPatient = new Patient()
            {
                Id = 1,
                FirstName = "Aaron",
                LastName = "Amm",
                DateOfBirth = new DateTime(2000, 3, 16)
            };

            repository.Stub(r => r.GetPatient(existingPatient.Id)).Return(existingPatient);

            var newFirstName = "NewAaron";
            var actionResult = (ViewResult)controller.UpdatePatient(id: existingPatient.Id, firstName: newFirstName, lastName: null, dateOfBirth: null);
            var updatedPatient = (Patient)actionResult.Model;

            Assert.AreEqual(newFirstName, updatedPatient.FirstName);
            Assert.AreEqual(existingPatient.LastName, updatedPatient.LastName);
            Assert.AreEqual(existingPatient.DateOfBirth, updatedPatient.DateOfBirth);
        }
    }
}
