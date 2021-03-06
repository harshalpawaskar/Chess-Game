﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script checks if any movement is possible by any chesspiece of the opponent
//If any movement is possible i.e. count>0 for any gamepiece of the opponent then it returns false
//If not then it return true and game ends with the current players win
public class CheckMate : MonoBehaviour
{
    public GameController1 controller;
    public BishopMovement bishop;
    public QueenMovement queen;
    public PawnMovement pawn;
    public KnightMovement knight;
    public RookMovement rook;
    public KingMovement king;

    public bool CheckMateOrNot(string[,] copy,bool turn)
    {
        int count;
        for (int i=0;i<8;i++)
        {
            for(int j=0;j<8;j++)
            {
                if(copy[i,j].Contains("W ") && turn)//WHITE
                {
                    if(copy[i,j].Contains("W Pawn"))
                    {
                        count = pawn.getCount(i, j);
                        controller.DeactivateExistingPlanes();
                        if (count > 0)
                            return false;
                    }
                    else if (copy[i, j].Contains("W Knight"))
                    {
                        count = knight.getCount(i, j);
                        controller.DeactivateExistingPlanes();
                        if (count > 0)
                            return false;
                    }
                    else if (copy[i, j].Contains("W Bishop"))
                    {
                        count = bishop.getCount(i, j);
                        controller.DeactivateExistingPlanes();
                        if (count > 0)
                            return false;
                    }
                    else if (copy[i, j].Contains("W Rook"))
                    {
                        count = rook.getCount(i, j);
                        controller.DeactivateExistingPlanes();
                        if (count > 0)
                            return false;
                    }
                    else if (copy[i, j].Contains("W Queen"))
                    {
                        count = bishop.getCount(i, j);
                        controller.DeactivateExistingPlanes();
                        if (count > 0)
                            return false;
                        count = rook.getCount(i, j);
                        controller.DeactivateExistingPlanes();
                        if (count > 0)
                            return false;
                    }
                    else if (copy[i, j].Contains("W King"))
                    {
                        count = king.getCount(i, j);
                        controller.DeactivateExistingPlanes();
                        if (count > 0)
                            return false;
                    }
                }
                else if(copy[i, j].Contains("B ") && !turn)//BLACK
                {
                    if (copy[i, j].Contains("B Pawn"))
                    {
                        count = pawn.getCount(i, j);
                        controller.DeactivateExistingPlanes();
                        if (count > 0)
                            return false;
                    }
                    else if (copy[i, j].Contains("B Knight"))
                    {
                        count = knight.getCount(i, j);
                        controller.DeactivateExistingPlanes();
                        if (count > 0)
                            return false;
                    }
                    else if (copy[i, j].Contains("B Bishop"))
                    {
                        count = bishop.getCount(i, j);
                        controller.DeactivateExistingPlanes();
                        if (count > 0)
                            return false;
                    }
                    else if (copy[i, j].Contains("B Rook"))
                    {
                        count = rook.getCount(i, j);
                        controller.DeactivateExistingPlanes();
                        if (count > 0)
                            return false;
                    }
                    else if (copy[i, j].Contains("B Queen"))
                    {
                        count = bishop.getCount(i, j);
                        controller.DeactivateExistingPlanes();
                        if (count > 0)
                            return false;
                        count = rook.getCount(i, j);
                        controller.DeactivateExistingPlanes();
                        if (count > 0)
                            return false;
                    }
                    else if (copy[i, j].Contains("B King"))
                    {
                        count = king.getCount(i, j);
                        controller.DeactivateExistingPlanes();
                        if (count > 0)
                            return false;
                    }
                }
            }
        }
        return true;
    }
}