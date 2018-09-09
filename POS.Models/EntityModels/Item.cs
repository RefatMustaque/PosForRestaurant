using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.EntityModels
{
	public class Item
	{
		public int Id { get; set; }
		public string Barcode { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Quantity { get; set; }

		public float PurchasePrice { get; set; }

		public float SalesPrice { get; set; }

		public float DiscountRate { get; set; }

		public int? ItemCategoryId { get; set; }
		public virtual ItemCategory ItemCategory { get; set; }

		public string Supplier { get; set; }

		public string ShopLocation { get; set; }

		public bool TaxApply { get; set; }

		public bool KitchenItem { get; set; }

		public string Weight { get; set; }

		public DateTime ManufacturingDate { get; set; }

		public DateTime ExpiryDate { get; set; }

		public byte[] Image { get; set; }
	}
}
