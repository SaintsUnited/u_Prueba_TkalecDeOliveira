using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int maxHealth = 100;
    public int health = 100;
    private void Awake()
    {
        //singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            Debug.Log("Instance already exists! Destroying...");
        }
    }
    private void Start()
    {
        Application.targetFrameRate = 60; //Limita el juego a 60frames
    }
    public void ModifyHealth(int amount) //Metodo para sumar o restar vida al jugador
    {
        health += amount;
        Debug.Log("Health: " + health + " / " + maxHealth);
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health <= 0) //Verifica si el jugador tiene 0 o menos vida y termina el juegp
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Game_Over");
        }
    }
}