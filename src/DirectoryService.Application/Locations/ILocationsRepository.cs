using DirectoryService.Domain.Locations;

namespace DirectoryService.Application.Locations;

public interface ILocationsRepository
{
    public Task<Guid> AddAsync(Location location);

    public Task<Location> GetByIdAsync(Guid id);

    public Task<Guid> UpdateAsync(Location location);

    public Task<Guid> DeleteAsync(Guid id);

    public Task<List<string>> GetAllNamesAsync();
}