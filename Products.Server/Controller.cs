using Microsoft.Win32;
using Products.Common;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Server
{
    public class Controller
    {
        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }
        private Controller() {
            userRepository = new UserDbRepository();
        }

        private IRepository<User, int> userRepository;

        public User Login(User u)
        {
            User user = null;
            try
            {

                user = ((UserDbRepository)userRepository).Login(u);
                ((IDbRepository<User, int>)userRepository).Commit();
            }
            catch (Exception)
            {
                ((IDbRepository<User, int>)userRepository).Rollback();
                throw;
            }
            finally
            {
                ((IDbRepository<User, int>)userRepository).Close();
            }
            return user;
        }
    }
}
