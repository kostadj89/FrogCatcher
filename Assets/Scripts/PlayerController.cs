using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private string name;
    //private float randomFloat;
    //public PlayerControler()
    //{
    //    name = "name";
    //}
    //public PlayerControler(string name)
    //{
    //    this.name = name;

    //}
    private float horizontal, vertical;
    private Rigidbody2D playerRigidbody;
    public Animator animator;
    public Animator animatorTool;

    public float playerMoveSpeed;

    void Awake()
    {
        //randomFloat = Random.Range(0, 100);
        //Debug.Log("random awake: " + randomFloat);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        //Animator animator2 = GetComponentInChildren<Animator>();

        foreach (Transform child in transform)
        {
            if (child.name == "CurrentTool") {
                animatorTool = (Animator)child.GetComponent(typeof(Animator));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        //move character in the right direction by applying force
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 vector = new Vector2(horizontal, vertical);
        
        gameObject.transform.Translate(playerMoveSpeed*Time.deltaTime*(horizontal * Vector2.right + vertical*Vector2.up));
        //playerRigidbody try to add force
        //playerRigidbody.AddForce(vector*playerMoveSpeed);
        //playerRigidbody.AddRelativeForce(vector*playerMoveSpeed);


        if (vector != Vector2.zero) {
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);
        }
        animator.SetFloat("Speed", new Vector2(horizontal,vertical).magnitude);

        if (vector != Vector2.zero)
        {
            animatorTool.SetFloat("Horizontal", horizontal);
            animatorTool.SetFloat("Vertical", vertical);
        }
        if(Input.GetMouseButtonDown(0) == true) animatorTool.SetTrigger("Use");

    }
}
