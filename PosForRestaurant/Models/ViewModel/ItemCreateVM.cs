using POS.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PosForRestaurant.Models.ViewModel
{
	public class ItemCreateVM
	{
		public int Id { get; set; }


		[Required]
		[Display(Name = "Item Barcode")]
		public string Barcode { get; set; }
		
		[Required]
		[Display(Name = "Item Name")]
		public string Name { get; set; }
		
		[Display(Name = "Description")]
		public string Description { get; set; }

		[Required]
		[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
		public string Quantity { get; set; }


		[Required]
		[Range(0, float.MaxValue, ErrorMessage = "Please enter valid float Number")]
		public float PurchasePrice { get; set; }

		[Required]
		[Range(0, float.MaxValue, ErrorMessage = "Please enter valid float Number")]
		public float SalesPrice { get; set; }

		[Display(Name = "Discount Rate")]
		public float DiscountRate { get; set; }

		[Required]
		[Display(Name = "Category")]
		public int? ItemCategoryId { get; set; }
		public List<ItemCategory> ItemCategories { get; set; }

		[Required]
		public string Supplier { get; set; }

		[Required]
		[Display(Name = "Assign Shop Location")]
		public string ShopLocation { get; set; }

		[Display(Name = "Is Tax Apply")]
		public bool TaxApply { get; set; }

		[Display(Name = "Is it Kitchen Item")]
		public bool KitchenItem { get; set; }

		public string Weight { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		[Display(Name = "Manufacturing Date")]
		[DataType(DataType.Date)]
		public DateTime ManufacturingDate { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		[DataType(DataType.Date)]
		[Display(Name = "Expire Date")]
		public DateTime ExpiryDate { get; set; }

		public byte[] Image { get; set; }

		// model, ImageUpload property
		public HttpPostedFileBase ImageUpload { get; set; }
	}
}