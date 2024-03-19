using UnityEngine;
using UnityEngine.Events;

public abstract class CommonEnemy : MonoBehaviour
{
    public static UnityAction KillAction;
    public int currentHealth;

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        ScoreManage.scoreValue++;
        KillAction?.Invoke();
        Destroy(gameObject);
    }

    

}
