using System.ComponentModel.DataAnnotations.Schema;
using ToDo.Domain.Constant;
using ToDo.Domain.IEntity;

namespace ToDo.Domain.Model
{
    public class BaseModel<TId> : IBaseEntity<TId>, IAuditable
    {
        public BaseModel()
        {
            DateCreated = DateTime.Now;
            LastUpdated = DateTime.Now;
        }
        public TId Id { get; set; }
        [Column(TypeName = DbDataType.DateTime)]
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = DbDataType.DateTime)]
        public DateTime? LastUpdated { get; set; }
        public int? UpdatedBy { get; set; }

    }
}
