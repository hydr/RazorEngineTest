using RazorEngine.Templating;
using RazorEngine.Text;

namespace RazorEngineTest
{
    public class HtmlHelper
    {
        private readonly dynamic _viewBag;

        public HtmlHelper(dynamic viewBag)
        {
            _viewBag = viewBag;
        }

        public IEncodedString Raw(string input)
        {
            return new RawString(input);
        }

        public IEncodedString Partial(string templateName, object model = null)
        {
            return new RawString(RazorEngine.Razor.Resolve(templateName, model).Run(new ExecuteContext(_viewBag)));
        }
    }
}
