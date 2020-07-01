using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    public GameController1 controller;
    public string[,] copy = new string[8, 8];
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
        if(x-2>=0)//UP
        {
            if(y+1<=7)//UP-RIGHT
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
            if(y-1>=0)//UP-LEFT
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
        }
        if(x+2<=7)//DOWN
        {
            if(y+1<=7)//DOWN-RIGHT
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
            if(y-1>=0)//DOWN-LEFT
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
        }
        if(y-2>=0)//LEFT
        {
            if(x+1<=7)//LEFT-DOWN
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
            if(x-1>=0)//LEFT-UP
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
        }
        if(y+2<=7)//RIGHT
        {
            if(x+1<=7)//RIGHT-DOWN
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
            if(x-1>=0)//RIGHT-UP
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
        }
    }
    internal int getCount(int i, int j)
    {
        ActivatePlanes(i, j);
        return count;
    }
}
