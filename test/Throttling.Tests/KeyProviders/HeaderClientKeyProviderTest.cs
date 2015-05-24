﻿using System.Collections.Generic;
using Microsoft.AspNet.Http.Internal;
using Xunit;

namespace Throttling.Tests
{
    public class HeaderClientKeyProviderTest
    {
        [Theory]
        [MemberData("Parameters")]
        public void GetKey_ReturnsFirstKey(string[] values)
        {
            // Arrange
            var keyProvider = new HeaderClientKeyProvider("apikey");
            var context = new DefaultHttpContext();
            context.Request.Headers.SetValues("apikey", values);

            // Act
            var result = keyProvider.GetKey(context);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(values[0], result);
        }

        public static IEnumerable<object[]> Parameters
        {
            get
            {
                return ApiKeys.Values;
            }
        }
    }
}
