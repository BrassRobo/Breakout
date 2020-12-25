using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed = 1f;
    private GameManager gameManager;
    public bool isActive;
    public AudioClip bounceSound;
    public AudioClip breakSound;
    public AudioClip deathSound;
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
    private void LateUpdate()
    {
        //Sets the velocity to a constant value.
        rigidBody.velocity = (rigidBody.velocity.normalized * speed);
    }

    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag== "Wall" || col.gameObject.name == "Paddle")
        {
            AudioSource.PlayClipAtPoint(bounceSound, new Vector3(0f, 0f, 0f));
        }
        else if(col.gameObject.tag == "Brick")
        {
            AudioSource.PlayClipAtPoint(breakSound, new Vector3(0f, 0f, 0f));
        }
        // Go out of bounds?
        else if (col.gameObject.name == "Floor") 
        {
            AudioSource.PlayClipAtPoint(deathSound, new Vector3(0f, 0f, 0f));
            gameManager.LoseALife(this);
        }

        // Hit the Racket?
        if (col.gameObject.name == "Paddle")
        {
            // Calculate hit Factor
            float hitFactor = getHitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            moveBall(new Vector2(hitFactor, 1).normalized);
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
