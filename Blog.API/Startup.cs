using Blog.Core.Domain.RepositoryInterfaces;
using Blog.Core.IServices;
using Blog.Core.Services;
using Blog.Infra.Repositories;

namespace Blog.API
{
    public static class Startup
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Add services to the container.
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITagService, TagService>();

            // repositories
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            return services;
        }
    }
}
