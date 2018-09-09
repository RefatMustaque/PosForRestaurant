using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.EntityModels
{
	public class TableZone
	{
		public int Id { get; set; }

		public string TableName { get; set; }

		public string ZoneName { get; set; }

		public int AvailableSeatNumber { get; set; }
	}
}
