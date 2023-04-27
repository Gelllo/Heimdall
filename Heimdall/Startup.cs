using Heimdall.Endpoints;
using System.Linq;

namespace Heimdall
{
    public static class Startup
    {

        public interface IQueryHandler<in TQuery, TResult>
        {
            Task<TResult> Handle(TQuery query, CancellationToken cancellation);
        }

        public interface ICommandHandler<in TCommand>
        {
            Task Handle(TCommand command, CancellationToken cancellation);
        }


        public delegate Task<TResult> QueryHandler<in TQuery, TResult>(TQuery query, CancellationToken ct);

        public delegate Task CommandHandler<in TCommand>(TCommand command, CancellationToken ct);

        public static IServiceCollection AddQueryHandler<T, TResult, TQueryHandler>(this IServiceCollection services) where TQueryHandler : class, IQueryHandler<T, TResult>
        {
            services.AddScoped<IQueryHandler<T, TResult>, TQueryHandler>()
                .AddScoped<QueryHandler<T, TResult>>(sp => sp.GetRequiredService<IQueryHandler<T,TResult>>().Handle);

            return services;
        }

        public static IServiceCollection AddCommandHandler<TCommand, TCommandHandler>(this IServiceCollection services) where TCommandHandler : class, ICommandHandler<TCommand>
        {
            services.AddScoped<ICommandHandler<TCommand>, TCommandHandler>()
                .AddScoped<CommandHandler<TCommand>>(sp => sp.GetRequiredService<ICommandHandler<TCommand>>().Handle);

            return services;
        }

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddQueryHandler<GetProducts, IReadOnlyList<ProductListItem>, HandleGetProducts>();

            return services;
        }

        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            //services.AddCommandHandler<AddPostCommand, AddPostCommandHandler>();
            return services;
        }

        internal class Product
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }

            private Product() { }

            public Product(Guid id, string name, string? description)
            {
                Id = id;
                Name = name;
                Description = description;
            }
        }

        internal class HandleGetProducts : IQueryHandler<GetProducts, IReadOnlyList<ProductListItem>>
        {
            private readonly IQueryable<Product> products;

            public HandleGetProducts(IQueryable<Product> products)
            {
                this.products = products;
            }

            public async Task<IReadOnlyList<ProductListItem>> Handle(GetProducts query, CancellationToken ct)
            {
                //var (filter, page, pageSize) = query;

                //var filteredProducts = string.IsNullOrEmpty(filter)
                //    ? products
                //    : products
                //        .Where(p =>
                //            p.Name.Contains(query.Filter!) ||
                //            p.Description!.Contains(query.Filter!)
                //        );

                //return filteredProducts
                //    .Skip(pageSize * (page - 1))
                //    .Take(pageSize)
                //    .Select(p => new ProductListItem(p.Id, p.Name)).ToList();

                return new List<ProductListItem>();
            }
        }


        public record GetProducts(
            string? Filter,
            int Page,
            int PageSize
        )
        {
            private const int DefaultPage = 1;
            private const int DefaultPageSize = 10;

            public static GetProducts With(string? filter, int? page, int? pageSize)
            {
                page ??= DefaultPage;
                pageSize ??= DefaultPageSize;

                if (page <= 0)
                    throw new ArgumentOutOfRangeException(nameof(page));

                if (pageSize <= 0)
                    throw new ArgumentOutOfRangeException(nameof(pageSize));

                return new(filter, page.Value, pageSize.Value);
            }
        }

        public record ProductListItem(
            Guid Id,
            string Name
        );

    }
}
