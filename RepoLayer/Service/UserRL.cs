using CommonLayer.Model;
using RepoLayer.Context;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RepoLayer.Service
{
    public class UserRL: IUserRL
    {
        FunDoContext fundoo;
        public UserRL(FunDoContext fundoo)
        {
            this.fundoo = fundoo;
        }
        public UserEntity UserRegister(UserRegistration userRegistration)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = userRegistration.FirstName;
                userEntity.LastName = userRegistration.LastName;
                userEntity.Email = userRegistration.Email;
                userEntity.Password = userRegistration.Password;
                fundoo.UsersTable.Add(userEntity);
                int result = fundoo.SaveChanges();
                if(result> 0)
                {
                    return userEntity;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public string Login(UserLogin userLogin)
        {
            try
            {
                var result = fundoo.UsersTable.Where(x => x.Email == userLogin.Email && x.Password == userLogin.Password).FirstOrDefault();
                if (result != null)
                {
                    return "Login Successful";
                }
                else
                {
                    return null ;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
