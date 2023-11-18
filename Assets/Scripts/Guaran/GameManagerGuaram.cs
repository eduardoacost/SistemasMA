using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManagerGuaram : MonoBehaviour
{
    [SerializeField] private Color m_correctColor = Color.white;
    [SerializeField] private Color m_incorrectColor = Color.white;
    [SerializeField] private float m_waitTime = 0.0f;

    [SerializeField] private QuizDB m_quizDB = null;
    [SerializeField] private QuizUI m_quizUI = null;

    private void Start()
    {
        NextQuestion();
    }

    private void NextQuestion()
    {
        m_quizUI.Construct(m_quizDB.GetQuestion(), GiveAnswer);
    }

    private void GiveAnswer(OptionButton optionButton)
    {
        StartCoroutine(GiveAnswerRoutine(optionButton));
    }

    private IEnumerator GiveAnswerRoutine(OptionButton optionButton)
    {
        optionButton.SetColor(optionButton.Option.corrcect ? m_correctColor : m_incorrectColor);

        yield return new WaitForSeconds(m_waitTime);

        optionButton.SetColor(optionButton.m_originalColor);

        if (optionButton.Option.corrcect)
            NextQuestion();
    }
}
