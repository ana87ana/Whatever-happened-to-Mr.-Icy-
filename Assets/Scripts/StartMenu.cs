using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject optionsPanel; 

    public void StartGame()
    {
        SaveManager.ClearSave(); 
        SceneManager.LoadSceneAsync("IntroScene");
    }

    public void LoadGame()
    {
        if (SaveManager.HasSave())
        {
            string savedScene = SaveManager.LoadLastScene();
            SceneManager.LoadScene(savedScene);
        }
        else
        {
            Debug.Log("No save found, loading default scene.");
            SceneManager.LoadScene("IntroScene");
        }
    }

    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void HideOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

