using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Repository.Base;
using POS.Models.EntityModels;
using POS.Repository.DatabaseContext;

namespace POS.Repository.Repositories
{
	public class ItemCategoryRepository : Repository<ItemCategory>
	{
		public ItemCategoryRepository() : base(new PosManagementDbContext())
		{
		}
	}
}
