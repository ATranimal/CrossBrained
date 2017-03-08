using UnityEngine;
using System.Collections;

public class StandardKnockback : MonoBehaviour
{
    Rigidbody rb;
    public bool poweredUp = false;
    public float timer;
    Transform playerTransform;
    public bool dead;



    void Start()
    {
        dead = false;
        playerTransform = GetComponent<Transform>();
        timer = 7f;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (poweredUp)
        {
            float scaleFactor = ((1.0f / 7.0f) * timer) + 1.0f;
            if (!dead)
            {
                playerTransform.position = new Vector3(playerTransform.position.x, scaleFactor, playerTransform.position.z);
            }
 
            playerTransform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor) ;
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                poweredUp = false;
                playerTransform.localScale = new Vector3(1, 1, 1);
                playerTransform.position.Set(playerTransform.position.x, 1, playerTransform.position.z);
            }
       }
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 difference = (this.transform.position - collision.gameObject.transform.position);
        rb.AddForce(difference * 450);

        if (collision.gameObject.CompareTag("Player") && poweredUp)
        {
            collision.rigidbody.AddForce(difference * -1 * 550);
        }
    }
}
