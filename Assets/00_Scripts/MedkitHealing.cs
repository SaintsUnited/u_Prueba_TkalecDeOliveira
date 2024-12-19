using System.Collections;
using UnityEngine;

public class MedkitHealing : MonoBehaviour, Interactables
{
    [SerializeField] private int healAmount;
    [SerializeField] private GameObject healingGUIObject;
    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Interactable");
        healAmount = GameManager.instance.maxHealth;
    }
    public void Interact()
    {
        if (GameManager.instance.health < GameManager.instance.maxHealth)
        {
            OnHealingObjectUsed();
        }
    }
    public string GetInteractionText()
    {
        return "Press [E] to use";
    }
    private void OnHealingObjectUsed()
    {
        StartCoroutine(LittleHealing());
    }
    private IEnumerator LittleHealing()
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