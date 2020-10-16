using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenZombieController : MonoBehaviour
{
    private Transform tr;
    public GameObject zombie;
    private int valor = 0;
    private float t=3.0f;
    void Start()
    {
        tr = GetComponent<Transform>();
        valor = Random.Range(5,10);
       // Debug.Log("aleatorio"+valor);
        
    }
    // Update is called once per frame
    void Update()
    {
        
        t += Time.deltaTime;
       // Debug.Log("Tiempo: "+t);
        if (valor<=t)
        {
            valor = Random.Range(4,9);
            Debug.Log("aleatorio"+valor);
            t = 0;
            Instantiate(zombie,transform.position,Quaternion.identity);
        }
        
    }
}
