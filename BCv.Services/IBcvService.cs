using Bcv.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BCv.Services
{
    [ServiceContract]
    public interface IBcvService 
    {
        [OperationContract]
        List<Product> GetProducts();
        [OperationContract]
        List<Customer> GetCustomers();
        [OperationContract]
        void SubmitOrder(Order order); 
    }
}
