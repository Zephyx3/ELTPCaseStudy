using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration;
using ELTPDomainModel;
using ELTPRepository;
using ELTPViewModel;

namespace ELTPServiceLayer
{
    public interface IUsersService
    {
        int InsertUser(RegisterUserViewModel uvm);
        void UpdateUserDetails(EditUserDetailsViewModel uvm);
        void UpdateUserPassword(EditUserPasswordViewModel uvm);
        void DeleteUser(int uid);
        List<UserViewModel> GetUsers();
        UserViewModel GetUsersByEmailAndPassword(string Email, string Password);
        UserViewModel GetUsersByEmail(string Email);

        //new code
        UserViewModel GetUsersByUserID(int UserID);

    }
    public class UserService : IUsersService
    {
        IUsersRepository ur;

        public UserService()
        {
            ur = new UsersRepository();
        }

        public void DeleteUser(int uid)
        {
            ur.DeleteUser(uid);
        }

        public List<UserViewModel> GetUsers()
        {
            List<Users> u = ur.GetUsers();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<UserViewModel, Users>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<UserViewModel> uvm = mapper.Map<List<Users>, List<UserViewModel>>(u);
            return uvm;
        }

        public UserViewModel GetUsersByEmail(string Email)
        {
            Users u = ur.GetUsersByEmail(Email).FirstOrDefault();
            UserViewModel uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Users, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<Users, UserViewModel>(u);
            }
            return uvm;
        }

        public UserViewModel GetUsersByEmailAndPassword(string Email, string Password)
        {
            Users u = ur.GetUsersByEmailAndPassword(Email, SHA256HashGenerator.GenerateHash(Password)).FirstOrDefault();
            UserViewModel uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Users, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<Users, UserViewModel>(u);
            }
            return uvm;

        }

        //New Code
        public UserViewModel GetUsersByUserID(int UserID)
        {
            Users u = ur.GetUsersByUserID(UserID).FirstOrDefault();
            UserViewModel uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Users, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<Users, UserViewModel>(u);
            }
            return uvm;
        }

        public int InsertUser(RegisterUserViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<RegisterUserViewModel, Users>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Users u = mapper.Map<RegisterUserViewModel, Users>(uvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);
            ur.InsertUser(u);
            int uid = ur.GetLatestUserID();
            return uid;
        }

        public void UpdateUserDetails(EditUserDetailsViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserDetailsViewModel, Users>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Users u = mapper.Map<EditUserDetailsViewModel, Users>(uvm);
            ur.UpdateUserDetails(u);
        }

        public void UpdateUserPassword(EditUserPasswordViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserPasswordViewModel, Users>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Users u = mapper.Map<EditUserPasswordViewModel, Users>(uvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);
            ur.UpdateUserPassword(u);
        }
    }
}