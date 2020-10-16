using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaController : MonoBehaviour
{
    private const int ANIMATION_QUIETO=0;
        private const int ANIMATION_CORRER=1;
        private const int ANIMATION_SALTAR=2;
        private const int ANIMATION_DESLIZAR=3;
        private const int ANIMATION_PLANEAR=4;
        private const int ANIMATION_ATACAR=5;
        private const int ANIMATION_MORIR=6;
        private const int ANIMATION_ESCALAR=7;
        private Rigidbody2D rb;
        private Transform t;
        private Animator anim;
        private SpriteRenderer spri;
        public GameObject kunai;
        public GameObject leftkunai;
        public PuntajeController PuntajeController;
        public Text Textvidas;
        private int vidas = 3;
        private int aviso=0;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            t = GetComponent<Transform>();
            spri = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            rb.gravityScale = 10;
            t.position = new Vector3(-15, -8, 0);
            aviso = 0;

        }
    
        // Update is called once per frame
        void Update()
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.gravityScale = 10;
            anim.SetInteger("Estado", ANIMATION_QUIETO);
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(8, rb.velocity.y);
                anim.SetInteger("Estado", ANIMATION_CORRER);
                spri.flipX = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-8, rb.velocity.y);
                anim.SetInteger("Estado", ANIMATION_CORRER);
                spri.flipX = true;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetInteger("Estado", ANIMATION_SALTAR);
                rb.AddForce(new Vector2(0, 35), ForceMode2D.Impulse);
                
            }
            if(Input.GetKey(KeyCode.V)){
                anim.SetInteger("Estado",ANIMATION_PLANEAR);
                rb.gravityScale = 1;
                aviso = 0;
            }
           
            if (Input.GetKey(KeyCode.C))
            {
                
                anim.SetInteger("Estado", ANIMATION_DESLIZAR);
               
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (spri.flipX){
                    var kunaiposition= new Vector3(t.position.x-2f,t.position.y,t.position.z);
                    Instantiate(leftkunai,kunaiposition,Quaternion.identity);
                }
                else{
                    var kunaiposition2= new Vector3(t.position.x+2f,t.position.y,t.position.z);
                    Instantiate(kunai,kunaiposition2,Quaternion.identity);
                }
                anim.SetInteger("Estado", ANIMATION_ATACAR);
            }

            
            if (t.position.y > 4)
            {
                
                Debug.Log("aviso activado");
                aviso = 1;
            }
           
            if (t.position.y <-7 )
            {
                if (aviso==1)
                {
                    anim.SetInteger("Morir", ANIMATION_MORIR);
                }
                
            }
            
           
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "zombie")
            {
                vidas--;
                Destroy(other.gameObject);
                Debug.Log("Vidas"+vidas);
                Textvidas.text = "Vidas: "+vidas;
                if (vidas < 0)
                {
                    anim.SetInteger("Morir", ANIMATION_MORIR);
                    
                }
                
            }
        }
        private void OnTriggerStay2D(Collider2D other) {
           
           
            rb.velocity = new Vector2(rb.velocity.x, 0);
          
            if(other.gameObject.tag == "Escalera"){
                // Debug.Log("Esta chocando");
           
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                //anim.SetInteger("Escalar", ANIMATION_ESCALAR);
                if(Input.GetKey(KeyCode.UpArrow)){
                    rb.velocity = new Vector2(rb.velocity.x, 8); 
                
                }
                if(Input.GetKey(KeyCode.DownArrow)){
                    rb.velocity = new Vector2(rb.velocity.x, -8); 
                 
                }
            }
           
        }

      
}
