using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell  {

    private GameObject floor;
    private GameObject roof;
    private GameObject nWall;
    private GameObject sWall;
    private GameObject eWall;
    private GameObject wWall;
    private int val;
    private int c, r;

    public GameObject Floor { get; set; }
    public GameObject Roof { get; set; }
    public GameObject NWall { get; set; }
    public GameObject SWall { get; set; }
    public GameObject EWall { get; set; }
    public GameObject WWall { get; set; }
    public int Val { get; set; }


    //Constructor
    public MazeCell(int r, int c)
    {
        this.c = c;
        this.r = r;
    }
    
    

}
