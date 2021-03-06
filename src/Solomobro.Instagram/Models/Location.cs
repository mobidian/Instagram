﻿using System.Runtime.Serialization;

namespace Solomobro.Instagram.Models
{
    [DataContract]
    public class Location
    {
        internal Location() { }

        [DataMember(Name = "id")]
        public long Id { get; internal set; }

        [DataMember(Name = "name")]
        public string Name { get; internal set; }

        [DataMember(Name = "latitude")]
        public float Latitude { get; internal set; }

        [DataMember(Name = "longitude")]
        public float Longitude { get; internal set; }
    }
}
