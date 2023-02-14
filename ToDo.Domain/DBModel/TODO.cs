using ToDo.Domain.Model;

namespace ToDo.Domain.DBModel
{
    public class TODO : BaseModel<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
