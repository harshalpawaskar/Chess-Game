using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Array2DEditor;
using System;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController1 : MonoBehaviour
{
    public Array2DString names;//Name of highlight tiles in imported 2d array 
    public string[,] highLightTilesMatrix;//Names of Highlight Tiles(copied from Array2Dstring names)
    public Array2DString chessBoardCheck;//Chess Pieces names positioned wrt chessboard
    public string[,] chessBoardMatrix;//To check position of all the gamepieces(contains names of the chesspieces) 
    public string[] pawnNames;
    public bool turn;
    public bool selected = false;//If an chess piece selected or not
    public List<string> activatedPlanesNames = new List<string>();//stores activated planes names
    public Dictionary<string, int> pawnFirstMove = new Dictionary<string, int>();
    public Dictionary<string, bool> movedOrNot = new Dictionary<string, bool> {
        {"W King",false },
        {"B King",false },
        {"W Rook 1",false },
        {"W Rook 2",false },
        {"B Rook 1",false },
        {"B Rook 2",false }
    };
    public Check check;
    public CheckMate checkMate;
    public Rewind rewind;
    public Mesh checkMesh;
    public Mesh normalMesh;
    public Animator animator;
    public GameObject invalidTextObject;
    public bool touchEnabled = true;
    public Result result;
    public AudioSource moveAudio;
    public bool helper;
    public int checki, checkj;
    RaycastHit hit,hit1;
    BishopMovement bishop;
    QueenMovement queen;
    PawnMovement pawn;
    KnightMovement knight;
    RookMovement rook;
    KingMovement king;
    int x, y;
    public bool summoning = false, gameOver = false;
    #region Movement variables
    RaycastHit hit2;
    bool move = false, castling = false;
    Vector3 endPositionCastling, endPosition;
    float movementSpeed,movementSpeedCastling;
    GameObject castlingRook;
    #endregion

    private void Awake()
    {
        if (PlayerPrefs.GetString("Helper") == "ON")
            helper = true;
        if (PlayerPrefs.GetString("Helper") == "OFF")
            helper = false;
    }

    void Start()
    {
        highLightTilesMatrix = names.GetCells();
        chessBoardMatrix = chessBoardCheck.GetCells();
        bishop = gameObject.GetComponent<BishopMovement>();
        queen = gameObject.GetComponent<QueenMovement>();
        king = gameObject.GetComponent<KingMovement>();
        pawn = gameObject.GetComponent<PawnMovement>();
        rook = gameObject.GetComponent<RookMovement>();
        knight = gameObject.GetComponent<KnightMovement>();
        for (int i = 0; i < 16; i++)
        {
            pawnFirstMove.Add(pawnNames[i], 0);
        }
    }

    void Update()
    {
        //Movement of the Selected ChessPiece
        if (move)
        {
            if (hit2.transform.position != endPosition)
            {
                hit2.transform.position = Vector3.MoveTowards(hit2.transform.position, endPosition, movementSpeed * Time.deltaTime);
            }
            else
            {
                GameObject.Find(hit2.collider.name).GetComponent<BoxCollider>().enabled = true;
                move = false;
                chk();
                if(!rewind.rewindDoneOnce)//rewind not done once this turn
                {
                    rewind.time = 5;
                    Color color = new Color(0.0352f, 0.2823f, 0.0156f, 1f);
                    rewind.displayText.color = color;
                    rewind.startTimer = true;
                }
                if(rewind.rewindDoneOnce)//rewind is done once this turn
                {
                    if (hit2.collider.name.Contains("W "))
                    {
                        StartCoroutine(Coroutine1());
                    }
                    if (hit2.collider.name.Contains("B "))
                    {
                        StartCoroutine(Coroutine2());
                    }
                    rewind.rewindDoneOnce = false;
                }
            }
        }
        //Rook's Castling Movement
        if (castling)
        {
            if (castlingRook.transform.position != endPositionCastling)
            {
                castlingRook.transform.position = Vector3.MoveTowards(castlingRook.transform.position, endPositionCastling, movementSpeedCastling * Time.deltaTime);
            }
            else
            {
                castlingRook.GetComponent<BoxCollider>().enabled = true;
                castling = false;
                chk();
            }
        }
        if (Input.GetMouseButtonDown(0) && touchEnabled)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.layer == LayerMask.NameToLayer("White") && turn)
                {
                    if (!selected)
                    {
                        hit1 = hit;
                        GetPosition();
                        ActivatePlanes();
                        selected = true;
                    }
                    else
                    {
                        if(hit.collider.transform.position!=hit1.collider.transform.position)
                        {
                            DeactivateExistingPlanes();
                            if (hit1.collider.name.Contains("King"))
                            {
                                if (check.CheckOrNot(chessBoardMatrix, turn))
                                {
                                    GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().enabled = true;
                                    GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().material.color = Color.red;
                                }
                            }
                            hit1 = hit;
                            GetPosition();
                            ActivatePlanes();
                        }
                    }
                }
                else if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Black") && !turn)
                {
                    if (!selected)
                    {
                        hit1 = hit;
                        GetPosition();
                        ActivatePlanes();
                        selected = true;
                    }
                    else
                    {
                        if (hit.collider.transform.position != hit1.collider.transform.position)
                        {
                            DeactivateExistingPlanes();
                            if (hit1.collider.name.Contains("King"))
                            {
                                if (check.CheckOrNot(chessBoardMatrix, turn))
                                {
                                    GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().enabled = true;
                                    GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().material.color = Color.red;
                                }
                            }
                            hit1 = hit;
                            GetPosition();
                            ActivatePlanes();
                        }
                    }
                }
                else if(selected)
                {
                    if (turn)//White's Turn
                    {
                        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("HightlightPlane"))//Normal Movement Selected
                        {
                            var ob = hit.transform.GetComponent<MeshRenderer>().material.color;
                            if (hit.collider.name != highLightTilesMatrix[x, y] && (ob == Color.green || ob == Color.red || ob == Color.yellow))
                            {
                                MoveSelected();
                                DeactivateExistingPlanes();
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().enabled = false;
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().material.color = Color.white;
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshFilter>().mesh = normalMesh;
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<Transform>().localScale = new Vector3(0.585f, 0.0001f, 0.585f);
                                string temp;
                                for (int i = 1; i <= 8; i++)
                                {
                                    temp = "B Pawn " + i.ToString();
                                    pawnFirstMove[temp] = 0;
                                }
                                touchEnabled = false;
                                turn = false;
                                selected = false;
                            }
                            if (ob != Color.green && ob != Color.red && ob != Color.blue && ob != Color.yellow)//If clicked somewhere else
                            {
                                DeactivateExistingPlanes();
                                chk();
                                selected = false;
                                if (!helper)
                                {
                                    invalidTextObject.SetActive(true);
                                    StartCoroutine(InvalidTextWait());
                                }
                            }
                        }
                        if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Black"))//Killing Movement Selected
                        {
                            GetPosition();
                            if (GameObject.Find(highLightTilesMatrix[x, y]).GetComponent<MeshRenderer>().material.color == Color.red)
                            {
                                MoveSelected();
                                DeactivateExistingPlanes();
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().enabled = false;
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().material.color = Color.white;
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshFilter>().mesh = normalMesh;
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<Transform>().localScale = new Vector3(0.585f, 0.0001f, 0.585f);
                                string temp;
                                for (int i = 1; i <= 8; i++)
                                {
                                    temp = "B Pawn " + i.ToString();
                                    pawnFirstMove[temp] = 0;
                                }
                                touchEnabled = false;
                                turn = false;
                                selected = false;
                            }
                            else//If clicked somewhere else
                            {
                                DeactivateExistingPlanes();
                                chk();
                                selected = false;
                                if (!helper)
                                {
                                    invalidTextObject.SetActive(true);
                                    StartCoroutine(InvalidTextWait());
                                }
                            }
                        }
                    }
                    else//Black's Turn
                    {
                        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("HightlightPlane"))//Normal Movement Selected
                        {
                            var ob = hit.transform.GetComponent<MeshRenderer>().material.color;
                            if (hit.collider.name != highLightTilesMatrix[x, y] && (ob == Color.green || ob == Color.red || ob == Color.yellow))
                            {
                                MoveSelected();
                                DeactivateExistingPlanes();
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().enabled = false;
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().material.color = Color.white;
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshFilter>().mesh = normalMesh;
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<Transform>().localScale = new Vector3(0.585f, 0.0001f, 0.585f);
                                string temp;
                                for (int i = 1; i <= 8; i++)
                                {
                                    temp = "W Pawn " + i.ToString();
                                    pawnFirstMove[temp] = 0;
                                }
                                touchEnabled = false;
                                turn = true;
                                selected = false;
                            }
                            if (ob != Color.green && ob != Color.red && ob != Color.blue && ob != Color.yellow)//If clicked somewhere else
                            {
                                DeactivateExistingPlanes();
                                chk();
                                selected = false;
                                if (!helper)
                                {
                                    invalidTextObject.SetActive(true);
                                    StartCoroutine(InvalidTextWait());
                                }
                            }
                        }
                        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("White"))//Killing Movement Selected
                        {
                            GetPosition();
                            if (GameObject.Find(highLightTilesMatrix[x, y]).GetComponent<MeshRenderer>().material.color == Color.red)
                            {
                                MoveSelected();
                                DeactivateExistingPlanes();
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().enabled = false;
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().material.color = Color.white;
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshFilter>().mesh = normalMesh;
                                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<Transform>().localScale = new Vector3(0.585f, 0.0001f, 0.585f);
                                string temp;
                                for (int i = 1; i <= 8; i++)
                                {
                                    temp = "W Pawn " + i.ToString();
                                    pawnFirstMove[temp] = 0;
                                }
                                touchEnabled = false;
                                turn = true;
                                selected = false;
                            }
                            else//If clicked somewhere else
                            {
                                DeactivateExistingPlanes();
                                chk();
                                selected = false;
                                if (!helper)
                                {
                                    invalidTextObject.SetActive(true);
                                    StartCoroutine(InvalidTextWait());
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    //Turn the Chessboard fo Black's Turn
    IEnumerator Coroutine1()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("Trigger1");
        yield return new WaitForSeconds(1f);
        touchEnabled = true;
    }

    //Turn the chessBoard for White's Turn 
    IEnumerator Coroutine2()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("Trigger2");
        yield return new WaitForSeconds(1f);
        touchEnabled = true;
    }

    //Deactivate invalidText after some Time
    IEnumerator InvalidTextWait()
    {
        yield return new WaitForSeconds(1f);
        invalidTextObject.SetActive(false);
    }

    //checking if check is been given,if yes then check if checkmate or not
    public void chk()
    {
        if (turn)//White
        {
            if (check.CheckOrNot(chessBoardMatrix, turn))
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (chessBoardMatrix[i, j] == "W King")
                        {
                            Debug.Log(highLightTilesMatrix[i, j]);
                            checki = i;
                            checkj = j;
                        }
                    }
                }
                if (checkMate.CheckMateOrNot(chessBoardMatrix, turn))
                {
                    gameOver = true;
                    GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshFilter>().mesh = checkMesh;
                    GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<Transform>().localScale = new Vector3(0.635f, 0.0001f, 0.635f);
                    GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().material.color = Color.red;
                    Debug.Log("CheckMate Black Wins");
                    touchEnabled = false;
                    StartCoroutine(Wait3(turn));
                }
                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshFilter>().mesh = checkMesh;
                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<Transform>().localScale = new Vector3(0.635f, 0.0001f, 0.635f);
                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
        else//Black 
        {
            if (check.CheckOrNot(chessBoardMatrix, turn))
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (chessBoardMatrix[i, j] == "B King")
                        {
                            Debug.Log(highLightTilesMatrix[i, j]);
                            checki = i;
                            checkj = j;
                        }
                    }
                }
                if (checkMate.CheckMateOrNot(chessBoardMatrix, turn))
                {
                    gameOver = true;
                    GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshFilter>().mesh = checkMesh;
                    GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<Transform>().localScale = new Vector3(0.635f, 0.0001f, 0.635f);
                    GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().material.color = Color.red;
                    Debug.Log("CheckMate White Wins");
                    touchEnabled = false;
                    StartCoroutine(Wait3(turn));
                }
                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshFilter>().mesh = checkMesh;
                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<Transform>().localScale = new Vector3(0.635f, 0.0001f, 0.635f);
                GameObject.Find(highLightTilesMatrix[checki, checkj]).GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }

    IEnumerator Wait3(bool turn1)//Activates result panel after waiting for some time
    {
        yield return new WaitForSeconds(0.5f);
        if (turn1)
            result.DisplayResult(false);
        else
            result.DisplayResult(true);
    }

    //Calls the movement function depending on the type of chess piece selected
    private void MoveSelected()
    {
        if (hit1.collider.CompareTag("Knight"))
        {
            Move(hit,hit1,x,y);
        }
        else if (hit1.collider.CompareTag("King"))
        {
            Move(hit, hit1,x,y);
        }
        else if (hit1.collider.CompareTag("Queen"))
        {
            Move(hit, hit1,x,y);
        }
        else if (hit1.collider.CompareTag("Rook"))
        {
            Move(hit, hit1,x,y);
        }
        else if (hit1.collider.CompareTag("Bishop"))
        {
            Move(hit, hit1,x,y);
        }
        else
        {
            pawn.MoveSelected(hit, hit1,x,y);
        }
    }

    public void ChangeValues()//change the values in chessBoardMatrix if hit is HighLightTile
    {
        string name1 = chessBoardMatrix[x, y];//x,y is Chesspiece position(hit1)
        chessBoardMatrix[x, y] = "";
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (String.Compare(hit.collider.name, highLightTilesMatrix[i, j]) == 0)
                {
                    x = i;
                    y = j;
                    break;
                }
            }
        }
        chessBoardMatrix[x, y] = name1;
    }

    public void HighLightTilesPosition(RaycastHit hit2, ref int a,ref int b)//selected HighLightTile position
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (String.Compare(hit2.collider.name, highLightTilesMatrix[i, j]) == 0)
                {
                    a = i;
                    b = j;
                    break;
                }
            }
        }
    }

    //Deactivates existing activated planes
    public void DeactivateExistingPlanes()
    {
        foreach (string i in activatedPlanesNames)
        {
            GameObject.Find(i).GetComponent<MeshRenderer>().material.color = Color.white;
            GameObject.Find(i).GetComponent<MeshRenderer>().enabled = false;
        }
        activatedPlanesNames.Clear();
    }

    //Calling activate plane depending on the type of chesspiece
    private void ActivatePlanes()
    {
        if(hit.collider.CompareTag("Knight"))
        {
            knight.ActivatePlanes(x,y);
        }
        else if (hit.collider.CompareTag("King"))
        {
            king.ActivatePlanes(x,y);
        }
        else if (hit.collider.CompareTag("Queen"))
        {
            queen.ActivatePlanes(x,y);
        }
        else if (hit.collider.CompareTag("Rook"))
        {
            rook.ActivatePlanes(x,y);
        }
        else if (hit.collider.CompareTag("Bishop"))
        {
            bishop.ActivatePlanes(x,y);
        }
        else
        {
            pawn.ActivatePlanes(x,y);
        }
    }

    private void GetPosition()//selected hit variable position
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (String.Compare(hit.collider.name, chessBoardMatrix[i, j]) == 0)
                {
                    x = i;
                    y = j;
                    break;
                }
            }
        }
    }


    //Movement function to store the movement values and Invoke the Update function to start the movement For Knight,Bishop,Rook,King and Queen
    private void Move(RaycastHit hit, RaycastHit hit1, int x, int y)
    {
        int a = 0, b = 0;
        HighLightTilesPosition(hit, ref a, ref b);
        #region HighLight Plane is Selected/hit to Move your ChessPiece
        //Here x,y is source position and a,b is destination position and hit variable is HighLight Plane
        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("HightlightPlane"))
        {
            if (hit.transform.GetComponent<MeshRenderer>().material.color == Color.green)//Normal Movement
            {
                GameObject.Find(hit1.collider.name).GetComponent<BoxCollider>().enabled = false;
                hit2 = hit1;
                endPosition = hit.transform.position;
                movementSpeed = Vector3.Distance(hit2.transform.position, endPosition)*2f;
                move = true;
                rewind.StoreValues(x, y, a, b, turn, "Normal", hit1.collider.name, "", pawnFirstMove, movedOrNot);
                ChangeValues();
            }
            if (hit.transform.GetComponent<MeshRenderer>().material.color == Color.red)//Killing Movement
            {
                GameObject.Find(chessBoardMatrix[a, b]).SetActive(false);
                GameObject.Find(hit1.collider.name).GetComponent<BoxCollider>().enabled = false;
                hit2 = hit1;
                endPosition = hit.transform.position;
                movementSpeed = Vector3.Distance(hit2.transform.position, endPosition)*2f;
                move = true;
                rewind.StoreValues(x, y, a, b, turn, "Killed", hit1.collider.name, chessBoardMatrix[a, b], pawnFirstMove, movedOrNot);
                ChangeValues();
            }
            if(hit.transform.GetComponent<MeshRenderer>().material.color == Color.yellow)//Castling Movement
            {
                GameObject.Find(hit1.collider.name).GetComponent<BoxCollider>().enabled = false;
                hit2 = hit1;
                endPosition = hit.transform.position;
                movementSpeed = Vector3.Distance(hit2.transform.position, endPosition) * 2f;
                move = true;
                rewind.StoreValues(x, y, a, b, turn, "Castling", hit1.collider.name, "", pawnFirstMove, movedOrNot);
                if (turn)//White King Castling
                {
                    if (b<y)
                    {
                        castlingRook = GameObject.Find(chessBoardMatrix[7, 0]);
                        var ob1 = GameObject.Find(highLightTilesMatrix[7, 3]);
                        castlingRook.GetComponent<BoxCollider>().enabled = false;
                        endPositionCastling = ob1.transform.position;
                        movementSpeedCastling = Vector3.Distance(castlingRook.transform.position, endPositionCastling) * 2f;
                        castling = true;
                        rewind.StoreExtraValues(7, 0, 7, 3, castlingRook.name, "");
                        chessBoardMatrix[7, 3] = chessBoardMatrix[7, 0];
                        chessBoardMatrix[a, b] = chessBoardMatrix[x, y];
                        chessBoardMatrix[7, 0] = "";
                        chessBoardMatrix[x, y] = "";
                    }
                    else
                    {
                        castlingRook = GameObject.Find(chessBoardMatrix[7, 7]);
                        var ob1 = GameObject.Find(highLightTilesMatrix[7, 5]);
                        castlingRook.GetComponent<BoxCollider>().enabled = false;
                        endPositionCastling = ob1.transform.position;
                        movementSpeedCastling = Vector3.Distance(castlingRook.transform.position, endPositionCastling) * 2f;
                        castling = true;
                        rewind.StoreExtraValues(7, 7, 7, 5, castlingRook.name, "");
                        chessBoardMatrix[7, 5] = chessBoardMatrix[7, 7];
                        chessBoardMatrix[a, b] = chessBoardMatrix[x, y];
                        chessBoardMatrix[7, 7] = "";
                        chessBoardMatrix[x, y] = "";
                    }
                }
                else//Black King Castling
                {
                    if (b < y)
                    {
                        castlingRook = GameObject.Find(chessBoardMatrix[0, 0]);
                        var ob1 = GameObject.Find(highLightTilesMatrix[0, 3]);
                        castlingRook.GetComponent<BoxCollider>().enabled = false;
                        endPositionCastling = ob1.transform.position;
                        movementSpeedCastling = Vector3.Distance(castlingRook.transform.position, endPositionCastling) * 2f;
                        castling = true;
                        rewind.StoreExtraValues(0, 0, 0, 3, castlingRook.name, "");
                        chessBoardMatrix[0, 3] = chessBoardMatrix[0, 0];
                        chessBoardMatrix[a, b] = chessBoardMatrix[x, y];
                        chessBoardMatrix[0, 0] = "";
                        chessBoardMatrix[x, y] = "";
                    }
                    else
                    {
                        castlingRook = GameObject.Find(chessBoardMatrix[0, 7]);
                        var ob1 = GameObject.Find(highLightTilesMatrix[0, 5]);
                        castlingRook.GetComponent<BoxCollider>().enabled = false;
                        endPositionCastling = ob1.transform.position;
                        movementSpeedCastling = Vector3.Distance(castlingRook.transform.position, endPositionCastling) * 2f;
                        castling = true;
                        rewind.StoreExtraValues(0, 7, 0, 5, castlingRook.name, "");
                        chessBoardMatrix[0, 5] = chessBoardMatrix[0, 7];
                        chessBoardMatrix[a, b] = chessBoardMatrix[x, y];
                        chessBoardMatrix[0, 7] = "";
                        chessBoardMatrix[x, y] = "";
                    }
                }
            }
        }
        #endregion
        #region Opponent ChessPiece is selected/hit to Move your ChessPiece
        //Here a,b is source position and x,y is destination position and hit variable is opponent ChessPiece
        for (int i = 0; i < 8; i++)//Finding the position of the selected chesspiece(hit1)
        {
            for (int j = 0; j < 8; j++)
            {
                if (String.Compare(hit1.collider.name, chessBoardMatrix[i, j]) == 0)
                {
                    a = i;
                    b = j;
                    goto brk;
                }
            }
        }
        brk:
        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Black") && turn)//White
        {
            var ob = GameObject.Find(highLightTilesMatrix[x, y]);
            if (ob.GetComponent<MeshRenderer>().material.color == Color.red)
            {
                GameObject.Find(chessBoardMatrix[x, y]).SetActive(false);
                GameObject.Find(hit1.collider.name).GetComponent<BoxCollider>().enabled = false;
                hit2 = hit1;
                endPosition = ob.transform.position;
                movementSpeed = Vector3.Distance(hit2.transform.position, endPosition) * 2f;
                move = true;
                rewind.StoreValues(a, b, x, y, turn, "Killed", hit1.collider.name, hit.collider.name, pawnFirstMove, movedOrNot);
                string name1 = chessBoardMatrix[a, b];
                chessBoardMatrix[a, b] = "";
                chessBoardMatrix[x, y] = name1;
            }
        }
        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("White") && !turn)//Black
        {
            var ob = GameObject.Find(highLightTilesMatrix[x, y]);
            if (ob.GetComponent<MeshRenderer>().material.color == Color.red)
            {
                GameObject.Find(chessBoardMatrix[x, y]).SetActive(false);
                GameObject.Find(hit1.collider.name).GetComponent<BoxCollider>().enabled = false;
                hit2 = hit1;
                endPosition = ob.transform.position;
                movementSpeed = Vector3.Distance(hit2.transform.position, endPosition) * 2f;
                move = true;
                rewind.StoreValues(a, b, x, y, turn, "Killed", hit1.collider.name, hit.collider.name, pawnFirstMove, movedOrNot);
                string name1 = chessBoardMatrix[a, b];
                chessBoardMatrix[a, b] = "";
                chessBoardMatrix[x, y] = name1;
            }
        }
        #endregion
        //If Rook is Moved for First Time then change its movedOrNot to true
        if (hit1.collider.CompareTag("Rook"))
        {
            if (movedOrNot.ContainsKey(hit1.collider.name))
            {
                if (!movedOrNot[hit1.collider.name])
                {
                    movedOrNot[hit1.collider.name] = true;
                }
            }
        }
        //If King is Moved for First Time then change its movedOrNot to true
        if (hit1.collider.CompareTag("King"))
        {
            if (!movedOrNot[hit1.collider.name])
            {
                movedOrNot[hit1.collider.name] = true;
            }
        }
        moveAudio.Play();//Movement Audio Playing
    }
}