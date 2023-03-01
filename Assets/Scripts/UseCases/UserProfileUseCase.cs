using Gateways;
using UnityEngine;
using UnityEngine.Events;

namespace UseCases
{
    public class UserProfileUseCase : IUserProfileUseCase
    {
        private readonly IPlayerProfileGateway m_gateway;

        public UserProfileUseCase(IPlayerProfileGateway _gateway)
        {
            OnScoreUpdateEvent = new UnityEvent<int>();
            m_gateway = _gateway;
        }

        public void UpdateScore(int _point)
        {
            m_gateway.UpdateScore(_point);
            var currentScore = m_gateway.GetCurrentScore();
            OnScoreUpdateEvent.Invoke(currentScore);
        }

        public UnityEvent<int> OnScoreUpdateEvent { get; }
        public void SayHello()
        {
            Debug.Log("Hello");
        }

        public int GetScore()
        {
            return m_gateway.GetCurrentScore();
        }
    }

    public interface IUserProfileUseCase
    {
        void UpdateScore(int _score);
        UnityEvent<int> OnScoreUpdateEvent { get; }
        void SayHello();
        int GetScore();
    }
}