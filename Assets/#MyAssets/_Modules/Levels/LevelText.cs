using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class LevelText : MonoBehaviour
{
    [TextAreaAttribute]
    public string format = "{0}";

    [Inject]
    CurrentLevel currentLevel;

    void Start()
    {
        GetComponent<TMP_Text>().text = string.Format(format, currentLevel.Num);
    }
}
