﻿using System;
using Microsoft.AspNet.Mvc.ApplicationModels;

namespace Throttling.Mvc
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class IPThrottlingAttribute : LimitRateAttribute
    {
        public IPThrottlingAttribute(long calls, long renewalPeriod)
            : base(calls, renewalPeriod)
        {
        }

        protected override void ApplyCore(ActionModel model, ThrottlingPolicyBuilder builder)
        {
            builder.LimitIPRate(Calls, TimeSpan.FromSeconds(RenewalPeriod), Sliding);
        }
    }
}