using UnityEngine;
using System.Collections;

public class GameOverlayScript : MonoBehaviour {
    // This is checked 
    private Resolution cachedResolution;
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

    public void PauseGame()
    {
        fOldTimeScale = Time.timeScale;
        Time.timeScale = 0.0f;

        oPauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        oPauseMenu.SetActive(false);
        Time.timeScale = fOldTimeScale;
    }

    public void QuitPrompt()
    {
        oPauseMenu.SetActive(false);
        oQuitMenu.SetActive(true);
    }

    public void QuitCancel()
    {
        oPauseMenu.SetActive(true);
        oQuitMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = fOldTimeScale;
        Application.LoadLevel("MainMenuScene");
    }
}
