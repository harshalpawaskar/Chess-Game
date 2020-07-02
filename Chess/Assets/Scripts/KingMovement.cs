using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is called when King is selected
//All the possible movements are checked and those movements are activated i.e the highlighplanes if only if the CheckOrNot returns false
//If CheckOrNot returns true then that plane is activated
public class KingMovement : MonoBehaviour
{
    public GameController1 controller;
    public string[,] copy = new string[8, 8];//copy of chessBoardMatrix
    public Check check;
    string name1;
    string name2;
    int count;

    public void ActivatePlanes(int x, int y)
    {
        count = 0;
        int a, b;
        Color color = new Color(0.137f, 0.737f, 1f, 1f);
        GameObject.Find(controller.highLightTilesMatrix[x, y]).GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find(controller.highLightTilesMatrix[x, y]).GetComponent<MeshRenderer>().material.color = color;
        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x, y]);
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                copy[i, j] = controller.chessBoardMatrix[i, j];
            }
        }
        name1 = copy[x, y];
        #region UP-LEFT,UP,UP-RIGHT
        a = x - 1;
        b = y - 1;
        if(a>=0)
        {
            while(b<=y+1)
            {
                if (b >= 0 && b <= 7)
                {
                    if (controller.chessBoardMatrix[a, b] == "")
                    {
                        name2 = copy[a, b];
                        copy[a, b] = name1;
                        copy[x, y] = "";
                        if (!check.CheckOrNot(copy, controller.turn))
                        {
                            if (controller.helper)
                                GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().enabled = true;
                            GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().material.color = Color.green;
                            controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[a, b]);
                            count++;
                        }
                        copy[x, y] = name1;
                        copy[a, b] = name2;
                    }
                    else if (controller.turn && copy[a, b].Contains("B "))
                    {
                        name2 = copy[a, b];
                        copy[a, b] = name1;
                        copy[x, y] = "";
                        if (!check.CheckOrNot(copy, controller.turn))
                        {
                            if (controller.helper)
                                GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().enabled = true;
                            GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().material.color = Color.red;
                            controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[a, b]);
                            count++;
                        }
                        copy[x, y] = name1;
                        copy[a, b] = name2;
                    }
                    else if (!controller.turn && copy[a, b].Contains("W "))
                    {
                        name2 = copy[a, b];
                        copy[a, b] = name1;
                        copy[x, y] = "";
                        if (!check.CheckOrNot(copy, controller.turn))
                        {
                            if (controller.helper)
                                GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().enabled = true;
                            GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().material.color = Color.red;
                            controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[a, b]);
                            count++;
                        }
                        copy[x, y] = name1;
                        copy[a, b] = name2;
                    }
                }
                b++;
            }
        }
        #endregion
        #region DOWN-LEFT,DOWN,DOWN-RIGHT
        a = x + 1;
        b = y - 1;
        if (a<=7)
        {
            while (b <= y + 1)
            {
                if (b >= 0 && b <= 7)
                {
                    if (controller.chessBoardMatrix[a, b] == "")
                    {
                        name2 = copy[a, b];
                        copy[a, b] = name1;
                        copy[x, y] = "";
                        if (!check.CheckOrNot(copy, controller.turn))
                        {
                            if (controller.helper)
                                GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().enabled = true;
                            GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().material.color = Color.green;
                            controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[a, b]);
                            count++;
                        }
                        copy[x, y] = name1;
                        copy[a, b] = name2;
                    }
                    else if (controller.turn && copy[a, b].Contains("B "))
                    {
                        name2 = copy[a, b];
                        copy[a, b] = name1;
                        copy[x, y] = "";
                        if (!check.CheckOrNot(copy, controller.turn))
                        {
                            if (controller.helper)
                                GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().enabled = true;
                            GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().material.color = Color.red;
                            controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[a, b]);
                            count++;
                        }
                        copy[x, y] = name1;
                        copy[a, b] = name2;
                    }
                    else if (!controller.turn && copy[a, b].Contains("W "))
                    {
                        name2 = copy[a, b];
                        copy[a, b] = name1;
                        copy[x, y] = "";
                        if (!check.CheckOrNot(copy, controller.turn))
                        {
                            if (controller.helper)
                                GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().enabled = true;
                            GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().material.color = Color.red;
                            controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[a, b]);
                            count++;
                        }
                        copy[x, y] = name1;
                        copy[a, b] = name2;
                    }
                }
                b++;
            }
        }
        #endregion
        #region LEFT
        a = x;
        b = y - 1;
        if (b>=0)
        {
            if (controller.chessBoardMatrix[a, b] == "")
            {
                name2 = copy[a, b];
                copy[a, b] = name1;
                copy[x, y] = "";
                if (!check.CheckOrNot(copy, controller.turn))
                {
                    if (controller.helper)
                        GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().material.color = Color.green;
                    controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[a, b]);
                    count++;
                }
                copy[x, y] = name1;
                copy[a, b] = name2;
            }
            else if (controller.turn && copy[a, b].Contains("B "))
            {
                name2 = copy[a, b];
                copy[a, b] = name1;
                copy[x, y] = "";
                if (!check.CheckOrNot(copy, controller.turn))
                {
                    if (controller.helper)
                        GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().material.color = Color.red;
                    controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[a, b]);
                    count++;
                }
                copy[x, y] = name1;
                copy[a, b] = name2;
            }
            else if (!controller.turn && copy[a, b].Contains("W "))
            {
                name2 = copy[a, b];
                copy[a, b] = name1;
                copy[x, y] = "";
                if (!check.CheckOrNot(copy, controller.turn))
                {
                    if (controller.helper)
                        GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().material.color = Color.red;
                    controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[a, b]);
                    count++;
                }
                copy[x, y] = name1;
                copy[a, b] = name2;
            }
        }
        #endregion
        #region RIGHT
        a = x;
        b = y + 1;
        if (b <= 7)
        {
            if (controller.chessBoardMatrix[a, b] == "")
            {
                name2 = copy[a, b];
                copy[a, b] = name1;
                copy[x, y] = "";
                if (!check.CheckOrNot(copy, controller.turn))
                {
                    if (controller.helper)
                        GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().material.color = Color.green;
                    controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[a, b]);
                    count++;
                }
                copy[x, y] = name1;
                copy[a, b] = name2;
            }
            else if (controller.turn && copy[a, b].Contains("B "))
            {
                name2 = copy[a, b];
                copy[a, b] = name1;
                copy[x, y] = "";
                if (!check.CheckOrNot(copy, controller.turn))
                {
                    if (controller.helper)
                        GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().material.color = Color.red;
                    controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[a, b]);
                    count++;
                }
                copy[x, y] = name1;
                copy[a, b] = name2;
            }
            else if (!controller.turn && copy[a, b].Contains("W "))
            {
                name2 = copy[a, b];
                copy[a, b] = name1;
                copy[x, y] = "";
                if (!check.CheckOrNot(copy, controller.turn))
                {
                    if (controller.helper)
                        GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find(controller.highLightTilesMatrix[a, b]).GetComponent<MeshRenderer>().material.color = Color.red;
                    controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[a, b]);
                    count++;
                }
                copy[x, y] = name1;
                copy[a, b] = name2;
            }
        }
        #endregion
        #region White King Castling
        if (controller.turn && !controller.movedOrNot["W King"])
        {
            if(copy[7,1]=="" && copy[7,2]=="" && copy[7,3]=="" && copy[7,0].Contains("W Rook") && controller.movedOrNot.ContainsKey(copy[7, 0]))
            {
                if (!controller.movedOrNot[copy[7, 0]])
                {
                    copy[7, 3] = copy[7, 0];
                    copy[7, 2] = copy[x, y];
                    copy[x, y] = "";
                    copy[7, 0] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[7, 2]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[7, 2]).GetComponent<MeshRenderer>().material.color = Color.yellow;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[7, 2]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[7, 0] = copy[7, 3];
                    copy[7, 3] = "";
                    copy[7, 2] = "";
                }
            }
            if (copy[7, 5] == "" && copy[7, 6] == "" && copy[7, 7].Contains("W Rook") && controller.movedOrNot.ContainsKey(copy[7, 7]))
            {
                if (!controller.movedOrNot[copy[7, 7]])
                {
                    copy[7, 5] = copy[7, 7];
                    copy[7, 6] = copy[x, y];
                    copy[x, y] = "";
                    copy[7, 7] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[7, 6]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[7, 6]).GetComponent<MeshRenderer>().material.color = Color.yellow;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[7, 6]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[7, 7] = copy[7, 5];
                    copy[7, 5] = "";
                    copy[7, 6] = "";
                }
            }
        }
        #endregion
        #region Black King Castling
        if (!controller.turn && !controller.movedOrNot["B King"])
        {
            if (copy[0, 1] == "" && copy[0, 2] == "" && copy[0, 3] == "" && copy[0, 0].Contains("B Rook") && controller.movedOrNot.ContainsKey(copy[0, 0]))
            {
                if (!controller.movedOrNot[copy[0, 0]])
                {
                    copy[0, 3] = copy[0, 0];
                    copy[0, 2] = copy[x, y];
                    copy[x, y] = "";
                    copy[0, 0] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[0, 2]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[0, 2]).GetComponent<MeshRenderer>().material.color = Color.yellow;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[0, 2]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[0, 0] = copy[0, 3];
                    copy[0, 3] = "";
                    copy[0, 2] = "";
                }
            }
            if (copy[0, 5] == "" && copy[0, 6] == "" && copy[0, 7].Contains("B Rook") && controller.movedOrNot.ContainsKey(copy[0, 7]))
            {
                if (!controller.movedOrNot[copy[0, 7]])
                {
                    copy[0, 5] = copy[0, 7];
                    copy[0, 6] = copy[x, y];
                    copy[x, y] = "";
                    copy[0, 7] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[0, 6]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[0, 6]).GetComponent<MeshRenderer>().material.color = Color.yellow;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[0, 6]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[0, 7] = copy[0, 5];
                    copy[0, 5] = "";
                    copy[0, 6] = "";
                }
            }
        }
        #endregion
    }

    //Counts no. of activated planes.This function is called by Checkmate Script
    internal int getCount(int i, int j)
    {
        ActivatePlanes(i, j);
        return count;
    }
}
