using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_Saver_API.Data_Structures;

namespace Smart_Saver_API.Controllers
{
    struct Login
    {
        String username;
        String password;
    }

    [ApiController]
    [Route("Login")]
    [EnableCors("AllowOrigin")]

    public class LoginController : ControllerBase
    {
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Instance Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        public LoginController() { }
        private static LoginController _instance = null; //Singleton pattern

        public static LoginController Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new LoginController();
            }
            return _instance;
        }
        [Route("AttemptLogin")]

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public bool AttemptLogin(String userName, String password) 
        {
            String passwordFromDatabase = "";

            System.Collections.Generic.List<Smart_Saver_API.Models.LoginDB> logins = new System.Collections.Generic.List<Smart_Saver_API.Models.LoginDB>();


            try
            {
                using (var context = new Data.Smart_Saver_APIContext())
                {
                    logins = context.LoginDB.ToList();
                }
            }
            catch (Exception e)
            {
                //_logger?.LogError(e.ToString());
            }

            bool userFound = false;

            foreach(Smart_Saver_API.Models.LoginDB oneUser in logins)
            {
                if (oneUser.Username == userName)
                {
                    passwordFromDatabase = oneUser.Password;
                    userFound = true;
                    break;
                }
            }

            return (passwordFromDatabase == password) && userFound;
        }

        public int UserId(String username, String password)
        {
            System.Collections.Generic.List<Smart_Saver_API.Models.LoginDB> logins = new System.Collections.Generic.List<Smart_Saver_API.Models.LoginDB>();

            try
            {
                using (var context = new Data.Smart_Saver_APIContext())
                {
                    logins = context.LoginDB.ToList();
                }
            }
            catch (Exception e)
            {
                //_logger?.LogError(e.ToString());
            }

            Smart_Saver_API.Models.LoginDB foundUser = new Smart_Saver_API.Models.LoginDB();

            bool userFound = false;

            foreach (Smart_Saver_API.Models.LoginDB oneUser in logins)
            {
                if (oneUser.Username == username)
                {
                    foundUser = oneUser;
                    userFound = true;
                    if (password == foundUser.Password)
                        return oneUser.UserId;
                    else
                        return -1;
                }
            }

            return -1;
        }
    }
}
