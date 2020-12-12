using System;

namespace lab5
{
    public delegate void EventDelegate();

    public class BirthdayBoy
    {
        public event EventDelegate Birthday = null;

        public void InvokeEvent()
        {
            Console.WriteLine("Birthday Start");
            Birthday.Invoke();
            Console.WriteLine("Birthday End");
        }
    }

    public class Friend
    {
        static int friendCount = 0;

        static Friend ()
        {
            friendCount++;
        }

        public void GoToBirthday()
        {
            Console.WriteLine(friendCount);
            Console.WriteLine("Going to birthday");
        }
    }

    class Program
    {
        static Friend friend1 = new Friend();
        static Friend friend2 = new Friend();
        static Friend friend3 = new Friend();

        static void InviteFriends()
        {
            friend1.GoToBirthday();
            friend2.GoToBirthday();
            friend3.GoToBirthday();
        }

        static void Main(string[] args)
        {
            BirthdayBoy iam = new BirthdayBoy();
            
            iam.Birthday += new EventDelegate(InviteFriends);

            iam.InvokeEvent();

            Console.Read();
        }
    }
}