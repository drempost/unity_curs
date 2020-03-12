using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LooseTxt;

    [Header("Other")]

    public ScoreScript scoreScript;

    public PuckScript puckScript;
    public PlayerMovement playerMovement;
    public AiScript aiScript;

    public void Start()
    {
      CanvasGame.SetActive(true);
      CanvasRestart.SetActive(false);
    }

    public void ShowRestartCanvas(bool didAiWin)
    {
        Time.timeScale = 0;

        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);

        if (didAiWin)
        {
            WinTxt.SetActive(false);
            LooseTxt.SetActive(true);
        }
        else
        {
            WinTxt.SetActive(true);
            LooseTxt.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        CanvasGame.SetActive(true);
        CanvasRestart.SetActive(false);

        scoreScript.ResetScores();
        puckScript.CenterPuck();
        playerMovement.ResetPosition();
        aiScript.ResetPosition();
    }

    public void ShowMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }
}
