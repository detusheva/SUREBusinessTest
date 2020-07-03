using System.Threading.Tasks;
using SUREBusiness.Models;

namespace SUREBusiness.Repository
{
    public interface IUserRepository
    {
        Task UpdateUser(UserModel model);
    }
}