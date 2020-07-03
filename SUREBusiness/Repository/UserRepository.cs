using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SUREBusiness.Data;
using SUREBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUREBusiness.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        public UserRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task UpdateUser(UserModel model)
        {
            //UserIdentity userEntity = context.UserIdentity.SingleOrDefault(p => p.Id == model.UserId);
            UserIdentity userEntity = await context.UserIdentity.SingleAsync(p => p.Id == model.UserId);

            userEntity.FullName = model.FullName;
            userEntity.MobileNumber = model.MobileNumber;
            context.SaveChangesAsync();
        }

    }
}
