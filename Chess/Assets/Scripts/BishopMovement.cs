using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is called when Bishop is selected
//All the possible movements are checked and those movements are activated i.e the highlighplanes if only if the CheckOrNot returns false
//If CheckOrNot returns true then that plane is activated
public class BishopMovement : MonoBehaviour
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
        #region Cross Right Up
        a = x - 1;
        b = y + 1;
        while(a>=0 && b<=7)//Keeps on checking for possible movements until it encounters an enemy gamepiece or until the condition becomes false 
        {
            if(copy[a, b] == "")
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
            else if(controller.turn && copy[a, b].Contains("B "))
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
                break;
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
                break;
            }
            else
            {
                break;
            }
            a--;
            b++;
        }
        #endregion
        #region Cross Left Up
        a = x - 1;
        b = y - 1;
        while (a >= 0 && b >=0)//Keeps on checking for possible movements until it encounters an enemy gamepiece or until the condition becomes false
        {
            if (copy[a, b] == "")
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
                break;
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
                break;
            }
            else
            {
                break;
            }
            a--;
            b--;
        }
        #endregion
        #region Cross Right Bottom
        a = x + 1;
        b = y + 1;
        while (a <= 7 && b <= 7)//Keeps on checking for possible movements until it encounters an enemy gamepiece or until the condition becomes false
        {
            if (copy[a, b] == "")
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
                break;
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
                break;
            }
            else
            {
                break;
            }
            a++;
            b++;
        }
        #endregion
        #region Cross Left Bottom
        a = x + 1;
        b = y - 1;
        while (a <= 7 && b >= 0)//Keeps on checking for possible movements until it encounters an enemy gamepiece or until the condition becomes false
        {
            if (copy[a, b] == "")
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
                break;
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
                break;
            }
            else
            {
                break;
            }
            a++;
            b--;
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
