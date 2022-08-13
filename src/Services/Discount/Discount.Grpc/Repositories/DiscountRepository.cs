using Dapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Repositories.Interface;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Threading.Tasks;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            _configuration = configuration;
        }

        public async Task<bool> CreateCoupont(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var affected = await connection.ExecuteAsync("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)", new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });
            return affected > 0;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var affected = await connection.ExecuteAsync("DELETE FROM Discount WHERE ProductName = @ProductName", new { ProductName = productName });
            return affected > 0;
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });
            return coupon == null ? new Coupon { ProductName = productName, Description = $"No discount for {productName}" } : coupon;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var affected = await connection.ExecuteAsync("UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount)", new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });
            return affected > 0;
        }
    }
}