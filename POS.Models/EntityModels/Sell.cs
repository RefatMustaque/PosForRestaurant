using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.EntityModels
{
	public class Sell
	{
		public int Id { get; set; }

		public string PayBy { get; set; }
		public float OverallDiscount { get; set; }

		public float Cash { get; set; }

		public float ChangeAmount { get; set; }

		public float Due { get; set; }

		public DateTime Date { get; set; }

		public string Customer { get; set; }

		public string Comment { get; set; }

		public int TokenNO { get; set; }

		public float Total { get; set; }

		public float SubTotal { get; set; }

		public float Tax { get; set; }

		public float TotalPayable { get; set; }

		public int TotalItemType { get; set; }

		public virtual List<SellDetails> SellDetailses { get; set; }

	}
}
