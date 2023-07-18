using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCatagory(string category)
        {
            var response = await _client.GetAsync($"/api/v1/Catalogs/GetProductByCategory/{category}");
            return await response.ReadContentAs<List<CatalogModel>>();
        }

        public async Task<CatalogModel> GetCatalogById(string id)
        {
            var response = await _client.GetAsync($"/api/v1/Catalogs/{id}");
            return await response.ReadContentAs<CatalogModel>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogs()
        {
            var response = await _client.GetAsync($"/api/v1/Catalogs");
            return await response.ReadContentAs<List<CatalogModel>>();
        }
    }
}