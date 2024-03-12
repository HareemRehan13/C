using Microsoft.AspNetCore.Mvc;
using WebApp_hareem.Data;

namespace WebApp_hareem.Views.Shared.Components
{
    public class DropdownViewComponent : ViewComponent
    {
        public readonly dotnetContext db;
        public DropdownViewComponent(dotnetContext Contex)
        {
            db = Contex;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.Roles.ToList());
        }
    }
}
