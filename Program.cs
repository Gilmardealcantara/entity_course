using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace entity_course
{
    class Program
    {
        static void Main(string[] args)
        {

            var pascoaPromo = new Promotion();
            pascoaPromo.Description= "Pomocao de Pascoa";
            pascoaPromo.StartDate = DateTime.Now;
            pascoaPromo.EndDate = DateTime.Now.AddMonths(3);
            //pascoaPromo.Poducts.Add(new Product());
            //pascoaPromo.Poducts.Add(new Product());
            //pascoaPromo.Poducts.Add(new Product());
            //pascoaPromo.Poducts.Add(new Product());

            using(var context = new StoreContext()){
                var serviceProvider = context.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

               
            }
        }

        private void TestPurchase(){
            var paoFrances = new Product();
            paoFrances.Name = "Pão Doce";
            paoFrances.UnityPrice = 0.40;
            paoFrances.Unity = "Unidade";
            paoFrances.Category = "Padaria";

            var compra = new Purchase();
            compra.Qnt = 6;
            compra.Product = paoFrances;
            compra.Price = paoFrances.UnityPrice * compra.Qnt;

            using(var context = new StoreContext()){
                var serviceProvider = context.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                context.Purchase.Add(compra);
                context.SaveChanges();
                ExibeEntries(context.ChangeTracker.Entries());
               
            }
        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            foreach(var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }
        
        private void TesteProductDatabase(){
            // GravarUsandoAdoNet();
            WriteUsingEntity();
            GetProducts();
            // DeleteProduct();
            UpdateProduct();
            GetProducts();
        }

        private static void UpdateProduct()
        {
            using (var context = new StoreContext())
            {
                Product product = context.Product.First();
                product.Name = product.Name  + " (Update)";
                context.Product.Update(product);
                context.SaveChanges();
            }
        }

        private static void DeleteProduct()
        {
            using (var context = new StoreContext())
            {
                IList<Product> products = context.Product.ToList();
                foreach (var item in products)
                {
                    context.Product.Remove(item);
                }
                context.SaveChanges();
            }
        }

        private static void GetProducts()
        {
            using (var context = new StoreContext())
            {
                IList<Product> products = context.Product.ToList();
                Console.WriteLine("Find {0} products.", products.Count);
                foreach (var item in products)
                {
                    // string output = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                    Console.WriteLine(item);
                }
            }
        }

        private static void WriteUsingEntity()
        {
            Product p1 = new Product();
            p1.Name = "Harry Potter e a Ordem da Fênix";
            p1.Category = "Livros";
            p1.Unity = "Unity";
            p1.UnityPrice = 19.89;

            Product p2 = new Product();
            p2.Name = "Senhor dos Anéis 1";
            p2.Category = "Livros";
            p2.Unity = "Unity";
            p2.UnityPrice = 19.89;

            Product p3 = new Product();
            p3.Name = "O Monge e o Executivo";
            p3.Category = "Livros";
            p3.Unity = "Unity";
            p3.UnityPrice = 19.89;

            using (var contex = new StoreContext())
            {
                contex.Product.AddRange(p1, p2, p3);
                contex.SaveChanges();
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
