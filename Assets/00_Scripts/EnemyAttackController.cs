using System.Collections;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
   [SerializeField] private GameObject enemy;
   [SerializeField] private GameObject rangeZone;
   [SerializeField] private GameObject damageUI;
   private IEnumerator dealDamage;
   private int damage = -1;
   private int attackCooldown = 2;
   private void Start()
   {
      dealDamage = DealDamage();
   }
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         StartCoroutine(dealDamage);
      }
   }
   private void OnTriggerExit(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         StopCoroutine(dealDamage);
         damageUI.SetActive(false);
         Debug.Log("Stopping Coroutine dealDamage()");
      }
   }
   private IEnumerator DealDamage()
   {
      while(GameManager.instance.health > 0)
      {
         GameManager.instance.ModifyHealth(damage);
         Debug.Log("Enemy has dealt " + damage + " damage");
         damageUI.SetActive(true);
         yield return new WaitForSeconds(1);
         damageUI.SetActive(false);
         yield return new WaitForSeconds(attackCooldown);
      }
   }
}
