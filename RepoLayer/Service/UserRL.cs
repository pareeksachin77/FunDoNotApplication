using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoLayer.Context;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepoLayer.Service
{
    public class UserRL: IUserRL
    {
        FunDoContext fundoo;
        private readonly string _secret;
        private readonly string _expDate;
        public UserRL(FunDoContext fundoo, IConfiguration config)
        {
            this.fundoo = fundoo;
            _secret = config.GetSection("JwtConfig").GetSection("secret").Value;
            _expDate = config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
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
                    var token = GenerateSecurityToken(result.Email, result.UserId);
                    return token;
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
        public string GenerateSecurityToken(string email, long userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim("userId",userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
        public string ForgotPassword(string email)
        {
            try
            {
                var result = fundoo.UsersTable.Where(x => x.Email == email).FirstOrDefault();
                if(result != null)
                {
                    var token = GenerateSecurityToken(result.Email, result.UserId);
                    MSMQModel mq = new MSMQModel();
                    mq.sendData2Queue(token);
                    return token;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ResetPassword(string email, string new_password, string confirm_password)
        {
            try
            {
                if(new_password== confirm_password)
                {
                    var result = fundoo.UsersTable.Where(x=>x.Email == email).FirstOrDefault();
                    result.Password = new_password;
                    fundoo.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
