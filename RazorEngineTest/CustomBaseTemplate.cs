using RazorEngine.Templating;

namespace RazorEngineTest
{
    public class CustomBaseTemplate<T> : TemplateBase<T>
    {
        
        private HtmlHelper _htmlHelper;

        public HtmlHelper Html { get
        {
            return _htmlHelper ?? (_htmlHelper = new HtmlHelper(ViewBag));
        } }
    }
}
