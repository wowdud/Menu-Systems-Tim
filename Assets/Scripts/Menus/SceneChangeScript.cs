using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    string playerClass;
    string playerRace;
    public static bool isNewCharacter = false;

    public void Start()
    {
        playerClass = PlayerPrefs.GetString("characterClass");
        playerRace = PlayerPrefs.GetString("characterRace");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void CharacterCreation()
    {
        SceneManager.LoadScene(1);
    }
    public void Game()
    {
        SceneManager.LoadScene(2);
    }
    public void GameFromCC()
    {
        isNewCharacter = true;
        SceneManager.LoadScene(2);
    }
}
