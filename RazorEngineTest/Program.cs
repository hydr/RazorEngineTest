using System;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace RazorEngineTest
{
    public class Program
    {
        static void Main(string[] agrs)
        {
            string template = "This is my sample template, Hello @Model.Name!";
            string result = Razor.Parse(template, new { Name = "World" });
            Console.WriteLine(result);

            var config = new TemplateServiceConfiguration
            {
                BaseTemplateType = typeof(CustomBaseTemplate<>),
                Resolver = new CustomTemplateResolver(),
            };
            

            var service = new TemplateService(config);


            Razor.SetTemplateService(service);

            string template3 = "My name @Html.Raw(Model.HtmlString) @Model.HtmlString in UPPER CASE is @Model.Name";
            string result3 = Razor.Parse(template3, new { Name = "Max", Email ="max.balbch@web.de", HtmlString = "<a href=\"/web/x.html\"> asd </a>" });
            
            Console.WriteLine(result3);

            var context = new ExecuteContext();
            var parsedView = Razor.Resolve("TestView").Run(context);
            Console.WriteLine(parsedView);


            Console.ReadKey();
        }

    }

}



