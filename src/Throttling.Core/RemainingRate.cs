﻿using System;

namespace Throttling
{
    public class RemainingRate
    {
        public DateTimeOffset Reset { get; set; }

        public long Remaining { get; set; }
    }
}