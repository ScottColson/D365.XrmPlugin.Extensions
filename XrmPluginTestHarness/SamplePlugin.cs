﻿using System;
using Microsoft.Xrm.Sdk;
using CCLLC.Telemetry;
using CCLLC.Xrm.Sdk;
using CCLLC.Telemetry.Sink;

namespace XrmPluginTestHarness
{
    public class SamplePlugin : InstrumentedPluginBase<Entity>, IPlugin
    {
        public SamplePlugin(string unsecureConfig, string secureConfig) : base(unsecureConfig, secureConfig)
        {
            base.RegisterEventHandler(null, null, ePluginStage.PostOperation, ExecuteHandler);
        }

        public void ExecuteHandler(ILocalContext<Entity> localContext)
        {
            
            TelemetrySink.OnConfigure = () =>
            {
                var sink = TelemetrySink;
                sink.Channel.EndpointAddress = new Uri("https://dc.services.visualstudio.com/v2/track"); //Application Insights
                sink.ProcessChain.TelemetryProcessors.Add(new SequencePropertyProcessor());
                sink.ProcessChain.TelemetryProcessors.Add(new InstrumentationKeyPropertyProcessor("7a6ecb67-6c9c-4640-81d2-80ce76c3ca34"));

                return true; //indicate that the delegate successfully configured the sink.
            };

            localContext.Trace("Simple trace message.");
            //localContext.Trace(SeverityLevel.Error, "Error message");
            //localContext.Trace("Parameterized message at {0}", DateTime.Now);

            var instrumentedContext = localContext as ISupportContextInstrumentation;
            if (instrumentedContext != null)
            {
                instrumentedContext.TelemetryClient.TelemetrySink.Channel.Flush();
            }
        }
    }
}
