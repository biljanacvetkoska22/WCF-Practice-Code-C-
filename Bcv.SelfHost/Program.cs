using BCv.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bcv.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var principal = Thread.CurrentPrincipal;
                ServiceHost host = new ServiceHost(typeof(BcvService));
                host.Open();

                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();

                host.Close();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }
    }
}
