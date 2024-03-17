using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform player; // Player's transform
    public Transform bulletSpawnPoint; // Bullet spawn point
    public GameObject bulletPrefab; // Bullet prefab
    public float shootInterval = 1.0f; // Interval between shots
    private float shootTimer = 0f; // Timer for shooting
    public float bulletSpeed = 10f; // Speed of the bullet

    void Update()
    {

        // Check if player is not null and it's time to shoot
        if (player != null && Time.time >= shootTimer)
        {

            

            // Reset shoot timer
            shootTimer = Time.time + shootInterval;
        }

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
