using UnityEngine;
using TMPro;

public class MathCircle : MonoBehaviour
{
    [Header("Configuración del cálculo")]
    public int numberA = 2;
    public int numberB = 3;

    [Header("Referencias")]
    public TMP_Text equationText;

    private int correctAnswer;
    private int hits = 0;
    private bool isComplete = false;

    void Start()
    {
        correctAnswer = numberA + numberB;
        equationText.text = numberA + " + " + numberB;
    }

    public void RegisterHit()
    {
        if (isComplete) return;

        hits++;
        Debug.Log("Clavadas: " + hits + "/" + correctAnswer);

        if (hits >= correctAnswer)
        {
            CompleteCircle();
        }
    }

    void CompleteCircle()
    {
        isComplete = true;
        Debug.Log("¡Círculo completo!");
        equationText.text = "¡Completado!";
        

        GetComponent<RotatingCircle>().enabled = false;
    }
}
