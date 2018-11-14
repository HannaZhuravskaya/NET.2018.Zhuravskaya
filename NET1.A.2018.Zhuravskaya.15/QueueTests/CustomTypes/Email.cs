using System;

namespace QueueTests.CustomTypes
{
    public class Email
    {
        private string _email;

        public Email(string email)
        {
            _email = email ?? throw new ArgumentNullException();
        }
    }
}
