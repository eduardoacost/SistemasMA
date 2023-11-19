using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrasilMinijuego_1 : MonoBehaviour
{
    public bool isGameOver;
    [SerializeField] MovimientosCamara MovCam;
    [SerializeField] GameObject Banana;
    [SerializeField] Sprite[] Preguntas;
    [SerializeField] Transform[] QuizBananaPositions;
    [SerializeField] Transform[] RecolectBananaPositions;
    [SerializeField] Camera cam;
    [SerializeField] GameObject infoPlayerGUI, BananaCounterGUI, MonkeyQuestionsGUI, ContextGUI_1, ContextGUI_2;
    [SerializeField] Text CounterText;
    public int MinigameState = -1;
    int RespuestaCorrecta = 0;
    int CountBananas = 0;
    MiniGameInteractiveArea InteractiveArea;
    bool isStart = false;
    Vector3 originalPosition;
    GameObject[] bananasA;
    private void Start()
    {
        isGameOver = false;
        originalPosition = transform.position;
        InteractiveArea = GetComponent<MiniGameInteractiveArea>();
    }
    private void Update()
    {
        //CheckMinigame();
        if (isStart)
        {
            MiniGame(MinigameState);
        }
    }
    public bool isAllowed = true;
    bool p = false;
    public void CheckMinigame()
    {
        if(MinigameState < 4 && isAllowed)
        {
            MinigameState++;
            Debug.Log(MinigameState);
            isStart = true;
        }
    }

    void MiniGame(int i)
    {
        switch (i)
        {
            case 0: ContextGUI(0, ContextGUI_1, BananaCounterGUI); break; //explicacion (video)
            case 1: RecolectionGame(); ContextGUI(1, ContextGUI_1, BananaCounterGUI); break;//Recolection game
            case 2: ContextGUI(0, ContextGUI_2, BananaCounterGUI); break; //Caractericticas
            case 3: QuizGame(); ContextGUI(1, ContextGUI_2, MonkeyQuestionsGUI); break; //Quiz Game
            case 4: EndMinigame(InteractiveArea.LastPosition, InteractiveArea.ActualTileMap, InteractiveArea.TileMapMinigame); break; //Fin del minijuego
        }
    }
    void StartMinigame(Transform spawn, GameObject minigameTilemap, GameObject actualTilemap)
    {
        InteractiveArea.GetComponent<MiniGameInteractiveArea>().isStart = true;
        transform.position = spawn.position;
        actualTilemap.SetActive(false);
        minigameTilemap.SetActive(true);

    }

    void EndMinigame(Transform lastPosition, GameObject mapTilemap, GameObject minigameTilemap)
    {
        isGameOver = true;
        MonkeyQuestionsGUI.SetActive(false);
        bananasA = GameObject.FindGameObjectsWithTag("Pickable");
        foreach (GameObject b in bananasA)
        {
            b.GetComponent<BananasMovimiento>().Delete();
        }
        transform.position = originalPosition;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        MovCam.ChangeCameraPosition(0);
        GameObject.FindGameObjectWithTag("Player").transform.position = lastPosition.position;
        minigameTilemap.SetActive(false);
        mapTilemap.SetActive(true);
        
    }

    void ContextGUI(int id, GameObject GUI, GameObject ActualGUI)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        switch (id)
        {
            case 0:
                GUI.SetActive(true);
                ActualGUI.SetActive(false); 
                break;
            case 1:
                GUI.SetActive(false);
                ActualGUI.SetActive(true);
                break;
        }
        
    }


    private bool isReady_1 = false;
    int[] correctAnswers = {3, 1, 4, 3};
    int actualAnswer = 0;
    int positionAnswerQuestion = 0;
    
    
    void QuizGame()
    {
        if (!isReady_1)
        {
            InteractiveArea.isStart = true;
            transform.position = new Vector3(InteractiveArea.SpawnMinigame.position.x - 15, InteractiveArea.SpawnMinigame.position.y, 0);
            GameObject.FindGameObjectWithTag("Player").transform.position = InteractiveArea.SpawnMinigame.position;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
            MonkeyQuestionsGUI.GetComponent<RawImage>().texture = Preguntas[0].texture;
            InteractiveArea.ActualTileMap.SetActive(false);
            InteractiveArea.TileMapMinigame.SetActive(true);

            MovCam.ChangeCameraPosition(1);
            for (int i = 0; i < QuizBananaPositions.Length; i++)
            {
                Transform t = QuizBananaPositions[i];
                GameObject b = Instantiate(Banana);
                
                b.transform.position = t.position;
                b.transform.localScale = b.transform.localScale * .5f;
                b.GetComponent<BananasMovimiento>().SetNum(i+1, cam);
                b.AddComponent<Rigidbody2D>();
                b.GetComponent<Rigidbody2D>().isKinematic = true;
                b.tag = "Pickable";

            }
            isReady_1 = true;
        }
        else
        {
            if (positionAnswerQuestion < Preguntas.Length)
            {
                if (actualAnswer == correctAnswers[positionAnswerQuestion])
                {
                    Debug.Log("Correcto= " + actualAnswer);
                    ChangeQuestion();
                }
            }
            else
            {
                //EndGame
                CheckMinigame();
            }
                

          
        }
        
    }
    void ChangeQuestion()
    {
        if (positionAnswerQuestion < Preguntas.Length)
        {
            positionAnswerQuestion ++;
            MonkeyQuestionsGUI.GetComponent<RawImage>().texture = Preguntas[positionAnswerQuestion].texture;
        }
        
    }
    public bool CheckAnswer(int i)
    {
        actualAnswer = i;
        bool isCorect = false;
        if (RespuestaCorrecta == actualAnswer)
        {
            isCorect = true;
        }
        return isCorect;
    }


    private bool isReady_2 = false;
    private List<GameObject> BananaAnswer;
    void RecolectionGame()
    {
        if (!isReady_2)
        {
            isAllowed = false;
            BananaCounterGUI.SetActive(true);
            for (int i = 0; i < RecolectBananaPositions.Length; i++)
            {
                Transform t = RecolectBananaPositions[i];
                GameObject b = Instantiate(Banana);
                b.transform.position = t.position;
                b.GetComponent<BananasMovimiento>().SetNum(0, cam);
                b.GetComponent<BoxCollider2D>().isTrigger = true;
                b.tag = "Recolectable";
                
            }
            isReady_2 = true;
        }
        else
        {
            if (CountBananas == RecolectBananaPositions.Length-1)
            {
                isAllowed = true;
            }
        }

        
    }


    public void AddBanana()
    {
        CountBananas++;
        CounterText.text = CountBananas.ToString();
    }
}
