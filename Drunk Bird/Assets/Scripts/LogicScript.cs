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

    //TODO: place player pref logic in seperate file
    private const string Highscore = "Highscore";

    void Start()
    {
        ToggleSoundOn(ref GameOverSound_Toggle);
        ToggleSoundOn(ref ScoreSound_Toggle);

        PlayerScore = 0;
        DisplayHighscore();

        Bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    [ContextMenu("Increase Player Score")]
    public void AddScore(int scoreToAdd = 1)
    {
        ToggleSoundOn(ref ScoreSound_Toggle);
       
        if (Bird.IsAlive)
        {
            PlaySound(ScoreSound, ref ScoreSound_Toggle);
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
        PlaySound(GameOverSound, ref GameOverSound_Toggle);
        SaveHighscore(PlayerScore);
        DisplayHighscore();
        GameOverScreen.SetActive(true);
    }

    //TODO: place sound scripts in seperate file
    private void PlaySound(AudioSource audio, ref bool soundToggle)
    {
        if (soundToggle)
        {
            audio.Play();
            ToggleSoundOff(ref soundToggle);
        }
    }

    private void ToggleSoundOff(ref bool soundToggle)
    {
        soundToggle = false;
    }

    private void ToggleSoundOn(ref bool soundToggle)
    {
        soundToggle = true;
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
