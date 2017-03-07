using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour {

    private float angleX, angleZ ,angleXMax,angleZMax ,tempX,tempZ;
	// Use this for initialization
	void Start ()
    {
        angleX = 0;
        angleZ = 0;
        angleXMax = 20;
        angleZMax = 20;
        

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
              if (Mathf.Abs(angleX + moveVertical) <= angleXMax)
                {
                transform.RotateAround(Vector3.zero, Vector3.right, moveVertical);
                angleX += moveVertical;
            }
        }
        else
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
              if (Mathf.Abs(angleZ - moveHorizontal) <= angleZMax)
                {
                transform.RotateAround(Vector3.zero, Vector3.forward, -moveHorizontal);
                angleZ += -moveHorizontal;
            }
        }
    }
}
