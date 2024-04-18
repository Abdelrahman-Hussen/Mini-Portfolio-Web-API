﻿using Microsoft.AspNetCore.Diagnostics;
using Portfolio.Common;
using Portfolio.Common.Objects;
using Portfolio.Common.Resources;
using System.Net;

namespace Portfolio.Infrastructure
{
    internal sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
                                              Exception exception,
                                              CancellationToken cancellationToken)
        {
            var (statusCode, errorMessage) = GetExaptationType(exception);

            _logger.Log(LogLevel.Error, exception.ToString());

            httpContext.Response.StatusCode = statusCode;

            var data = httpContext.Request.Method == HttpMethod.Get.ToString() ? httpContext.Request.QueryString.ToString() : httpContext.Request.Body.ToString();

            await httpContext.Response
                .WriteAsJsonAsync(
                    ResponseModel<string>
                    .Error(errorMessage, data),
                    cancellationToken);

            return true;
        }

        private (int statusCode, string errorMessage) GetExaptationType(Exception exception)
            => exception switch
            {
                NotFoundException => ((int)HttpStatusCode.NotFound, exception.Message),
                BadRequestException => ((int)HttpStatusCode.BadRequest, exception.Message),
                _ => ((int)HttpStatusCode.InternalServerError,
                Message.Error_General)
            };
    }
}
