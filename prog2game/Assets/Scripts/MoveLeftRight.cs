using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxPositionX;
    [SerializeField] private float minPositionX;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ClampPosition();
    }

    private void Move()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
        
        //Change direction when reaching the borders
        if(transform.position.x <= minPositionX || transform.position.x >= maxPositionX)
        {
            currentSpeed = -currentSpeed;
        }
    }

    private void ClampPosition()
    {
        //Limits player movement
        float newPositionX = Mathf.Clamp(transform.position.x, minPositionX, maxPositionX);
        transform.position = new Vector2(newPositionX, transform.position.y);
    }
}
