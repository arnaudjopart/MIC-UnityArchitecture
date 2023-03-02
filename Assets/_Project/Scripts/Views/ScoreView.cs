using Controllers;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Views
{
    public class ScoreView : MonoBehaviour
    {
        [Inject] private IScoreController m_scoreController;
        [SerializeField] private TMP_Text m_scoreText;

        private void Start()
        {
            m_scoreController.OnScoreUpdateEvent.AddListener(UpdateScore);
            var currentScore = m_scoreController.GetScore();
            UpdateScore(currentScore);
        }

        private void UpdateScore(int _arg0)
        {
            m_scoreText.SetText("Score: "+_arg0);
        }
    }
}