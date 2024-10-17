using System.Collections;
using UnityEngine;

public class HealingScript : MonoBehaviour
{
   [SerializeField] private GameObject healingTrigger;
   [SerializeField] private GameObject recoveryUI;
   [SerializeField] private int healingAmount = 1;
   private IEnumerator recoveryCoroutine;
   private void Start()
   {
      recoveryCoroutine = HealingCoroutine();
   }
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         Debug.Log("Entering healing zone");
         StartCoroutine(recoveryCoroutine);
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.CompareTag("Player"))
      { 
         StopCoroutine(recoveryCoroutine);
         recoveryUI.SetActive(false);
         Debug.Log("recoveryCoroutine() stopped.");
      }
   }
   private IEnumerator HealingCoroutine()
   {
      while (GameManager.instance.health > 0  && GameManager.instance.health != GameManager.instance.maxHealth)
      {
         GameManager.instance.ModifyHealth(healingAmount);
         Debug.Log("recoveryCoroutine() healed " + healingAmount);
         recoveryUI.SetActive(true);
         yield return new WaitForSeconds(1);
         recoveryUI.SetActive(false);
         yield return new WaitForSeconds(1);
      }
   }
}
