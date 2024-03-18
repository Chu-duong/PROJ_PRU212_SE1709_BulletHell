using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;
using Weapons;

public class Player : MonoBehaviour
{
    public float HP;
    public float MovementSpeed;
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;
    public static UnityAction<float> MinusHealth;
    public Animator John;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        MinusHealth += SetMinusHealth;
        rb = GetComponent<Rigidbody2D>();
        John = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * MovementSpeed * Time.deltaTime;
        Debug.Log(rb.velocity);

        // Left click to shoot
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        //BulletSpawnPoint.transform.rotation = Quaternion.Euler(0f, 0f, GetAngle());

        //Set animation
        //setAnimationState();
        John.SetFloat("MoveX", rb.velocity.x);
        John.SetFloat("MoveY", rb.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            John.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            John.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    float GetAngle()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 distAngleVector = (worldMousePosition - transform.position).normalized;
        return Vector3.Angle(distAngleVector, Vector3.right);
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(
            BulletPrefab,
            BulletSpawnPoint.transform.position,
            BulletSpawnPoint.transform.rotation
        );
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 distAngleVector = (worldMousePosition - transform.position).normalized;
        bullet.GetComponent<PlayerBullet>().vec = distAngleVector;
    }

    private void SetMinusHealth(float MinusHP)
    {
        HP -= MinusHP;
        if (HP <= 0)
        {
            // ending game
        }
    }
}
