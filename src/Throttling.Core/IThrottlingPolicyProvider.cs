﻿using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Internal;

namespace Throttling
{
    public interface IThrottlingPolicyProvider
    {
        /// <summary>
        /// Selects a throttling policy to apply for the given request.
        /// </summary>
        /// <param name="context">The <see cref="HttpContext"/> associated with this call.</param>
        /// <param name="policyName">An optional policy name to look for.</param>
        /// <returns>A <see cref="IThrottlingPolicy"/></returns>
        Task<IThrottlingPolicy> GetThrottlingPolicyAsync([NotNull] HttpContext context, string policyName);
    }
}