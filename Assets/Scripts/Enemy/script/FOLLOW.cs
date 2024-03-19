using UnityEngine;

public class FOLLOW : CommonEnemy
{
    Transform player;
    public float speed;
    public int maxHealth = 3;

    public float traiphai;
    public bool facingRight = true;
    public Animator anim;

    public GameObject enem;

    Rigidbody2D rb;

    private void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        // Đảo chiều hình ảnh nếu cần
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(
                Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
            anim.SetFloat("di", Mathf.Abs(direction.x));
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(
                -Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
            anim.SetFloat("di", Mathf.Abs(direction.x));
        }
    }
}
