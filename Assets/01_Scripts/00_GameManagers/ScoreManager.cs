
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreManager : SingletonManager<ScoreManager>
{ 
    
    [FormerlySerializedAs("ScoreEvent")] [FormerlySerializedAs("EO")] [SerializeField]private EventObserver EventObserver;
    [SerializeField] private int _score;
    public int Score
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
        EventObserver.OnAddScore += AddScore;
        EventObserver.OnRestScore += RestScore;
        EventObserver.OnStartGame += ResetScore;
        EventObserver.OnEndGame += SaveScore;
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
    
    void SaveScore()
    {
        int HighScore = 0;
        if (PlayerPrefs.HasKey("Score"))
            HighScore = PlayerPrefs.GetInt("Score");
        
        if(Score>HighScore)
            PlayerPrefs.SetInt("Score", Score);
    }
}
