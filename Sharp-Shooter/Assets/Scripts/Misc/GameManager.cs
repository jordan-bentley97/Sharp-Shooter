using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool isPaused;

    [SerializeField] TMP_Text enemiesRemainingText;
    [SerializeField] GameObject youWinText;
    [SerializeField] GameObject pauseContainer;

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
        if (starterAssetsInputs.pause) {
            Pause();
            starterAssetsInputs.PauseInput(false);
        }
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
        enemiesRemainingText.text = ENEMIES_REMAINING_STRING + enemiesRemaining.ToString();

        if (enemiesRemaining <= 0) {
            youWinText.SetActive(true);
        }
    }

    public void ResetLevelButton() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void QuitButton() {
        Application.Quit();
    }
}
