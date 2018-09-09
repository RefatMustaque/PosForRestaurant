using AutoMapper;
using POS.BLL.ManagerRepositories;
using POS.Models.EntityModels;
using PosForRestaurant.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PosForRestaurant.Controllers
{
    public class SalesRegisterController : Controller
    {
		// GET: SalesRegister
		ItemCategoryManager _itemCategoryManager = new ItemCategoryManager();
		ItemManager _itemManager = new ItemManager();
		SellManager _sellManager = new SellManager();
		SellDetailsManager _sellDetailsManager = new SellDetailsManager();

		public ActionResult Terminal()
        {
			var model = new TerminalVM();
			model.ItemCategories = _itemCategoryManager.GetAll();
			model.Items = _itemManager.GetAll();
            return View(model);
        }

		[HttpPost]
		public ActionResult Terminal(TerminalVM model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var terminal = Mapper.Map<Sell>(model);
					bool isSaved = _sellManager.Save(terminal);
					if (isSaved)
					{
						return RedirectToAction("Payment");
					}
				}
			}
			catch (Exception exception)
			{
				ModelState.AddModelError("", exception.Message);
				model.ItemCategories = _itemCategoryManager.GetAll();
				model.Items = _itemManager.GetAll();
				return View(model);
			}
			model.ItemCategories = _itemCategoryManager.GetAll();
			model.Items = _itemManager.GetAll();
			return View(model);
		}

		public ActionResult Payment()
		{
			var sellItem = _sellManager.GetLastOrDefault(m => m.Id == m.Id);
			var model = Mapper.Map<TerminalVM>(sellItem);
			return View(model);
		}

		[HttpPost]
		public ActionResult Payment(TerminalVM model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var terminal = Mapper.Map<Sell>(model);
					
					bool isSaved = _sellManager.Update(terminal);
					if (isSaved)
					{
						int id = terminal.Id;
						return RedirectToAction("Receit", new { id });
					}
				}
			}
			catch (Exception exception)
			{
				ModelState.AddModelError("", exception.Message);
				var sell = _sellManager.GetLastOrDefault(m => m.Id == m.Id);
				model = Mapper.Map<TerminalVM>(sell);
				return View(model);
			}
			return View(model);
		}

		public ActionResult Receit(int id)
		{
			var sellItem = _sellManager.GetById(id);
			var model = Mapper.Map<TerminalVM>(sellItem);
			model.SellDetailses = _sellDetailsManager.Get(m => m.SellId == id);
			return View(model);
		}
	}

	
}