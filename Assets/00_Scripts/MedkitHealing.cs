using System.Collections;
using UnityEngine;

public class MedkitHealing : MonoBehaviour, Interactables
{
    [SerializeField] private int healAmount;
    [SerializeField] private GameObject healingGUIObject;
    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Interactable"); //autoasigna la Layer del objeto a la layer "Interactable"
    }
    public void Interact()
    {
        if (GameManager.instance.health < GameManager.instance.maxHealth)
        {
            OnHealingObjectUsed();
        }
    }
    public string GetInteractionText() //Texto a mostrar
    {
        return "Press [E] to use";
    }
    private void OnHealingObjectUsed() //Calcula cuanta vida se necesita para llenarla toda
    {
        healAmount = GameManager.instance.maxHealth - GameManager.instance.health;
        StartCoroutine(LittleHealing());
    }
    private IEnumerator LittleHealing() //Animacion de activar y desactivar la GUI de curar.
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