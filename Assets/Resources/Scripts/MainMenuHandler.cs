using UnityEngine;
using System.Collections;

public class MainMenuHandler : MonoBehaviour {
    enum MenuState
    {
        Normal,
        Quit
    }
    private MenuState CurrentState;

    private GameObject mainMenu;
    private GameObject quitMenu;

	// Use this for initialization
	void Start () {
        CurrentState = MenuState.Normal;
        mainMenu = GameObject.Find("MainMenu");
        quitMenu = GameObject.Find("QuitGameMenu");
	}
	
	// Update is called once per frame
	void Update () {
        switch (CurrentState)
        {
            case MenuState.Normal:
                mainMenu.SetActive(true);
                quitMenu.SetActive(false);
                break;
            case MenuState.Quit:
                mainMenu.SetActive(false);
                quitMenu.SetActive(true);
                break;
        }
	}

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CancelQuitGame()
    {
        CurrentState = MenuState.Normal;
    }

    public void CreateQuitGamePopup()
    {
        CurrentState = MenuState.Quit;
    }
}
