using Entities;

namespace Gateways
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
            m_profile.Score += _point;
        }

        public int GetCurrentScore()
        {
            return m_profile.Score;
        }
    }

    public interface IPlayerProfileGateway
    {
        void UpdateScore(int _point);
        int GetCurrentScore();
    }
}