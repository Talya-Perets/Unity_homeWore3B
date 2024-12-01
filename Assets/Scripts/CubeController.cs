using UnityEngine;

public class CubeCollision : MonoBehaviour
{


  

    public string cubeColor; // The color of the cube
    private bool isCollided = false; // Has the cube collided with the bottom object?
    private bool isActive = true; //  // Is the cube still active?
    private float cubeLifetime = 5f;// The total lifetime of the cube (in seconds)
    private float timer; //Timer to track the cube's lifetime

    void Start()
    {
        // אתחול טיימר
        timer = cubeLifetime;

    }

    void Update()
    {
        if (isActive)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                DestroyCube();
            }

            if (isCollided)
            {
                CheckInput();
            }
        }
    }

    void CheckInput()
    {
        if (cubeColor == "Red" && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Red cube pressed Z");
            Destroy(gameObject); //destroy cube
        }
        else if (cubeColor == "Blue" && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Blue cube pressed X");
            Destroy(gameObject); //destroy cube
        }
        else if (cubeColor == "Yellow" && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Yellow cube pressed C");
            Destroy(gameObject); //destroy cube
        }
    }


    void DestroyCube()
    {
        isActive = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BottomCollider"))
        {
            isCollided = true;
        }
    }
}