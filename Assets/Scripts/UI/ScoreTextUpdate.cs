using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreTextUpdate : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = Score.score.ToString();
    }
}
