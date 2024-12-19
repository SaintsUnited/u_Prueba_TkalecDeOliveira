using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnMainMenuButtonClicked() //cambia la escena a la del menu principal luego de 2 seg
    {
        Debug.Log("Going to main menu, 2s Left...");
        Invoke(nameof(MainMenu), 2f);
    }
    public void OnRestartButtonClicked() //reinicia la escena "Asylum" despues de 2 seg
    {
        Debug.Log("Restarting Game. 2s Left...");
        Invoke(nameof(RestartButton), 2f);
    }
    public void OnPlayButtonClicked() //cambia la escena a la de "Asylum" despues de 2 seg
    {
        Debug.Log("Initializing. 2s Left...");
        Invoke(nameof(PlayButton), 2f);
    }
    private void MainMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Main_Menu"); 
        GameManager.instance.health = GameManager.instance.maxHealth; //establece la vida al 100%
    }
    private void PlayButton()
    {
        Cursor.visible = false; //desactiva la visibilidad del cursor
        Cursor.lockState = CursorLockMode.Locked; //bloquea el raton al centro de la pantalla
        SceneManager.LoadScene("Asylum"); //carga la escena "Asylum"
    }
    private void RestartButton()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.instance.health = GameManager.instance.maxHealth; //establece la vida al 100%
        SceneManager.LoadScene("Asylum");
    }
}
