using ITStudy.Models;

namespace ITStudy.Interface
{
    public interface IUsersRepository
    {
        string Regiter(Users_Register Regis);
        bool Delete(long Id);
        Users Login(Users_Login Login);
        ICollection<Users> GetAll();
        Users GetById(long UserId);
        bool Update(Users User, List<IFormFile> Images);
        bool VerifyUser(string Tokens);
        bool RejectUser(string Tokens);
    }
}
