using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float speed = 5.0f;
    private float gravity = 1.0f;
    private float jumpHeight = 15.0f;
    private float dyTemp;

    private int coins;
    private int lives = 3;

    private bool canDoubleJump = false;

    private CharacterController controller;

    private UIManager uiManager;

    [SerializeField]
    private GameObject startPosition;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        uiManager.LivesDisplay(lives);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        direction *=  speed;

        if(!controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                dyTemp += jumpHeight;
                canDoubleJump = false;
            }
            
            dyTemp -= gravity;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                dyTemp = jumpHeight;
                canDoubleJump = true;
            }
        }

        direction.y = dyTemp;

        controller.Move(direction  * Time.deltaTime);

        if(transform.position.y < -10f)
        {
            lives--;
            uiManager.LivesDisplay(lives);
            transform.position = startPosition.transform.position;
            if(lives < 1)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void AddCoin()
    {
        coins++;

        if(uiManager != null)
        {
            uiManager.CoinDisplay(coins);
        }
    }
}
