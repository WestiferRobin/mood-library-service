namespace MoodLibraryApi.Db
{
    public static class DbInitializer
    {
        public static void Initialize(PostgresContext context)
        {
            context.Database.EnsureCreated(); // Ensure the database is created

            // Check if the table is empty
            if (!context.Artists.Any())
            {
                DbTestData.InitTestData(context);
            }
        }
    }
}

