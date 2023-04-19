using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom.web.Models
{
    public class ProductModel:BaseModel
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }

        //public bool IsActive { get; set; }

        //public bool IsDeleted { get; set; }
        //public DateTime? CreatedOn { get; set; }
        //public DateTime? UpdatedOn { get; set; }
    }
}
