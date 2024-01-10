using DictionaryApp.Services;

namespace DictionaryApp.Startup;

public static class StartupExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder) {
        builder.Services.AddScoped<IEntryService, EntryService>();
        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddScoped<IAuthorService, AuthorService>();
    }
}
