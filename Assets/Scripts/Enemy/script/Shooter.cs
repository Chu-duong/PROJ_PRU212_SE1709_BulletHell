using UnityEngine;

public class Shooter : MonoBehaviour
{
     Transform player; // Player's transform
    public Transform bulletSpawnPoint; // Bullet spawn point
    public GameObject bulletPrefab; // Bullet prefab

    private float shootInterval = 5.0f; // Interval between shots
    private float shootTimer = 3.0f; // Timer for shooting
    public float bulletSpeed = 10f; // Speed of the bullet
    Rigidbody2D rb;

    public int maxHealth = 2;
    public int currentHealth;


    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentHealth = maxHealth;
         rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {

        Vector2 directions = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + directions * 2 * Time.deltaTime);

        // Đảo chiều hình ảnh nếu cần
        if (directions.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        }
        else if (directions.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        }

        // Check if player is not null and it's time to shoot
        if (player != null && Time.time >= shootTimer)
        {
            // Flip enemy if its x position is greater than player's x position
            if (transform.position.x > player.position.x)
            {
                // Lật ngược enemy
                transform.localScale = new Vector3(1, -1, 1);
            }
            else
            {
                // Không lật ngược enemy
                transform.localScale = new Vector3(1, 1, 1);
            }

            // Calculate direction towards the player
            Vector3 direction = (player.position - bulletSpawnPoint.position).normalized;

            // Rotate enemy to face the player
            transform.right = direction;

            // Shoot
            Shoot();
            // Reset shoot timer
            shootTimer = Time.time + shootInterval;
        }

        

        


    }

    void Shoot()
    {
        // Instantiate bullet at the bullet spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Calculate direction towards the player
        Vector3 direction = (player.position - bulletSpawnPoint.position).normalized;

        // Move the bullet towards the player
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        // Destroy bullet after some time
        Destroy(bullet, 3f);
    }

}
