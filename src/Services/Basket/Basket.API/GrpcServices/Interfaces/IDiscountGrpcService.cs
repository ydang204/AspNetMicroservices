﻿using Discount.Grpc.Protos;
using System.Threading.Tasks;

namespace Basket.API.GrpcServices.Interfaces
{
    public interface IDiscountGrpcService
    {
        Task<CouponModel> GetDiscount(string productName);
    }
}