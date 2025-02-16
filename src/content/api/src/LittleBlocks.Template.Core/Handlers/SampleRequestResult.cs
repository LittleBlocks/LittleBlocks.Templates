﻿using System.Collections.Generic;
using LittleBlocks.Template.Core.Shared.Domain;

namespace LittleBlocks.Template.Core.Handlers
{
    public class SampleRequestResult
    {
        public IEnumerable<Sample> Samples { get; private set; } = new Sample[] { };
        public bool HasError { get; private set; }
        public string ErrorMessage { get; private set; } = "";

        public static SampleRequestResult Fail(string message)
        {
            return new() {ErrorMessage = message, HasError = true};
        }

        public static SampleRequestResult Success(IEnumerable<Sample> samples)
        {
            return new() {ErrorMessage = string.Empty, HasError = false, Samples = samples};
        }
    }
}
