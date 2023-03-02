using UnityEngine;
using UnityEngine.Events;
using UseCases;
using Zenject;

namespace _Project.Scripts.Controllers
{
    public class DoublePointController : MonoBehaviour, IPointController
    {
        private IUserProfileUseCase m_useCase;

        [Inject]
        public void Construct(IUserProfileUseCase _useCase)
        {
            OnDestroyEvent = new UnityEvent();
            m_useCase = _useCase;
        }
        

        public void ProcessCollision()
        {
            m_useCase.UpdateScore(2);
            OnDestroyEvent.Invoke();
        }

        public UnityEvent OnDestroyEvent { get; private set; }
        
        public class Factory : PlaceholderFactory<IUserProfileUseCase,DoublePointController>
        {
            public override DoublePointController Create(IUserProfileUseCase _param)
            {
                return base.Create(_param);
            }
        }
    }
}