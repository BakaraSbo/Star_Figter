using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public float MusicVolume, EffectVolume;
    public Sound[] sounds;
    public GameObject MusicRange, EffectRange;
    public GameObject[] MusicRangeImages, EffectRangeImages;
    public Color blue, black;
    void Awake()
    {
        
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            if (s.name == "Theme") s.music = true;
            else s.music = false;
        }
        Play("Theme");

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void SetMusicVolume(bool increase)
    {
        if (increase)
        {
            if (MusicVolume < 0.1f) MusicVolume += 0.01f;
        }
        else
        {
            if (MusicVolume > 0) MusicVolume -= 0.01f;
        }
        foreach(Sound s in sounds)
        {

            if (s.music)
            {
                s.volume = MusicVolume;
                s.source.volume = s.volume;
            }

        }
        ChangeRange(MusicRangeImages, MusicVolume);
    }
    public void SetEffectsVolume(bool increase)
    {
        if (increase)
        {
            if (EffectVolume < 0.1f) EffectVolume += 0.01f;
        }
        else
        {
            if (EffectVolume > 0) EffectVolume -= 0.01f;
        }
        foreach (Sound s in sounds)
        {
            if (!s.music)
            {
                s.volume = EffectVolume;
                s.source.volume = s.volume;
            }
        }
        ChangeRange(EffectRangeImages, EffectVolume);
    }
    private void ChangeRange(GameObject[] Range, float volume)
    {
        float i = 0f;
        foreach(GameObject image in Range)
        {
            if (i <= volume - 0.01f) image.GetComponent<Image>().color = blue;
            else image.GetComponent<Image>().color = black;
            i += 0.01f;
        }
    }

}
