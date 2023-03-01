using UnityEngine.Events;
using UseCases;
using Zenject;

namespace Controllers
{
    public class PlayerScoreController :IScoreController
    {
        private IUserProfileUseCase m_useCase;
        
        public PlayerScoreController(IUserProfileUseCase _playerProfileUserCase)
        {
            m_useCase = _playerProfileUserCase;
            m_useCase.OnScoreUpdateEvent.AddListener(UpdateScore);
            OnScoreUpdateEvent = new UnityEvent<int>();
        }

        private void UpdateScore(int _arg0)
        {
            OnScoreUpdateEvent.Invoke(_arg0);
        }

        public UnityEvent<int> OnScoreUpdateEvent { get; set; }
        public int GetScore()
        {
            return m_useCase.GetScore();
        }
    }
}