using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text winMessage;
    private Rigidbody rb;

    void Start()
    {
        winMessage.text = "";
        int rows = PlayerPrefs.GetInt("rows", 1);
        int columns = PlayerPrefs.GetInt("columns", 1);
        transform.position += new Vector3(-columns / 2, 0, rows / 2);
    }
    
    void OnCollisionEnter(Collision other)
    {        
        if (other.gameObject.CompareTag("goal") )
        {
            winMessage.text = "You win!";
            other.gameObject.SetActive(false);
            
        }
    }
    
}
