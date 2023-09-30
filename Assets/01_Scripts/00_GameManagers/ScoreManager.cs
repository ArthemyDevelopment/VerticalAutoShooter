
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{ 
    [SerializeField]private EventObserver EO;
    [SerializeField] private int _score;
    private int Score
    {
        get => _score;
        set
        {
            _score = value;
            UpdateText();
            ProgressManager.current.CheckProgress(_score);
        }
    }
   
    #if UNITY_EDITOR 
    [Button][FoldoutGroup("DEBUG")] public void DEBUG_Add_1_Score(){AddScore(1);}
    [Button][FoldoutGroup("DEBUG")] public void DEBUG_Add_X_Score(int i){AddScore(i);}
    [Button][FoldoutGroup("DEBUG")] public void DEBUG_ResetScore(){ResetScore();}
    #endif

    public TMP_Text ScoreText;

    private void OnEnable()
    {
        EO.OnAddScore += AddScore;
        EO.OnRestScore += RestScore;
        ResetScore();
    }

    public void ResetScore()
    {
        Score = 0;
    }

    private void UpdateText()
    {
        ScoreText.text = Score.ToString();
    }

    private void AddScore(int i)
    {
        Score += i;
    }

    private void RestScore(int i)

    {
        Score -= i;
    }
}
