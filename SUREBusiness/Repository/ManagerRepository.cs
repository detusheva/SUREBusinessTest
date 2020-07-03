using Microsoft.AspNetCore.Mvc.Rendering;
using SUREBusiness.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUREBusiness.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly ApplicationDbContext context;
        public ManagerRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<SelectListItem> GetManagerList()
        {
            {
                List<SelectListItem> clients = context.Managers
                    .OrderBy(n => n.ManagerName)
                    .Select(n =>
                    new SelectListItem
                    {
                        Value = Convert.ToString(n.ManagerId),
                        Text = n.ManagerName
                    }).ToList();
                return new SelectList(clients, "Value", "Text");
            }
        }
    }
}
