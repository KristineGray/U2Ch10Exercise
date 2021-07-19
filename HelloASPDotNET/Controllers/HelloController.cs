using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloASPDotNET.Controllers
{
    [Route("/helloworld/")]
    public class HelloController : Controller
    {
        /* English = Hello
         * French = Bonjour
         * Spanish = Hola
         * Pashto = Salaam
         * Binary = 0110100001100101011011000110110001101111
        */

        [HttpGet]
        public IActionResult Index()
        {
            string formOpen = "<form method='post' action='/helloworld/'>";
            string formClose = "</form>";
            string inputNameText = "<input type='text' name='name' />";
            string inputLangSelector = "<select name='language'>";
            string langOptionEng = "<option value='English'>English</option>";
            string langOptionPashto = "<option value='Pashto'>Pashto</option>";
            string langOptionFrench = "<option value='French'>French</option>";
            string langOptionSpanish = "<option value='Spanish'>Spanish</option>";
            string langOptionBinary = "<option value='Binary'>Binary</option>";
            string langChoice = langOptionEng + langOptionFrench + langOptionPashto + langOptionSpanish + langOptionBinary;

            string inputSubmit = "<input type='submit' value='Greet Me!' />";

            string html =  formOpen + inputNameText + inputLangSelector + langChoice + inputSubmit + formClose;

            return Content(html, "text/html");
        }

        [HttpGet("welcome/{name?}")]
        [HttpPost]
        public IActionResult Welcome(string name, string language)
        {
            string greeting = CreateMessage(name, language);
            return Content(greeting, "text/html");
        }

        public static string CreateMessage(string name, string language)
        {
            string greeting = "<h1>";
            if (language == "English") greeting += "Hello";
            else if (language == "French") greeting += "Bonjour";
            else if (language == "Spanish") greeting += "Hola";
            else if (language == "Pashto") greeting += "Salaam";
            else if (language == "Binary") greeting += "0110100001100101011011000110110001101111";
            greeting += ", " + name + "!</h1>";

            return greeting;
        }

    }
}
