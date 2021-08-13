using Asp.netCoreMvcCrud.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;

namespace UnitTestClassLibrary
{
    [TestFixture]
    public class UnitTestControllers
    {

        [Test]
        public void TestHomeIndex()
        {
            var obj = new HomeController();

            var actResult = obj.Index() as ViewResult;

            Assert.That(actResult.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void TestPrivacyPage()
        {
            var obj = new HomeController();


            var actResult = obj.Privacy() as ViewResult;

            Assert.That(actResult.ViewName, Is.EqualTo("Privacy"));

        }

    }
}
