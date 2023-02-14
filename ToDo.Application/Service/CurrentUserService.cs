using ToDo.Domain.Constant;
using ToDo.Domain.IEntity;
using ToDo.Domain.DBModel;
using Microsoft.AspNetCore.Http;

namespace ToDo.Application.Service
{
    public class CurrentUserService : ICurrentUser
    {
        private readonly IHttpContextAccessor _accessor;
        public CurrentUserService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public ApplicationUser User => new ApplicationUser()
        {
            Id = Convert.ToInt32(_accessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimConstant.Id)?.Value),
            UserName = _accessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimConstant.UserName)
                ?.Value,
            NormalizedUserName = _accessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimConstant.Name)
                ?.Value,
            Email = _accessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimConstant.Email)?.Value
        };

    }
}

