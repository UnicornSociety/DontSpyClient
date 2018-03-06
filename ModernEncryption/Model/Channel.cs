using System.Collections.Generic;
using System.Linq;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.Interfaces;
using ModernEncryption.Presentation.View;
using ModernEncryption.Translations;
using Plugin.SecureStorage;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    [Table("Channel")]
    public class Channel : IEntity
    {
        private ChannelPage _channelView;

        private readonly IKeyHandler _keyHandler = new KeyHandlerLogic();

        [PrimaryKey, Unique, Column("id"), MaxLength(40)]
        public string Id { get; set; }

        [ManyToMany(typeof(ChannelUser), CascadeOperations = CascadeOperation.All)]
        public List<User> Members { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Message> Messages { get; set; } = new List<Message>();

        public string Name { get; set; }

        [Ignore]
        public ChannelPage View => _channelView ?? (_channelView = new ChannelPage(this));

		private Dictionary<int, int> _keyTable;

        [Ignore]
        public Dictionary<int, int> KeyTable
        {
            get
            {
                if (_keyTable != null) return _keyTable;
                var key = DependencyService.Get<IStorage>().GetValueFromKey(Id);
                int[] _key = key.Split(';').Select(int.Parse).ToArray();
                //int[] _key = key.Split(';').Select(n => Convert.ToInt32(n)).ToArray();
                _keyTable = _keyHandler.KeyTable(_key);
                return _keyTable;
            }
        }

        [Ignore]
        public bool ChannelKeyVisibility { get; set; } = true;

        public Channel()
        {
        }

        public Channel(string id, List<User> members, string name = null, bool generateKey = true)
        {
            if(generateKey) {
                var key = _keyHandler.ProduceKeys(8100);
                var empty = "";
                for (var number = 0; number < key.Length-1; number++)
                {
                    var _key = empty + key[number] + ";";
                    empty = _key;
                }
                empty = empty + key[key.Length-1];
                CrossSecureStorage.Current.SetValue(id, empty);
            } else
            {
                // TODO: Waiting for key (QR Code)
            }
            empty = empty + key[key.Length-1];
            DependencyService.Get<IStorage>().SetValueWithKey(id, empty);
            Id = id;
            Members = members;


            if (name == null)
            {
                if (members.Count > 1)
                    Name = members[0].Username + " " + AppResources.And + " " + (members.Count - 1) + " " + AppResources.MoreMembers;
                else
                    Name = members[0].Username;
            }
            else
                Name = name;
        }
    }
}
