using Auror.Models.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.ViewComponents
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly AurorDataContext _dt;

        public NavigationViewComponent(AurorDataContext dt)
        {
            _dt = dt;
        }
        public  IViewComponentResult Invoke()
        {
            var navigation = _dt.Navigation.OrderBy(o => o.Order).ToList();
            return View(navigation);
        }
    }
}
