using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELTPDomainModel;

namespace ELTPRepository
{
    public interface IUsersRepository
    {
        void InsertUser(Users u);
        void UpdateUser(Users u);
        void UpdateUserDetails(Users u);
        void UpdateUserPassword(Users u);
        void DeleteUser(Users u);

        List<Users> GetUsers();

        List<Users> GetUsersByEmailAndPassowrd(string Email, string Password);

        List<Users> GetUsersByEmail(string Email);
        List<Users> GetUsersByID(int UserID);

        int GetLatestUserID();
    }
    public class UsersRepository : IUsersRepository
    {
        public void DeleteUser(Users u)
        {
            throw new NotImplementedException();
        }

        public int GetLatestUserID()
        {
            throw new NotImplementedException();
        }

        public List<Users> GetUsers()
        {
            throw new NotImplementedException();
        }

        public List<Users> GetUsersByEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetUsersByEmailAndPassowrd(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetUsersByID(int UserID)
        {
            throw new NotImplementedException();
        }

        public void InsertUser(Users u)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Users u)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserDetails(Users u)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserPassword(Users u)
        {
            throw new NotImplementedException();
        }
    }
}