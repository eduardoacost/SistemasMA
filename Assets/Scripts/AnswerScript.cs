using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isCorrect = false;
    public QuizManager quizManager;

    // Update is called once per frame
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Respuesta correcta");
            quizManager.correct();

        }
        else
        {
            Debug.Log("Respuesta incorrecta");
            quizManager.wrong();
        }
    }
}
