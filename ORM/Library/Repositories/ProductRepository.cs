using System.Collections.Generic;
using System.Linq;
using Library.Models;

namespace Library.Repositories
{
    public class ProductRepository
    {
        private readonly OrderProductContext _context;

        public ProductRepository()
        {
            _context = new OrderProductContext();  
        }

        public void Create(Product product)
        {
            _context.Products.Add(product); 
            _context.SaveChanges();
        }

        public Product Read(int id)
        {
            return _context.Products.Find(id);  
        }

        public void Update(Product product)
        {
            var toUpdate = _context.Products.Find(product.Id);
            if (toUpdate != null)
            {
                _context.Entry(toUpdate).CurrentValues.SetValues(product);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var toDelete = _context.Products.Find(id);
            if (toDelete != null)
            {
                _context.Products.Remove(toDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Product> Read()
        {
            return _context.Products.ToList();
        }

        public void Delete()
        {
            _context.Products.RemoveRange(_context.Products);
        }
    }
}
