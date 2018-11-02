using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BestBuyInClassProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductRepository prod = new ProductRepository();
            List<Product> listprod = prod.GetProducts();
            foreach(Product product in listprod)
            {
                Console.WriteLine(product.Productid + " " + product.Name + " " + product.Price + " " + product.Categoryid);
            }

            
           
         

            Console.ReadLine();
        }
    }
    
}
