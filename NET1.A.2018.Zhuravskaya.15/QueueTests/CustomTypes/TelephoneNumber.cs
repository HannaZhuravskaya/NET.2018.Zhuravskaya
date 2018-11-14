using System;
using System.Collections.Generic;

namespace QueueTests.CustomTypes
{
    public class TelephoneNumber : IEquatable<TelephoneNumber>
    {
        private readonly string _phoneNumber;

        public TelephoneNumber(string phoneNumber)
        {
            _phoneNumber = phoneNumber ?? throw new ArgumentNullException();
        }

        public bool Equals(TelephoneNumber other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }

            return _phoneNumber == other._phoneNumber;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException();
            }

            return obj is TelephoneNumber number &&
                   _phoneNumber == number._phoneNumber;
        }

        public override int GetHashCode()
        {
            return -949999037 + EqualityComparer<string>.Default.GetHashCode(_phoneNumber);
        }
    }
}
