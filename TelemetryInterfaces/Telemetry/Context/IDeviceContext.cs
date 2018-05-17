﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCLCC.Telemetry.Interfaces 
{
    public interface IDeviceContext 
    {

        void UpdateTags(IDictionary<string, string> tags);

        void CopyTo(IDeviceContext target);
    }
}