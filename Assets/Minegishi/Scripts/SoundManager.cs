using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider seSlider;

    void Start()
    {
        bgmSlider.onValueChanged.AddListener(SetAudioMixerBGM);
        seSlider.onValueChanged.AddListener(SetAudioMixerSE);
    }

    void Update()
    {
        
    }

    public void SetAudioMixerBGM(float value)
    {
        //5íiäKï‚ê≥
        value /= 5;
        //-80Å`0Ç…ïœä∑
        var volume = Mathf.Clamp(Mathf.Log10(value) * 20f,-80,0f);
        //audioMixerÇ…ë„ì¸
        audioMixer.SetFloat("BGM", volume);
        Debug.Log($"BGM:{volume}");
    }

    public void SetAudioMixerSE(float value)
    {
        //5íiäKï‚ê≥
        value /= 5;
        //-80Å`0Ç…ïœä∑
        var volume = Mathf.Clamp(Mathf.Log10(value) * 20f, -80, 0f);
        //audioMixerÇ…ë„ì¸
        audioMixer.SetFloat("SE",volume);
        Debug.Log($"SE:{volume}");
    }
}
