using DataBaseContext;
using Domain.SmartMarket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.SmartMarket
{
    public class AuthOperations
    {
        public static DatabaseContext _dbObj;




        public AuthOperations(DatabaseContext dbContext)
        {
            _dbObj = dbContext;
        }

        public Boolean Authanticate(string email,string password)
        {
            
            Users user =_dbObj.Users.
                            FirstOrDefault(obj => obj.Email == email && obj.Password == password);
            if(user != null )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean RegisterUser(Users user)
        {
            try
            {
                _dbObj.Users.Add(user);
                _dbObj.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public List<Users> GetUsers()
        {
            try
            {
                List<Users> users;
                users = _dbObj.Users.ToList();
                return users;


            }catch(Exception ex)
            {
                return [];
            }
        }

    }
}
