using System;

namespace QueueTests.CustomTypes
{
    public class Profile
    {
        private readonly string _profileId;

        public Profile(string profileId)
        {
            _profileId = profileId ?? throw new ArgumentNullException();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException();
            }

            return obj is Profile profile &&
                   _profileId == profile._profileId;
        }

        public override int GetHashCode()
        {
            return _profileId != null ? _profileId.GetHashCode() : 0;
        }

        public bool Equals(Profile profile)
        {
            return this._profileId == profile._profileId;
        }
    }
}
