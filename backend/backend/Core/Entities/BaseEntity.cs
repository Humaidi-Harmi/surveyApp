using System.ComponentModel.DataAnnotations;

namespace backend.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]

        public long Id { get; set; }

    }
}