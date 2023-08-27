using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;

  //  [SerializeField]
  //  private FloatSO ScoreSO;

    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text,int.Parse(ScoreSO.Value));
    }
}
