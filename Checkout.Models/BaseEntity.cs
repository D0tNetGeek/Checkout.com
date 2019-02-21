using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Checkout.Models.Audit;

namespace Checkout.Models
{
    public class BaseEntity<TPrimaryKey> : AuditCreatorModifier where TPrimaryKey : struct
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TPrimaryKey Id { get; set; }
    }
}