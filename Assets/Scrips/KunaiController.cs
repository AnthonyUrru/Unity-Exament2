using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    public float velocityx = 10f;
    private Rigidbody2D rb;
    private PuntajeController PuntajeController;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PuntajeController = FindObjectOfType<PuntajeController>();
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=new Vector2(velocityx,rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "zombie")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            PuntajeController.AddPoints(10);
            
        }
    }
}
