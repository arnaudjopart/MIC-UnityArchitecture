using UnityEngine.Events;

namespace Controllers
{
    public interface IScoreController
    {
        UnityEvent<int> OnScoreUpdateEvent { get; set; }
        int GetScore();
    }
}