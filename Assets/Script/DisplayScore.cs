using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{

    [SerializeField]
    public TMP_Text scoreText;

    [SerializeField]
    private FloatSO ScoreSO;

    private void Start()
    {
        scoreText.text = ScoreSO.Value.ToString();
    }

}
