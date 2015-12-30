﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solomobro.Instagram.Authentication;

namespace Solomobro.Instagram.Interfaces
{
    internal interface IAccessTokenRetriever
    {
        Task<ExplicitAuthResponse> AuthenticateAsync(Uri authEndpoint, IEnumerable<KeyValuePair<string, string>> authParams);
    }
}