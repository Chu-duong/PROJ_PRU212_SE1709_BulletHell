using System.Collections;
using System.Collections.Generic;
using Bullets;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public float HP;
    public float MovementSpeed;
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;
    public static UnityAction<float> MinusHealth;

    // Start is called before the first frame update
    void Start()
    {
        MinusHealth += SetMinusHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) // Up
        {
            transform.position += Vector3.up * MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) // Left
        {
            transform.position += Vector3.left * MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) // Down
        {
            transform.position += Vector3.down * MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) // Right
        {
            transform.position += Vector3.right * MovementSpeed * Time.deltaTime;
        }

        // Click to shoot
        if (Input.GetMouseButtonDown(0)) // Left click
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

        //BulletSpawnPoint.transform.rotation = Quaternion.Euler(0f, 0f, GetAngle());
    }

    float GetAngle()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 distAngleVector = (worldMousePosition - transform.position).normalized;
        return Vector3.Angle(distAngleVector, Vector3.right);
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
