using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For activating the planes if queen is selected
public class QueenMovement : MonoBehaviour
{
    public BishopMovement bishop;
    public RookMovement rook;
    public void ActivatePlanes(int x, int y)
    {
        rook.ActivatePlanes(x, y);
        bishop.ActivatePlanes(x, y);
    }
}
