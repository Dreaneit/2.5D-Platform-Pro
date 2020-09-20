using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 playerVelocity;
    private float yVelocity;
    private bool canDoubleJump;
    [SerializeField]
    private float playerSpeed = 5.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = 9.81f;
    [SerializeField]
    private int lives = 3, coinsCollected;

    private CharacterController characterController;
    private UIManager uiManager;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        uiManager.RenderLives(lives);
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleDeadZone();
    }

    private void HandleDeadZone()
    {
        if (isFallOf())
        {
            CCDisable();
            SetInitialPosition();

            if (lives == 0)
            {
                gameManager.RestartGame();
            }
            else
            {
                Damage();
                uiManager.RenderLives(lives);
            }

            StartCoroutine(CCEnable());
        }
    }

    private void SetInitialPosition()
    {
        transform.position = new Vector3(-9, 0, 0);
    }

    private void CCDisable()
    {
        characterController.enabled = false;
    }

    IEnumerator CCEnable()
    {
        yield return new WaitForSeconds(0.35f);
        characterController.enabled = true;
    }

    private void HandleMovement()
    {
        var horizontalAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontalAxis, verticalAxis, 0);
        playerVelocity = direction * playerSpeed;

        if (characterController.isGrounded)
        {
            canDoubleJump = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpHeight;
            }
        }
        else
        {
            if (canDoubleJump && Input.GetKeyDown(KeyCode.Space))
            {
                canDoubleJump = false;
                yVelocity += jumpHeight;
            }
            yVelocity -= gravityValue;
        }

        playerVelocity.y = yVelocity;

        characterController.Move(playerVelocity * Time.deltaTime);
    }

    private bool isFallOf()
    {
        float yBottom = -10f;
        if (transform.position.y <= yBottom)
        {
            return true;
        }

        return false;
    }

    public void CollectCoin()
    {
        coinsCollected += 1;
    }

    public int GetCollectedCoins()
    {
        return coinsCollected;
    }

    private void Damage()
    {
        lives--;
    }
}
