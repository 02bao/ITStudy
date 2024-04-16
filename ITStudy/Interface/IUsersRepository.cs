using ITStudy.Models;

namespace ITStudy.Interface
{
    public interface IUsersRepository
    {
        bool Regiter(Users_Register Regis);
        bool Delete(long Id);
        ICollection<Users> GetAll();
    }
}
