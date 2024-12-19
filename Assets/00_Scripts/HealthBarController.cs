using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class HealthBarController : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Scrollbar healthBar;
    //velocidad de animacion
    [SerializeField] private float animationDuration = 0.2f;
    private float targetHealth;

    private void Start()
    {
        gameManager = GameManager.instance; //Asigna la instancia del GameManager a la variable gameManager
    }
    private void Update()
    {
        UpdateHealth(); //Actualiza constantemente la barra de vida
    }
    private void UpdateHealth()
    {
        //Actualiza y convierte la salud a numero decimal entre 0 y 1
        float targetHealth = gameManager.health / 100f;
        StartCoroutine(AnimateHealthBar(targetHealth));
    }
    private IEnumerator AnimateHealthBar(float targetHealth) //Anima la barra de vida
    {
        while (Mathf.Abs(targetHealth - healthBar.size) > 0.01f)
        {
            healthBar.size = Mathf.Lerp(healthBar.size, targetHealth, animationDuration * Time.deltaTime);
            yield return null;
        }
        healthBar.size = targetHealth;
        UpdateHandleColor();
    }
    private void UpdateHandleColor() //Cambia el color de la barra de vida segun el porcentaje
    {
        Image handleImage = healthBar.handleRect.GetComponent<Image>();
        
        float healthPercentage = (float)gameManager.health / 100f;
        switch (healthPercentage)
        {
            case >0.7f:
                handleImage.color = Color.green;
                break;
            
            case >0.3f:
                handleImage.color = Color.yellow;
                break;
            
            case >0.01f:
                handleImage.color = Color.red;
                break;
        }
    }
}