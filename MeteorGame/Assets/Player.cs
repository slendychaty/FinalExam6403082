using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject sprite;
    public GameManager gameManager;
    public float speed = 5f;
    public float rotationSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //Get Control Axis
        Vector2 controlAxis = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        //rb.AddForce();
        transform.Translate(controlAxis * speed * Time.deltaTime);
        sprite.transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.GetComponent<Meteor>() != null)
        {
            Debug.Log("Hit Meteor");
            gameManager.score -= 1;
        }
        if (collision.gameObject.GetComponent<Score>() != null)
        {
            Debug.Log("Hit Score");
            gameManager.score += 5;
        }
        collision.gameObject.SetActive(false);
        gameManager.scoreUpdate();
    }
}
