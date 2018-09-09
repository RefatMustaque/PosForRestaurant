using POS.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PosForRestaurant.Models.ViewModel
{
	public class ItemCategoryCreateVM
	{

		[Required]
		[Display(Name = "Insert Category Name:")]
		public string Name { get; set; }

		public List<ItemCategory> ItemCategories { get; set; }
	}
}