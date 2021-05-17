using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            // CategoryTest();
            //DTO : Data Transformation Object

        }

        private static void CategoryTest()
        {
            CategoryManager categorymanager = new CategoryManager(new EfCategoryDal());
            foreach (var item in categorymanager.GetAll().Data)
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productmanager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
            var result = productmanager.GetProductDetails();

            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ProductName + " - " + item.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
