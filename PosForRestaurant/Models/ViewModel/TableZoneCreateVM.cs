using POS.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PosForRestaurant.Models.ViewModel
{
	public class TableZoneCreateVM
	{
		public int Id { get; set; }

		public string TableName { get; set; }

		public string ZoneName { get; set; }

		public int AvailableSeatNumber { get; set; }

		public List<TableZone> TableZones { get; set; }
	}
}