using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizDB : MonoBehaviour
{
    [SerializeField] private List<Question> n_questionList = null;

    public GameObject canvasPreguntas;
    public GameObject actividad;
    public GameObject mapa;

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    public GameObject panelDespues;

    public GameObject player;

    public Question GetQuestion(bool remove = true)
    {
        if (n_questionList.Count == 0)
            ApagarPreguntas();
        if (n_questionList.Count == 2)
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
        }
        else if (n_questionList.Count == 1)
        {
            panel2.SetActive(false);
            panel3.SetActive(true);
        }


            int index = Random.Range(0, n_questionList.Count);

        if (!remove)
            return n_questionList[index];

        Question q = n_questionList[index];
        n_questionList.RemoveAt(index);

        return q;
    }

    public void ApagarPreguntas()
    {
        canvasPreguntas.SetActive(false);
        panelDespues.SetActive(true);
    }
}
