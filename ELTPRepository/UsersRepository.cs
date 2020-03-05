using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELTPDomainModel;
using System.Collections;

namespace ELTPRepository
{
    public interface IUsersRepository
    {
        void InsertUser(Users u);
        void UpdateUser(Users u);
        void UpdateUserDetails(Users u);
        void UpdateUserPassword(Users u);
        void DeleteUser(int uid);

        List<Users> GetUsers();

        List<Users> GetUsersByEmailAndPassword(string Email, string Password);

        List<Users> GetUsersByEmail(string Email);
        List<Users> GetUsersByUserID(int UserID);

        int GetLatestUserID();
    }
    public class UsersRepository : IUsersRepository
    {
        ELTPDbContext db;
        public void DeleteUser(int uid)
        {
            Users us = db.Users.Where(temp => temp.UserID == uid).FirstOrDefault();
            if (us != null)
            {
                db.Users.Remove(us);
                db.SaveChanges();
            }
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

        public List<Users> GetUsersByEmailAndPassword(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetUsersByUserID(int UserID)
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