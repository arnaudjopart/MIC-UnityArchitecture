using Controllers;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Views
{
    public class KeyboardAndMouseInput : MonoBehaviour
    {
        [Inject] private IPlayerShipController m_controller;
        [SerializeField] private Camera m_camera;
        private Vector3 m_mousePosition;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                m_controller.ProcessKeyDown(KeyCode.Z);
            }
            if (Input.GetKeyUp(KeyCode.Z))
            {
                m_controller.ProcessKeyUp(KeyCode.Z);
            }

            m_mousePosition = m_camera.ScreenToWorldPoint(Input.mousePosition);
            m_controller.ProcessMousePosition(m_mousePosition);
        }
    }
}