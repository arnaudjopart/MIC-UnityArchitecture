using UnityEngine.Events;

namespace _Project.Scripts.Controllers
{
    public interface IPointController
    {
        void ProcessCollision();
        UnityEvent OnDestroyEvent { get;}
    }
}