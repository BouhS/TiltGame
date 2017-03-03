using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text winMessage;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        winMessage.text = "";

        int rows = PlayerPrefs.GetInt("rows", 1);
        int columns = PlayerPrefs.GetInt("columns", 1);
        transform.position += new Vector3(-rows / 2, 0, columns / 2);
        

    }
    
    void OnCollisionEnter(Collision other)
    {        
        if (other.gameObject.CompareTag("goal") )
        {
            winMessage.text = "You win!";
            
        }
    }
    
}
