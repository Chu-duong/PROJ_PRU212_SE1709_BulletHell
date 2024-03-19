//using System.Collections;
//using System.Collections.Generic;
//using Unity.Mathematics;
//using UnityEngine;

//public class FOLLOW : MonoBehaviour
//{
//    public GameObject player;
//    public float speed;
//    public bool flip;

//    Rigidbody2D rb;

//    private void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }


//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Vector3 scale = transform.localScale;
//        if (player.transform.position.x > transform.position.x)
//        {
//            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1) ;
//            transform.Translate(x : speed * Time.deltaTime, y : 0, z : 0);
//        } else
//        {
//            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1) * -1;
//            transform.Translate(x: speed * Time.deltaTime * -1, y: 0, z: 0);
//        }
//        transform.localScale = scale;
//    }
//}


using UnityEngine;

public class FOLLOW : MonoBehaviour
{
    public Transform player;
    public float speed;
    public int maxHealth = 3;
    public int currentHealth;

    public float traiphai;
    public bool facingRight = true;
    public Animator anim;

    public GameObject enem;

    Rigidbody2D rb;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
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
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);

        // Đảo chiều hình ảnh nếu cần
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            anim.SetFloat("di", Mathf.Abs(direction.x));
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            anim.SetFloat("di", Mathf.Abs(direction.x));
        }
            


    }
}
