using POS.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.DatabaseContext
{
	public class PosManagementDbContext : DbContext
	{
		public DbSet<ItemCategory> ItemCategories { get; set; }

		public DbSet<Item> Items { get; set; }

		public DbSet<Sell> Sells { get; set; }

		public DbSet<SellDetails> SellDetailses { get; set; }

		public DbSet<TableZone> tableZones { get; set; }

	}
}
