namespace IntegrationTests.EntityFrameworkTests;

using System;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

public sealed class StandardFixture : IDisposable
{
    public StandardFixture()
    {
        const string connectionString =
            "Data Source=.;Initial Catalog=aspnet-clean-architecture-manga;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=true";

        DbContextOptions<MangaContext> options = new DbContextOptionsBuilder<MangaContext>()
            .UseSqlServer(connectionString)
            .Options;

        this.Context = new MangaContext(options);
        this.Context
            .Database
            .EnsureCreated();
    }

    public MangaContext Context { get; }

    public void Dispose() => this.Context.Dispose();
}
