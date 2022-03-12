﻿using System.Collections.Generic;
using System.Text.Json;
using Library.Models;
using Library.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ProductRepositoryTests
    {
        private readonly ProductRepository _productRepository;
        private const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADO.NET_DB;Integrated Security=True";

        public ProductRepositoryTests()
        {
            _productRepository = new ProductRepository(ConnectionString);
            _productRepository.Delete();
        }

        [TestMethod]
        public void Create_Product()
        {
            var product = InsertInitialProduct();
            var result = _productRepository.Read(product.Id);

            Assert.AreEqual(ToJson(product), ToJson(result));
        }

        [TestMethod]
        public void Read_Products()
        {
            var product = InsertInitialProduct();
            var products = new List<Product>();
            products.Add(product);

            var result = _productRepository.Read();

            Assert.AreEqual(ToJson(products), ToJson(result));
        }

        [TestMethod]
        public void Update_Product()
        {
            var product = InsertInitialProduct();

            product.Name = "update";
            _productRepository.Update(product);
            var result = _productRepository.Read(product.Id);

            Assert.AreEqual(ToJson(product), ToJson(result));
        }

        [TestMethod]
        public void Delete_Product()
        {
            var product = InsertInitialProduct();

            _productRepository.Delete(product.Id);
            var result = _productRepository.Read(product.Id);

            Assert.IsNull(result);
        }

        private Product InsertInitialProduct()
        {
            var product = new Product
            {
                Name = "product",
                Description = "description",
                Weight = 1,
                Height = 1,
                Width = 1,
                Length = 1
            };

            _productRepository.Create(product);

            return product;
        }

        private string ToJson(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
