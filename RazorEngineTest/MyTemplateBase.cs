using System.Web.WebPages;
using RazorEngine.Templating;
using System.Web.Mvc;

namespace RazorEngineTest
{

    [RequireNamespaces("System.Web.Mvc")]
    [RequireNamespaces("System.Web.Mvc.Html")]
    public class MyTemplateBase<T> : TemplateBase<T>, IViewDataContainer
    {
        private HtmlHelper<T> _helper;
        private ViewDataDictionary _viewdata;
        private System.Dynamic.DynamicObject viewbag = null;
        
        public dynamic ViewBag
        {
            get
            {
                return (WebPageContext.Current.Page as WebViewPage).ViewBag;
            }
        }

        public HtmlHelper<T> Html
        {
            get
            {
                if (_helper == null) 
                {
                    var p = WebPageContext.Current ?? new WebPageContext();
                    var wvp = p.Page as WebViewPage;
                    var context = wvp != null ? wvp.ViewContext : new ViewContext();
    
                    _helper = new HtmlHelper<T>(context, this);
                }
                return _helper;
            }
        }

        public ViewDataDictionary ViewData
        {
            get
            {
                if (viewbag == null)
                {
                    var p = WebPageContext.Current ?? new WebPageContext(); 
                    var viewcontainer = p.Page as IViewDataContainer;
                    _viewdata = viewcontainer != null ? new ViewDataDictionary(viewcontainer.ViewData) : new ViewDataDictionary();

                    if (this.Model != null)
                    {
                        _viewdata.Model = Model;
                    }

                }

                return _viewdata;
            }
            set
            {
                _viewdata = value;
            }
        }

        public string Bla()
        {
            return "Bla";
        }
    }

}
