using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5.0f;
    private float gravity = 1.0f;
    private float jumpHeight = 15.0f;
    private float dyTemp;

    private int coins;

    private bool canDoubleJump = false;

    private CharacterController controller;

    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
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
