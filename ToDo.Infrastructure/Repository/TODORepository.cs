
using ToDo.Domain.DBModel;
using ToDo.Domain.IRepository;
using ToDo.Infrastructure.DBContext;

namespace ToDo.Infrastructure.Repository
{
    public class TODORepository : Repository<TODO, int>, ITODORepository
    {
        public TODORepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
