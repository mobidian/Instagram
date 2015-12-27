﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

// todo: add users in photo

namespace Solomobro.Instagram.Models
{
    [DataContract]
    public class Post
    {
        internal Post() { }

        [DataMember(Name = "user")]
        public User User { get; internal set; }

        [DataMember(Name = "location")]
        public Location Location { get; internal set; }

        [DataMember(Name = "comments")]
        public ObjectCollection<Comment> Comments { get; internal set; }

        [DataMember(Name = "caption")]
        public Comment Caption { get; internal set; }

        public Uri Link => new Uri(LinkInternal);

        [DataMember(Name = "link")]
        internal string LinkInternal;

        [DataMember(Name = "likes")]
        public ObjectCollection<User> Likes { get; internal set; }

        [DataMember(Name = "type")]
        public string Type { get; internal set; }

        public DateTime CreatedTime => UnixTimeConverter.ConvertFromUnixTime(CreatedTimeInternal);

        [DataMember(Name = "created_time")]
        internal string CreatedTimeInternal;

        [DataMember(Name = "filter")]
        public string Filter { get; internal set; }

        public IReadOnlyList<string> Tags => TagsInternal?.AsReadOnly();
            
        [DataMember(Name = "tags")]
        internal List<string> TagsInternal;

        [DataMember(Name = "images")]
        public MediaResolutions Images { get; internal set; }

        [DataMember(Name = "videos")]
        public MediaResolutions Videos { get; internal set; }
    }
}
