﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DontSpy.BusinessLogic.Crypto;
using DontSpy.Interfaces;
using DontSpy.Model;
using DontSpy.Translations;
using DontSpy.Utils;
using SQLiteNetExtensions.Extensions;

namespace DontSpy.Service
{
    internal class ChannelService : IChannelService
    {
        private IRestService RestService { get; }

        public ChannelService()
        {
            RestService = new RestService();
        }

        public Channel CreateChannel(User member, string channelName = null)
        {
            return CreateChannel(new List<User> { member }, channelName);
        }

        public Channel CreateChannel(List<User> members, string channelName = null)
        {
            var channelIdentifier = IdentifierCreator.UniqueDigits();
            var channel = new Channel(channelIdentifier, members, channelName);
            DependencyManager.ChannelsPage.ViewModel.Channels.Add(channel);
            DependencyManager.Database.InsertOrReplaceWithChildren(channel);

            var memberList = members.Aggregate("", (current, member) => current + member.Username + ";");
            memberList = memberList.Remove(memberList.Length - 1); // Remove last semicolon
            foreach (var member in members)
            {
                var preparedMessage = new Message(DependencyManager.Me.Id + ";" + channelIdentifier + ";" + memberList,
                    AppResources.CryptedOnBoardingMessage)
                {
                    ChannelId = member.Id // Manipulated to call pull broadcast by receiver
                };

                new Task(() => { RestService.SendMessage(preparedMessage); }).Start(); // TODO: Handle in future if request is not succeeded
            }

            return channel;
        }

        public List<Channel> LoadChannels()
        {
            return DependencyManager.Database.GetAllWithChildren<Channel>();
        }

        public List<DecryptedMessage> LoadDecryptedMessagesForChannel(Channel channel)
        {
            return channel.Messages.Select(encryptedMessage =>
            //new DecryptionLogic(encryptedMessage, channel.KeyTable)).Select(decryption =>
            new DecryptionLogic(encryptedMessage)).Select(decryption =>
            ((IDecrypt)decryption).Decrypt()).ToList().OrderBy(encryptedMessage =>
            encryptedMessage.Timestamp).ToList();
        }

        public bool SendMessage(string message, Channel channel)
        {
            IEncrypt encryption = new EncryptionLogic(new Message(DependencyManager.Me.Id, message));
            var preparedMessage = encryption.Encrypt();
            IDecrypt decryption = new DecryptionLogic(preparedMessage);
            channel.View.ViewModel.Messages.Add(decryption.Decrypt());
            channel.Messages.Add(preparedMessage);
            DependencyManager.Database.InsertWithChildren(preparedMessage);
            DependencyManager.Database.UpdateWithChildren(channel);

            // TODO: Handle REST return
            new Task(() => { RestService.SendMessage(preparedMessage); }).Start();
            return true;
            //return RestService.SendMessage(preparedMessage).Result;
        }
    }
}
