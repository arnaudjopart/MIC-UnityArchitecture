using System;
using Entities;
using UnityEngine;

namespace _Project.Scripts.Gateways
{
    public class PlayerPrefsPlayerProfileGateway : IPlayerProfileGateway
    {
        private readonly PlayerProfile m_profile;

        public PlayerPrefsPlayerProfileGateway()
        {
            try
            {
                m_profile = JsonUtility.FromJson<PlayerProfile>(PlayerPrefs.GetString("PlayerProfile"));
                if(m_profile == null) m_profile = new PlayerProfile("Johnny PlayerPrefs");
            }
            catch (Exception _exception)
            {
                m_profile = new PlayerProfile("Johnny PlayerPrefs");
            }
            
            
        }
        public void UpdateScore(int _point)
        {
            m_profile.m_score += _point;
            var data = JsonUtility.ToJson(m_profile);
            PlayerPrefs.SetString("PlayerProfile",data);
        }

        public int GetCurrentScore()
        {
            return m_profile.m_score;
        }
    }
}