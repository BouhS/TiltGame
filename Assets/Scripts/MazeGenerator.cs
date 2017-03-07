using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{

    public GameObject wall, floor, roof;
    private int MazeRows, MazeColumns;

    private MazeCell[,] maze;
    private Vector3 pos, vec, scale, floorPos, roofPos;
    private Quaternion rot;
    private float width, height;


    // Use this for initialization
    void Start()
    {

        PlayerPrefs.SetFloat("wallThickness", wall.transform.localScale.z);
        PlayerPrefs.SetFloat("floorWidth", floor.transform.localScale.x );
        PlayerPrefs.SetFloat("floorHeight", floor.transform.localScale.z );

        MazeRows = PlayerPrefs.GetInt("rows", 1);
        MazeColumns = PlayerPrefs.GetInt("columns", 1);

        Vector3 off = new Vector3(-MazeColumns / 2, 0, MazeRows / 2);
        pos = wall.transform.position + off;
        scale = wall.transform.localScale;
        floorPos = floor.transform.position + off;
        roofPos = roof.transform.position + off;
        width = floor.transform.localScale.x;
        height = floor.transform.localScale.z;
        InitMaze();
        KruskalAlgo();

    }



    //Initalize the Maze as a mesh of MazeRows*MazeColumns cells
    void InitMaze()
    {
        maze = new MazeCell[MazeRows, MazeColumns];

        for (int r = 0; r < MazeRows; r++)
        {
            for (int c = 0; c < MazeColumns; c++)
            {
                MazeCell mazeCell = new MazeCell(r, c);

                //create Floor
                vec.Set(floorPos.x + (c * width), floorPos.y, floorPos.z - (r * height));
                rot = Quaternion.Euler(0, 0, 0);
                mazeCell.Floor = Instantiate(floor, vec, rot);
                mazeCell.Floor.transform.parent = this.transform;
                mazeCell.Floor.name = "Floor " + r + " " + c + "";

                //create Roof
                vec.Set(roofPos.x + (c * width), roofPos.y, roofPos.z - (r * height));
                mazeCell.Roof = Instantiate(roof, vec, rot);
                mazeCell.Roof.transform.parent = this.transform;
                mazeCell.Roof.name = "Roof " + r + " " + c + "";

                if (r == 0){
                    //create NorthWall
                    vec.Set(pos.x + (c*width), pos.y, pos.z);
                    rot = Quaternion.Euler(0, 0, 0);

                    mazeCell.NWall = Instantiate(wall, vec, rot);
                    mazeCell.NWall.transform.parent = this.transform;
                    mazeCell.NWall.name = "North Wall " + r + " " + c + "";

                }else{
                    mazeCell.NWall = maze[r - 1, c].SWall;
                }
                
                //create SouthWall
                vec.Set(pos.x + (c * width), pos.y, pos.z - (r*height) - scale.x);
                rot = Quaternion.Euler(0, 0, 0);
                mazeCell.SWall = Instantiate(wall, vec, rot);
                mazeCell.SWall.transform.parent = this.transform;
                mazeCell.SWall.name = "South Wall " + r + " " + c + "";

                if (c == 0)
                {
                    //create WestWall
                    vec.Set(pos.x + (c * width) - (scale.x / 2), pos.y, pos.z - (r*height) - (scale.x / 2));
                    rot = Quaternion.Euler(0, 90, 0);
                    mazeCell.WWall = Instantiate(wall, vec, rot);
                    mazeCell.WWall.transform.parent = this.transform;
                    mazeCell.WWall.name = "West Wall " + r + " " + c + "";
                }
                else
                {
                    mazeCell.WWall = maze[r, c - 1].EWall;

                }

                //create EastWall
                vec.Set((pos.x + (c * width) + (scale.x / 2)), pos.y, pos.z - (r * height) - (scale.x / 2));
                rot = Quaternion.Euler(0, 90, 0);
                mazeCell.EWall = Instantiate(wall, vec, rot);
                mazeCell.EWall.transform.parent = this.transform;
                mazeCell.EWall.name = "East Wall " + r + " " + c + "";
                
                mazeCell.Val = MazeColumns * r + c;
                maze[r, c] = mazeCell;
            }
        }
        maze[MazeRows - 1, MazeColumns - 1].Floor.tag = "goal";
        maze[MazeRows - 1, MazeColumns - 1].Floor.GetComponent<Renderer>().material.color = new Color(1, 0, 0);

    }

    //isNotConnected(r,c,w) returns false if the w wall of the cell[r,c] connects it to another cell,  true otherwise
    bool isNotConnected(int r, int c, int w)
    {
        return ((r == 0 && w == 0) || (r == MazeRows - 1 && w == 1)  || (c == MazeColumns - 1 && w == 2) || (c == 0 && w == 3));

    }

    /*spreadValue(row,column,way,value) spreads value to the cell[row,columns] and its neighbors  */
    void spreadValue(int r, int c, int w, int val)
    {
        maze[r, c].Val = val;
        switch (w)
        {
            case 0://North
                if (r > 0 && maze[r, c].NWall == null)//No wall North
                {
                    if (maze[r - 1, c].Val != val)
                    {
                        spreadValue(r - 1, c, 0, val);
                    }
                }
                if (c < MazeColumns - 1 && maze[r, c].EWall == null)//No wall East
                {
                    if (maze[r, c + 1].Val != val)
                    {
                        spreadValue(r, c + 1, 2, val);
                    }

                }
                if (c > 0 && maze[r, c].WWall == null)//No wall West
                {
                    if (maze[r, c - 1].Val != val)
                    {
                        spreadValue(r, c - 1, 3, val);
                    }

                }

                break;
            case 1://South
                if (r < MazeRows - 1 && maze[r, c].SWall == null)//No Wall south
                {
                    if (maze[r + 1, c].Val != val)
                    {
                        spreadValue(r + 1, c, 1, val);
                    }
                }
                if (c < MazeColumns - 1 && maze[r, c].EWall == null)
                {
                    if (maze[r, c + 1].Val != val)
                    {
                        spreadValue(r, c + 1, 2, val);
                    }

                }
                if (c > 0 && maze[r, c].WWall == null)
                {
                    if (maze[r, c - 1].Val != val)
                    {
                        spreadValue(r, c - 1, 3, val);
                    }

                }

                break;
            case 2://East

                if (r > 0 && maze[r, c].NWall == null)
                {
                    if (maze[r - 1, c].Val != val)
                    {
                        spreadValue(r - 1, c, 0, val);
                    }
                }

                if (r < MazeRows - 1 && maze[r, c].SWall == null)
                {
                    if (maze[r + 1, c].Val != val)
                    {
                        spreadValue(r + 1, c, 1, val);
                    }
                }
                if (c < MazeColumns - 1 && maze[r, c].EWall == null)
                {
                    if (maze[r, c + 1].Val != val)
                    {
                        spreadValue(r, c + 1, 2, val);
                    }

                }
                break;
            case 3://West
                if (r > 0 && maze[r, c].NWall == null)
                {
                    if (maze[r - 1, c].Val != val)
                    {
                        spreadValue(r - 1, c, 0, val);
                    }
                }

                if (r < MazeRows - 1 && maze[r, c].SWall == null)
                {
                    if (maze[r + 1, c].Val != val)
                    {
                        spreadValue(r + 1, c, 1, val);
                    }
                }
                if (c > 0 && maze[r, c].WWall == null)
                {
                    if (maze[r, c - 1].Val != val)
                    {
                        spreadValue(r, c - 1, 3, val);
                    }

                }
                break;
        }
        return;

    }

    //Kruskal algorithm to compute a maze
    void KruskalAlgo()
    {
        int rRand, cRand, wRand;
        int groupNb = MazeColumns * MazeRows;
        int count = 1;
        int MAX = (MazeColumns * MazeRows) * 10;
        while (groupNb > 1 && count < MAX)
        {
            //Randomly picking a cell and its wall
            rRand = Random.Range(0, MazeRows );
            cRand = Random.Range(0, MazeColumns );
            wRand = Random.Range(0, 4);

            //Not OutOfBound
            if (!isNotConnected(rRand, cRand, wRand))
            {
                switch (wRand)
                {
                    case 0:
                        //If wall is there AND the value of this cell and its neighbor differ
                        if (maze[rRand, cRand].NWall != null && maze[rRand, cRand].Val != maze[rRand - 1, cRand].Val)
                        {
                            //Destroy the wall
                            Destroy(maze[rRand, cRand].NWall);
                            maze[rRand, cRand].NWall = null;
                            maze[rRand - 1, cRand].SWall = null;
                            //Spread the value
                            spreadValue(rRand - 1, cRand, wRand, maze[rRand, cRand].Val);
                            groupNb--;
                        }
                        break;
                    case 1:
                        if (maze[rRand, cRand].SWall != null && maze[rRand, cRand].Val != maze[rRand + 1, cRand].Val)
                        {
                            Destroy(maze[rRand, cRand].SWall);
                            maze[rRand, cRand].SWall = null;
                            maze[rRand + 1, cRand].NWall = null;
                            spreadValue(rRand + 1, cRand, wRand, maze[rRand, cRand].Val);
                            groupNb--;
                        }

                        break;
                    case 2:
                        if (maze[rRand, cRand].EWall != null && maze[rRand, cRand].Val != maze[rRand, cRand + 1].Val)
                        {
                            Destroy(maze[rRand, cRand].EWall);
                            maze[rRand, cRand].EWall = null;
                            maze[rRand, cRand + 1].WWall = null;
                            spreadValue(rRand, cRand + 1, wRand, maze[rRand, cRand].Val);
                            groupNb--;
                        }
                        break;
                    case 3:
                        if (maze[rRand, cRand].WWall != null && maze[rRand, cRand].Val != maze[rRand, cRand - 1].Val)
                        {
                            Destroy(maze[rRand, cRand].WWall);
                            maze[rRand, cRand].WWall = null;
                            maze[rRand, cRand - 1].EWall = null;
                            spreadValue(rRand, cRand - 1, wRand, maze[rRand, cRand].Val);
                            groupNb--;
                        }
                        break;
                }
            }


            count++;
        }

    }
}
