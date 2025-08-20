using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool isPaused;

    [SerializeField] GameObject levelCompleteText;
    [SerializeField] GameObject pauseContainer;
    [SerializeField] GameObject menuContainer;
    [SerializeField] GameObject optionsContainer;
    [SerializeField] GameObject controlsContainer;
    [SerializeField] int nextLevelDelay;

    StarterAssetsInputs starterAssetsInputs;
    int enemiesRemaining = 0;

    const string ENEMIES_REMAINING_STRING = "robots remaining: ";

    void Awake() {
        starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
    }

    void Update() {
        HandlePausing();
    }

    void HandlePausing() {
        if (!starterAssetsInputs) return;
        if (starterAssetsInputs.pause && !isPaused) {
            Pause();
            starterAssetsInputs.PauseInput(false);
        }
    }

    public void Back() {
        optionsContainer.SetActive(false);
        pauseContainer.SetActive(true);
    }

    public void Options() {
        pauseContainer.SetActive(false);
        optionsContainer.SetActive(true);
    }

    public void MenuBack() {
        controlsContainer.SetActive(false);
        menuContainer.SetActive(true);
    }

    public void Controls() {
        menuContainer.SetActive(false);
        controlsContainer.SetActive(true);
    }

    void Pause() {
        Time.timeScale = 0f;
        pauseContainer.SetActive(true);
        starterAssetsInputs.SetCursorState(false);
        isPaused = true;
    }

    public void Unpause() {
        Time.timeScale = 1f;
        pauseContainer.SetActive(false);
        starterAssetsInputs.SetCursorState(true);
        isPaused = false;
    }

    public void AdjustEnemiesRemaining(int amount) {
        enemiesRemaining += amount;

        if (enemiesRemaining <= 0)
        {
            levelCompleteText.SetActive(true);
            Invoke("NextLevel", nextLevelDelay);
        }
    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetLevelButton() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void QuitButton() {
        Debug.Log("Cannot quit in the editor but good try");
        Application.Quit();
    }
}
