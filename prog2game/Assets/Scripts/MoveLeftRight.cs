using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxPositionX;
    [SerializeField] private float minPositionX;

    // Start is called before the first frame update
    void Start()
    {

        //Random chance to start moving left
        if(Mathf.CeilToInt(Random.Range(0, 9))%2 == 0)
        {
            Turn();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ClampPosition();
    }

    private void Move()
    {
        //Moves the object left/right
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //Change direction when reaching the borders
        if (transform.position.x <= minPositionX || transform.position.x >= maxPositionX)
        {
            Turn();
        }
    }

    private void ClampPosition()
    {
        //Limits player movement
        float newPositionX = Mathf.Clamp(transform.position.x, minPositionX, maxPositionX);
        transform.position = new Vector2(newPositionX, transform.position.y);
    }

    private void Turn()
    {
        //Start moving to the opposite direction
        speed = -speed;

        //Turn/mirror the object on the x axis
        float xScale = gameObject.transform.localScale.x;
        float yScale = gameObject.transform.localScale.y;
        gameObject.transform.localScale = new Vector2(-xScale, yScale);
    }
}
