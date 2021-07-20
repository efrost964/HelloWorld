using System.Runtime.InteropServices;
using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

[assembly: Guid("609247d4-00d7-4620-b0d9-c1a5910f4cf4")]


namespace HelloWorld.Controllers
{
    public class HelloController : Controller
    {
        private readonly ILogger<HelloController> _logger;

        public HelloController(ILogger<HelloController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("/hello/welcome")]
        public IActionResult Index()
        {
            string html = "<form method = 'post' action = '/hello/welcome/message'>" +
                   "<input type='text' name='name' />" +
                   "<select name= languageUpper id=languageUpper> " +
                   "<option value=english>English</option>" +
                   "<option value=spanish>Spanish</option>" +
                   "<option value=arabic>Arabic</option>" +
                   "<option value=japanese>Japanese</option>" +
                   "<option value=french>French</option>" +
                   "</select>" +
                   "<input type='submit' value='Greet Me!' />" +
                   "</form>";
            return Content(html, "text/html");
        }

        [HttpPost]
        [Route("/hello/welcome/message")]
        public IActionResult CreateMessage(string name = "Ethan", string languageUpper = "English")
        {
            string html = "";
            string language = languageUpper.ToLower();
            if (language == "spanish")
            {
                html = $"<h1>Hola, {name}</h1>";
            }
            else if (language == "arabic")
            {
                html = $"<h1>Marhaba, {name}</h1>";
            }
            else if (language == "french")
            {
                html = $"<h1>Bonjour, {name}</h1>";
            }
            else if (language == "japanese")
            {
                html = $"<h1>Konnichiwa, {name}</h1>";
            }
            else if(language == "english")
            {
                html = $"<h1>Hello, {name}</h1>";
            }
                return Content(html, "text/html");
        }
    }
}

