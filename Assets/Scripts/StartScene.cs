using UnityEngine;
using UnityEngine.SceneManagement;

namespace Spacerocks
{
    public class StartScene : MonoBehaviour
    {
        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Loading GameScene");
                SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
            }
        }
    }
}