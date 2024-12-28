using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField] TMP_Text enemiesRemainingText;
    [SerializeField] GameObject youWinText;

    int enemiesRemaining = 0;

    const string ENEMIES_REMAINING_STRING = "Robots Remaining: ";

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
        Debug.LogWarning("Quitting doesnt work in the editor, silly goose!");
        Application.Quit();
    }
}
