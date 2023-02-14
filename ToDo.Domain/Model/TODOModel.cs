
using ToDo.Domain.Enum;

namespace ToDo.Domain.Model
{
    public class TODOModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ToDoStatus Status { get; set; }
    }
}
