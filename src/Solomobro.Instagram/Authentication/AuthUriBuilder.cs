﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Solomobro.Instagram.Exceptions;

namespace Solomobro.Instagram.Authentication
{
    /// <summary>
    /// an internal-only class used to build auth urls
    /// </summary>
    internal class AuthUriBuilder
    {
        private readonly AuthenticationMethod _authMethod;
        private readonly string _clientId;
        private readonly string _redirectUri;
        private readonly HashSet<string> _scopes;

        private const string ExplicitBaseUri = "https://api.instagram.com";
        private const string ImplicitBaseUri = "https://instagram.com";
        private const string ExplicitResponseType = "code";
        private const string ImplicityResponseType = "token";

        public AuthUriBuilder(string clientId, string redirectUri, AuthenticationMethod method)
        {
            _clientId = clientId;
            _redirectUri = redirectUri;
            _authMethod = method;
            _scopes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        public Uri BuildAuthenticationUri()
        {
            string baseUri;
            string responseType;

            switch (_authMethod)
            {
                case AuthenticationMethod.Implicit:
                    baseUri = ImplicitBaseUri;
                    responseType = ImplicityResponseType;
                    break;
                case AuthenticationMethod.Explicit:
                    baseUri = ExplicitBaseUri;
                    responseType = ExplicitResponseType;
                    break;
                default:
                    throw new OAuthException("bad OAuth method");
            }

            var scope = BuildScope();

            var uri = $"{baseUri}/oauth/authorize/?client_id={_clientId}&redirect_uri={_redirectUri}&response_type={responseType}&scope={scope}";

            return new Uri(uri);
        }

        public Uri BuildAccessCodeUri()
        {
            return new Uri($"{ExplicitBaseUri}/oauth/access_token");
        }

        public void AddScope(string scope)
        {
            if (scope.Equals(OAuthScope.Basic, StringComparison.OrdinalIgnoreCase))
            {
                return; // basic scope. no need to add explicitly
            }
            _scopes.Add(scope);
        }

        private string BuildScope()
        {
            var sb = new StringBuilder(OAuthScope.Basic);

            if (_scopes != null)
            {
                foreach (var scope in _scopes.OrderBy(s => s))
                {
                    sb.Append("+");
                    sb.Append(scope.ToLower());
                }
            }

            return sb.ToString();
        }
    }
}