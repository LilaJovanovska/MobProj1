using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdController : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField] private float jumpSpeed;

    [SerializeField] private GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //unpause game
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetJumpInput())
        {
            Debug.Log("Player pressed the jump button.");
            Jump();        
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //pause the game
        Time.timeScale = 0;

        //show game off screen
        if (gameOverScreen)
        {
            gameOverScreen.SetActive(true);
        }

        //show points

    }

    private bool GetJumpInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        } else {
            return false;
        }
    }


    private void Jump()
    //code for jump
    {
        //calculate the direction and speed
        Vector2 jumpDirection = new Vector2(0, 1);
        Vector2 jumpVector = jumpDirection * jumpSpeed;

        //reset speed
        rb.velocity = Vector2.zero;
        //jump
        rb.AddForce(jumpVector, ForceMode2D.Impulse);

        // rb.velocity = Vector2.zero;
        // rb.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
