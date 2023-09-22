using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float velocity = 10;
    Rigidbody miRigidbody; 
    Vector3 initialPosition;
    int coins = 0;
    int lifes = 3;
    public Text Points;
    public Text Lifes;
    
    // Start is called before the first frame update
    void Start()
    {
        miRigidbody = GetComponent<Rigidbody>(); 
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        miRigidbody.AddForce(new Vector3(horizontal, 0, vertical) * velocity);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Exit"))
        {
            Debug.Log("Muy bien, Ha finalizado el recorrido");
        } 
        else if (collision.CompareTag("Enemy"))
        {
            miRigidbody.MovePosition(initialPosition);
            miRigidbody.velocity = Vector3.zero;
            miRigidbody.angularVelocity = Vector3.zero;
            lifes = lifes - 1;
            Lifes.text = "Lifes: "+ lifes;
        } 
        else if (collision.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            coins = coins + 1;
            Points.text = "Points: " + coins;
        }
    }
}