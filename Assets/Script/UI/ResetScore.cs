using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    [SerializeField]
    private FloatSO ScoreSO,TotalSO;

    private void Start()
    {
        ScoreSO.Value = 0;
        TotalSO.Value = 0;
    }
}
