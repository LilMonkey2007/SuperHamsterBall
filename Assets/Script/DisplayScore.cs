using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{

    [SerializeField]
    private FloatSO ScoreSO;

    [SerializeField]
    public TMP_Text scoreText;

    private void Start()
    {
        scoreText.text = ScoreSO.Value.ToString();
    }

}
