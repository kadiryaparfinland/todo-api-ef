using System.ComponentModel.DataAnnotations.Schema;
using ToDo.Domain.Constant;
using ToDo.Domain.IEntity;

namespace ToDo.Domain.Model
{
    public class BaseIdentityModel<TId> : IBaseEntity<TId>
    {
        //public BaseIdentityModel()
        //{
        //    DateCreated = DateTime.Now;
        //}
        public TId Id { get; set; }
        //[Column(TypeName = DbDataType.DateTime)]
        //public DateTime DateCreated { get; set; }
    }
}
