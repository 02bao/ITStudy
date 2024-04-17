using ITStudy.Data;
using ITStudy.Interface;
using ITStudy.Models;

namespace ITStudy.Repository;

public class UsersRepository(DataContext _context) : IUsersRepository
{
    public bool Delete(long Id)
    {
        Users user = _context.Users.SingleOrDefault(s => s.Id == Id);
        if (user == null) { return false; } 
        _context.Users.Remove(user);
        _context.SaveChanges();
        return true;
    }

    public ICollection<Users> GetAll()
    {
        return _context.Users.ToList();
    }

    public Users GetById(long UserId)
    {
        return _context.Users.SingleOrDefault(s => s.Id == UserId);
    }

    public bool Regiter(Users_Register Regis)
    {
        Users UserEmail = _context.Users.SingleOrDefault(s => s.Email == Regis.Email);
        if (UserEmail != null) { return false; }
        Users NewAccount = new Users()
        {
            UserName = Regis.UserName,
            Email = Regis.Email,
            Phone = Regis.Phone,
            Password = Regis.Password,
            Role = Regis.Role,
        };
        _context.Users.Add(NewAccount);
        _context.SaveChanges();
        return true;
    }
}
