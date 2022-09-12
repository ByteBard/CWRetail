using System.ComponentModel.DataAnnotations;

namespace CWRetail.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
    }
}
