﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DemoApi.Middlewares {
    public class PerformanceMiddleware
    {
        private readonly ILogger<PerformanceMiddleware> _logger;
        private readonly RequestDelegate _next;

        public PerformanceMiddleware(RequestDelegate next, ILogger<PerformanceMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            const int performanceTimeLog = 500;

            var sw = new Stopwatch();

            sw.Start();

            await _next(context);

            sw.Stop();

            if (performanceTimeLog < sw.ElapsedMilliseconds)
                _logger.LogInformation("Request {method} {path} it took about {elapsed} ms",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    sw.ElapsedMilliseconds);
        }
    }
}

