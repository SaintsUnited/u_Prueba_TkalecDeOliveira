using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject playButton;
    
    public void OnMainMenuButtonClicked()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Main_Menu");
        GameManager.instance.health = GameManager.instance.maxHealth;
    }
    public void OnRestartButtonClicked()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.instance.health = GameManager.instance.maxHealth;
        SceneManager.LoadScene("Stage_01");
    }
    public void OnPlayButtonClicked()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Stage_01");
    }
}
