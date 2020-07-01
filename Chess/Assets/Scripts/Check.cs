using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    int x, y;
    public bool CheckOrNot(string[,] copy,bool turn)
    {
        int a, b;
        if (turn)
        {
            getPosition(copy, "W King");
        }
        else
        {
            getPosition(copy, "B King");
        }
        //Cross Right Up
        a = x - 1;
        b = y + 1;
        while (a >= 0 && b <= 7)
        {
            if (copy[a, b] == "")
            {
                a--;
                b++;
                continue;
            }
            else if (turn && copy[a, b].Contains("B "))
            {
                if(a==x-1 && b==y+1 && !copy[a, b].Contains("B Rook") && !copy[a, b].Contains("B Knight"))
                {
                  //  Debug.Log("Pawn or King");
                    return true;
                }
                else if(copy[a, b].Contains("B Bishop") || copy[a, b].Contains("B Queen"))
                {
                 //   Debug.Log("Bishop or Queen");
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (a == x - 1 && b == y + 1 && !copy[a, b].Contains("W Rook") && !copy[a, b].Contains("W Knight"))
                {
                  //  Debug.Log("Pawn or King");
                    return true;
                }
                else if (copy[a, b].Contains("W Bishop") || copy[a, b].Contains("W Queen"))
                {
                  //  Debug.Log("Bishop or Queen");
                    return true;
                }
                break;
            }
            break;
        }

        //Cross Left UP
        a = x - 1;
        b = y - 1;
        while (a >= 0 && b >= 0)
        {
            if (copy[a, b] == "")
            {
                a--;
                b--;
                continue;
            }
            else if (turn && copy[a, b].Contains("B "))
            {
                if (a == x - 1 && b == y - 1 && !copy[a, b].Contains("B Rook") && !copy[a, b].Contains("B Knight"))
                {
                 //   Debug.Log("Pawn or King");
                    return true;
                }
                else if (copy[a, b].Contains("B Bishop") || copy[a, b].Contains("B Queen"))
                {
                 //   Debug.Log("Bishop or Queen");
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (a == x - 1 && b == y - 1 && !copy[a, b].Contains("W Rook") && !copy[a, b].Contains("W Knight"))
                {
                  //  Debug.Log("Pawn or King");
                    return true;
                }
                else if (copy[a, b].Contains("W Bishop") || copy[a, b].Contains("W Queen"))
                {
                 //   Debug.Log("Bishop or Queen");
                    return true;
                }
                break;
            }
            break;
        }

        //Cross Right Down
        a = x + 1;
        b = y + 1;
        while (a <= 7 && b <= 7)
        {
            if (copy[a, b] == "")
            {
                a++;
                b++;
                continue;
            }
            else if (turn && copy[a, b].Contains("B "))
            {
                if (a == x + 1 && b == y + 1 && !copy[a, b].Contains("B Rook") && !copy[a, b].Contains("B Knight"))
                {
                   // Debug.Log("Pawn or King");
                    return true;
                }
                else if (copy[a, b].Contains("B Bishop") || copy[a, b].Contains("B Queen"))
                {
                  //  Debug.Log("Bishop or Queen");
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (a == x + 1 && b == y + 1 && !copy[a, b].Contains("W Rook") && !copy[a, b].Contains("W Knight"))
                {
                   // Debug.Log("Pawn or King");
                    return true;
                }
                else if (copy[a, b].Contains("W Bishop") || copy[a, b].Contains("W Queen"))
                {
                   // Debug.Log("Bishop or Queen");
                    return true;
                }
                break;
            }
            break;
        }

        //Cross Left Down
        a = x + 1;
        b = y - 1;
        while (a <= 7 && b >= 0)
        {
            if (copy[a, b] == "")
            {
                a++;
                b--;
                continue;
            }
            else if (turn && copy[a, b].Contains("B "))
            {
                if (a == x + 1 && b == y - 1 && !copy[a, b].Contains("B Rook") && !copy[a, b].Contains("B Knight"))
                {
                   // Debug.Log("Pawn or King");
                    return true;
                }
                else if (copy[a, b].Contains("B Bishop") || copy[a, b].Contains("B Queen"))
                {
                    //Debug.Log("Bishop or Queen");
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (a == x + 1 && b == y - 1 && !copy[a, b].Contains("W Rook") && !copy[a, b].Contains("W Knight"))
                {
                    //Debug.Log("Pawn or King");
                    return true;
                }
                else if (copy[a, b].Contains("W Bishop") || copy[a, b].Contains("W Queen"))
                {
                    //Debug.Log("Bishop or Queen");
                    return true;
                }
                break;
            }
            break;
        }

        //UP
        a = x - 1;
        b = y;
        while (a >= 0)
        {
            if (copy[a, b] == "")
            {
                a--;
                continue;
            }
            else if (turn && copy[a, b].Contains("B "))
            {
                if (a == x - 1 && !copy[a, b].Contains("B Pawn") && !copy[a, b].Contains("B Knight") && !copy[a, b].Contains("B Bishop"))
                {
                  //  Debug.Log("King");
                    return true;
                }
                else if (copy[a, b].Contains("B Rook") || copy[a, b].Contains("B Queen"))
                {
                  //  Debug.Log("Rook or Queen");
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (a == x - 1 && !copy[a, b].Contains("W Pawn") && !copy[a, b].Contains("W Knight") && !copy[a, b].Contains("W Bishop"))
                {
                  //  Debug.Log("King");
                    return true;
                }
                else if (copy[a, b].Contains("W Rook") || copy[a, b].Contains("W Queen"))
                {
                  //  Debug.Log("Rook or Queen");
                    return true;
                }
                break;
            }
            break;
        }

        //DOWN
        a = x + 1;
        b = y;
        while (a <= 7)
        {
            if (copy[a, b] == "")
            {
                a++;
                continue;
            }
            else if (turn && copy[a, b].Contains("B "))
            {
                if (a == x + 1 && !copy[a, b].Contains("B Pawn") && !copy[a, b].Contains("B Knight") && !copy[a, b].Contains("B Bishop"))
                {
                   // Debug.Log("King");
                    return true;
                }
                else if (copy[a, b].Contains("B Rook") || copy[a, b].Contains("B Queen"))
                {
                   // Debug.Log("Rook or Queen");
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (a == x + 1 && !copy[a, b].Contains("W Pawn") && !copy[a, b].Contains("W Knight") && !copy[a, b].Contains("W Bishop"))
                {
                  //  Debug.Log("King");
                    return true;
                }
                else if (copy[a, b].Contains("W Rook") || copy[a, b].Contains("W Queen"))
                {
                  //  Debug.Log("Rook or Queen");
                    return true;
                }
                break;
            }
            break;
        }

        //RIGHT
        a = x;
        b = y + 1;
        while (b <= 7)
        {
            if (copy[a, b] == "")
            {
                b++;
                continue;
            }
            else if (turn && copy[a, b].Contains("B "))
            {
                if (b == y + 1 && !copy[a, b].Contains("B Pawn") && !copy[a, b].Contains("B Knight") && !copy[a, b].Contains("B Bishop"))
                {
                  //  Debug.Log("King");
                    return true;
                }
                else if (copy[a, b].Contains("B Rook") || copy[a, b].Contains("B Queen"))
                {
                   // Debug.Log("Rook or Queen");
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (b == y + 1 && !copy[a, b].Contains("W Pawn") && !copy[a, b].Contains("W Knight") && !copy[a, b].Contains("W Bishop"))
                {
                  //  Debug.Log("King");
                    return true;
                }
                else if (copy[a, b].Contains("W Rook") || copy[a, b].Contains("W Queen"))
                {
                 //   Debug.Log("Rook or Queen");
                    return true;
                }
                break;
            }
            break;
        }

        //LEFT
        a = x;
        b = y - 1;
        while (b >= 0)
        {
            if (copy[a, b] == "")
            {
                b--;
                continue;
            }
            else if (turn && copy[a, b].Contains("B "))
            {
                if (b == y - 1 && !copy[a, b].Contains("B Pawn") && !copy[a, b].Contains("B Knight") && !copy[a, b].Contains("B Bishop"))
                {
                  //  Debug.Log("King");
                    return true;
                }
                else if (copy[a, b].Contains("B Rook") || copy[a, b].Contains("B Queen"))
                {
                  //  Debug.Log("Rook or Queen");
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (b == y - 1 && !copy[a, b].Contains("W Pawn") && !copy[a, b].Contains("W Knight") && !copy[a, b].Contains("W Bishop"))
                {
                  //  Debug.Log("King");
                    return true;
                }
                else if (copy[a, b].Contains("W Rook") || copy[a, b].Contains("W Queen"))
                {
                  //  Debug.Log("Rook or Queen");
                    return true;
                }
                break;
            }
            break;
        }

        //Knight UP
        if (x - 2 >= 0)
        {
            if (y + 1 <= 7)//UP-RIGHT
            {
                if (turn && copy[x - 2, y + 1].Contains("B Knight"))
                {
                  //  Debug.Log("Knight");
                    return true;
                }
                if (!turn && copy[x - 2, y + 1].Contains("W Knight"))
                {
                  //  Debug.Log("Knight");
                    return true;
                }
            }
            if (y - 1 >= 0)//UP-LEFT
            {
                if (turn && copy[x - 2, y - 1].Contains("B Knight"))
                {
                  //  Debug.Log("Knight");
                    return true;
                }
                if (!turn && copy[x - 2, y - 1].Contains("W Knight"))
                {
                  //  Debug.Log("Knight");
                    return true;
                }
            }
        }

        //Knight DOWN
        if (x + 2 <= 7)
        {
            if (y + 1 <= 7)//DOWN-RIGHT
            {
                if (turn && copy[x + 2, y + 1].Contains("B Knight"))
                {
                  //  Debug.Log("Knight");
                    return true;
                }
                if (!turn && copy[x + 2, y + 1].Contains("W Knight"))
                {
                  //  Debug.Log("Knight");
                    return true;
                }
            }
            if (y - 1 >= 0)//DOWN-LEFT
            {
                if (turn && copy[x + 2, y - 1].Contains("B Knight"))
                {
                  //  Debug.Log("Knight");
                    return true;
                }
                if (!turn && copy[x + 2, y - 1].Contains("W Knight"))
                {
                  //  Debug.Log("Knight");
                    return true;
                }
            }
        }

        //Kinght LEFT
        if (y - 2 >= 0)
        {
            if (x + 1 <= 7)//LEFT-DOWN
            {
                if (turn && copy[x + 1, y - 2].Contains("B Knight"))
                {
                  //  Debug.Log("Knight");
                    return true;
                }
                if (!turn && copy[x + 1, y - 2].Contains("W Knight"))
                {
                  //  Debug.Log("Knight");
                    return true;
                }
            }
            if (x - 1 >= 0)//LEFT-UP
            {
                if (turn && copy[x - 1, y - 2].Contains("B Knight"))
                {
                   // Debug.Log("Knight");
                    return true;
                }
                if (!turn && copy[x - 1, y - 2].Contains("W Knight"))
                {
                   // Debug.Log("Knight");
                    return true;
                }
            }
        }

        //Knight RIGHT
        if (y + 2 <= 7)
        {
            if (x + 1 <= 7)//RIGHT-DOWN
            {
                if (turn && copy[x + 1, y + 2].Contains("B Knight"))
                {
                  //  Debug.Log("Knight");
                    return true;
                }
                if (!turn && copy[x + 1, y + 2].Contains("W Knight"))
                {
                  //  Debug.Log("Knight");
                    return true;
                }
            }
            if (x - 1 >= 0)//RIGHT-UP
            {
                if (turn && copy[x - 1, y + 2].Contains("B Knight"))
                {
                  //  Debug.Log("Knight");
                    return true;
                }
                if (!turn && copy[x - 1, y + 2].Contains("W Knight"))
                {
                  //  Debug.Log("Knight");
                    return true;
                }
            }
        }

        return false;
    }

    private void getPosition(string[,] copy, string v)
    {
        for(int i=0;i<8;i++)
        {
            for(int j=0;j<8;j++)
            {
                if(copy[i,j]==v)
                {
                    x = i;
                    y = j;
                    return;
                }
            }
        }
    }
}