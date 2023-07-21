using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject2.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] float delayLevelTime = 1f;

        public static GameManager Instance { get; private set; }

        public event System.Action<bool> OnSceneChanged;

        private void Awake()
        {
            SingletonThisGameObject();
        }

        private void SingletonThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void LoadScene(int levelIndex = 0)
        {
            StartCoroutine(LoadSceneAsync(levelIndex));
        }

        private IEnumerator LoadSceneAsync(int levelIndex)
        {
            yield return new WaitForSeconds(delayLevelTime);

            int buildIndex = SceneManager.GetActiveScene().buildIndex;

            yield return SceneManager.UnloadSceneAsync(buildIndex);

            SceneManager.LoadSceneAsync(buildIndex + levelIndex, LoadSceneMode.Additive).completed += (AsyncOperation obj) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));
            };

            OnSceneChanged?.Invoke(false);
        }

        private void GameManager_completed(AsyncOperation obj)
        {
            
        }

        public void ExitGame()
        {
            Debug.Log("Exit Game Method Triggered");
            Application.Quit();
        }

        public void LoadMenuAndUi(float delayLoadingTime)
        {
            StartCoroutine(LoadMenuAndUiAsync(delayLevelTime));
        }

        private IEnumerator LoadMenuAndUiAsync(float delayLoadingTime)
        {
            yield return new WaitForSeconds(delayLoadingTime);
            yield return SceneManager.LoadSceneAsync("Menu");
            yield return SceneManager.LoadSceneAsync("Ui", LoadSceneMode.Additive);

            OnSceneChanged?.Invoke(true);
        }
    }
}

