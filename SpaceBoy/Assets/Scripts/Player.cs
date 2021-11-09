using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;

    public GameObject canvas;

    public Transform feetPosition;

    public int speed;
    public int jumpForce;

    public GameObject portal;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMovement();

        PlayerJump();

        PlayerTeleportation();

        Physics2D.IgnoreCollision(portal.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        if (Input.GetKeyDown("escape"))
        {
            canvas.SetActive(true);

            this.gameObject.SetActive(false);
        }
    }

    private void PlayerTeleportation()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (portal.transform.position.y > 6)
            {
                portal.transform.position = this.transform.position;
            }
            else if (portal.transform.position.x -0.8f < this.transform.position.x && portal.transform.position.x + 0.8f > this.transform.position.x)
            {
                if (portal.transform.position.y - 1f < this.transform.position.y && portal.transform.position.y + 1f > this.transform.position.y)
                    portal.transform.position = new Vector3(0f, 9f, 0f);
            }
                
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (portal.transform.position.y < 6)
            {
                this.transform.position = portal.transform.position;
            }
        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(feetPosition.position, 0.1f);

            foreach(Collider2D col in cols)
            {
                if (col.tag == "Floor")
                {
                    this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    //animator.SetBool("Walk", false);
                    //animator.SetBool("Jump", true);
                }
            }
            
        }
    }

    private void PlayerMovement()
    {


        if (Input.GetAxis("Horizontal") == 1)
        {
            animator.SetBool("Walk", true);
            float x = transform.position.x + speed * Time.deltaTime;
            transform.position = new Vector3(x, transform.position.y, 0f);

            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (Input.GetAxis("Horizontal") == -1)
        {
            animator.SetBool("Walk", true);
            float x = transform.position.x + -speed * Time.deltaTime;
            transform.position = new Vector3(x, transform.position.y, 0f);

            this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            animator.SetBool("Walk", false);
        }


    }

    public void PickUpCircuit(GameObject circuit)
    {
        if (circuit.name == "CircuitGreen")
        {
            GameObject.Find("LaserGreen").SetActive(false);
            circuit.SetActive(false);
        }
        else if (circuit.name == "CircuitRed")
        {
            GameObject.Find("LaserRed").SetActive(false);
            circuit.SetActive(false);
        }
        else if (circuit.name == "CircuitBlue")
        {
            GameObject.Find("LaserBlue").SetActive(false);
            circuit.SetActive(false);
        }
        else if (circuit.name == "CircuitYellow")
        {
            GameObject.Find("LaserYellow").SetActive(false);
            circuit.SetActive(false);
        }
        else if (circuit.name == "CircuitPurple")
        {
            GameObject.Find("LaserPurple").SetActive(false);
            circuit.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Trap")
        {
            canvas.SetActive(true);
            
            this.gameObject.SetActive(false);
        }
        else if (col.tag == "End")
        {
            canvas.SetActive(true);
            canvas.GetComponent<PauseManager>().isWin = true;
            this.gameObject.SetActive(false);
        }

        if (col.tag == "Destroyer")
        {
            portal.transform.position = new Vector3(0f, 9f, 0f);
        }

        if (col.tag == "Circuit")
        {
            PickUpCircuit(col.gameObject);
        }
    }



}
