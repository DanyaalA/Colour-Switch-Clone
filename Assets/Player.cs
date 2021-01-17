using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float jumpForce = 10f;

    public Rigidbody2D rb;

    public string currentCol;
    public SpriteRenderer sr;
    public int Score = 0;

    public Color colCyan;
    public Color colYellow;
    public Color colMagenta;
    public Color colPink;

    private void Start()
    {
        SetRandomColour();
    }

    void OnBecameInvisible()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);

        if (collision.tag == "Coin")
        {
            Score++;
            Debug.Log("Coin Hit");
            Destroy(collision.gameObject);
            
            return;
        }

        if (collision.tag == "ColourChanger")
        {
            SetRandomColour();
            Destroy(collision.gameObject);
            return;
        }

        if (collision.tag != currentCol && collision.tag != "Coin")
        {
            Debug.Log("GAME OVER");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }


    }

    void SetRandomColour()
    {
        int index = UnityEngine.Random.Range(0, 4);

        switch (index)
        {
            case 0:
                //if (SameColour("Cyan")) SetRandomColour();
                currentCol = "Cyan";
                sr.color = colCyan;
                break;
            case 1:
                //if (SameColour("Yellow")) SetRandomColour();
                currentCol = "Yellow";
                sr.color = colYellow;
                break;
            case 2:
                //if (SameColour("Magenta")) SetRandomColour();
                currentCol = "Magenta";
                sr.color = colMagenta;
                break;
            case 3:
                //if (SameColour("Pink")) SetRandomColour();
                currentCol = "Pink";
                sr.color = colPink;
                break;
        }
    }

    private bool SameColour(string newCol)
    {
        if (newCol == currentCol) return true;

        return false;
    }
}
