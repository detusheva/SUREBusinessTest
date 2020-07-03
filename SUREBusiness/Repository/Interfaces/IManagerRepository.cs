using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SUREBusiness.Repository
{
    public interface IManagerRepository
    {
        IEnumerable<SelectListItem> GetManagerList();
    }
}