using System;
using DontSpy.Interfaces;
using DontSpy.Model;

namespace DontSpy.BusinessLogic.Crypto
{
    internal class SaltingLogic : ISaltingLogic
    {
        private readonly Message _message;

        public SaltingLogic(Message message)
        {
            _message = message;
        }

        public Message Salting()
        {
            var key = CreateSwapKey(_message.Timestamp);
            _message.Text = SwapAfterEncryption(_message.Text, key);
            return _message;
        }

        public Message Desalinating()
        {
            var key = CreateSwapKey(_message.Timestamp);
            _message.Text = SwapBeforeDecryption(_message.Text, key);
            return _message;
        }

        private char[] CreateSwapKey(int timestamp)
        {
            const string filler = "0123456789ABCDEF";
            var hexNumbers = new ulong[5];
            var permutation = "";
            for (var i = 0; i < Constants.Prime.Length; i++)
            {
                hexNumbers[i] = (ulong) (timestamp * Constants.Prime[i] % 1099511627776); //1099511627776=16^10
                permutation = permutation + string.Format("{0:x}", hexNumbers[i]);
            }
            permutation = permutation + filler;
            var allSigns = permutation.ToCharArray();
            var permutationKey = new char[16];

            var permutationKeyLength = 0;
            foreach (var sign in allSigns)
            {
                var check = true;
                for (var value = 0; value <= permutationKeyLength; value++)
                {
                    if (sign == permutationKey[value])
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    permutationKey[permutationKeyLength] = sign;
                    permutationKeyLength++;
                }
                if (permutationKeyLength == 16) break;
            }
            return permutationKey;
        }

        private string SwapAfterEncryption(string encryptedMessage, char[] swapKey)
        {
            var text = encryptedMessage.ToCharArray();
            var saltedText = "";
            for (var times16 = 0; times16 <= text.Length - 18; times16 = times16 + 16)
            {
                var partText = new char[16];
                for (var i = 0; i < 16; i++)
                {
                    partText[i] = text[int.Parse(swapKey[i].ToString(), System.Globalization.NumberStyles.HexNumber)];
                }
                saltedText = saltedText + new string(partText);
            }
            return saltedText;
        }

        private string SwapBeforeDecryption (string message, char[] swapKey)
        {
            var text = message.ToCharArray();
            var desalinatedText = "";
            for (var times16 = 0; times16 <= text.Length - 18; times16 = times16 + 16)
            {
                var partText = new char[16];
                for (var i = 0; i < 16; i++)
                {
                    partText[int.Parse(swapKey[i].ToString(), System.Globalization.NumberStyles.HexNumber)] = text[i];
                }
                desalinatedText = desalinatedText + new string(partText);
            }
            return desalinatedText;
        }
    }
}
