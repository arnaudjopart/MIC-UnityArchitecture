using System;
using _Project.Scripts.Controllers;
using UnityEngine;
using UseCases;
using Zenject;

namespace Controllers
{
    public class PointSpawnerController : MonoBehaviour
    {
        [Inject] private PointController.Factory m_factory;
        [Inject] private DoublePointController.Factory m_doubleFactory;
        [Inject] private IUserProfileUseCase m_useCase;
        

        public void CreatePoint(Vector3 _position)
        {
            var point = m_factory.Create(m_useCase);
            point.transform.position = _position;

        }
        
        public void CreateDoublePoint(Vector3 _position)
        {
            var point = m_doubleFactory.Create(m_useCase);
            point.transform.position = _position;

        }

        private void Start()
        {
            CreatePoint(new Vector3(5,0,0));
            CreateDoublePoint(new Vector3(-5,0,0));
        }
    }
}