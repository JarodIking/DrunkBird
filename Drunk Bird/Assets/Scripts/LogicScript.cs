using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int PlayerScore { get; private set; }
    public Text ScoreText;
    
    public GameObject GameOverScreen;

    public AudioSource GameOverSound;
    private bool GameOverSound_Toggle;

    public AudioSource ScoreSound;
    private bool ScoreSound_Toggle;

    public BirdScript Bird;

    void Start()
    {
        ToggleSoundOn(ref GameOverSound_Toggle);
        ToggleSoundOn(ref ScoreSound_Toggle);

        PlayerScore = 0;

        Bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    [ContextMenu("Increase Player Score")]
    public void AddScore(int scoreToAdd = 1)
    {
        Debug.Log("Add Score triggerd");
        ToggleSoundOn(ref ScoreSound_Toggle);
       
        if (Bird.IsAlive)
        {
            PlaySound(ScoreSound, ref ScoreSound_Toggle);
            PlayerScore += scoreToAdd;
            ScoreText.text = PlayerScore.ToString();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        PlaySound(GameOverSound, ref GameOverSound_Toggle);
        GameOverScreen.SetActive(true);
    }

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
}
