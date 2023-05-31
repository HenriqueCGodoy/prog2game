using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Hit obstacle
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Hit Obstacle !");
        }

        //Hit target
        if(other.gameObject.CompareTag("Target"))
        {
            Debug.Log("Hit Target !");
        }

        //Hit bullet-destroy zone (missed all obstacles and targets)
        if(other.gameObject.CompareTag("BulletEndZone"))
        {
            Debug.Log("Hit BulletEndZone !");
        }

        //Destroy bullet
        Destroy(gameObject);

    }
}
