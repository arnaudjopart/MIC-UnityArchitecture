using Controllers;
using UnityEngine;
using Zenject;

namespace Views
{
    public class PlayerShipView : MonoBehaviour
    {
        [SerializeField] private Camera m_camera;
        [SerializeField] private GameObject m_reactor;
        [Inject] private IPlayerShipController m_controller;

        private Vector3 m_mousePosition;
        

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
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
            m_reactor.SetActive(m_controller.IsMoving);
        }
    }
}
