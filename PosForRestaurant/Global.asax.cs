using AutoMapper;
using POS.Models.EntityModels;
using PosForRestaurant.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PosForRestaurant
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			Mapper.Initialize(cfg =>
				{
					cfg.CreateMap<ItemCategoryCreateVM, ItemCategory>();
					cfg.CreateMap<ItemCreateVM, Item>();
					cfg.CreateMap<Item, ItemCreateVM>();
					cfg.CreateMap<TerminalVM, Sell>();
					cfg.CreateMap<Sell, TerminalVM>();
				}
			);
		}
    }
}
