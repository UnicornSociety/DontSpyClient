using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DontSpy.BusinessLogic.Crypto;
using DontSpy.Interfaces;
using DontSpy.Presentation.View;
using DontSpy.Translations;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using Xamarin.Forms;

namespace DontSpy.Model
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

        public KeyMetadata KeyInformation { get; }

        public enum KeyMetadata
        {
            InitiatorKeyNotDisplayed,
            InitiatorKeyDisplayed,
            ConcernedKeyless,
            ConcernedHasKey
        }

        private Dictionary<int, int> _keyTable;

        [Ignore]
        public Dictionary<int, int> KeyTable
        {
            get
            {
                if (_keyTable != null) return _keyTable;
                var key = DependencyService.Get<IStorage>().GetValueFromKey(Id);
                int[] _key = _keyHandler.SplitKeys(key);
                //var key = DependencyService.Get<IStorage>().GetValueFromKey(Id).Split(';').Select(int.Parse).ToArray();
                var keyTable = _keyHandler.KeyTable(_key);
                _keyTable = keyTable;
                return _keyTable;
            }
        }

        public Channel()
        {
        }

        public Channel(string id, List<User> members, KeyMetadata keyMetadata, string name = null)
        {
            Id = id;
            Members = members;
            KeyInformation = keyMetadata;

            var key = _keyHandler.ProduceKeys(8100);
            var empty = "";
            foreach (var number in key)
            {
                var keyA = number / 90 + 1;
                var keyB = number % 90 + 1;
                empty = empty + MathematicalMappingLogic.TransformationTable[keyA] + MathematicalMappingLogic.TransformationTable[keyB];
            }
            Debug.WriteLine(empty);
            /*
            for (var number = 0; number < key.Length - 1; number++)
            {
                empty = empty + key[number] + ";";
            }
            empty = empty + key[key.Length - 1];*/

            DependencyService.Get<IStorage>().SetValueWithKey(Id, empty);

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
