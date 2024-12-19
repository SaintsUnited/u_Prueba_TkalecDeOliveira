using System.Collections;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
   [SerializeField] private GameObject enemy;
   [SerializeField] private GameObject rangeZone;
   [SerializeField] private GameObject damageUI;
   [SerializeField] private int damage = -25; //cuanta vida quita el enemigo
   [SerializeField] private int attackCooldown = 2; //tiempo que tarda en volver a atacar
   
   private IEnumerator dealDamage;
   
   private Animator animator;
   private void Start()
   {
      animator = enemy.GetComponent<Animator>();
   }
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player")) //activa la animacion de atacar si el jugador entra en el alcance
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
      if (other.CompareTag("Player")) //desactiva la animacion cuando el jugador sale del alcance
      {
         StopCoroutine("DealDamage");
         animator.SetBool("isAttacking", false);
         damageUI.SetActive(false);
         Debug.Log("Stopping Coroutine dealDamage()");
      }
   }
   private IEnumerator DealDamage() //corrutina que resta vida al jugador mientras aun este vivo (vida >0)
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