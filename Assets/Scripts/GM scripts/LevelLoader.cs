using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] GameObject howToPlay;


    public void StartGamefunction()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        Application.Quit();
    }


    public void ContinueGame()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            int savedLevelIndex = PlayerPrefs.GetInt("SavedLevel");
            SceneManager.LoadScene(savedLevelIndex);
        }
        else
        {
            Color buttonColor = GetComponent<Button>().colors.normalColor;
            buttonColor = Color.grey;
            return;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void HowToPlayMenu()
    {
        howToPlay.SetActive(true);
    }

    public void BackToMenu()
    {
        howToPlay.SetActive(false);
    }    

}
