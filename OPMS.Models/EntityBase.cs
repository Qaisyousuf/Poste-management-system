using System.ComponentModel.DataAnnotations;

namespace OPMS.Models
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }

    }
}
