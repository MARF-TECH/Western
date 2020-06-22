using System;

using Xunit;
using FluentAssertions;
using Xunit.Abstractions;

namespace Western.Test
{
    public class WestrenTests
    {

        private readonly ITestOutputHelper output;

        public WestrenTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void App_Should_Build()
        {
            output.WriteLine("Hello Run Tests");

            var __WestrenTells = "Tombstone, Arizona, en octobre 1881";
            __WestrenTells.Should().NotBeNull();
        }
    }
}   
