using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioS, audioM;
    public AudioClip[] pistas_Sfx, pistas_Musica;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(int index, float delay = 0f)
    {
        audioS.clip = pistas_Sfx[index];
        audioS.loop = false;
        if (delay == 0f)
            audioS.Play();
        else
        {
            audioS.time = delay;
            audioS.Play();
        }
    }

    public void PlayJump()
    {
        PlaySound(0);
    }
    public void PlayHurt()
    {
        PlaySound(1);
    }
    public void PlayCollectable()
    {
        PlaySound(2);
    }

    public void PlayMusic(int index)
    {
        audioM.clip = pistas_Musica[index];
        audioM.loop = true;
        audioM.Play();
    }

    public void PlayRandomMusic()
    {
        PlayMusic(Random.Range(0, pistas_Musica.Length));
    }
}
