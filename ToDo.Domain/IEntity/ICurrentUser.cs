using ToDo.Domain.DBModel;

namespace ToDo.Domain.IEntity
{
    public interface ICurrentUser
    {
        public ApplicationUser User { get; }
    }
}
