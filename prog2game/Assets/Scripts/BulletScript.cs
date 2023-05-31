using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private PlayerScript playerScript;

    private void Awake()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

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
            playerScript.DamagePlayer();
        }

        //Hit target
        if(other.gameObject.CompareTag("Target"))
        {
            Debug.Log("Hit Target !");
            int targetValue = other.GetComponent<TargetScript>().GetTargetValue();
            playerScript.IncreaseScore(targetValue);
        }

        //Hit bullet-destroy zone (missed all obstacles and targets)
        if(other.gameObject.CompareTag("BulletEndZone"))
        {
            Debug.Log("Hit BulletEndZone !");
            playerScript.DamagePlayer();
        }

        //Destroy bullet
        Destroy(gameObject);

    }
}
