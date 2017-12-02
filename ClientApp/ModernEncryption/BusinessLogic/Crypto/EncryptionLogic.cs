﻿using System;
using System.Collections.Generic;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;

namespace ModernEncryption.BusinessLogic.Crypto
{
    internal class EncryptionLogic : IEncrypt
    {
        private readonly char[] _messageTextSymbols;
        private readonly Message _message;
        private readonly Dictionary<int, int> _keyTable;

        public EncryptionLogic(Message message, Dictionary<int, int> keyTable)
        {
            _message = message;
            _messageTextSymbols = message.Text.ToCharArray();
            _keyTable = keyTable;
        }

        public Message Encrypt()
        {
            var concatenatedEncryptedSymbols = string.Empty;

            foreach (var symbol in _messageTextSymbols)
            {
                var chipher = CreateChipher(symbol);
                var permutedChipher = RunPermutationFor(chipher, _keyTable);

                concatenatedEncryptedSymbols += CreateCharacterPair(permutedChipher);
            }

            _message.Text = concatenatedEncryptedSymbols;
            return _message;
        }

        private int CreateChipher(char symbol)
        {
            var rnd = new Random();
            var interval = MathematicalMappingLogic.IntervalTable[symbol];
            return rnd.Next(interval.Start, interval.End + 1);
        }

        private int RunPermutationFor(int chipher, Dictionary<int, int> KeyTable)
        {
            if (KeyTable.ContainsKey(chipher))
                return KeyTable[chipher];
            return chipher;
        }

        private string CreateCharacterPair(int permutedChipher)
        {
            var keyA = (permutedChipher - 1) / 40 + 1;
            var keyB = (permutedChipher - 1) % 40 + 1;
            return "" + MathematicalMappingLogic.TransformationTable[keyA] + MathematicalMappingLogic.TransformationTable[keyB];
        }
    }
}
