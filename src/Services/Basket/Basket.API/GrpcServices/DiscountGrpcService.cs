using Basket.API.GrpcServices.Interfaces;
using Discount.Grpc.Protos;
using System;
using System.Threading.Tasks;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService : IDiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            _discountProtoService = discountProtoService ?? throw new ArgumentNullException(nameof(discountProtoService));
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var request = new GetDiscountRequest { ProductName = productName };
            return await _discountProtoService.GetDiscountAsync(request);
        }
    }
}