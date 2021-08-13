using Asp.netCoreMvcCrud.Controllers;
using Asp.netCoreMvcCrud.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;

namespace IntegrationTest
{
    [TestFixture]
    public class EmployeeControllerTest
    {
        private readonly EmployeeContext _context;

        public EmployeeControllerTest(EmployeeContext context)
        {
            _context = context;
        }
        [Test]
        public void TestDepartmentCreateRedirect()
        {

           
                var obj = new HomeController();

                var actResult = obj.Index() as ViewResult;

                Assert.That(actResult.ViewName, Is.EqualTo("Index"));
            



        }
    }
}
