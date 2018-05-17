﻿using System;
using System.Collections.Generic;

namespace CCLCC.Telemetry
{ 
    public interface IDataModelTelemetry
    {
        void SerializeData(ITelemetrySerializer serializer, IJsonWriter writer);
        string BaseType { get; }             
        
    }

    public interface IDataModelTelemetry<TData> : IDataModelTelemetry where TData : IDataModel
    {        
        TData Data { get; }
        
        IDataModelTelemetry<TData> DeepClone();
        
    }
}