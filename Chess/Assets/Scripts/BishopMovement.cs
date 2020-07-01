using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopMovement : MonoBehaviour
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
        //Cross Right Up
        a = x - 1;
        b = y + 1;
        while(a>=0 && b<=7)
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
        //Cross Left Up
        a = x - 1;
        b = y - 1;
        while (a >= 0 && b >=0)
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
        //Cross Right Bottom
        a = x + 1;
        b = y + 1;
        while (a <= 7 && b <= 7)
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
        //Cross Left Bottom
        a = x + 1;
        b = y - 1;
        while (a <= 7 && b >= 0)
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
    }
    internal int getCount(int i, int j)
    {
        ActivatePlanes(i, j);
        return count;
    }
}
