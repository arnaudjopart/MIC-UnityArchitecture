﻿using System;
using UnityEngine;
using UseCases;
using Zenject;

namespace Controllers
{
    public class PointSpawnerController : MonoBehaviour
    {
        [Inject] private PointController.Factory m_factory;
        [Inject] private IUserProfileUseCase m_useCase;
        

        public void CreatePoint(Vector3 _position)
        {
            var point = m_factory.Create(m_useCase);
            point.transform.position = _position;

        }

        private void Start()
        {
            CreatePoint(new Vector3(5,0,0));
        }
    }
}