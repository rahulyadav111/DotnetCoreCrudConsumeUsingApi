using CrudDotnetCoreWebApiConsume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Text; // install Newtonsoft.newget package

namespace CrudDotnetCoreWebApiConsume.Controllers
{
    public class StudentController : Controller
    {
        private string url = "https://localhost:7253/api/StudentAPI";  // root url running api...
        private HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if (data != null)
                {
                    students = data;
                }
            }

            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            string data = JsonConvert.SerializeObject(student);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["insert-message"] = "Student Added..";

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {

                    student = data;
                }
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            string data = JsonConvert.SerializeObject(student);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url + "/" + student.id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Update-message"] = "Student Updated..";

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {

                    student = data;
                }
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {

                    student = data;
                }
            }
            return View(student);
        }
    
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteItem(int id)
        //{
        //    var response = client.DeleteAsync(url + "/" + id).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        TempData["Delete-message"] = "Student Deleted..";
        //        return RedirectToAction("Index");
        //    }
        //    return View();


        //}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var response = await client.DeleteAsync(url+"/"+id);
            if (response.IsSuccessStatusCode)
            {
                TempData["Delete-message"] = "Student Deleted..";
                return RedirectToAction("Index");
            }

            // Handle failure (e.g., show an error message)
            return View();
        }
    }
}
