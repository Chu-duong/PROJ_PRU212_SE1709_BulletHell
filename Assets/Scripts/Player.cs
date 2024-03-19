using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;
using Weapons;
using WeaponTestScene;
using WeaponTestScene.Bullets;
using WeaponTestScene.Guns;

public class Player : MonoBehaviour
{
    public static bool isGameOver;
    public float HP;
    public float MovementSpeed;
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;
    public static UnityAction<float> MinusHealth;
    public Animator John;
    private Rigidbody2D rb;
    public static int killNum = 0;
    public static int killCountForGun = 0;

    private int gunIndex;

    [SerializeField]
    private List<BaseRangeWeapon> weapons;

    [SerializeField]
    private BaseRangeWeapon weapon;

    [SerializeField]
    private SpinMele spin;

    Vector2 movement;

    private readonly int PISTOL_KILL = 0;
    private readonly int SHOTGUN_KILL = 5;
    private readonly int M4A1_KILL = 10;
    private readonly int SPIN_KILL = 20;

    // Start is called before the first frame update
    void Start()
    {
        gunIndex = 0;
        MinusHealth += SetMinusHealth;
        rb = GetComponent<Rigidbody2D>();
        John = GetComponent<Animator>();
        weapon = GetWeapon(gunIndex);
        CommonEnemy.KillAction += UpdateKill;
        PlayerCollsion.MinusHealthAction += MinusHealthEvent;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity =
        //    new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))
        //    * MovementSpeed
        //    * Time.deltaTime;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        John.SetFloat("MoveX", movement.x);
        John.SetFloat("MoveY", movement.y);

        if (
            Input.GetAxisRaw("Horizontal") == 1
            || Input.GetAxisRaw("Horizontal") == -1
            || Input.GetAxisRaw("Vertical") == 1
            || Input.GetAxisRaw("Vertical") == -1
        )
        {
            John.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            John.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
        }

        // Left click to shoot
        if (Input.GetMouseButton(0))
        {
            weapon.Shoot();
            //Shoot();
        }
        //BulletSpawnPoint.transform.rotation = Quaternion.Euler(0f, 0f, GetAngle());

        // Update Gun base on kill
        if (killCountForGun == SHOTGUN_KILL && gunIndex == 0)
        {
            weapon = GetWeapon(++gunIndex);
        }

        if (killCountForGun == M4A1_KILL && gunIndex == 1)
        {
            weapon = GetWeapon(++gunIndex);
        }

        if (killCountForGun == SPIN_KILL && gunIndex == 2 && !spin.gameObject.activeInHierarchy)
        {
            spin.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MovementSpeed * Time.deltaTime);
    }

    float GetAngle()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 distAngleVector = (worldMousePosition - transform.position).normalized;
        return Vector3.Angle(distAngleVector, Vector3.right);
    }

    private void Shoot()
    {
        //GameObject bullet = Instantiate(
        //	BulletPrefab,
        //	BulletSpawnPoint.transform.position,
        //	BulletSpawnPoint.transform.rotation
        //);
        //Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 distAngleVector = (worldMousePosition - transform.position).normalized;
        //bullet.GetComponent<PlayerBullet>().vec = distAngleVector;
    }

    private void SetMinusHealth(float MinusHP)
    {
        HP -= MinusHP;
        if (HP <= 0)
        {
            // ending game
        }
    }

    private void UpdateKill()
    {
        killNum++;
        killCountForGun++;
    }

    private BaseRangeWeapon GetWeapon(int index)
    {
        foreach (var g in weapons)
        {
            g.gameObject.SetActive(false);
        }
        var gun = weapons[index];
        gun.gameObject.SetActive(true);
        return gun;
    }

    private void MinusHealthEvent()
    {
        if (gunIndex == 0)
            return;
        weapon = GetWeapon(--gunIndex);
        if (killCountForGun > M4A1_KILL)
            killCountForGun = M4A1_KILL;
        if (killCountForGun > SHOTGUN_KILL)
            killCountForGun = SHOTGUN_KILL;
        if (killCountForGun > PISTOL_KILL)
            killCountForGun = PISTOL_KILL;
    }
}
