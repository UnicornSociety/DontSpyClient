﻿using System;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using Xamarin.Forms;

namespace ModernEncryption
{
    internal class LocalDatabaseOptions
    {
        public LocalDatabaseOptions(ConnectionMode connMode)
        {
            switch (connMode)
            {
                case ConnectionMode.Create:
                    CreateTables();
                    break;
                case ConnectionMode.DropAndRecreate:
                    DropTables();
                    CreateTables();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(connMode), connMode, null);
            }
        }

        public enum ConnectionMode
        {
            Create, DropAndRecreate
        }

        private static void CreateTables()
        {
            var db = DependencyService.Get<IStorage>().GetConnection();
            db.CreateTable<User>();
            db.CreateTable<Channel>();
            db.CreateTable<ChannelUser>();
            db.CreateTable<Message>();
        }

        private static void DropTables()
        {
            var db = DependencyService.Get<IStorage>().GetConnection();
            db.DropTable<User>();
            db.DropTable<Channel>();
            db.DropTable<ChannelUser>();
            db.DropTable<Message>();
        }
    }
}
