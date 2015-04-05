﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.Framework.OptionsModel;

namespace Throttling
{
    public class DefaultThrottlingPolicyProvider : IThrottlingPolicyProvider
    {
        private readonly ThrottlingOptions _options;

        /// <summary>
        /// Creates a new instance of <see cref="DefaultThrottlingPolicyProvider"/>.
        /// </summary>
        /// <param name="options">The options configured for the application.</param>
        public DefaultThrottlingPolicyProvider(IOptions<ThrottlingOptions> options)
        {
            _options = options.Options;
        }

        /// <inheritdoc />
        public virtual Task<IThrottlingPolicy> GetThrottlingPolicyAsync(HttpContext context, string policyName)
        {
            var policy = _options.Routes.Route(context.Request);
            
            return Task.FromResult(policy);
        }
    }
}