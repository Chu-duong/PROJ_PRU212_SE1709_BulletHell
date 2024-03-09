using UnityEngine;
using WeaponTestScene.Bullets;

public class NineMMBullet : BaseBullet
{
    private Rigidbody2D _rb;
    private float _timeout;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = Direction * Speed;
        _timeout += Time.deltaTime;
        if (!(_timeout >= TimeOut)) return;
        gameObject.SetActive(false);
        _timeout = 0;
    }
}