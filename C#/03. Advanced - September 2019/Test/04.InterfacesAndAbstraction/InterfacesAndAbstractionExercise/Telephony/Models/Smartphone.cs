using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string website)
        {
            foreach (char symbol in website)
            {
                if (char.IsDigit(symbol))
                {
                    throw new ArgumentException("Invalid URL!");
                }
            }

            return $"Browsing: {website}!";
        }

        public string Call(string phoneNumber)
        {
            foreach (char symbol in phoneNumber)
            {
                if (!char.IsDigit(symbol))
                {
                    throw new ArgumentException("Invalid number!");
                }
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
