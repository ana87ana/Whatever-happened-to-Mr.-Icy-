using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    public bool isWrong;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isWrong)
        {
            ReloadLevel();
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("Promjena scene: " + sceneToLoad);
            SaveManager.SaveCurrentScene(sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }

    }
    
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
