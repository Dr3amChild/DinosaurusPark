﻿using DinosaurusPark.IntegrationTests.Requests;
using Refit;
using System.Threading.Tasks;

namespace DinosaurusPark.IntegrationTests.Apis
{
    [Headers("Content-Type: application/json")]
    internal interface IGenerationControllerApi
    {
        [Post("/generation/create")]
        Task<ApiResponse<T>> Generate<T>([Body]GenerationRequest request);
    }
}
