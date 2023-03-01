using UnityEngine;
using UnityEngine.Events;
using UseCases;
using Zenject;

namespace Controllers
{
    public interface IPointController
    {
        void ProcessCollision();
        UnityEvent OnDestroyEvent { get;}
    }

    public class PointController : MonoBehaviour, IPointController
    {
        private IUserProfileUseCase m_useCase;

        [Inject]
        public void Construct(IUserProfileUseCase _useCase)
        {
            OnDestroyEvent = new UnityEvent();
            m_useCase = _useCase;
            m_useCase.SayHello();
        }
        public class Factory : PlaceholderFactory<IUserProfileUseCase,PointController>
        {
            public override PointController Create(IUserProfileUseCase _param)
            {
                return base.Create(_param);
            }
        }

        public void ProcessCollision()
        {
            m_useCase.UpdateScore(1);
            OnDestroyEvent.Invoke();
        }

        public UnityEvent OnDestroyEvent { get; private set; }
    }
}