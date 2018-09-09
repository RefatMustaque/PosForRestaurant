using AutoMapper;
using POS.BLL.ManagerRepositories;
using POS.Models.EntityModels;
using PosForRestaurant.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PosForRestaurant.Controllers
{
    public class StockListController : Controller
    {
		ItemCategoryManager _ItemCategoryManager = new ItemCategoryManager();
		ItemManager _itemManager = new ItemManager();
        // GET: StockList
        public ActionResult ItemList()
        {
			var model = _itemManager.GetAll();

			return View(model);
		}

		public ActionResult AddCategory()
		{
			var model = new ItemCategoryCreateVM();
			model.ItemCategories = _ItemCategoryManager.GetAll();
			return View(model);
		}

		[HttpPost]
		public ActionResult AddCategory(ItemCategoryCreateVM model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var itemCategory = Mapper.Map<ItemCategory>(model);
					bool isSaved = _ItemCategoryManager.Save(itemCategory);
					if (isSaved)
					{
						return RedirectToAction("AddCategory");
					}
				}
			}
			catch (Exception exception)
			{
				ModelState.AddModelError("", exception.Message);
				model.ItemCategories = _ItemCategoryManager.GetAll();
				return View(model);
			}
			model.ItemCategories = _ItemCategoryManager.GetAll();
			return View(model);

		}

		public ActionResult AddItem()
		{
			var model = new ItemCreateVM();
			model.ItemCategories = _ItemCategoryManager.GetAll();
			return View(model);
		}


		// POST: Item/Create
		[HttpPost]
		public ActionResult AddItem(ItemCreateVM model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					using (var binaryReader = new BinaryReader(model.ImageUpload.InputStream))
					{
						model.Image = binaryReader.ReadBytes(model.ImageUpload.ContentLength);
					}

					var item = Mapper.Map<Item>(model);

					bool isSaved = _itemManager.Save(item);
					if (isSaved)
					{
						return RedirectToAction("AddItem");
					}
				}

			}
			catch(Exception exception)
			{
				ModelState.AddModelError("", exception.Message);
				model.ItemCategories = _ItemCategoryManager.GetAll();
				return View(model);
			}
			model.ItemCategories = _ItemCategoryManager.GetAll();
			return View(model);

		}


		public ActionResult ItemDetailsView(int id)
		{
			var item = _itemManager.GetById(id);
			var model = Mapper.Map<ItemCreateVM>(item);
			var base64 = Convert.ToBase64String(item.Image);
			var imgsrc = string.Format("data:image/png;base64,{0}", base64);

			//model.ImageUpload = imgsrc;
			
			model.ItemCategories = _ItemCategoryManager.GetAll();
			return View(model);
		}


		[HttpPost]
		public ActionResult ItemDetailsView(ItemCreateVM model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					if(model.ImageUpload != null)
					{
						using (var binaryReader = new BinaryReader(model.ImageUpload.InputStream))
						{
							model.Image = binaryReader.ReadBytes(model.ImageUpload.ContentLength);
						}
					}

					var item = Mapper.Map<Item>(model);

					bool isSaved = _itemManager.Update(item);
					if (isSaved)
					{
						return RedirectToAction("ItemList");
					}
				}

			}
			catch (Exception exception)
			{
				ModelState.AddModelError("", exception.Message);
				model.ItemCategories = _ItemCategoryManager.GetAll();
				return View(model);
			}
			model.ItemCategories = _ItemCategoryManager.GetAll();
			return View(model);
		}

		public ActionResult DeleteItem(int id)
		{
			var item = _itemManager.GetById(id);
			var model = Mapper.Map<ItemCreateVM>(item);
			try
			{
					bool isDeleted = _itemManager.Remove(item);
					if (isDeleted)
					{
						return RedirectToAction("ItemList");
					}
			}
			catch (Exception exception)
			{
				ModelState.AddModelError("", exception.Message);
				model.ItemCategories = _ItemCategoryManager.GetAll();
				return View("ItemDetailsView", model);
			}
			model.ItemCategories = _ItemCategoryManager.GetAll();
			return View("ItemDetailsView", model);
		}

		public JsonResult DeleteCategory(ItemCategory categoryId)
		{
			if (categoryId == null)
			{
				return null;
			}

			bool Result = _ItemCategoryManager.Remove(categoryId);

			return Json(Result);
		} 

		public JsonResult GetItemList(int id)
		{
			var item = _itemManager.GetById(id);
			return Json(item);
		}


	}
}