using Entities;

namespace _Project.Scripts.Gateways
{
    public class PlayerProfileGateway : IPlayerProfileGateway
    {
        private readonly PlayerProfile m_profile;

        public PlayerProfileGateway(PlayerProfile _profile)
        {
            m_profile = _profile;
        }
        public void UpdateScore(int _point)
        {
            m_profile.m_score += _point;
        }

        public int GetCurrentScore()
        {
            return m_profile.m_score;
        }
    }
}