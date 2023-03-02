using System;
using _Project.Scripts.Controllers;
using Controllers;
using UnityEngine;

namespace Views
{
    public class PointView : MonoBehaviour  
    {
        private IPointController m_controller;

        private void Awake()
        {
            m_controller = GetComponent<IPointController>();
            m_controller.OnDestroyEvent.AddListener(Remove);
        }

        private void Remove()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D (Collider2D collision)
        {
            m_controller.ProcessCollision();
        }
    }
}