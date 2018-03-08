using System.Collections.Generic;
using DontSpy.Interfaces;
using DontSpy.Utils;
using Newtonsoft.Json;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace DontSpy.Model
{
    [Table("User")]
    public class User : IEntity
    {
        [PrimaryKey, Unique, Column("id"), MaxLength(40), JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [ManyToMany(typeof(ChannelUser), CascadeOperations = CascadeOperation.All), JsonIgnore]
        public List<Channel> Channels { get; set; }

        [Unique, Column("username"), MaxLength(254), JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        public User()
        {
        }

        public User(string username)
        {
            Id = IdentifierCreator.UniqueDigits();
            Username = username;
        }
    }
}
