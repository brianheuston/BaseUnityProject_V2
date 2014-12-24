using UnityEngine;
using System.Collections;

public class GameOverlayScript : MonoBehaviour {
    enum MenuState {
        GAME,
        PAUSE,
        OPTIONS,
        QUIT
    }

    private MenuState oCurrentState;

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
	    switch (oCurrentState)
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
        oCurrentState = MenuState.PAUSE;
    }

    public void ResumeGame()
    {
        oCurrentState = MenuState.GAME;
    }

    public void QuitPrompt()
    {
        oCurrentState = MenuState.QUIT;
    }

    public void QuitCancel()
    {
        oCurrentState = MenuState.PAUSE;
    }

    public void QuitGame()
    {
        Time.timeScale = fOldTimeScale;
        Application.LoadLevel("MainMenuScene");
    }
    #endregion
}
