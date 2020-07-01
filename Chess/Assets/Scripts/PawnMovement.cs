using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : MonoBehaviour
{
    public GameController1 controller;
    public string[,] copy = new string[8,8];
    public Check check;
    public GameObject blackSummon;
    public GameObject whiteSummon;
    public GameObject[] summonPieces;
    public Transform parent;
    string name1;
    string name2;
    int count;
    public int xpos, ypos;
    public bool move = false;
    Vector3 endposition;
    public RaycastHit hit2;
    public float movementSpeed;
    public Rewind rewind;
    public GameObject enpassantTextObject;

    public void ActivatePlanes(int x, int y)
    {
        count = 0;
        Color color = new Color(0.137f, 0.737f, 1f, 1f);
        GameObject.Find(controller.highLightTilesMatrix[x, y]).GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find(controller.highLightTilesMatrix[x, y]).GetComponent<MeshRenderer>().material.color = color;
        controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x, y]);
        for (int i=0;i<8;i++)
        {
            for(int j=0;j<8;j++)
            {
                copy[i, j] = controller.chessBoardMatrix[i, j];
            }
        }
        name1 = copy[x, y];
        if (controller.turn)
        {
            if(copy[x-1,y]=="")
            {
                name2 = copy[x-1, y];
                copy[x - 1, y] = name1;
                copy[x, y] = "";
                if (!check.CheckOrNot(copy, controller.turn))
                {
                    if (controller.helper)
                        GameObject.Find(controller.highLightTilesMatrix[x - 1, y]).GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find(controller.highLightTilesMatrix[x - 1, y]).GetComponent<MeshRenderer>().material.color = Color.green;
                    controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 1, y]);
                    count++;
                }
                copy[x, y] = name1;
                copy[x - 1, y] = name2;
                if (x==6)
                {
                    if (copy[x - 2, y] == "")
                    {
                        name2 = copy[x - 2, y];
                        copy[x - 2, y] = name1;
                        copy[x, y] = "";
                        if (!check.CheckOrNot(copy, controller.turn))
                        {
                            if (controller.helper)
                                GameObject.Find(controller.highLightTilesMatrix[x - 2, y]).GetComponent<MeshRenderer>().enabled = true;
                            GameObject.Find(controller.highLightTilesMatrix[x - 2, y]).GetComponent<MeshRenderer>().material.color = Color.green;
                            controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 2, y]);
                            count++;
                        }
                        copy[x - 2, y] = name2;
                        copy[x, y] = name1;
                    }
                }
            }
            if (y != 0 && copy[x - 1, y - 1].Contains("B "))
            {
                name2 = copy[x - 1, y - 1];
                copy[x - 1, y - 1] = name1;
                copy[x, y] = "";
                if (!check.CheckOrNot(copy, controller.turn))
                {
                    if (controller.helper)
                        GameObject.Find(controller.highLightTilesMatrix[x - 1, y - 1]).GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find(controller.highLightTilesMatrix[x - 1, y - 1]).GetComponent<MeshRenderer>().material.color = Color.red;
                    controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 1, y - 1]);
                    count++;
                }
                copy[x - 1, y - 1] = name2;
                copy[x, y] = name1;
            }
            else
            {
                if (x == 3 && y != 0 && copy[x, y - 1].Contains("B Pawn"))
                {
                    if (controller.pawnFirstMove[copy[x, y - 1]] == 1)
                    {
                        name2 = copy[x, y - 1];
                        copy[x, y - 1] = "";
                        copy[x, y] = "";
                        copy[x - 1, y - 1] = name1;
                        if (!check.CheckOrNot(copy, controller.turn))
                        {
                            if (controller.helper)
                                GameObject.Find(controller.highLightTilesMatrix[x - 1, y - 1]).GetComponent<MeshRenderer>().enabled = true;
                            GameObject.Find(controller.highLightTilesMatrix[x - 1, y - 1]).GetComponent<MeshRenderer>().material.color = Color.green;
                            controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 1, y - 1]);
                            count++;
                        }
                        copy[x, y - 1] = name2;
                        copy[x, y] = name1;
                        copy[x - 1, y - 1] = "";
                    }
                }
            }
            if (y != 7 && copy[x - 1, y + 1].Contains("B "))
            {
                name2 = copy[x - 1, y + 1];
                copy[x - 1, y + 1] = name1;
                copy[x, y] = "";
                if (!check.CheckOrNot(copy, controller.turn))
                {
                    if (controller.helper)
                        GameObject.Find(controller.highLightTilesMatrix[x - 1, y + 1]).GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find(controller.highLightTilesMatrix[x - 1, y + 1]).GetComponent<MeshRenderer>().material.color = Color.red;
                    controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 1, y + 1]);
                    count++;
                }
                copy[x - 1, y + 1] = name2;
                copy[x, y] = name1;
            }
            else
            {
                if (x == 3 && y != 7 && copy[x, y + 1].Contains("B Pawn"))
                {
                    if (controller.pawnFirstMove[copy[x, y + 1]] == 1)
                    {
                        copy[x, y + 1] = "";
                        copy[x, y] = "";
                        copy[x - 1, y + 1] = name1;
                        if (!check.CheckOrNot(copy, controller.turn))
                        {
                            if (controller.helper)
                                GameObject.Find(controller.highLightTilesMatrix[x - 1, y + 1]).GetComponent<MeshRenderer>().enabled = true;
                            GameObject.Find(controller.highLightTilesMatrix[x - 1, y + 1]).GetComponent<MeshRenderer>().material.color = Color.green;
                            controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x - 1, y + 1]);
                            count++;
                        }
                        copy[x, y + 1] = name2;
                        copy[x, y] = name1;
                        copy[x - 1, y + 1] = "";
                    }
                }
            }
        }
        else
        {
            if (copy[x + 1, y] == "")
            {
                name2 = copy[x + 1, y];
                copy[x + 1, y] = name1;
                copy[x, y] = "";
                if (!check.CheckOrNot(copy, controller.turn))
                {
                    if (controller.helper)
                        GameObject.Find(controller.highLightTilesMatrix[x + 1, y]).GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find(controller.highLightTilesMatrix[x + 1, y]).GetComponent<MeshRenderer>().material.color = Color.green;
                    controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 1, y]);
                    count++;
                }
                copy[x, y] = name1;
                copy[x + 1, y] = name2;
                if (x == 1)
                {
                    if (copy[x + 2, y] == "")
                    {
                        name2 = copy[x + 2, y];
                        copy[x + 2, y] = name1;
                        copy[x, y] = "";
                        if (!check.CheckOrNot(copy, controller.turn))
                        {
                            if (controller.helper)
                                GameObject.Find(controller.highLightTilesMatrix[x + 2, y]).GetComponent<MeshRenderer>().enabled = true;
                            GameObject.Find(controller.highLightTilesMatrix[x + 2, y]).GetComponent<MeshRenderer>().material.color = Color.green;
                            controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 2, y]);
                            count++;
                        }
                        copy[x + 2, y] = name2;
                        copy[x, y] = name1;
                    }
                }
            }
            if (y != 0 && copy[x + 1, y - 1].Contains("W "))
            {
                name2 = copy[x + 1, y - 1];
                copy[x + 1, y - 1] = name1;
                copy[x, y] = "";
                if (!check.CheckOrNot(copy, controller.turn))
                {
                    if (controller.helper)
                        GameObject.Find(controller.highLightTilesMatrix[x + 1, y - 1]).GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find(controller.highLightTilesMatrix[x + 1, y - 1]).GetComponent<MeshRenderer>().material.color = Color.red;
                    controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 1, y - 1]);
                    count++;
                }
                copy[x + 1, y - 1] = name2;
                copy[x, y] = name1;
            }
            else
            {
                if (x == 4 && y != 0 && copy[x, y - 1].Contains("W Pawn"))
                {
                    if (controller.pawnFirstMove[copy[x, y - 1]] == 1)
                    {
                        name2 = copy[x, y - 1];
                        copy[x, y - 1] = "";
                        copy[x, y] = "";
                        copy[x + 1, y - 1] = name1;
                        if (!check.CheckOrNot(copy, controller.turn))
                        {
                            if (controller.helper)
                                GameObject.Find(controller.highLightTilesMatrix[x + 1, y - 1]).GetComponent<MeshRenderer>().enabled = true;
                            GameObject.Find(controller.highLightTilesMatrix[x + 1, y - 1]).GetComponent<MeshRenderer>().material.color = Color.green;
                            controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 1, y - 1]);
                            count++;
                        }
                        copy[x, y - 1] = name2;
                        copy[x, y] = name1;
                        copy[x + 1, y - 1] = "";
                    }
                }
            }
            if (y != 7 && copy[x + 1, y + 1].Contains("W "))
            {
                name2 = copy[x + 1, y + 1];
                copy[x + 1, y + 1] = name1;
                copy[x, y] = "";
                if (!check.CheckOrNot(copy, controller.turn))
                {
                    if (controller.helper)
                        GameObject.Find(controller.highLightTilesMatrix[x + 1, y + 1]).GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find(controller.highLightTilesMatrix[x + 1, y + 1]).GetComponent<MeshRenderer>().material.color = Color.red;
                    controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 1, y + 1]);
                    count++;
                }
                copy[x + 1, y + 1] = name2;
                copy[x, y] = name1;
            }
            else
            {
                if (x == 4 && y != 7 && copy[x, y + 1].Contains("W Pawn"))
                {
                    if (controller.pawnFirstMove[copy[x, y + 1]] == 1)
                    {
                        copy[x, y + 1] = "";
                        copy[x, y] = "";
                        copy[x + 1, y + 1] = name1;
                        if (!check.CheckOrNot(copy, controller.turn))
                        {
                            if (controller.helper)
                                GameObject.Find(controller.highLightTilesMatrix[x + 1, y + 1]).GetComponent<MeshRenderer>().enabled = true;
                            GameObject.Find(controller.highLightTilesMatrix[x + 1, y + 1]).GetComponent<MeshRenderer>().material.color = Color.green;
                            controller.activatedPlanesNames.Add(controller.highLightTilesMatrix[x + 1, y + 1]);
                            count++;
                        }
                        copy[x, y + 1] = name2;
                        copy[x, y] = name1;
                        copy[x + 1, y + 1] = "";
                    }
                }
            }
        }
    }

    internal int getCount(int i, int j)
    {
        ActivatePlanes(i, j);
        return count;
    }

    internal void MoveSelected(RaycastHit hit, RaycastHit hit1, int x, int y)
    {
        int a = 0, b = 0;
        controller.HighLightTilesPosition(hit,ref a, ref b);
        xpos = a;
        ypos = b;
        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("HightlightPlane"))
        {
            if (hit.transform.GetComponent<MeshRenderer>().material.color == Color.green)
            {
                if (hit1.collider.name.Contains("W "))
                {
                    hit2 = hit1;
                    endposition = hit.transform.position;
                    GameObject.Find(hit2.collider.name).GetComponent<BoxCollider>().enabled = false;
                    movementSpeed = Vector3.Distance(hit2.transform.position, endposition) * 2f;
                    move = true;
                    rewind.StoreValues(x, y, a, b, controller.turn, "Normal", hit1.collider.name, "",controller.pawnFirstMove, controller.movedOrNot);
                    if (a == 4 && x == 6)
                    {
                        //rewind.StoreValues(x, y, a, b, controller.turn, "PawnFirstMove", hit1.collider.name, "", controller.pawnFirstMove, controller.movedOrNot);
                        controller.pawnFirstMove[hit1.collider.name] = 1;
                    }
                    else if (a == x - 1 && (b == y - 1 || b == y + 1))
                    {
                        GameObject.Find(controller.chessBoardMatrix[a + 1, b]).SetActive(false);
                        rewind.StoreValues(x, y, a, b, controller.turn, "Enpassant", hit1.collider.name, "", controller.pawnFirstMove, controller.movedOrNot);
                        rewind.StoreExtraValues(a + 1, b, -1, -1, controller.chessBoardMatrix[a + 1, b], "");
                        controller.chessBoardMatrix[a + 1, b] = "";
                        enpassantTextObject.SetActive(true);
                        StartCoroutine(EnpassantTextWait());
                    }
                    if (a == 0)
                        rewind.StoreValues(x, y, a, b, controller.turn, "Summoning", hit1.collider.name, "", controller.pawnFirstMove, controller.movedOrNot);
                    controller.ChangeValues();
                }
                else if (hit1.collider.name.Contains("B "))
                {
                    hit2 = hit1;
                    endposition = hit.transform.position;
                    GameObject.Find(hit2.collider.name).GetComponent<BoxCollider>().enabled = false;
                    movementSpeed = Vector3.Distance(hit2.transform.position, endposition) * 2f;
                    move = true;
                    rewind.StoreValues(x, y, a, b, controller.turn, "Normal", hit1.collider.name, "", controller.pawnFirstMove, controller.movedOrNot);
                    if (a == 3 && x == 1)
                    {
                        //rewind.StoreValues(x, y, a, b, controller.turn, "PawnFirstMove", hit1.collider.name, "", controller.pawnFirstMove, controller.movedOrNot);
                        controller.pawnFirstMove[hit1.collider.name] = 1;
                    }
                    else
                    {
                        if (a == x + 1 && (b == y - 1 || b == y + 1))
                        {
                            GameObject.Find(controller.chessBoardMatrix[a - 1, b]).SetActive(false);
                            rewind.StoreValues(x, y, a, b, controller.turn, "Enpassant", hit1.collider.name, "", controller.pawnFirstMove, controller.movedOrNot);
                            rewind.StoreExtraValues(a - 1, b, -1, -1, controller.chessBoardMatrix[a - 1, b], "");
                            controller.chessBoardMatrix[a - 1, b] = "";
                            enpassantTextObject.SetActive(true);
                            StartCoroutine(EnpassantTextWait());
                        }
                    }
                    if (a == 7)
                        rewind.StoreValues(x, y, a, b, controller.turn, "Summoning", hit1.collider.name, "", controller.pawnFirstMove, controller.movedOrNot);
                    controller.ChangeValues();
                }
            }
            if (hit.transform.GetComponent<MeshRenderer>().material.color == Color.red)
            {
                GameObject.Find(controller.chessBoardMatrix[a, b]).SetActive(false);
                hit2 = hit1;
                endposition = hit.transform.position;
                GameObject.Find(hit2.collider.name).GetComponent<BoxCollider>().enabled = false;
                movementSpeed = Vector3.Distance(hit2.transform.position, endposition) * 2f;
                move = true;
                rewind.StoreValues(x, y, a, b, controller.turn, "Killed", hit1.collider.name, controller.chessBoardMatrix[a, b], controller.pawnFirstMove, controller.movedOrNot);
                if(hit1.collider.name.Contains("W ") && a==0)
                    rewind.StoreValues(x, y, a, b, controller.turn, "Summoning", hit1.collider.name, controller.chessBoardMatrix[a, b], controller.pawnFirstMove, controller.movedOrNot);
                if(hit1.collider.name.Contains("B ") && a == 7)
                    rewind.StoreValues(x, y, a, b, controller.turn, "Summoning", hit1.collider.name, controller.chessBoardMatrix[a, b], controller.pawnFirstMove, controller.movedOrNot);
                controller.ChangeValues();
            }
        }
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (String.Compare(hit1.collider.name, controller.chessBoardMatrix[i, j]) == 0)
                {
                    a = i;
                    b = j;
                    goto brk;
                }
            }
        }
        brk:
        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Black") && controller.turn)
        {
            var ob = GameObject.Find(controller.highLightTilesMatrix[x, y]);
            if (ob.GetComponent<MeshRenderer>().material.color == Color.red)
            {
                GameObject.Find(controller.chessBoardMatrix[x, y]).SetActive(false);
                hit2 = hit1;
                endposition = ob.transform.position;
                GameObject.Find(hit2.collider.name).GetComponent<BoxCollider>().enabled = false;
                movementSpeed = Vector3.Distance(hit2.transform.position, endposition) * 2f;
                move = true;
                rewind.StoreValues(a, b, x, y, controller.turn, "Killed", hit1.collider.name, hit.collider.name, controller.pawnFirstMove, controller.movedOrNot);
                if (x == 0)
                    rewind.StoreValues(a, b, x, y, controller.turn, "Summoning", hit1.collider.name, hit.collider.name, controller.pawnFirstMove, controller.movedOrNot);
                string name1 = controller.chessBoardMatrix[a, b];
                controller.chessBoardMatrix[a, b] = "";
                controller.chessBoardMatrix[x, y] = name1;
                xpos = x;
                ypos = y;
            }
        }
        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("White") && !controller.turn)
        {
            var ob = GameObject.Find(controller.highLightTilesMatrix[x, y]);
            if (ob.GetComponent<MeshRenderer>().material.color == Color.red)
            {
                GameObject.Find(controller.chessBoardMatrix[x, y]).SetActive(false);
                hit2 = hit1;
                endposition = ob.transform.position;
                GameObject.Find(hit2.collider.name).GetComponent<BoxCollider>().enabled = false;
                movementSpeed = Vector3.Distance(hit2.transform.position, endposition) * 2f;
                move = true;
                rewind.StoreValues(a, b, x, y, controller.turn, "Killed", hit1.collider.name, hit.collider.name, controller.pawnFirstMove, controller.movedOrNot);
                if (x == 7)
                    rewind.StoreValues(a, b, x, y, controller.turn, "Summoning", hit1.collider.name, hit.collider.name, controller.pawnFirstMove, controller.movedOrNot);
                string name1 = controller.chessBoardMatrix[a, b];
                controller.chessBoardMatrix[a, b] = "";
                controller.chessBoardMatrix[x, y] = name1;
                xpos = x;
                ypos = y;
            }
        }
        if(controller.turn && xpos==0)
        {
            controller.summoning = true;
            StartCoroutine(Wait(controller.turn));
        }
        if(!controller.turn && xpos==7)
        {
            controller.summoning = true;
            StartCoroutine(Wait(controller.turn));
        }
        controller.moveAudio.Play();
    }

    IEnumerator EnpassantTextWait()
    {
        yield return new WaitForSeconds(0.5f);
        enpassantTextObject.SetActive(false);
    }

    IEnumerator Wait(bool turn)
    {
        yield return new WaitForSeconds(0.75f);
        if(turn)
        {
            Time.timeScale = 0f;
            whiteSummon.SetActive(true);
        }
        else
        {
            Time.timeScale = 0f;
            blackSummon.SetActive(true);
        }
    }

    #region Summon Code
    public void SummonQueen()
    {
        var ob = GameObject.Find(controller.chessBoardMatrix[xpos, ypos]).transform;
        GameObject.Find(controller.chessBoardMatrix[xpos, ypos]).SetActive(false);
        if (controller.chessBoardMatrix[xpos,ypos].Contains("W "))
        {
            var clone = Instantiate(summonPieces[0], ob.position, summonPieces[0].transform.rotation, parent);
            controller.chessBoardMatrix[xpos, ypos] = clone.name;
            Debug.Log(controller.chessBoardMatrix[xpos, ypos]);
        }
        if(controller.chessBoardMatrix[xpos, ypos].Contains("B "))
        {
            var clone = Instantiate(summonPieces[1], ob.position, summonPieces[1].transform.rotation, parent);
            controller.chessBoardMatrix[xpos, ypos] = clone.name;
            Debug.Log(controller.chessBoardMatrix[xpos, ypos]);
        }
        Time.timeScale = 1f;
        controller.chk();
        startCoroutine();
    }

    public void SummonBishop()
    {
        var ob = GameObject.Find(controller.chessBoardMatrix[xpos, ypos]).transform;
        GameObject.Find(controller.chessBoardMatrix[xpos, ypos]).SetActive(false);
        if (controller.chessBoardMatrix[xpos, ypos].Contains("W "))
        {
            var clone = Instantiate(summonPieces[2], ob.position, summonPieces[2].transform.rotation, parent);
            controller.chessBoardMatrix[xpos, ypos] = clone.name;
            Debug.Log(controller.chessBoardMatrix[xpos, ypos]);
        }
        if (controller.chessBoardMatrix[xpos, ypos].Contains("B "))
        {
            var clone = Instantiate(summonPieces[3], ob.position, summonPieces[3].transform.rotation, parent);
            controller.chessBoardMatrix[xpos, ypos] = clone.name;
            Debug.Log(controller.chessBoardMatrix[xpos, ypos]);
        }
        Time.timeScale = 1f;
        controller.chk();
        startCoroutine();
    }

    public void SummonRook()
    {
        var ob = GameObject.Find(controller.chessBoardMatrix[xpos, ypos]).transform;
        GameObject.Find(controller.chessBoardMatrix[xpos, ypos]).SetActive(false);
        if (controller.chessBoardMatrix[xpos, ypos].Contains("W "))
        {
            var clone = Instantiate(summonPieces[4], ob.position, summonPieces[4].transform.rotation, parent);
            controller.chessBoardMatrix[xpos, ypos] = clone.name;
            Debug.Log(controller.chessBoardMatrix[xpos, ypos]);
        }
        if (controller.chessBoardMatrix[xpos, ypos].Contains("B "))
        {
            var clone = Instantiate(summonPieces[5], ob.position, summonPieces[5].transform.rotation, parent);
            controller.chessBoardMatrix[xpos, ypos] = clone.name;
            Debug.Log(controller.chessBoardMatrix[xpos, ypos]);
        }
        Time.timeScale = 1f;
        controller.chk();
        startCoroutine();
    }

    public void SummonKnight()
    {
        var ob = GameObject.Find(controller.chessBoardMatrix[xpos, ypos]).transform;
        GameObject.Find(controller.chessBoardMatrix[xpos, ypos]).SetActive(false);
        if (controller.chessBoardMatrix[xpos, ypos].Contains("W "))
        {
            var clone = Instantiate(summonPieces[6], ob.position, summonPieces[6].transform.rotation, parent);
            controller.chessBoardMatrix[xpos, ypos] = clone.name;
            Debug.Log(controller.chessBoardMatrix[xpos, ypos]);
        }
        if (controller.chessBoardMatrix[xpos, ypos].Contains("B "))
        {
            var clone = Instantiate(summonPieces[7], ob.position, summonPieces[7].transform.rotation, parent);
            controller.chessBoardMatrix[xpos, ypos] = clone.name;
            Debug.Log(controller.chessBoardMatrix[xpos, ypos]);
        }
        Time.timeScale = 1f;
        controller.chk();
        startCoroutine();
    }
    #endregion

    private void startCoroutine()
    {
        if(!rewind.rewindDone)
        {
            controller.summoning = false;
            rewind.time = 5;
            Color color = new Color(0.0352f, 0.2823f, 0.0156f, 1f);
            rewind.displayText.color = color;
            rewind.startTimer = true;
        }
        if(rewind.rewindDone)
        {
            if (!controller.turn)
            {
                controller.GetComponent<GameController1>().StartCoroutine("Coroutine1");
            }
            if (controller.turn)
            {
                controller.GetComponent<GameController1>().StartCoroutine("Coroutine2");
            }
            rewind.rewindDone = false;
        }
        /*
        if (xpos == 0 && !controller.gameOver)
        {
            StartCoroutine(Coroutine2());
        }
        if (xpos == 7 && !controller.gameOver)
        {
            StartCoroutine(Coroutine3());
        }
        */
    }

    /*
    IEnumerator Coroutine2()
    {
        yield return new WaitForSeconds(0.5f);
        controller.animator.SetTrigger("Trigger1");
        yield return new WaitForSeconds(1f);
        controller.touchEnabled = true;
    }

    IEnumerator Coroutine3()
    {
        yield return new WaitForSeconds(0.5f);
        controller.animator.SetTrigger("Trigger2");
        yield return new WaitForSeconds(1f);
        controller.touchEnabled = true;
        controller.summoning = false;
    }
    */
    private void Update()
    {
        if(move)
        {
            if(hit2.transform.position!=endposition)
            {
                hit2.transform.position = Vector3.MoveTowards(hit2.transform.position, endposition, movementSpeed * Time.deltaTime);
            }
            else
            {
                GameObject.Find(hit2.collider.name).GetComponent<BoxCollider>().enabled = true;
                move = false;
                controller.chk();
                if (!rewind.rewindDone && !controller.summoning)
                {
                    rewind.time = 5;
                    Color color = new Color(0.0352f, 0.2823f, 0.0156f, 1f);
                    rewind.displayText.color = color;
                    rewind.startTimer = true;
                }
                if (rewind.rewindDone && !controller.summoning)
                {
                    if (hit2.collider.name.Contains("W "))
                    {
                        controller.GetComponent<GameController1>().StartCoroutine("Coroutine1");
                    }
                    if (hit2.collider.name.Contains("B "))
                    {
                        controller.GetComponent<GameController1>().StartCoroutine("Coroutine2");
                    }
                    rewind.rewindDone = false;
                }
            }
        }
    }
}