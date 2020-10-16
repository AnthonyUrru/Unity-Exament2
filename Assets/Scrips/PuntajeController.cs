using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeController : MonoBehaviour
{
    private int points = 0;
    public Text puntajeText;
    public void AddPoints(int points)
    {
        this.points += points;
        puntajeText.text = "Puntaje: " + this.points;
    }
    public int GetPoins() 
    {
        return points;
    }
}
