public interface IPlatformRepo{

    bool SaveChanges();

    IEnumerable<Platform> GetAllPlatforms();

    Platform GetPlatformById(Guid id);

    void CreatePlatform(Platform newPlatform);
}