using UnityEngine;
using System.Collections;

public class GameOverlayScript : MonoBehaviour {
    enum MenuState {
        GAME,
        PAUSE,
        OPTIONS,
        QUIT
    }

    private MenuState currentState;
    private MenuState CurrentState {
        get
        {
            return currentState;
        }
        set {
            currentState = value;

            switch (currentState)
            {
                case MenuState.GAME:
                    GameState();
                    break;
                case MenuState.PAUSE:
                    PauseState();
                    break;
                case MenuState.OPTIONS:
                    OptionsState();
                    break;
                case MenuState.QUIT:
                    QuitState();
                    break;
            }
        }
    }

    private float fOldTimeScale;

    private string szPauseMenuName = "PauseCanvas";
    private string szQuitMenuName = "QuitCanvas";
    
    private GameObject oPauseMenu;
    private GameObject oQuitMenu;

	// Use this for initialization
	void Start () {
        oPauseMenu = GameObject.Find(szPauseMenuName);
        oQuitMenu = GameObject.Find(szQuitMenuName);

        oPauseMenu.SetActive(false);
        oQuitMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate()
    {
    }

    #region GameStateFunctions
    private void GameState()
    {
        oPauseMenu.SetActive(false);
        oQuitMenu.SetActive(false);
        Time.timeScale = fOldTimeScale;
    }

    private void QuitState()
    {
        oPauseMenu.SetActive(false);
        oQuitMenu.SetActive(true);
    }

    private void PauseState()
    {
        fOldTimeScale = Time.timeScale;
        Time.timeScale = 0.0f;

        oPauseMenu.SetActive(true);
        oQuitMenu.SetActive(false);
    }

    private void OptionsState()
    {

    }
    #endregion

    #region MenuFunctions
    public void PauseGame()
    {
        CurrentState = MenuState.PAUSE;
    }

    public void ResumeGame()
    {
        CurrentState = MenuState.GAME;
    }

    public void QuitPrompt()
    {
        CurrentState = MenuState.QUIT;
    }

    public void QuitCancel()
    {
        CurrentState = MenuState.PAUSE;
    }

    public void QuitGame()
    {
        Time.timeScale = fOldTimeScale;
        Application.LoadLevel("MainMenuScene");
    }
    #endregion
}
