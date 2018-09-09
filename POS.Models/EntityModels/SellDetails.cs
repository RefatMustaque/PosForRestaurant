using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.EntityModels
{
	public class SellDetails
	{
		public int Id { get; set; }

		public int ItemId { get; set; }

		public virtual Item Item { get; set; }

		public int Quantity { get; set; }

		public float ItemTotal { get; set; }

		public int? SellId { get; set; }

		public Sell Sell { get; set; }
	}
}
