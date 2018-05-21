﻿using System;
using System.Collections.Generic;

namespace CCLLC.Telemetry
{
    public interface IComponentTelemetryClient : ITelemetryClient, IDisposable
    {
        string ApplicationName { get; set; }
        string InstrumentationKey { get; set; }
        ITelemetrySink TelemetrySink { get; }   
        ITelemetryContext Context { get; }
        ITelemetryInitializerChain Initializers { get; }
    }
}
