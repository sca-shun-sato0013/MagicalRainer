using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimeController : MonoBehaviour
{
    public PlayableDirector PlayableDirector;
    public int maxPlayCount = 3;

    private int playCount = 0;

    public WaveController waveController;

    // Start is called before the first frame update
    void Start()
    {
        PlayableDirector.stopped += OnTimelineStopped;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        playCount++;
        if(playCount < maxPlayCount)
        {
            PlayableDirector.Play();
        }
        else if(playCount >= maxPlayCount && !waveController.WaveCompleted)
        {
            waveController.PlayNextWave(); 
        }
    }
}
