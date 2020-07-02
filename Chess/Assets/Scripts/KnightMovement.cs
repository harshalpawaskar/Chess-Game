using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is called when Knight is selected
//All the possible movements are checked and those movements are activated i.e the highlighplanes if only if the CheckOrNot returns false
//If CheckOrNot returns true then that plane is activated
public class KnightMovement : MonoBehaviour
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
        #region UP
        if (x-2>=0)
        {
            #region UP-RIGHT
            if (y+1<=7)
            {
                if (controller.chessBoardMatrix[x - 2, y + 1] == "")
                {
                    name2 = copy[x - 2, y + 1];
                    copy[x - 2, y + 1] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x - 2, y + 1]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x - 2, y + 1]).GetComponent<MeshRenderer>().material.color = Color.green;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 2, y + 1]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x - 2, y + 1] = name2;
                }
                if (controller.turn && copy[x - 2, y + 1].Contains("B "))
                {
                    name2 = copy[x - 2, y + 1];
                    copy[x - 2, y + 1] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x - 2, y + 1]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x - 2, y + 1]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 2, y + 1]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x - 2, y + 1] = name2;
                }
                if (!controller.turn && copy[x - 2, y + 1].Contains("W "))
                {
                    name2 = copy[x - 2, y + 1];
                    copy[x - 2, y + 1] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x - 2, y + 1]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x - 2, y + 1]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 2, y + 1]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x - 2, y + 1] = name2;
                }
            }
            #endregion
            #region UP-LEFT
            if (y-1>=0)
            {
                if (controller.chessBoardMatrix[x - 2, y - 1] == "")
                {
                    name2 = copy[x - 2, y - 1];
                    copy[x - 2, y - 1] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x - 2, y - 1]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x - 2, y - 1]).GetComponent<MeshRenderer>().material.color = Color.green;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 2, y - 1]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x - 2, y - 1] = name2;
                }
                if (controller.turn && copy[x - 2, y - 1].Contains("B "))
                {
                    name2 = copy[x - 2, y - 1];
                    copy[x - 2, y - 1] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x - 2, y - 1]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x - 2, y - 1]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 2, y - 1]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x - 2, y - 1] = name2;
                }
                if (!controller.turn && copy[x - 2, y - 1].Contains("W "))
                {
                    name2 = copy[x - 2, y - 1];
                    copy[x - 2, y - 1] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x - 2, y - 1]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x - 2, y - 1]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 2, y - 1]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x - 2, y - 1] = name2;
                }
            }
            #endregion
        }
        #endregion
        #region DOWN
        if (x+2<=7)
        {
            #region DOWN-RIGHT
            if (y+1<=7)
            {
                if (controller.chessBoardMatrix[x + 2, y + 1] == "")
                {
                    name2 = copy[x + 2, y + 1];
                    copy[x + 2, y + 1] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x + 2, y + 1]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x + 2, y + 1]).GetComponent<MeshRenderer>().material.color = Color.green;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 2, y + 1]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x + 2, y + 1] = name2;
                }
                if (controller.turn && copy[x + 2, y + 1].Contains("B "))
                {
                    name2 = copy[x + 2, y + 1];
                    copy[x + 2, y + 1] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x + 2, y + 1]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x + 2, y + 1]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 2, y + 1]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x + 2, y + 1] = name2;
                }
                if (!controller.turn && copy[x + 2, y + 1].Contains("W "))
                {
                    name2 = copy[x + 2, y + 1];
                    copy[x + 2, y + 1] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x + 2, y + 1]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x + 2, y + 1]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 2, y + 1]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x + 2, y + 1] = name2;
                }
            }
            #endregion
            #region DOWN-LEFT
            if (y-1>=0)
            {
                if (controller.chessBoardMatrix[x + 2, y - 1] == "")
                {
                    name2 = copy[x + 2, y - 1];
                    copy[x + 2, y - 1] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x + 2, y - 1]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x + 2, y - 1]).GetComponent<MeshRenderer>().material.color = Color.green;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 2, y - 1]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x + 2, y - 1] = name2;
                }
                if (controller.turn && copy[x + 2, y - 1].Contains("B "))
                {
                    name2 = copy[x + 2, y - 1];
                    copy[x + 2, y - 1] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x + 2, y - 1]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x + 2, y - 1]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 2, y - 1]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x + 2, y - 1] = name2;
                }
                if (!controller.turn && copy[x + 2, y - 1].Contains("W "))
                {
                    name2 = copy[x + 2, y - 1];
                    copy[x + 2, y - 1] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x + 2, y - 1]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x + 2, y - 1]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 2, y - 1]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x + 2, y - 1] = name2;
                }
            }
            #endregion
        }
        #endregion
        #region LEFT
        if (y-2>=0)
        {
            #region LEFT-DOWN
            if (x+1<=7)
            {
                if (controller.chessBoardMatrix[x + 1, y - 2] == "")
                {
                    name2 = copy[x + 1, y - 2];
                    copy[x + 1, y - 2] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x + 1, y - 2]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x + 1, y - 2]).GetComponent<MeshRenderer>().material.color = Color.green;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 1, y - 2]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x + 1, y - 2] = name2;
                }
                if (controller.turn && copy[x + 1, y - 2].Contains("B "))
                {
                    name2 = copy[x + 1, y - 2];
                    copy[x + 1, y - 2] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x + 1, y - 2]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x + 1, y - 2]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 1, y - 2]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x + 1, y - 2] = name2;
                }
                if (!controller.turn && copy[x + 1, y - 2].Contains("W "))
                {
                    name2 = copy[x + 1, y - 2];
                    copy[x + 1, y - 2] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x + 1, y - 2]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x + 1, y - 2]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 1, y - 2]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x + 1, y - 2] = name2;
                }
            }
            #endregion
            #region LEFT-UP
            if (x-1>=0)
            {
                if (controller.chessBoardMatrix[x - 1, y - 2] == "")
                {
                    name2 = copy[x - 1, y - 2];
                    copy[x - 1, y - 2] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x - 1, y - 2]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x - 1, y - 2]).GetComponent<MeshRenderer>().material.color = Color.green;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 1, y - 2]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x - 1, y - 2] = name2;
                }
                if (controller.turn && copy[x - 1, y - 2].Contains("B "))
                {
                    name2 = copy[x - 1, y - 2];
                    copy[x - 1, y - 2] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x - 1, y - 2]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x - 1, y - 2]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 1, y - 2]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x - 1, y - 2] = name2;
                }
                if (!controller.turn && copy[x - 1, y - 2].Contains("W "))
                {
                    name2 = copy[x - 1, y - 2];
                    copy[x - 1, y - 2] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x - 1, y - 2]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x - 1, y - 2]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 1, y - 2]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x - 1, y - 2] = name2;
                }
            }
            #endregion
        }
        #endregion
        #region RIGHT
        if (y+2<=7)
        {
            #region RIGHT-DOWN
            if (x+1<=7)
            {
                if (controller.chessBoardMatrix[x + 1, y + 2] == "")
                {
                    name2 = copy[x + 1, y + 2];
                    copy[x + 1, y + 2] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x + 1, y + 2]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x + 1, y + 2]).GetComponent<MeshRenderer>().material.color = Color.green;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 1, y + 2]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x + 1, y + 2] = name2;
                }
                if (controller.turn && copy[x + 1, y + 2].Contains("B "))
                {
                    name2 = copy[x + 1, y + 2];
                    copy[x + 1, y + 2] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x + 1, y + 2]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x + 1, y + 2]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 1, y + 2]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x + 1, y + 2] = name2;
                }
                if (!controller.turn && copy[x + 1, y + 2].Contains("W "))
                {
                    name2 = copy[x + 1, y + 2];
                    copy[x + 1, y + 2] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x + 1, y + 2]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x + 1, y + 2]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 1, y + 2]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x + 1, y + 2] = name2;
                }
            }
            #endregion
            #region RIGHT-UP
            if (x-1>=0)
            {
                if (controller.chessBoardMatrix[x - 1, y + 2] == "")
                {
                    name2 = copy[x - 1, y + 2];
                    copy[x - 1, y + 2] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x - 1, y + 2]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x - 1, y + 2]).GetComponent<MeshRenderer>().material.color = Color.green;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 1, y + 2]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x - 1, y + 2] = name2;
                }
                if (controller.turn && copy[x - 1, y + 2].Contains("B "))
                {
                    name2 = copy[x - 1, y + 2];
                    copy[x - 1, y + 2] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x - 1, y + 2]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x - 1, y + 2]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 1, y + 2]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x - 1, y + 2] = name2;
                }
                if (!controller.turn && copy[x - 1, y + 2].Contains("W "))
                {
                    name2 = copy[x - 1, y + 2];
                    copy[x - 1, y + 2] = name1;
                    copy[x, y] = "";
                    if (!check.CheckOrNot(copy, controller.turn))
                    {
                        if (controller.helper)
                            GameObject.Find(controller.highLightTilesMatrix[x - 1, y + 2]).GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find(controller.highLightTilesMatrix[x - 1, y + 2]).GetComponent<MeshRenderer>().material.color = Color.red;
                        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 1, y + 2]);
                        count++;
                    }
                    copy[x, y] = name1;
                    copy[x - 1, y + 2] = name2;
                }
            }
            #endregion
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
