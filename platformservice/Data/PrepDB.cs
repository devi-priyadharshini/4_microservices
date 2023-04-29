public static class PrepDb {

    public static void PopulateDB(IApplicationBuilder app)
    {
        // In a process, services can be singleton, scoped or transient
        // Singleton service can be accessed via dependency injection
        // If a service is scoped or transient, then it has to resolved by creating a scope...
        
        using(IServiceScope scope = app.ApplicationServices.CreateScope())
         SeedData (scope?.ServiceProvider.GetService<AppDbContext>());
    }

    private static void SeedData(AppDbContext? dbContext)
    {
        if(dbContext == null )
          return;

        if(dbContext.Platforms!.Any()!)
        {
            Console.WriteLine("Db already seeded with data");
            return;
        }
        
        Console.WriteLine("Seeding data");
        dbContext.Platforms!.Add(new Platform(){Id=Guid.NewGuid(), Name ="Docker", Publisher="Docker Whale", Cost ="Free" });
        dbContext.Platforms!.Add(new Platform(){Id=Guid.NewGuid(), Name ="Kubernetes", Publisher="Cloud Foundation", Cost ="Free" });
        dbContext.Platforms!.Add(new Platform(){Id=Guid.NewGuid(), Name ="RabbitMQ", Publisher="CSpace", Cost ="Free" });
        dbContext.Platforms!.Add(new Platform(){Id=Guid.NewGuid(), Name ="Kafka", Publisher="Confluent", Cost ="Free" });
        dbContext.Platforms!.Add(new Platform(){Id=Guid.NewGuid(), Name ="Azure Subscription", Publisher="Microsoft", Cost ="Free" });
        dbContext.SaveChanges();
    }
}