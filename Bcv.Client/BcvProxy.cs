using Bcv.Client.BcvServices;
using Bcv.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Bcv.Client
{
    public class BcvProxy : ClientBase<IBcvService>, IBcvService
    {
        public BcvProxy()
        {

        }

        public BcvProxy(string endpointName) : base(endpointName)
        {

        }

        public BcvProxy(Binding binding, string address ) : base (binding, new EndpointAddress(address))
        {

        }


        public ObservableCollection<Customer> GetCustomers()
        {
            return Channel.GetCustomers();
        }

        public Task<ObservableCollection<Customer>> GetCustomersAsync()
        {
            return Channel.GetCustomersAsync();
        }

        public ObservableCollection<Product> GetProducts()
        {
            return Channel.GetProducts();
        }

        public Task<ObservableCollection<Product>> GetProductsAsync()
        {
            return Channel.GetProductsAsync();
        }

        public void SubmitOrder(Order order)
        {
            Channel.SubmitOrder(order);
        }

        public Task SubmitOrderAsync(Order order)
        {
           return Channel.SubmitOrderAsync(order);
        }
    }
}
