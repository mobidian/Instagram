﻿using System;
using System.Threading.Tasks;
using Solomobro.Instagram.Models;

namespace Solomobro.Instagram.Endpoints
{
    public class Users : EndpointBase
    {   
        private const string BaseEndpointUri = "https://api.instagram.com/v1/users";

        internal Users(string accessToken) : base(accessToken)
        {
        }

        /// <summary>
        /// Implements /users/{user-id}
        /// </summary>
        public async Task<ObjectResponse<User>> GetAsync(string userId = Self)
        {
            var uri = new Uri($"{BaseEndpointUri}/{userId}/?access_token={AccessToken}");
            return await GetObjectResponseAsync<User>(uri).ConfigureAwait(false);
        }

        /// <summary>
        /// Implements /users/self/feed
        /// </summary>
        public async Task<CollectionResponse<Post>> GetFeedAsync()
        {
            var uri = new Uri($"{BaseEndpointUri}/self/feed?access_token={AccessToken}");
            return await GetCollectionResponseAsync<Post>(uri).ConfigureAwait(false);
        }

        /// <summary>
        /// Implements /users/{user-id}/media/recent
        /// </summary>
        public async Task<CollectionResponse<Post>> GetMediaRecentAsync(string userId = Self)
        {
            var uri = new Uri($"{BaseEndpointUri}/{userId}/media/recent?access_token={AccessToken}");
            return await GetCollectionResponseAsync<Post>(uri).ConfigureAwait(false);
        }

        /// <summary>
        /// Implements /users/self/media/liked
        /// </summary>
        public async Task<CollectionResponse<Post>> GetMediaLikedAsync()
        {
            var uri = new Uri($"{BaseEndpointUri}/self/media/liked?access_token={AccessToken}");
            return await GetCollectionResponseAsync<Post>(uri).ConfigureAwait(false);
        }

        /// <summary>
        /// Implements /users/search
        /// </summary>
        public async Task<CollectionResponse<User>> SearchAsync(string query)
        {
            var uri = new Uri($"{BaseEndpointUri}/search?access_token={AccessToken}&q={query}");
            return await GetCollectionResponseAsync<User>(uri).ConfigureAwait(false);
        }
    }
}
