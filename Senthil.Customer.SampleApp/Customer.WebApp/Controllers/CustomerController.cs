using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Customer.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HttpClient client;
        private readonly string apiURL;
        private readonly string userName;

        public CustomerController()
        {
            client = new HttpClient();
            apiURL = ConfigurationManager.AppSettings["ApiURL"];
            userName = "Senthil"; //HttpContext.User.Identity.Name;
        }

        // GET: Customer
        public async Task<ActionResult> Index()
        {
            var customerModel = new List<Models.CustomerModel>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //client.BaseAddress = new Uri(apiURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(apiURL);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        customerModel = JsonConvert.DeserializeObject<List<Models.CustomerModel>>(data);
                        return this.View("Index", customerModel);
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, Helpers.ConstantMessage.GeneralError + "|| Exception:" + ex.Message);
                return this.View("Index", customerModel);
            }
        }

        // GET: Customer/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customerModel = new Models.CustomerModel();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(apiURL + "/" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        customerModel = JsonConvert.DeserializeObject<Models.CustomerModel>(data);
                        return this.View("View", customerModel);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, Helpers.ConstantMessage.ViewRecordError + response.StatusCode);
                        return this.View("View", customerModel);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, Helpers.ConstantMessage.GeneralError + " || Exception:" + ex.Message);
                return this.View("View", customerModel);
            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var viewModel = new Models.CustomerModel();
            return this.View("Create", viewModel);
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.CustomerModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View("Create", customerModel);
            }

            try
            {
                customerModel.CreatedOn = DateTime.Now;
                customerModel.CreatedBy = userName;

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    string jsonData = JsonConvert.SerializeObject(customerModel);
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiURL, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return this.RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, Helpers.ConstantMessage.CreateRecordError + response.StatusCode);
                        return this.View("Create", customerModel);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to save the customer details to the database, please try again.|| Exception:" + ex.Message);
                return this.View("Create", customerModel);
            }
        }

        // GET: Customer/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customerModel = new Models.CustomerModel();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(apiURL + "/" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        customerModel = JsonConvert.DeserializeObject<Models.CustomerModel>(data);
                        return this.View("Edit", customerModel);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, Helpers.ConstantMessage.ViewRecordError + response.StatusCode);
                        return this.View("Edit", customerModel);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, Helpers.ConstantMessage.GeneralError + " || Exception:" + ex.Message);
                return this.View("Edit", customerModel);
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Models.CustomerModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View("Edit", customerModel);
            }

            try
            {
                customerModel.UpdatedOn = DateTime.Now;
                customerModel.UpdatedBy = userName;

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    string jsonData = JsonConvert.SerializeObject(customerModel);
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync(apiURL + "/" + id, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return this.RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, Helpers.ConstantMessage.UpdateRecordError + response.StatusCode);
                        return this.View("Edit", customerModel);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to update the customer details to the database, please try again.|| Exception:" + ex.Message);
                return this.View("Edit", customerModel);
            }
        }

        // GET: Customer/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customerModel = new Models.CustomerModel();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(apiURL + "/" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        customerModel = JsonConvert.DeserializeObject<Models.CustomerModel>(data);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, Helpers.ConstantMessage.ViewRecordError + response.StatusCode);
                        return this.View("Delete", customerModel);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, Helpers.ConstantMessage.GeneralError + " || Exception:" + ex.Message);
                return this.View("Delete", customerModel);
            }
            return View("Delete", customerModel);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int? id, Models.CustomerModel customerModel)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new Models.CustomerModel();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.DeleteAsync(apiURL + "/" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, Helpers.ConstantMessage.DeleteRecordError + response.StatusCode);
                        return this.View("Delete", customerModel);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, Helpers.ConstantMessage.GeneralError + " || Exception:" + ex.Message);
                return this.View("Delete", customerModel);
            }
        }
    }
}
