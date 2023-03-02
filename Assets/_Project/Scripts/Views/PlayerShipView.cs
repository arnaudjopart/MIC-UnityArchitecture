using Controllers;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Views
{
    public class PlayerShipView : MonoBehaviour
    {
        [SerializeField] private GameObject m_reactor;
        [Inject] private IPlayerShipController m_controller;

        private void Update()
        {
            m_reactor.SetActive(m_controller.IsMoving);
        }
    }
}
