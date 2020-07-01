using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rewind : MonoBehaviour
{
    public GameController1 controller;
    public Animator animator;
    public GameObject chessBoard;
    public GameObject chessPiecesParentObject;
    public GameObject completeTurnButtonObject;
    public GameObject rewindStatusPanel;
    public Text rewindStatusText;
    #region Values before Rewind Variables
    [NonSerialized] public int x1Position, y1Position, x2Position, y2Position, x3Position, y3Position, x4Position, y4Position;
    [NonSerialized] public bool turn;
    [NonSerialized] public string type,x1y1Name,x2y2Name,x3y3Name,x4y4Name;
    [NonSerialized] public Dictionary<string, int> copyOfPawnFirstMove = new Dictionary<string, int>();
    [NonSerialized] public Dictionary<string, bool> copyOfMovedOrNot = new Dictionary<string, bool>();
    #endregion
    public bool startTimer = false, rewindDone = false;
    public float time,timeToDisplay;
    public Text displayText;
    public GameObject activatedTextObject;
    public GameObject deactivatedTextObject;
    string name1, name2;
    #region Movement Variables
    GameObject rewindChessPiece,castlingRook;
    bool move = false, castling = false;
    Vector3 endPosition, endPositionCastling;
    float movementSpeed, castlingMovementSpeed;
    #endregion

    public void Update()
    {
        //If rewind is not done and rewind button is pressed
        if(startTimer)
        {
            completeTurnButtonObject.SetActive(true);
            deactivatedTextObject.SetActive(false);
            activatedTextObject.SetActive(true);
            if (time > 0)
            {
                time -= Time.deltaTime;
                //timeToDisplay = time;
                //timeToDisplay += 1;
                //float seconds = Mathf.FloorToInt(timeToDisplay % 60);
                displayText.text = String.Format("{0:0.00}", time) + "s";
            }
            else
            {
                startTimer = false;
                displayText.text = "";
                completeTurnButtonObject.SetActive(false);
                activatedTextObject.SetActive(false);
                deactivatedTextObject.SetActive(true);
                if(turn)
                    controller.GetComponent<GameController1>().StartCoroutine("Coroutine1");
                else
                    controller.GetComponent<GameController1>().StartCoroutine("Coroutine2");
            }
            if(time < 1)
            {
                //Color color = new Color(0.0156f, 0f, 0.0078f, 1f);
                displayText.color = Color.red;
            }
        }
        //Moves back the chesspiece to its previous position
        if (move)
        {
            if (rewindChessPiece.transform.position != endPosition)
            {
                rewindChessPiece.transform.position = Vector3.MoveTowards(rewindChessPiece.transform.position, endPosition, movementSpeed * Time.deltaTime);
            }
            else
            {
                rewindChessPiece.GetComponent<BoxCollider>().enabled = true;
                GameObject.Find(controller.highLightTilesMatrix[controller.checki, controller.checkj]).GetComponent<MeshRenderer>().enabled = false;
                GameObject.Find(controller.highLightTilesMatrix[controller.checki, controller.checkj]).GetComponent<MeshRenderer>().material.color = Color.white;
                GameObject.Find(controller.highLightTilesMatrix[controller.checki, controller.checkj]).GetComponent<MeshFilter>().mesh = controller.normalMesh;
                GameObject.Find(controller.highLightTilesMatrix[controller.checki, controller.checkj]).GetComponent<Transform>().localScale = new Vector3(0.585f, 0.0001f, 0.585f);
                controller.turn = turn;
                controller.chk();
                rewindDone = true;
                controller.touchEnabled = true;
                move = false;
            }
        }
        //For Rook,if castling is done this turn then it is activated
        if (castling)
        {
            if (castlingRook.transform.position != endPositionCastling)
            {
                castlingRook.transform.position = Vector3.MoveTowards(castlingRook.transform.position, endPositionCastling, castlingMovementSpeed * Time.deltaTime);
            }
            else
            {
                castlingRook.GetComponent<BoxCollider>().enabled = true;
                castling = false;
            }
        }
    }

    public void RewindGame()
    {
        //If no movement is done this turn and the rewind button is pressed
        if (!startTimer && !rewindDone)
        {
            rewindStatusPanel.SetActive(true);
            rewindStatusText.text = "Rewind is Off.\nNo Movement done this turn.";
            StartCoroutine(RewindStatusWait());
        }
        //When movement is done and rewind button is pressed before time expires
        if (time > 0 && startTimer)
        {
            startTimer = false;
            displayText.text = "";
            activatedTextObject.SetActive(false);
            deactivatedTextObject.SetActive(true);
            if (type == "Normal")
                NormalRewind();
            else if (type == "Enpassant")
                EnPassantRewind();
            else if (type == "Summoning")
                SummoningRewind();
            else if (type == "Killed")
                KilledRewind();
            else if (type == "Castling")
                CastingRewind();
        }
        //If rewind is pressed after rewinding once
        if (rewindDone)
        {
            rewindStatusPanel.SetActive(true);
            rewindStatusText.text = "Rewind is Off.\nCan rewind only once each turn.";
            StartCoroutine(RewindStatusWait());
        }
    }

    IEnumerator RewindStatusWait()
    {
        yield return new WaitForSeconds(1f);
        rewindStatusPanel.SetActive(false);
    }

    private void SummoningRewind()
    {
        Destroy(GameObject.Find(controller.chessBoardMatrix[x2Position, y2Position]));//Destroying summoned gameobject
        if(x2y2Name!="")//If killed and then summoned
            chessPiecesParentObject.transform.Find(x2y2Name).gameObject.SetActive(true);
        rewindChessPiece = chessPiecesParentObject.transform.Find(x1y1Name).gameObject;
        rewindChessPiece.SetActive(true);
        var ob = GameObject.Find(controller.highLightTilesMatrix[x1Position, y1Position]);
        rewindChessPiece.GetComponent<BoxCollider>().enabled = false;
        movementSpeed = Vector3.Distance(rewindChessPiece.transform.position, ob.transform.position) * 2f;
        endPosition = ob.transform.position;
        move = true;
        //Restoring the changes made to the variables
        controller.pawnFirstMove = new Dictionary<string, int>(copyOfPawnFirstMove);
        controller.movedOrNot = new Dictionary<string, bool>(copyOfMovedOrNot);
        controller.chessBoardMatrix[x1Position, y1Position] = x1y1Name;
        controller.chessBoardMatrix[x2Position, y2Position] = x2y2Name;
    }

    private void CastingRewind()
    {
        //King Rewind
        rewindChessPiece = GameObject.Find(x1y1Name);
        var ob = GameObject.Find(controller.highLightTilesMatrix[x1Position, y1Position]);
        rewindChessPiece.GetComponent<BoxCollider>().enabled = false;
        movementSpeed = Vector3.Distance(rewindChessPiece.transform.position, ob.transform.position) * 2f;
        endPosition = ob.transform.position;
        //Rook Rewind
        castlingRook = GameObject.Find(x3y3Name);
        var ob1 = GameObject.Find(controller.highLightTilesMatrix[x3Position, y3Position]);
        castlingRook.GetComponent<BoxCollider>().enabled = false;
        castlingMovementSpeed = Vector3.Distance(castlingRook.transform.position, ob1.transform.position) * 2f;
        endPositionCastling = ob1.transform.position;
        move = true;
        castling = true;
        //Restoring the changes made to the variables
        controller.pawnFirstMove = new Dictionary<string, int>(copyOfPawnFirstMove);
        controller.movedOrNot = new Dictionary<string, bool>(copyOfMovedOrNot);
        controller.chessBoardMatrix[x1Position, y1Position] = x1y1Name;
        controller.chessBoardMatrix[x2Position, y2Position] = x2y2Name;
        controller.chessBoardMatrix[x3Position, y3Position] = x3y3Name;
        controller.chessBoardMatrix[x4Position, y4Position] = x4y4Name;
    }

    private void EnPassantRewind()
    {
        rewindChessPiece = GameObject.Find(x1y1Name);
        var ob = GameObject.Find(controller.highLightTilesMatrix[x1Position, y1Position]);
        rewindChessPiece.GetComponent<BoxCollider>().enabled = false;
        movementSpeed = Vector3.Distance(rewindChessPiece.transform.position, ob.transform.position) * 2f;
        endPosition = ob.transform.position;
        chessPiecesParentObject.transform.Find(x3y3Name).gameObject.SetActive(true);
        move = true;
        //Restoring the changes made to the variables
        controller.pawnFirstMove = new Dictionary<string, int>(copyOfPawnFirstMove);
        controller.movedOrNot = new Dictionary<string, bool>(copyOfMovedOrNot);
        controller.chessBoardMatrix[x1Position, y1Position] = x1y1Name;
        controller.chessBoardMatrix[x2Position, y2Position] = x2y2Name;
        controller.chessBoardMatrix[x3Position, y3Position] = x3y3Name;
    }

    private void KilledRewind()
    {
        rewindChessPiece = GameObject.Find(x1y1Name);
        var ob = GameObject.Find(controller.highLightTilesMatrix[x1Position, y1Position]);
        rewindChessPiece.GetComponent<BoxCollider>().enabled = false;
        movementSpeed = Vector3.Distance(rewindChessPiece.transform.position, ob.transform.position) * 2f;
        endPosition = ob.transform.position;
        chessPiecesParentObject.transform.Find(x2y2Name).gameObject.SetActive(true);
        move = true;
        //Restoring the changes made to the variables
        controller.pawnFirstMove = new Dictionary<string, int>(copyOfPawnFirstMove);
        controller.movedOrNot = new Dictionary<string, bool>(copyOfMovedOrNot);
        controller.chessBoardMatrix[x1Position, y1Position] = x1y1Name;
        controller.chessBoardMatrix[x2Position, y2Position] = x2y2Name;
    }

    private void NormalRewind()
    {
        rewindChessPiece = GameObject.Find(x1y1Name);
        var ob = GameObject.Find(controller.highLightTilesMatrix[x1Position, y1Position]);
        rewindChessPiece.GetComponent<BoxCollider>().enabled = false;
        movementSpeed = Vector3.Distance(rewindChessPiece.transform.position, ob.transform.position) * 2f;
        endPosition = ob.transform.position;
        move = true;
        //Restoring the changes made to the variables
        controller.pawnFirstMove = new Dictionary<string, int>(copyOfPawnFirstMove);
        controller.movedOrNot = new Dictionary<string, bool>(copyOfMovedOrNot);
        controller.chessBoardMatrix[x1Position, y1Position] = x1y1Name;
        controller.chessBoardMatrix[x2Position, y2Position] = x2y2Name;
    }

    //storing the variables values before the movement
    internal void StoreValues(int x, int y, int a, int b, bool turn, string typeName, string v1, string v2, Dictionary<string, int> pawnFirstMove, Dictionary<string, bool> movedOrNot)
    {
        x1Position = x;
        y1Position = y;
        x2Position = a;
        y2Position = b;
        this.turn = turn;
        type = typeName;
        x1y1Name = v1;
        x2y2Name = v2;
        copyOfPawnFirstMove = new Dictionary<string, int>(pawnFirstMove);
        copyOfMovedOrNot = new Dictionary<string, bool>(movedOrNot);
    }

    //storing extra variable values if movement is Castling or Enpassant
    internal void StoreExtraValues(int x, int y, int a, int b, string v1, string v2)
    {
        x3Position = x;
        y3Position = y;
        x4Position = a;
        y4Position = b;
        x3y3Name = v1;
        x4y4Name = v2;
    }

    //Skips the timer and completes your turn.Called on OnClick()
    public void CompleteTurn()
    {
        startTimer = false;
        displayText.text = "";
        completeTurnButtonObject.SetActive(false);
        activatedTextObject.SetActive(false);
        deactivatedTextObject.SetActive(true);
        if (turn)
            controller.GetComponent<GameController1>().StartCoroutine("Coroutine1");
        else
            controller.GetComponent<GameController1>().StartCoroutine("Coroutine2");
    }
}