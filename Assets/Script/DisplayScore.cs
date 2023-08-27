using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    [SerializeField]
    private FloatSO ScoreSO;
>>>>>>> Stashed changes

    [SerializeField]
    public TMP_Text scoreText;

<<<<<<< Updated upstream
    [SerializeField]
    private FloatSO ScoreSO;

=======
>>>>>>> Stashed changes
    private void Start()
    {
        scoreText.text = ScoreSO.Value.ToString();
    }

}
