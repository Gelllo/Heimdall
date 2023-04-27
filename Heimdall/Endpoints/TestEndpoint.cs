using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Heimdall.Endpoints
{
    public class MyRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class MyResponse
    {
        public string FullName { get; set; }
        public string Message { get; set; }
    }

    public class TestEndpoint: Endpoint<MyRequest, MyResponse>
    {
        private Startup.QueryHandler<Startup.GetProducts, IReadOnlyList<Startup.ProductListItem>> getProducts;
        public override void Configure()
        {
            Post("/hello/world");
            AllowAnonymous();
        }

        public override async Task HandleAsync(MyRequest r, CancellationToken c)
        {
            var random = getProducts(Startup.GetProducts.With(null, 1, 1), c);

            await SendAsync(new()
            {
                FullName = $"{r.FirstName} {r.LastName}",
                Message = "Welcome to FastEndpoints..."
            });
        }
    }
}
