using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int PlayerScore { get; private set; }
    public Text ScoreTextField;
    public Text HighscoreTextField;
    
    public GameObject GameOverScreen;

    public AudioSource GameOverSound;
    private bool GameOverSound_Toggle;

    public AudioSource ScoreSound;
    private bool ScoreSound_Toggle;

    public BirdScript Bird;
    private SoundScript SoundScript;

    //TODO: place player pref logic in seperate file
    private const string Highscore = "Highscore";

    private void Awake()
    {
        Bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
        SoundScript = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>();
    }

    void Start()
    {
        SoundScript.ToggleSoundOn(ref GameOverSound_Toggle);
        SoundScript.ToggleSoundOn(ref ScoreSound_Toggle);

        PlayerScore = 0;
        DisplayHighscore();

    }

    [ContextMenu("Increase Player Score")]
    public void AddScore(int scoreToAdd = 1)
    {
        SoundScript.ToggleSoundOn(ref ScoreSound_Toggle);
       
        if (Bird.IsAlive)
        {
            SoundScript.PlaySound(ScoreSound, ref ScoreSound_Toggle);
            PlayerScore += scoreToAdd;
            ScoreTextField.text = PlayerScore.ToString();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        SoundScript.PlaySound(GameOverSound, ref GameOverSound_Toggle);
        
        SaveHighscore(PlayerScore);
        DisplayHighscore();
        
        GameOverScreen.SetActive(true);
    }

    //TODO: place player pref logic in seperate file
    private void SaveHighscore(int score)
    {
        if (score > LoadHighScore())
        PlayerPrefs.SetInt(Highscore, score);
    }

    private int LoadHighScore()
    {
        return PlayerPrefs.GetInt(Highscore);
    }

    private void DisplayHighscore()
    {
        HighscoreTextField.text = $"{Highscore}: {LoadHighScore()}";
    }
}
