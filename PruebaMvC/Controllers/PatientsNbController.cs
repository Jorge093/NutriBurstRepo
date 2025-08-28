using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriBurst.Web.Models;
using NutriBurst.Web.Data;
using NutriBurst.Web.Models.Entities;
using System.Windows.Forms;
using Azure.Core;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

namespace NutriBurst.Web.Controllers
{
    [Route("[controller]")]
    public class PatientsNbController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public PatientsNbController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //****************************************************************************************

        //<<<<<<<<<<<<><>>>>>>>>>>>>
        //<<<< CONSULT PATIENT >>>>
        //<<<<<<<<<<<<><>>>>>>>>>>>>

        [HttpGet, Route("List")]
        public IActionResult List()
        {
            var patients = dbContext.PatientsNb.ToList(); // Get all patients
            return View(patients);
        }
        //****************************************************************************************



        //****************************************************************************************

        //<<<<<<<<<<<<><>>>>>>>>>>>>
        //<<<< INSERT PATIENT >>>>
        //<<<<<<<<<<<<><>>>>>>>>>>>>

        [HttpGet, Route("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost, Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddPatientNbViewModel viewModel)
        {
            HttpClient httpClient = new HttpClient();

            // Define the API endpoint
            string ApiURL = "http://localhost:5018/api/PatientsNb";

            try
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
              
                // Send GET request
                var response = await httpClient.PostAsJsonAsync(ApiURL, viewModel);

                // Ensure the response status is successful
                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                {

                    // Read and display the response
                    string responseJsonString = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<ResultadoLLamada>(responseJsonString)
                                            ?? new ResultadoLLamada();



                    // dispose HttpClient
                    httpClient.Dispose();

                    return Ok(resultado);
                }
                else
                {
                    throw new Exception("IsSuccessStatusCode false");
                }
            }
            catch (Exception ex)
            {
                // dispose HttpClient
                httpClient.Dispose();

                // return error response

                return StatusCode((int)HttpStatusCode.InternalServerError, new { error="Ocurrio un error" });
            }

           
        }

        //****************************************************************************************



        //****************************************************************************************

        //<<<<<<<<<<<<><>>>>>>>>>>>>
        //<<<< EDIT PATIENT >>>>
        //<<<<<<<<<<<<><>>>>>>>>>>>>

        [HttpGet, Route("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var patient = await dbContext.PatientsNb.FindAsync(id);
            if (patient is null)
            {
                return NotFound();
            }

            return View(patient); // returns the view with patient data for editing
        }

        [HttpPost, Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] EditPatientNbViewModel viewModel)
        {
            HttpClient httpClient = new HttpClient();

            // Define the API endpoint
            string ApiURL = "http://localhost:5018/api/PatientsNb/Edit";

            try
            {
                
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                // Send GET request
                var response = await httpClient.PostAsJsonAsync(ApiURL, viewModel);

                // Ensure the response status is successful
                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                {

                    // Read and display the response
                    string responseJsonString = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<ResultadoLLamada>(responseJsonString)
                                            ?? new ResultadoLLamada();



                    // dispose HttpClient
                    httpClient.Dispose();

                    return Ok(resultado);
                }
                else
                {
                    throw new Exception("IsSuccessStatusCode false");
                }
            }
            catch (Exception ex)
            {
                // dispose HttpClient
                httpClient.Dispose();

                // return error response

                return StatusCode((int)HttpStatusCode.InternalServerError, new { error = "Ocurrio un error" });
            }


        }
        //****************************************************************************************
        //[HttpPost]
        //public async Task<IActionResult> Edit(PatientsNb viewModel)
        //{
        //    var patientsNb4 = await dbContext.PatientsNb.FindAsync(viewModel.PatientsId);

        //    if (patientsNb4 is not null)
        //    {
        //        patientsNb4.FirstName = viewModel.FirstName;
        //        patientsNb4.LastName = viewModel.LastName;
        //        patientsNb4.Age = viewModel.Age;
        //        patientsNb4.Height = viewModel.Height;
        //        patientsNb4.Weight = viewModel.Weight;
        //        patientsNb4.BodyMassIndex = viewModel.BodyMassIndex;
        //        patientsNb4.Phone = viewModel.Phone;
        //        patientsNb4.Email = viewModel.Email;

        //        await dbContext.SaveChangesAsync();
        //    }
        //    return RedirectToAction("List", "PatientsNb");
        //}

        //[HttpGet, Route("delete/{Patientid}")]
        //public async Task<IActionResult> Delete(Guid Patientid)
        //{
        //    var patientsNb3 = await dbContext.PatientsNb.FindAsync(Patientid);

        //    if (patientsNb3 == null)
        //    {
        //        return NotFound();
        //    }

        //    dbContext.PatientsNb.Remove(patientsNb3);
        //    await dbContext.SaveChangesAsync();
        //    return RedirectToAction("List", "PatientsNb");
        //}
    }
}
