using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int maxHealth = 3;
    public int health = 3;
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
        Application.targetFrameRate = 60;
    }
    public void ModifyHealth(int amount)
    {
        health += amount;
        Debug.Log("Health: " + health + " / " + maxHealth);
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Game_Over");
        }
    }
}