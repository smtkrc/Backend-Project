using System;

namespace ProjectView
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productmanager = new ProductManager(new EfProductDal());
            foreach (var item in productmanager.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
