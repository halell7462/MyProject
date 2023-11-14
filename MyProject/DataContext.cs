
using MyProject.Entities;
namespace MyProject
{
    public class DataContext
    {
        public List<City> city { get; set; }
        public List<Customer> customers { get; set; }
        public List<Product> products {get; set; }  

        public DataContext()
        {

            city = new List<City>();
            city.Add(new City {cnt=1, Name="halell"});
            customers = new List<Customer>();
            customers.Add(new Customer { Id = 1, Name = "hadas" });
            products = new List<Product>();
            products.Add(new Product { Name="shira",Id = 1});   
        }
      


    }
}

