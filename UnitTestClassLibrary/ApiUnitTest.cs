using Asp.netCoreMvcCrud.Controllers;
using Asp.netCoreMvcCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
 

namespace UnitTestClassLibrary
{
    [TestFixture]
    public class ApiUnitTest
    {
        [Test]
        public void APiCheck()
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
                    Assert.AreEqual(true,true);

                }
                else
                {
                    Assert.Fail("Employee API Not found");
                }
                
            }

        }

    }
}
