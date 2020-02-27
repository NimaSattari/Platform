using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float Speed = 5.0f;
    [SerializeField] private float gravity = 1.0f;
    [SerializeField] private float jumpHeight = 15.0f;
    private float yVelocity;
    private bool CanDJump = false;
    [SerializeField] private int Coins;
    private UIManager UIManager;
    [SerializeField] private int Life = 3;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(UIManager == null)
        {
            Debug.Log("UIManager is NULL");
        }
        UIManager.UpdateLifeDisplay(Life);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * Speed;
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpHeight;
                CanDJump = true;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(CanDJump == true)
                {
                    yVelocity += jumpHeight;
                    CanDJump = false;
                }
            }
            yVelocity -= gravity;
        }
        velocity.y = yVelocity;
        controller.Move(velocity * Time.deltaTime);
    }
    public void AddCoins()
    {
        Coins++;
        UIManager.UpdateCoinDisplay(Coins);
    }
    public void Damage()
    {
        Life--;
        UIManager.UpdateLifeDisplay(Life);
        if(Life < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
