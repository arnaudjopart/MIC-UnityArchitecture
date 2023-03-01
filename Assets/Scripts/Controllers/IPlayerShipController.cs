using UnityEngine;

namespace Controllers
{
    public interface IPlayerShipController
    {
        void ProcessKeyDown(KeyCode space);
        void ProcessMousePosition(Vector3 _mousePosition);
        bool IsMoving { get; }
        void ProcessKeyUp(KeyCode _upArrow);
    }
}