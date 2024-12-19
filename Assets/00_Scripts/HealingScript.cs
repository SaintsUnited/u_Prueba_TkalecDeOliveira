using UnityEngine;

public class HealingScript : MonoBehaviour, Interactables
{
   [SerializeField] private int healAmount;

   private void Start()
   {
      gameObject.layer = LayerMask.NameToLayer("Interactable");
   }
   public void Interact()
   {
      OnHealingObjectUsed();
   }
   public string GetInteractionText()
   {
      return "Press [E] to use";
   }
   private void OnHealingObjectUsed()
   {
      GameManager.instance.ModifyHealth(healAmount);
   }
}