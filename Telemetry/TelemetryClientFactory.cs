﻿using System.Collections.Generic;
using CCLLC.Telemetry.Client;

namespace CCLLC.Telemetry
{
    public class TelemetryClientFactory : ITelemetryClientFactory
    {
        ITelemetryContext telemetryContext;
        ITelemetryInitializerChain telemetryInitializers;

        public TelemetryClientFactory(ITelemetryContext context, ITelemetryInitializerChain telemetryInitializers)
        {
            this.telemetryContext = context;
            this.telemetryInitializers = telemetryInitializers;
        }

        public IComponentTelemetryClient BuildClient(string applicationName, ITelemetrySink telemetrySink, IDictionary<string, string> contextProperties = null)
        {
            return new ComponentTelemetryClient(applicationName, telemetrySink, telemetryContext, telemetryInitializers, contextProperties);
        }
    }
}
