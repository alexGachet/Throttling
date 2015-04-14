﻿using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Framework.Internal;

namespace Throttling.IPRanges
{
    public class CidrPattern : IIPAddressPattern
    {
        // CIDR range: "192.168.0.0/24", "fe80::/10"
        private static readonly Regex CidrRangeRegex = new Regex(@"^(?<adr>[\da-f\.:]+)/(?<maskLen>\d+)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public bool TryParse([NotNull] string range, out IIPAddressRangeValidator rangeValidator)
        {
            var cidrMatch = CidrRangeRegex.Match(range);
            if (cidrMatch.Success)
            {
                var baseAdrBytes = IPAddress.Parse(cidrMatch.Groups["adr"].Value).GetAddressBytes();
                var maskLen = int.Parse(cidrMatch.Groups["maskLen"].Value, CultureInfo.InvariantCulture);
                if (baseAdrBytes.Length * 8 < maskLen)
                {
                    rangeValidator = null;
                    return false;
                }

                var maskBytes = BitMaskHelper.GetBitMask(baseAdrBytes.Length, maskLen);
                baseAdrBytes = baseAdrBytes.And(maskBytes).ToArray();
                rangeValidator = new IPAddressRangeValidator(new IPAddress(baseAdrBytes), new IPAddress(baseAdrBytes.Or(maskBytes.Not()).ToArray()));
                return true;
            }

            rangeValidator = null;
            return false;
        }
    }
}