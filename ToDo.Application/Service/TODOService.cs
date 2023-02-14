using AutoMapper;
using ToDo.Application.IService;
using ToDo.Domain.DBModel;
using ToDo.Domain.IEntity;
using ToDo.Domain.IRepository;
using ToDo.Domain.Model;
using ToDo.Domain.ViewModel;

namespace ToDo.Application.Service
{
    public class TODOService : ITODOService
    {
        private readonly IRepository<TODO, int> _toDoRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;
        public TODOService(IRepository<TODO, int> toDoRepository, IMapper mapper, ICurrentUser currentUser)
        {
            _toDoRepository = toDoRepository;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task Add(TODOModel toDoModel)
        {
            var toDo = _mapper.Map<TODO>(toDoModel);
            toDo.UserId = _currentUser.User.Id;
            await _toDoRepository.Insert(toDo);
            await _toDoRepository.SaveAsync();
        }

        public async Task<List<TODOViewModel>> GetAll(int? toDoStatus)
        {
            var toDos = new List<TODO>();
            if(toDoStatus != null)
            {
                toDos = (List<TODO>)await _toDoRepository.GetAll(x => x.Status == toDoStatus,y => y.User);
            }
            else
            {
                toDos = (List<TODO>)await _toDoRepository.GetAll(y => y.User);
            }
            
            var data = _mapper.Map<List<TODOViewModel>>(toDos);
            return data;
        }

        public async Task<TODOViewModel> GetById(int id)
        {
            var toDo = await _toDoRepository.FindBy(x=> x.Id == id);
            var data = _mapper.Map<TODOViewModel>(toDo);
            return data;
        }

        public async Task Update(TODOModel toDoModel)
        {
            var toDo = await _toDoRepository.GetById(toDoModel.Id);
            if (toDo != null)
            {
                toDo.Name = toDoModel.Name;
                toDo.Description = toDoModel.Description;
                toDo.Status = (int)toDoModel.Status;

                await _toDoRepository.Update(toDo);
                await _toDoRepository.SaveAsync();
            }
        }

        public async Task Delete(int id)
        {
            await _toDoRepository.Delete(id);
            await _toDoRepository.SaveAsync();
        }

        

        

        
    }
}
