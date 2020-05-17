using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bcv.Entities;
using Bcv.Data;
using System.ServiceModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading;
using System.Security;
using System.Security.Permissions;
using System.Security.Claims;

namespace BCv.Services
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class BcvService : IBcvService, IDisposable
    {
        readonly BcvDbContext _Context = new BcvDbContext();

        [PrincipalPermission(SecurityAction.Demand, Role = "BUILTIN\\Administrators")]
        public List<Product> GetProducts()
        {
            var principal = Thread.CurrentPrincipal;
            if(!principal.IsInRole("BUILTIN\\Administrators"))
            {
                throw new SecurityException("Access denied");
            }

            //ClaimsPrincipal.Current.HasClaim();
            var re =  _Context.Products.ToList();

            
            return re;
        }

        public List<Customer> GetCustomers()
        {
            return _Context.Customers.ToList();
        }

        [OperationBehavior(TransactionScopeRequired = true)] // will rollback if fail
        public void SubmitOrder(Order order)
        {
            _Context.Orders.Add(order);
            order.OrderItems.ForEach(oi => _Context.OrderItems.Add(oi));
            _Context.SaveChanges();
        }

        public void Dispose()
        {
            _Context.Dispose();
        }
    }
}
