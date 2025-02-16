﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LittleBlocks.Template.Core.Shared.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LittleBlocks.Template.Core.Handlers
{
    public class SampleRequestHandler : IRequestHandler<SampleRequest, SampleRequestResult>
    {
        private readonly ILogger<SampleRequestHandler> _logger;

        public SampleRequestHandler(ILogger<SampleRequestHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<SampleRequestResult> Handle(SampleRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Loading the list of samples");
                var samples = await LoadSamplesAsync();

                return SampleRequestResult.Success(samples);
            }
            catch (Exception e)
            {
                _logger.LogError("Error in loading samples", e);
                return SampleRequestResult.Fail(e.Message);
            }
        }

        private static Task<IEnumerable<Sample>> LoadSamplesAsync()
        {
            return Task.FromResult(new[] {new Sample("Sample #1"), new Sample("Sample #2")}.AsEnumerable());
        }
    }
}
