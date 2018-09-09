using POS.BLL.ManagerRepositories;
using PosForRestaurant.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PosForRestaurant.Controllers
{
    public class SettingController : Controller
    {
		TableZoneManager _tableZoneManeger = new TableZoneManager();
        public ActionResult TableZone()
        {
			var model = new TableZoneCreateVM();
			model.TableZones = _tableZoneManeger.GetAll();
            return View(model);
        }
    }
}