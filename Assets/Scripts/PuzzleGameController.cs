using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGameController : MonoBehaviour
{
    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> AllCards = new List<Button>();

    [SerializeField] private Sprite backImage;

    private bool primeraSeleccion, segundaSeleccion;

    private int intentosDeHacerParejas;
    private int contadorParejasCorrectas;
    private int parejasEnJuego;

    private int indexPrimeraSeleccion, indexSegundaSeleccion;
    private string primeraSeleccionPuzzle, segundaSeleccionPuzzle;

    public GameObject GameOverScreen;



    private void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites");
        GameOverScreen.SetActive(false);
        GetCards();
        AddListeners();
        AddGamePuzzles();
        parejasEnJuego = gamePuzzles.Count / 2;
        aleatorizarLista(gamePuzzles);
    }

    void Start()
    {
        GameOverScreen.SetActive(false);
        GetCards();
        AddListeners();
        AddGamePuzzles();
        parejasEnJuego = gamePuzzles.Count / 2;
        aleatorizarLista(gamePuzzles);
    }

    void GetCards()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleCard");

        for(int i = 0; i < objects.Length; i++)
        {
            AllCards.Add(objects[i].GetComponent<Button>());
            AllCards[i].image.sprite = backImage;
        }
    }

    void AddGamePuzzles()
    {
        int looper = AllCards.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if(index == looper / 2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);

            index++;
        }

    }

    void AddListeners()
    {
        foreach(Button card in AllCards)
        {
            card.onClick.AddListener(() => PickAPuzzle());
        }
    }

    public void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("You are Clicking the card: " + name);

        if (!primeraSeleccion)
        {
            primeraSeleccion = true;

            indexPrimeraSeleccion = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            primeraSeleccionPuzzle = gamePuzzles[indexPrimeraSeleccion].name;

            AllCards[indexPrimeraSeleccion].image.sprite = gamePuzzles[indexPrimeraSeleccion];
        } else if (!segundaSeleccion)
        {
            segundaSeleccion = true;

            indexSegundaSeleccion = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            segundaSeleccionPuzzle = gamePuzzles[indexSegundaSeleccion].name;

            AllCards[indexSegundaSeleccion].image.sprite = gamePuzzles[indexSegundaSeleccion];

            intentosDeHacerParejas++;

            StartCoroutine(comprobarSiLasCartasCoinciden());
        }
    }

    IEnumerator comprobarSiLasCartasCoinciden()
    {
        yield return new WaitForSeconds(1f);
        if(primeraSeleccionPuzzle == segundaSeleccionPuzzle)
        {
            yield return new WaitForSeconds(0.5f);

            AllCards[indexPrimeraSeleccion].interactable = false;
            AllCards[indexSegundaSeleccion].interactable = false;

            AllCards[indexPrimeraSeleccion].image.color = new Color(0, 0, 0, 0);
            AllCards[indexSegundaSeleccion].image.color = new Color(0, 0, 0, 0);

            RevisaSiElJuegoHaTerminado();
        } else
        {
            AllCards[indexPrimeraSeleccion].image.sprite = backImage;
            AllCards[indexSegundaSeleccion].image.sprite = backImage;
        }
        yield return new WaitForSeconds(0.5f);

        primeraSeleccion = segundaSeleccion = false;
        
    }

    void RevisaSiElJuegoHaTerminado()
    {
        contadorParejasCorrectas++;

        if (contadorParejasCorrectas == parejasEnJuego)
        {
            GameOverScreen.SetActive(true);
            Debug.Log("Game Finished");
            Debug.Log("It took you: " + intentosDeHacerParejas + "many guess(es) to finish the game");
        }
    }

    void aleatorizarLista(List<Sprite> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            Sprite temporal = lista[i];
            int randomIndex = Random.Range(i, lista.Count);
            lista[i] = lista[randomIndex];
            lista[randomIndex] = temporal;
        }
    }


    

    // Update is called once per frame
    void Update()
    {
        
    }
}
