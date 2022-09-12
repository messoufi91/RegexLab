namespace RegexLab
{
    public class Singleton
    {
        private static Singleton _instance;
        private Singleton()
        {
        }

        // existing object stored in the static field.
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}
