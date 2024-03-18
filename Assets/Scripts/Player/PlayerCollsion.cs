using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollsion : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="Enemy")
        {
            HeartManager.health--; 
            if(HeartManager.health <= 0 )
            {
                Player.isGameOver = true; 
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
      
    }
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(8,9);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(8, 9, false); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
