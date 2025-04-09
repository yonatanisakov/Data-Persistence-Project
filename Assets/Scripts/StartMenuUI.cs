#if UNITY_EDITOR
using TMPro;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TMP_InputField playerInput;

    private UiManager uiManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiManager = UiManager.instance;
        scoreText.text = "Best Score: " + uiManager.highestScorePlayer + ": " + uiManager.highestScore;
        playerInput.text = uiManager.playerInput;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        uiManager.SaveJsonData();
        SceneManager.LoadScene("main");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void OnEndEditName()
    {
        uiManager.playerInput = playerInput.text;
    }
}
