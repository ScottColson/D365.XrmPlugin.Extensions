﻿using System;
using System.Net;

namespace CCLLC.Xrm.Sdk
{
    public interface IPluginWebRequest : IDisposable
    {
        ICredentials Credentials { get; set; }
        WebHeaderCollection Headers { get; set; }       
        TimeSpan Timeout { get; set; }
        IPluginWebResponse Get();
        IPluginWebResponse Post(byte[] data, string contentType = null, string contentEncoding = null);
        IPluginWebResponse Put(string body, string contentType = null);
    }
}
