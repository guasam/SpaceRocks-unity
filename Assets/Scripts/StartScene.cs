using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Spacerocks
{
    public class StartScene : MonoBehaviour
    {
        public Text yourScoreText;
        private string yourScorePrefix;

        public Text shipsSavedText;
        private string shipsSavedPrefix;

        private void Start()
        {
            var sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == "OverScene" || sceneName == "WinScene")
            {
                yourScorePrefix = yourScoreText.text;
                yourScoreText.text = yourScorePrefix + GameManager.ScoreCount;
            }

            if (sceneName == "WinScene")
            {
                shipsSavedPrefix = shipsSavedText.text;
                shipsSavedText.text = shipsSavedPrefix + GameManager.ShipsCount;
            }
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Loading GameScene");

                if (SceneManager.GetActiveScene().name != "StartScene")
                    GameManager.ResetCounters();

                SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
            }
        }
    }
}