﻿using System.Collections.Generic;
using ModernEncryption.Interfaces;
using ModernEncryption.Utils;
using Newtonsoft.Json;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    [Table("User")]
    public class User : IEntity
    {
        [PrimaryKey, Unique, Column("id"), MaxLength(40), JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [ManyToMany(typeof(ChannelUser), CascadeOperations = CascadeOperation.All), JsonIgnore]
        public List<Channel> Channels { get; set; }

        [Column("displayname"), MaxLength(30), JsonProperty(PropertyName = "displayname")]
        public string Displayname { get; set; }

        [Unique, Column("email"), MaxLength(254), JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        /*[Unique, Column("username"), MaxLength(254), JsonProperty(PropertyName = "username")]
        public string Username { get; set; }*/

        public User()
        {
        }

        public User(string displayname, string username)
        {
            Id = IdentifierCreator.UniqueDigits();
            Displayname = displayname;
            Email = username;//Username = username
        }
    }
}
