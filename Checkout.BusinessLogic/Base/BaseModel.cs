using System.ComponentModel.DataAnnotations;

namespace Checkout
{
    public class BaseModel<TPrimaryKey> where TPrimaryKey : struct
    {
        [Required]
        public virtual TPrimaryKey Id { get; set; }

        [StringLength(100)]
        public virtual string Name { get; set; }
    }
}