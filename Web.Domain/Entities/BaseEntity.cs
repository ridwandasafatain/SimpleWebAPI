using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Domain
{
    public abstract class BaseEntity
    {
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedAt { get; set; }
    }
}
