﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCLLC.Telemetry
{
    public interface ISupportSampling
    {
        double? SamplingPercentage { get; set; }
    }
}
