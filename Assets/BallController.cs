using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed = 1f;
    private GameManager gameManager;
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //moveBall(new Vector2(0f, -1f));
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ball doesn't start moving until the left mouse button is pressed.
        if(!isActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isActive = true;
                moveBall(new Vector2(0f, -1f));
            }
        }
    }

    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the Racket?
        if (col.gameObject.name == "Paddle")
        {
            // Calculate hit Factor
            float hitFactor = getHitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            moveBall(new Vector2(hitFactor, 1).normalized);
        }

        // Go out of bounds?
        if (col.gameObject.name == "Floor")
        {
            gameManager.LoseALife(this);
        }
     }
    private void moveBall(Vector2 direction)
    {
        rigidBody.velocity= (direction * speed);
    }
    private float getHitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }
    public void destroyBall()
    {
        Destroy(gameObject);
    }
}
