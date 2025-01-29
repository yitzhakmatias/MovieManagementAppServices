using MovieManagementAppServices.Core.Entities;

namespace MovieManagementAppServices.Core.Interfaces
{
    public interface IActorRepository
    {
        Task<List<Actor>> GetAllActors();
        Task<Actor> GetActorById(int id);
        Task AddActor(Actor actor);
    }
}
