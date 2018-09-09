using POS.BLL.BaseManager;
using POS.Models.EntityModels;
using POS.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL.ManagerRepositories
{
	public class ItemCategoryManager : Manager<ItemCategory>
	{
		public ItemCategoryManager() : base(new ItemCategoryRepository())
		{
		}
	}
}
