namespace GOD.Membership.Database.Services;

public interface IDbService
{
	Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
		where TEntity : class
		where TDto : class;

	Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;
	Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class, IEntity;
	bool DeleteRef<TEntity, TDto>(TDto dto)
		where TEntity : class
		where TDto : class;
	Task<List<TDto>> GetAsync<TEntity, TDto>()
		where TEntity : class, IEntity
		where TDto : class;
	Task<List<TDto>> GetBoolAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
		where TEntity : class, IEntity
		where TDto : class;
	Task<List<TDto>> GetRefAsync<TEntity, TDto>()
		where TEntity : class, IReferenceEntity
		where TDto : class;
	string GetURI<TEntity>(TEntity entity) where TEntity : class, IEntity;
	void Include<TEntity>() where TEntity : class, IEntity;
	void IncludeRef<TEntity>() where TEntity : class, IReferenceEntity;
	Task<bool> SaveChangesAsync();
	Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
		where TEntity : class, IEntity
		where TDto : class;
	void Update<TEntity, TDto>(int id, TDto dto)
		where TEntity : class, IEntity
		where TDto : class;
}