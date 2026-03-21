using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Contexts
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products {  get;  }

        public IMongoCollection<ProductBrand> Brands { get; }

        public IMongoCollection<ProductType> Types { get; }

        /*
         هنا عرفنا 3 جداول:

        Products → جدول المنتجات
        Brands → جدول البراندات
        Types → جدول أنواع المنتجات
         */
        public CatalogContext(IConfiguration configuration) {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            /*
             ينشئ اتصال مع 
            MongoDB 
            باستخدام
            ConnectionString
             */
            var database = client.GetDatabase(configuration["DatabaseName:CatalogDb"]);
            /*
             يفتح قاعدة البيانات
            CatalogDb
             */
            Products = database.GetCollection<Product>(configuration[" ProductsCollection: Products"]);
            Brands = database.GetCollection<ProductBrand>(configuration[" ProductsCollection: Brands"]);
            Types = database.GetCollection<ProductType>(configuration[" ProductsCollection: Types"]);
            /*
             يفتح جدول 
            Brands
            ونفس الشيء لـ
            Types و Products.
             */



        }
    }
}
