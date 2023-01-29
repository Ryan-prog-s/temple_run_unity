using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    public GameObject bob;
    public int currentOptionKeyboard;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;

    public int speedBob;

    // Infinity mode
    public int optionLevel;
    public double incrementSpeed;


    // Start is called before the first frame update
    void Start()
    {
        int optionKeyboard = PlayerPrefs.GetInt("SelectedOptionKeyboard");
        optionLevel = PlayerPrefs.GetInt("SelectedOptionLevel") + 1;
        currentOptionKeyboard = optionKeyboard;
        rb = bob.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 4.0f, 0.0f);
        incrementSpeed = 1;
    }

    public void GetKeyboard()
    {
        // option ZQSD
        if (currentOptionKeyboard == 0)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                bob.transform.Translate(-3 * Time.deltaTime * 2, 0, 0);
             }
            if (Input.GetKey(KeyCode.D))
            {
                bob.transform.Translate(3 * Time.deltaTime * 2, 0, 0);
             }
            if (Input.GetKey(KeyCode.Z))
            {
                rb.useGravity = true;
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
            bob.transform.position = new Vector3(Mathf.Clamp(bob.transform.position.x, -4, 4), bob.transform.position.y, bob.transform.position.z);
        }
        // option Arrows
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                bob.transform.Translate(-3 * Time.deltaTime * 2, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                bob.transform.Translate(3 * Time.deltaTime * 2, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) )
            {
                rb.useGravity = true;
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
            int vitesse = 8 + optionLevel;
            if (optionLevel == 5) bob.transform.Translate(0, 0, (float)( (vitesse + incrementSpeed) * Time.deltaTime));
            else bob.transform.Translate(0, 0, (vitesse * Time.deltaTime));
            bob.transform.position = new Vector3(Mathf.Clamp(bob.transform.position.x, -4, 4), bob.transform.position.y, bob.transform.position.z);
        }

    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.useGravity = false;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.gameIsPaused)
        {
            if (optionLevel == 5)
            {
                incrementSpeed += 0.002;
                Debug.Log("Increment speed is " + incrementSpeed);
            }
            GetKeyboard();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
            }
        }  

    }
}
