namespace ToDoApp.Services
{
    public class UsernameStore
    {
        public static string _username;

        private UsernameStore _instance;
        public UsernameStore Instance()
        {
            if (_instance == null)
            {
                _instance = new UsernameStore();
            }
            return _instance;
        }

        public static void AddUsername(string username)
        {
            _username = username;
        }

        public static string ReturnUsername()
        {
            return _username;
        }

        public static void DeleteUsername()
        {
            _username = null;
        }
    }
}
