namespace MarvelComicsStore.Domain.Interface.Base
{
    public interface IBaseRepositoryApi<TEntity>
    {
        string ControllerName { get; }
        TEntity Get(int id);
        TEntity GetAll();
    }
}
