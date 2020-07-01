using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script finds king's position and checks for check by the opponent gamepieces from all directions    
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
        #region Cross Right Up
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
                    return true;
                }
                else if(copy[a, b].Contains("B Bishop") || copy[a, b].Contains("B Queen"))
                {
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (a == x - 1 && b == y + 1 && !copy[a, b].Contains("W Rook") && !copy[a, b].Contains("W Knight"))
                {
                    return true;
                }
                else if (copy[a, b].Contains("W Bishop") || copy[a, b].Contains("W Queen"))
                {
                    return true;
                }
                break;
            }
            break;
        }
        #endregion
        #region Cross Left UP
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
                    return true;
                }
                else if (copy[a, b].Contains("B Bishop") || copy[a, b].Contains("B Queen"))
                {
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (a == x - 1 && b == y - 1 && !copy[a, b].Contains("W Rook") && !copy[a, b].Contains("W Knight"))
                {
                    return true;
                }
                else if (copy[a, b].Contains("W Bishop") || copy[a, b].Contains("W Queen"))
                {
                    return true;
                }
                break;
            }
            break;
        }
        #endregion
        #region Cross Right Down
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
                    return true;
                }
                else if (copy[a, b].Contains("B Bishop") || copy[a, b].Contains("B Queen"))
                {
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (a == x + 1 && b == y + 1 && !copy[a, b].Contains("W Rook") && !copy[a, b].Contains("W Knight"))
                {
                    return true;
                }
                else if (copy[a, b].Contains("W Bishop") || copy[a, b].Contains("W Queen"))
                {
                    return true;
                }
                break;
            }
            break;
        }
        #endregion
        #region Cross Left Down
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
                    return true;
                }
                else if (copy[a, b].Contains("B Bishop") || copy[a, b].Contains("B Queen"))
                {
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (a == x + 1 && b == y - 1 && !copy[a, b].Contains("W Rook") && !copy[a, b].Contains("W Knight"))
                {
                    return true;
                }
                else if (copy[a, b].Contains("W Bishop") || copy[a, b].Contains("W Queen"))
                {
                    return true;
                }
                break;
            }
            break;
        }
        #endregion
        #region UP
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
                    return true;
                }
                else if (copy[a, b].Contains("B Rook") || copy[a, b].Contains("B Queen"))
                {
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (a == x - 1 && !copy[a, b].Contains("W Pawn") && !copy[a, b].Contains("W Knight") && !copy[a, b].Contains("W Bishop"))
                {
                    return true;
                }
                else if (copy[a, b].Contains("W Rook") || copy[a, b].Contains("W Queen"))
                {
                    return true;
                }
                break;
            }
            break;
        }
        #endregion
        #region DOWN
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
                    return true;
                }
                else if (copy[a, b].Contains("B Rook") || copy[a, b].Contains("B Queen"))
                {
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (a == x + 1 && !copy[a, b].Contains("W Pawn") && !copy[a, b].Contains("W Knight") && !copy[a, b].Contains("W Bishop"))
                {
                    return true;
                }
                else if (copy[a, b].Contains("W Rook") || copy[a, b].Contains("W Queen"))
                {
                    return true;
                }
                break;
            }
            break;
        }
        #endregion
        #region RIGHT
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
                    return true;
                }
                else if (copy[a, b].Contains("B Rook") || copy[a, b].Contains("B Queen"))
                {
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (b == y + 1 && !copy[a, b].Contains("W Pawn") && !copy[a, b].Contains("W Knight") && !copy[a, b].Contains("W Bishop"))
                {
                    return true;
                }
                else if (copy[a, b].Contains("W Rook") || copy[a, b].Contains("W Queen"))
                {
                    return true;
                }
                break;
            }
            break;
        }
        #endregion
        #region LEFT
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
                    return true;
                }
                else if (copy[a, b].Contains("B Rook") || copy[a, b].Contains("B Queen"))
                {
                    return true;
                }
                break;
            }
            else if (!turn && copy[a, b].Contains("W "))
            {
                if (b == y - 1 && !copy[a, b].Contains("W Pawn") && !copy[a, b].Contains("W Knight") && !copy[a, b].Contains("W Bishop"))
                {
                    return true;
                }
                else if (copy[a, b].Contains("W Rook") || copy[a, b].Contains("W Queen"))
                {
                    return true;
                }
                break;
            }
            break;
        }
        #endregion
        #region Knight UP
        if (x - 2 >= 0)
        {
            #region UP-RIGHT
            if (y + 1 <= 7)//
            {
                if (turn && copy[x - 2, y + 1].Contains("B Knight"))
                {
                    return true;
                }
                if (!turn && copy[x - 2, y + 1].Contains("W Knight"))
                {
                    return true;
                }
            }
            #endregion
            #region UP-LEFT
            if (y - 1 >= 0)
            {
                if (turn && copy[x - 2, y - 1].Contains("B Knight"))
                {
                    return true;
                }
                if (!turn && copy[x - 2, y - 1].Contains("W Knight"))
                {
                    return true;
                }
            }
            #endregion
        }
        #endregion
        #region Knight DOWN
        if (x + 2 <= 7)
        {
            #region DOWN-RIGHT
            if (y + 1 <= 7)
            {
                if (turn && copy[x + 2, y + 1].Contains("B Knight"))
                {
                    return true;
                }
                if (!turn && copy[x + 2, y + 1].Contains("W Knight"))
                {
                    return true;
                }
            }
            #endregion
            #region DOWN-LEFT
            if (y - 1 >= 0)
            {
                if (turn && copy[x + 2, y - 1].Contains("B Knight"))
                {
                    return true;
                }
                if (!turn && copy[x + 2, y - 1].Contains("W Knight"))
                {
                    return true;
                }
            }
            #endregion
        }
        #endregion
        #region Kinght LEFT
        if (y - 2 >= 0)
        {
            #region LEFT-DOWN
            if (x + 1 <= 7)
            {
                if (turn && copy[x + 1, y - 2].Contains("B Knight"))
                {
                    return true;
                }
                if (!turn && copy[x + 1, y - 2].Contains("W Knight"))
                {
                    return true;
                }
            }
            #endregion
            #region LEFT-UP
            if (x - 1 >= 0)
            {
                if (turn && copy[x - 1, y - 2].Contains("B Knight"))
                {
                    return true;
                }
                if (!turn && copy[x - 1, y - 2].Contains("W Knight"))
                {
                    return true;
                }
            }
            #endregion
        }
        #endregion
        #region Knight RIGHT
        if (y + 2 <= 7)
        {
            #region RIGHT-DOWN
            if (x + 1 <= 7)
            {
                if (turn && copy[x + 1, y + 2].Contains("B Knight"))
                {
                    return true;
                }
                if (!turn && copy[x + 1, y + 2].Contains("W Knight"))
                {
                    return true;
                }
            }
            #endregion
            #region RIGHT-UP
            if (x - 1 >= 0)
            {
                if (turn && copy[x - 1, y + 2].Contains("B Knight"))
                {
                    return true;
                }
                if (!turn && copy[x - 1, y + 2].Contains("W Knight"))
                {
                    return true;
                }
            }
            #endregion
        }
        #endregion
        return false;
    }

    //Finds position of the king
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