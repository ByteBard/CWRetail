using CWRetail.Model;
using CWRetail.Provider;
using System.Net.Http.Headers;

namespace UnitTest
{
    public class Tests
    {
        private Product _p1;
        private Product _p2;
        private Product _p3;
        private Product _p4;
        private Product _p5;
        private Product _p6;
        private Product _p7;
        private Product _p8;
        private Product _p9;
        private Product _p10;
        private Product _p11;
        private Product _p12;
        private Product _p13;
        private Product _p14;
        private Product _p15;
        private Product _p16;
        private Product _p17;
        private Product _p18;
        private Product _p19;
        private Product _p20;
        private Product _p21;
        private Product _p22;
        private Product _p23;
        private Product _p24;
        private Product _p25;

        [SetUp]
        public void Setup()
        {
            _p1 = new Product { Id = 1, Name = "JHSS", Price = 14.5, Type = "Books", Active = true };
            _p2 = new Product { Id = 2, Name = "SDFGA", Price = 15.5, Type = "Food", Active = true };
            _p3 = new Product { Id = 3, Name = "JHSS", Price = 17.5, Type = "Electronics", Active = true };
            _p4 = new Product { Id = 4, Name = "GAAYR", Price = 121.5, Type = "Toys", Active = true };
            _p5 = new Product { Id = 5, Name = "UJEWT", Price = 12.5, Type = "Electronics", Active = true };
            _p6 = new Product { Id = 6, Name = "JETSRT", Price = 155.5, Type = "Furniture", Active = true };
            _p7 = new Product { Id = 7, Name = "ARWER", Price = 12.5, Type = "Electronics", Active = true };
            _p8 = new Product { Id = 8, Name = "HWRTEGHE", Price = 177.5, Type = "Books", Active = true };
            _p9 = new Product { Id = 9, Name = "QGRETG", Price = 12.5, Type = "Books", Active = true };
            _p10 = new Product { Id = 10, Name = "HERT6", Price = 12.5, Type = "Electronics", Active = true };
            _p11 = new Product { Id = 11, Name = "HGWRT", Price = 14.5, Type = "Food", Active = true };
            _p12 = new Product { Id = 12, Name = "QRYE5", Price = 13.5, Type = "Books", Active = true };
            _p13 = new Product { Id = 13, Name = "OT789O7", Price = 166.5, Type = "Electronics", Active = true };
            _p14 = new Product { Id = 14, Name = "AERGER", Price = 1246.5, Type = "Food", Active = true };
            _p15 = new Product { Id = 15, Name = "JETDRT", Price = 163.5, Type = "Toys", Active = true };
            _p16 = new Product { Id = 16, Name = "HWBERTGH", Price = 1255.5, Type = "Electronics", Active = true };
            _p17 = new Product { Id = 17, Name = "TWTHR", Price = 17.5, Type = "Furniture", Active = true };
            _p18 = new Product { Id = 18, Name = "KJUYR", Price = 14.5, Type = "Electronics", Active = true };
            _p19 = new Product { Id = 19, Name = "ARGR", Price = 123.5, Type = "Books", Active = true };
            _p20 = new Product { Id = 20, Name = "K87U", Price = 122.5, Type = "Toys", Active = true };
            _p21 = new Product { Id = 21, Name = "758RJIK8", Price = 127.5, Type = "Electronics", Active = true };
            _p22 = new Product { Id = 22, Name = "RTYHWE", Price = 132.5, Type = "Books", Active = true };
            _p23 = new Product { Id = 23, Name = "45HYG4WE", Price = 312.5, Type = "Electronics", Active = true };
            _p24 = new Product { Id = 24, Name = "JKR6T7YJH", Price = 152.5, Type = "Furniture", Active = true };
            _p25 = new Product { Id = 25, Name = "WSRTHG", Price = 128.5, Type = "Books", Active = true };

        }

        [Test]
        public void Product_Create()
        {
            var createdProduct = ProductProvider.CreateProduct("aa", 11, "aa", false);
            Assert.That(createdProduct.Name, Is.EqualTo("aa"));
            Assert.That(createdProduct.Price, Is.EqualTo(11));
            Assert.That(createdProduct.Type, Is.EqualTo("aa"));
            Assert.That(createdProduct.Active, Is.EqualTo(false));
        }

        [Test]
        public void Product_Update()
        {
            ProductProvider.GetUpdatedProduct(_p1, "aa", 11, "aa", false);
            Assert.That(_p1.Name, Is.EqualTo("aa"));
            Assert.That(_p1.Price, Is.EqualTo(11));
            Assert.That(_p1.Type, Is.EqualTo("aa"));
            Assert.That(_p1.Active, Is.EqualTo(false));
        }

        [Test]
        public void Product_delete_with_id() 
        {
            var productList = new List<Product>();
            productList.Add(_p1);
            productList.Add(_p2);
            productList.Add(_p3);
            productList.Add(_p4);
            var deleteP = ProductProvider.GetDeleteProduct(productList.ToArray(), 1);
            productList.Remove(deleteP);
            Assert.That(productList.Any(x => x.Id == 1), Is.EqualTo(false));
            Assert.That(deleteP.Id, Is.EqualTo(1));
        }


    }
}