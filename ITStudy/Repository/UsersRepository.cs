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

    public Users? Login(Users_Login Login)
    {
        Users? users = _context.Users.Where(s => s.UserName == Login.UserName &&
                                            s.Password == Login.Password &&
                                            s.Status == Status_Register.Active).FirstOrDefault();
        if (users == null) { return null; }
        return users;
    }

    public string Regiter(Users_Register Regis)
    {
        Users UserEmail = _context.Users.SingleOrDefault(s => s.Email == Regis.Email);
        if (UserEmail != null) { return ""; }
        Users NewAccount = new Users()
        {
            UserName = Regis.UserName,
            Email = Regis.Email,
            Phone = Regis.Phone,
            Password = Regis.Password,
            Role = Regis.Role,
            Token = _context.randomString(20),
            Status = Status_Register.Wating,
        };
        _context.Users.Add(NewAccount);
        _context.SaveChanges();
        return NewAccount.Token;
    }

    public bool RejectUser(string Tokens)
    {
        Users? user = _context.Users.SingleOrDefault(s => s.Token == Tokens);
        if (user == null) { return false; }
        _context.Users.Remove(user);
        _context.SaveChanges();
        return true;
    }

    public bool Update(Users User, List<IFormFile> Images)
    {
        var users = _context.Users.SingleOrDefault(u => u.Id == User.Id);
        if (users == null) { return false;}
        users.UserName = User.UserName;
        users.Email = User.Email;
        users.Phone = User.Phone;
        users.Password = User.Password;
        users.Role = User.Role;
        if (Images != null)
        {
            CloudinaryRepository cloudinary = new CloudinaryRepository();
            string Url = cloudinary.uploadFile(Images[0]);
            if (!string.IsNullOrEmpty(Url))
            {
                users.Image = Url;
            }
        }
        _context.Users.Update(users);
        _context.SaveChanges();
        return true;
    }

    public bool VerifyUser(string Tokens)
    {
        Users? user = _context.Users.SingleOrDefault(s => s.Token == Tokens);
        if (user == null) { return false;}
        user.Status = Status_Register.Active;
        user.Token = string.Empty;
        _context.SaveChanges();
        return true;
    }
}
