using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriBurst.Web.Models;
using NutriBurst.Web.Data;
using NutriBurst.Web.Models.Entities;
using System.Windows.Forms;

namespace NutriBurst.Web.Controllers
{
    public class PatientsNbController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public PatientsNbController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddPatientNbViewModel viewModel)
        {
            
            var patientsNb = new PatientsNb
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Age = viewModel.Age,
                Height = viewModel.Height,
                Weight = viewModel.Weight,
                BodyMassIndex = viewModel.BodyMassIndex,
                Email = viewModel.Email,
                Phone = viewModel.Phone
            };

            await dbContext.PatientsNb.AddAsync(patientsNb);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
           var patientsNb2 = await dbContext.PatientsNb.ToListAsync();

            return View(patientsNb2);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Patientid)
       {
            var patientsNb3 = await dbContext.PatientsNb.FindAsync(Patientid);

            return View(patientsNb3);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PatientsNb viewModel)
        {
            var patientsNb4 = await dbContext.PatientsNb.FindAsync(viewModel.PatientsId);

            if (patientsNb4 is not null) 
            {
                patientsNb4.FirstName = viewModel.FirstName;
                patientsNb4.LastName = viewModel.LastName;
                patientsNb4.Age = viewModel.Age;
                patientsNb4.Height = viewModel.Height;
                patientsNb4.Weight = viewModel.Weight;
                patientsNb4.BodyMassIndex = viewModel.BodyMassIndex;
                patientsNb4.Phone = viewModel.Phone;
                patientsNb4.Email = viewModel.Email;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "PatientsNb");
        }
    }
}
