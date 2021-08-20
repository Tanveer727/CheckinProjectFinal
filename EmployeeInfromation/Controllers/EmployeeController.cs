using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.netCoreMvcCrud.Models;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.netCoreMvcCrud.Controllers
{
    public class EmployeeController : Controller
    {
         

        public EmployeeController()
        {
            
        }

        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        // GET: Employee
        public async Task<IActionResult> Index()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44348/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Employees");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var EmpResponse = result.Content.ReadAsStringAsync().Result;
                    
                    var readTask = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse);


                   
                    return View(readTask);
                }
                else //web api sent error response 
                {
                    //log response status here..

                   var  students = Enumerable.Empty<Employee>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return View(students);
                }
            }
           // return View(students);
        }

        //return View(await _context.Employees.ToListAsync());
    

        // GET: Employee/Create
        public IActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Employee());
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44348/api/");
                    //HTTP GET
                    var responseTask = client.GetAsync("Employees/"+id);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var EmpResponse = result.Content.ReadAsStringAsync().Result;

                        var readTask = JsonConvert.DeserializeObject<Employee>(EmpResponse);



                        return View(readTask);
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        var students = new Employee();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        return View(students);
                    }
                }

                //return View(_context.Employees.Find(id));
            }
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("EmployeeId,FirstName,LastName,Department,EmpCode,Position,Email,OfficeLocation")] Employee employee)
        {


            if (ModelState.IsValid)
            {
                //if (employee.EmployeeId == 0)
                //    _context.Add(employee);
                //else
                //    _context.Update(employee);
                //await _context.SaveChangesAsync();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44348/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Employee>("Employees", employee);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                return View(employee);


                //return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44348/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Employees/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
            //var employee = await _context.Employees.FindAsync(id);
            //_context.Employees.Remove(employee);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }
    }
}
