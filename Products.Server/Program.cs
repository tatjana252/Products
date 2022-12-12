using Products.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Server
{

    internal class Program
    {
        static void Main(string[] args)
        {
            User u = Controller.Instance.Login(new User
            {
                Username = "p",
                Password = "p"
            });
            User u1 = Controller.Instance.Login(new User
            {
                Username = "p",
                Password = "p"
            });
            u1 = Controller.Instance.Login(new User
            {
                Username = "p",
                Password = "p"
            });
            u1 = Controller.Instance.Login(new User
            {
                Username = "p",
                Password = "p"
            });
        }
    }
}
