using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnMainMenuButtonClicked()
    {
        Debug.Log("Going to main menu, 2s Left...");
        Invoke(nameof(MainMenu), 2f);
    }
    public void OnRestartButtonClicked()
    {
        Debug.Log("Restarting Game. 2s Left...");
        Invoke(nameof(RestartButton), 2f);
    }
    public void OnPlayButtonClicked()
    {
        Debug.Log("Initializing. 2s Left...");
        Invoke(nameof(PlayButton), 2f);
    }
    private void MainMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Main_Menu");
        GameManager.instance.health = GameManager.instance.maxHealth;
    }
    private void PlayButton()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Asylum");
    }
    private void RestartButton()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.instance.health = GameManager.instance.maxHealth;
        SceneManager.LoadScene("Asylum");
    }
}
