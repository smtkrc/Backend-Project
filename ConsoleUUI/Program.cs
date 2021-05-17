using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productmanager = new ProductManager(new EfProductDal());
            foreach (var item in productmanager.GetAllBycategoryId(2))
            {
                Console.WriteLine(item.ProductName);
            }
            Console.ReadLine();
        }
    }
}
