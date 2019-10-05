using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D playerRb;
    public float jumpForce = 10;
    public float speed = 10;
    public float horizontalInput;
    public float xRange = 10;
    public float score;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);
        
        
       
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("Enemy")){

            Debug.Log("Enemy Hit");
            score++;
            Debug.Log($"{score}");
            Destroy(collision2D.gameObject);
        }

       
    }

   
}
