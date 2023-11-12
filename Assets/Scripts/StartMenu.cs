using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject about;

    [Header("Main Menu Buttons")]
    public Button oneButton; //Module 1 Button
    public Button twoButton; //Module 2 Button
    public Button aboutButton;
    public Button quitButton;

    public List<Button> returnButtons;

    
    void Start()
    {
        EnableMainMenu();

        //Hook events
        oneButton.onClick.AddListener(StartModuleOne);
        twoButton.onClick.AddListener(StartModuleTwo);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //Scene Transitions to module 1 when respective button is pressed
    public void StartModuleOne()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(1);
    }

    //Scene transitions to module 2 when respective button is pressed
    public void StartModuleTwo()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(2);
    }
    public void HideAll()
    {
        mainMenu.SetActive(false);
        about.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        about.SetActive(false);
    }

    public void EnableAbout()
    {
        mainMenu.SetActive(false);
        about.SetActive(true);
    }
}
