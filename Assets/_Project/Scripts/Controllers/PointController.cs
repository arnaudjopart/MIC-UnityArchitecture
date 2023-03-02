using _Project.Scripts.Controllers;
using UnityEngine;
using UnityEngine.Events;
using UseCases;
using Zenject;

namespace Controllers
{
    public class PointController : MonoBehaviour, IPointController
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
            m_useCase.UpdateScore(1);
            OnDestroyEvent.Invoke();
        }

        public UnityEvent OnDestroyEvent { get; private set; }
        
        public class Factory : PlaceholderFactory<IUserProfileUseCase,PointController>
        {
            public override PointController Create(IUserProfileUseCase _param)
            {
                return base.Create(_param);
            }
        }
    }
}