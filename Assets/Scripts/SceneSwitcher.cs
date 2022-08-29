using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private int sceneNumber;
    public static event Action buttonClicked;
    public void SwitchScene(int sceneIndex)
    {
        buttonClicked?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneIndex);
    }

    public void QuitGame()
    { 
        buttonClicked?.Invoke(); 
        Application.Quit();
    }
}
