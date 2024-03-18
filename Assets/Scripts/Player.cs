using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;
using Weapons;
using WeaponTestScene;
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
	public Rigidbody2D rb;
	[SerializeField]
	private BaseRangeWeapon weapon;

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
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // Up
		{
			transform.position += Vector3.up * MovementSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // Left
		{
			transform.position += Vector3.left * MovementSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // Down
		{
			transform.position += Vector3.down * MovementSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // Right
		{
			transform.position += Vector3.right * MovementSpeed * Time.deltaTime;
		}

		// Left click to shoot
		if (Input.GetMouseButtonDown(0))
		{
			weapon.Shoot();
			//Shoot();
		}
		//BulletSpawnPoint.transform.rotation = Quaternion.Euler(0f, 0f, GetAngle());

		//Set animation
		setAnimationState();
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

	private void setAnimationState()
	{
		if (Mathf.Abs(MovementSpeed) == 0)
		{
			John.SetBool("isWalkUp", false);
			John.SetBool("isWalkLeft", false);
			John.SetBool("isWalkDown", false);
			John.SetBool("isWalkRight", false);
		}
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			John.SetBool("isWalkUp", true);
		else
			John.SetBool("isWalkUp", false);

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			John.SetBool("isWalkLeft", true);
		else
			John.SetBool("isWalkLeft", false);

		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			John.SetBool("isWalkDown", true);
		else
			John.SetBool("isWalkDown", false);

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			John.SetBool("isWalkRight", true);
		else
			John.SetBool("isWalkRight", false);
	}
}
