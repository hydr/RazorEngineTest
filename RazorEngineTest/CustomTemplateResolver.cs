using System;
using System.IO;
using System.Text;
using RazorEngine.Templating;

namespace RazorEngineTest
{
    public class CustomTemplateResolver : ITemplateResolver
    {
        private readonly string _viewFolder;

        public CustomTemplateResolver(string viewFolder = null)
        {
            _viewFolder = viewFolder ?? "Views";
        }


        public string Resolve(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            var filename = name.EndsWith(".cshtml") ? name : name + ".cshtml";

            var path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, _viewFolder, filename);
            return File.ReadAllText(path, Encoding.UTF8);
        }
        
    }
}
