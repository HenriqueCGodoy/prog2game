using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float maxPositionX;
    [SerializeField] private float minPositionX;
    [SerializeField] private int startingLives;
    private int currentLives;
    private int score;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = startingLives;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameOver())
        {
            Move();
            Shoot();
            ClampPosition();
        }
    }
    
    private void Move()
    {
        //Move left
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        
        //Move right
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate bullet
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }

    private void ClampPosition()
    {
        //Limits player movement
        float newPositionX = Mathf.Clamp(transform.position.x, minPositionX, maxPositionX);
        transform.position = new Vector2(newPositionX, transform.position.y);
    }

    public void DamagePlayer()
    {
        currentLives--;
    }

    public void IncreaseScore(int value)
    {
        if (!gameManager.isGameOver())
        {
            score += value;
        }
    }

    public int GetPlayerLives()
    {
        return currentLives;
    }

    public int GetPlayerScore()
    {
        return score;
    }
    
}
