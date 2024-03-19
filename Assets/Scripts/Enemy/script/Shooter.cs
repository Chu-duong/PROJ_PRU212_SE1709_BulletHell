using UnityEngine;

public class Shooter : CommonEnemy
{
    Transform player; // Player's transform
    public Transform bulletSpawnPoint; // Bullet spawn point
    public GameObject bulletPrefab; // Bullet prefab

    private float shootInterval = 5.0f; // Interval between shots
    private float shootTimer = 3.0f; // Timer for shooting
    public float bulletSpeed = 10f; // Speed of the bullet
    Rigidbody2D rb;

    public int maxHealth = 2;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * 2 * Time.deltaTime);

        // Đảo chiều hình ảnh nếu cần
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.Normalize();

        // Calculate the angle to rotate
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        // Rotate towards the player
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);

        // Kiểm tra nếu player không null và khoảng cách nhỏ hơn 10
        if (player != null && Vector2.Distance(transform.position, player.position) <= 10 && Time.time >= shootTimer)
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
            Vector3 directionToPlayerNormalized = (player.position - bulletSpawnPoint.position).normalized;

            // Rotate enemy to face the player
            transform.right = directionToPlayerNormalized;

            // Shoot
            Shoot();

            // Reset shoot timer
            shootTimer = Time.time + shootInterval;
        }
    }


    void Shoot()
    {
        // Instantiate bullet at the bullet spawn point
        GameObject bullet = Instantiate(
            bulletPrefab,
            bulletSpawnPoint.position,
            Quaternion.identity
        );

        // Calculate direction towards the player
        Vector3 direction = (player.position - bulletSpawnPoint.position).normalized;

        // Move the bullet towards the player
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        // Destroy bullet after some time
        Destroy(bullet, 3f);
    }
}
