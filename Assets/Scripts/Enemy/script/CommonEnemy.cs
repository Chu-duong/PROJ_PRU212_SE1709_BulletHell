using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class CommonEnemy : MonoBehaviour
{
    public static UnityAction KillAction;
    public int currentHealth;
    private float rValue = 1f;

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }

        // For effect
        rValue = 0f;
    }

    public void Die()
    {
        ScoreManage.scoreValue++;
        KillAction?.Invoke();
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (rValue < 1f)
        {
            rValue += 0.05f;
            GetComponent<SpriteRenderer>().color = new Color(1.0f, rValue, rValue);
        }
    }



}
