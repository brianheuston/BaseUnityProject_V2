using UnityEngine;
using System.Collections;

public class MainMenuHandler : MonoBehaviour {
    enum MenuState
    {
        Normal,
        Quit
    }
    private MenuState currentState;
    private MenuState CurrentState
    {
        get
        {
            return currentState;
        }
        set
        {
            currentState = value;

            switch (currentState)
            {
                case MenuState.Normal:
                    NormalState();
                    break;
                case MenuState.Quit:
                    QuitState();
                    break;
            }
        }
    }

    private GameObject mainMenu;
    private GameObject quitMenu;

	// Use this for initialization
	void Start () {
        mainMenu = GameObject.Find("MainMenuCanvas");
        quitMenu = GameObject.Find("QuitCanvas");

        CurrentState = MenuState.Normal;
	}
	
	// Update is called once per frame
	void Update () {
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

    public void NewGame()
    {
        Application.LoadLevel("GameScene");
    }

    #region STATE_FUNCTIONS
    private void NormalState()
    {
        mainMenu.SetActive(true);
        quitMenu.SetActive(false);
    }

    private void QuitState()
    {
        mainMenu.SetActive(false);
        quitMenu.SetActive(true);
    }
    #endregion
}
