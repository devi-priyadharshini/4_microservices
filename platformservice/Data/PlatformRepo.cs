public class PlatformRepo : IPlatformRepo
{
    AppDbContext? _appDbContext = null;

    public PlatformRepo(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;     
    }

    public void CreatePlatform(Platform newPlatform)
    {
        if(newPlatform == null)
            throw new ArgumentNullException(nameof(newPlatform));

        _appDbContext?.Platforms?.Add(newPlatform);
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        var platforms = _appDbContext?.Platforms;
        if(platforms == null)
            return new List<Platform>();
        
        return platforms.ToList();
    }

    public Platform GetPlatformById(Guid id)
    {
        var platforms = _appDbContext?.Platforms;
        if(platforms != null)
            {
                var platform = platforms.SingleOrDefault(p => p.Id == id );
                if(platform != null)
                    return platform;
            }
        return new Platform();
    }

    public bool SaveChanges()
    {
       return _appDbContext?.SaveChanges() >= 0; 
    }
}