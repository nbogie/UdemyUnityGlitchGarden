using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{    

    void Start()
    {
        //move past splash screen after a pause
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Invoke("LoadStartMenu", 3.5f);
        }
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(3);
    }


    public void LoadWinScene()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene(7);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadStartMenu();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
