using Microsoft.AspNetCore.Identity;

namespace ToDo.Domain.DBModel
{
    public class ApplicationUser : IdentityUser<int>
    {
        public int Status { get; set; }
        public string Name { get; set; }

        public virtual TODO TODOUser { get; set; }
    }
}
