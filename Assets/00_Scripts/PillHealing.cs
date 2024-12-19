using System.Collections;
using UnityEngine;

public class PillHealing : MonoBehaviour, Interactables
{
    [SerializeField] private int healAmount;
    [SerializeField] private GameObject healingGUIObject;
    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Interactable"); //Autoasigna la capa del objeto a "Interactable"
    }
    public void Interact()
    {
        if (GameManager.instance.health < GameManager.instance.maxHealth) //se asegura que el jugador tenga menos del 100% de vida
        {
            OnHealingObjectUsed();
        }
    }
    public string GetInteractionText() //texto a mostrar en pantalla
    {
        return "Press [E] to use";
    }
    private void OnHealingObjectUsed()
    {
        healAmount = (int)(GameManager.instance.maxHealth * 0.2); //establece el valor a curar como el 20% de la vida maxima
        StartCoroutine(LittleHealing());
    }
    private IEnumerator LittleHealing() //animacion para retroalimentacion del jugador
    {
        GameManager.instance.ModifyHealth(healAmount);
        Debug.Log("Activating Feedback...");
        healingGUIObject.SetActive(true); 
        yield return new WaitForSeconds(1.5f);
        healingGUIObject.SetActive(false);
        Debug.Log("Deactivating Feedback.");
        Destroy(gameObject);
    }
}