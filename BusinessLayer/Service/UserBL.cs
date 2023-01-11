using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        IUserRL userIuserRL;
        public UserBL(IUserRL userIuserRL)
        {
            this.userIuserRL = userIuserRL;
        }

        public string Login(UserLogin userLogin)
        {
            try
            {
                return userIuserRL.Login(userLogin);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserEntity UserRegister(UserRegistration userRegistration)
        {
            try
            {
                return userIuserRL.UserRegister(userRegistration);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
