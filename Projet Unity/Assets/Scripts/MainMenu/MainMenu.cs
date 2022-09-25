using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] GameObject currentContainer;
    [SerializeField] GameObject nextMenuContainer;
    [SerializeField] string playerChoosen;
    public void StartGameButton()
    {
        PlayerPrefs.SetString("PlayerChoosen", playerChoosen);
        SceneManager.LoadScene("SampleScene");
    }

    public void ChangeMenu()
    {
        currentContainer.SetActive(false);
        nextMenuContainer.SetActive(true);
    }

    public void OnQuitte()
    {
        Application.Quit();
    }
}
