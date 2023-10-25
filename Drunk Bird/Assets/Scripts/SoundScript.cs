using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public void PlaySound(AudioSource audio, ref bool soundToggle)
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

    public void ToggleSoundOn(ref bool soundToggle)
    {
        soundToggle = true;
    }
}
