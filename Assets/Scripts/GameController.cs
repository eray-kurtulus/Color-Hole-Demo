using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace DefaultNamespace
{
    public class GameController : Singleton<GameController>
    {
        [SerializeField] private Transform mainCameraTransform;
        [SerializeField] private Vector3 failPunch;
        [SerializeField] private float failPunchDuration;
        [SerializeField] private int failPunchVibratio;
        [SerializeField] private float failPunchElasticty;

        [SerializeField] private ConfettiController _confettiController;

        [SerializeField] private Transform[] grayObjects;

        private bool gameEnded;
        
        private void Awake()
        {
            gameEnded = false;
        }

        private void Update()
        {
            if (!gameEnded)
            {
                int activeGrayObjectCount = 0;
                foreach (var grayObject in grayObjects)
                {
                    if (grayObject.gameObject.activeSelf)
                    {
                        activeGrayObjectCount++;
                    }
                }

                if (activeGrayObjectCount == 0)
                {
                    LevelCompleted();
                }
            }
        }

        public void GameFailed()
        {
            gameEnded = true;
            _confettiController.ShowLoseConfetti();
            StartCoroutine(FailScreenAnimation());
            StartCoroutine(ReloadSceneWithDelay());
        }

        public void LevelCompleted()
        {
            if (!gameEnded)
            {
                gameEnded = true;
                _confettiController.ShowConfetti();
                StartCoroutine(ReloadSceneWithDelay());
            }
        }

        private IEnumerator FailScreenAnimation()
        {
            yield return mainCameraTransform
                .DOPunchPosition(failPunch, failPunchDuration, failPunchVibratio, failPunchElasticty)
                .WaitForCompletion();
        }
        
        private IEnumerator ReloadSceneWithDelay()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}