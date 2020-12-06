/**
 * Author: Abdus Sattar Mia
 * Date: Dec 05, 2020
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Staff.Models;

namespace Staff.Controllers
{
    /// <summary>
    /// This class contains actions methods to create a patient and retrieve patients list 
    /// </summary>
    public class PatientController : Controller
    {
        // API base url
        string baseURL = "https://localhost:44325/api/";


        // GET: All Patients
        /// <summary>
        /// Method to display all the patients from API
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> List()
        {
            List<Patient> patients = new List<Patient>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var URL = "patients";
                HttpResponseMessage response = await client.GetAsync(URL);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    patients = JsonConvert.DeserializeObject<List<Patient>>(json);
                }
            }

            return View(patients);
        }


        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Patient/Create
        /// <summary>
        /// Method to create a patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json");

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(baseURL);
                        var URL = $"patients/";
                        HttpResponseMessage response = await client.PostAsync(URL, content);
                    }
                }
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

    }
}