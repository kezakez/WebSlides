namespace ServerUpdate.Models
{
    public class Follower
    {
        private static int _pageNumber = 1;
        private static int _version = 0;

        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = value;
                _version++;
            }
        }

        public int Version
        {
            get
            {
                return _version;
            }
        }
    }
}