using POS.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PosForRestaurant.Models.ViewModel
{
	public class TerminalVM
	{
		public int Id { get; set; }
		
		[Display(Name = "Pay By")]
		public string PayBy { get; set; }

		[Display(Name = "Overall Discount")]
		public float OverallDiscount { get; set; }

		
		[Display(Name = "Cash")]
		public float Cash { get; set; }

		[Display(Name = "Change Amount")]
		public float ChangeAmount { get; set; }

		[Display(Name = "Due")]
		public float Due { get; set; }

		[Required]
		[Display(Name = "Date")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		[DataType(DataType.Date)]
		public DateTime Date { get; set; }
		
		[Display(Name = "Customer")]
		public string Customer { get; set; }
		
		[Display(Name = "Comment")]
		public string Comment { get; set; }

		[Display(Name = "Token No")]
		public int TokenNO { get; set; }

		[Required]
		[Display(Name = "Total")]
		public float Total { get; set; }

		[Required]
		[Display(Name = "SubTotal")]
		public float SubTotal { get; set; }

		[Required]
		[Display(Name = "Tax")]
		public float Tax { get; set; }

		[Required]
		[Display(Name = "Total Payable")]
		public float TotalPayable { get; set; }
		
		[Display(Name = "Total Item Type")]
		public int TotalItemType { get; set; }

		public List<SellDetails> SellDetailses { get; set; }
		public List<ItemCategory> ItemCategories { get; set; }
		public List<Item> Items { get; set; }
	}
}