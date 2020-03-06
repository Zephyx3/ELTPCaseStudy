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
            int uid = db.Users.Select(temp => temp.UserID).Max();
            return uid;
        }

        public List<Users> GetUsers()
        {
            List<Users> us = db.Users.Where(temp => temp.IsAdmin == Convert.ToBoolean(false)).OrderBy(temp => temp.Name).ToList();
            return us;
        }

        public List<Users> GetUsersByEmail(string Email)
        {
            List<Users> us = db.Users.Where(temp => temp.Email == Email).ToList();
            return us;
        }

        public List<Users> GetUsersByEmailAndPassword(string Email, string Password)
        {
            List<Users> us = db.Users.Where(temp => temp.Email == Email && temp.PasswordHash == Password).ToList();
            return us;
        }

        public List<Users> GetUsersByUserID(int UserID)
        {
            List<Users> us = db.Users.Where(temp => temp.UserID == UserID).ToList();
            return us;
        }

        public void InsertUser(Users u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }

        public void UpdateUser(Users u)
        {
            Users us = db.Users.Where(temp => temp.UserID == u.UserID).FirstOrDefault();
            if(us != null)
            {
                us.Email = u.Email;
                us.PasswordHash = u.PasswordHash;
                us.Name = u.Name;
                us.Mobile = u.Mobile;
                db.SaveChanges();
            }
        }

        public void UpdateUserDetails(Users u)
        {
            Users us = db.Users.Where(temp => temp.UserID == u.UserID).FirstOrDefault();
            if (us != null)
            {
                us.Name = u.Name;
                us.Mobile = u.Mobile;
                db.SaveChanges();
            }
        }

        public void UpdateUserPassword(Users u)
        {
            Users us = db.Users.Where(temp => temp.UserID == u.UserID).FirstOrDefault();
            if (us != null)
            {
                us.PasswordHash = u.PasswordHash;
                db.SaveChanges();
            }
        }
    }
}