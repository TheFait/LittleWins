using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogManager : MonoBehaviour
{

    public static LogManager Instance;

    public TextMeshPro DebugTextField;


    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DebugTextField.text = "Celebrate even the small wins";
    }
    public void AddToLog(string text)
    {
        DebugTextField.text += "\n" + text;
    }

    public void SetLog(string text)
    {
        DebugTextField.text = text;
    }

    public void Reset()
    {
        DebugTextField.text = "Celebrate even the small wins";
    }
}
