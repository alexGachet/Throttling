﻿using System;
using System.Collections.Generic;

namespace Throttling
{
    public class ThrottlingResult
    {
        public string Category { get; set; }

        public bool LimitReached { get; set; }

        public DateTimeOffset? Reset { get; set; }

        public IDictionary<string, string> RateLimitHeaders { get; } = new Dictionary<string, string>();

    }
}