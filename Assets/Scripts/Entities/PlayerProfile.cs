namespace Entities
{
    public class PlayerProfile
    {
        private readonly string m_name;
        public int Score { get; set; }

        public PlayerProfile(string _name)
        {
            m_name = _name;
        }
    }
}
