using System.Collections;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
   [SerializeField] private GameObject enemy;
   [SerializeField] private GameObject rangeZone;
   [SerializeField] private GameObject damageUI;
   [SerializeField] private int damage = -25;
   [SerializeField] private int attackCooldown = 2;
   
   private IEnumerator dealDamage;
   
   private Animator animator;
   private void Start()
   {
      animator = enemy.GetComponent<Animator>();
   }
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         animator.SetBool("isAttacking", true);
         if (animator.GetBool("isAttacking"))
         {
            StartCoroutine("DealDamage");
         }
      }
   }
   private void OnTriggerExit(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         StopCoroutine("DealDamage");
         animator.SetBool("isAttacking", false);
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