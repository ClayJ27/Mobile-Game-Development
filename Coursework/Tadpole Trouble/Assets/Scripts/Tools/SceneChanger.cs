using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string load_game = "TestLevel";
    [SerializeField] private string title_screen = "TitleScreen";
    [SerializeField] private string credits_screen = "CreditsScreen";

    public void StartGame()
    {
        SceneManager.LoadScene(load_game); //Loads the test level
    }


    public void TitleScreen()
    {
        SceneManager.LoadScene(title_screen); //Loads the title screen
    }


    public void CreditsScreen()
    {
        SceneManager.LoadScene(credits_screen); //Loads the credits screen
    }


    //public void QuitGame()
    //{
        //Application.Quit();
    //}

}
//Scripting help from https://www.youtube.com/watch?v=gSfdCke3684