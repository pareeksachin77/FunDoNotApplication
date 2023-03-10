using CommonLayer.Model;
using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IUserRL
    {
        public UserEntity UserRegister(UserRegistration userRegistration);
        public string Login(UserLogin userLogin);

        public string ForgotPassword(string email);
        public bool ResetPassword(string email, string new_password, string confirm_password);
    }
}
