using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class PropertySearchViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
