using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class WaveController : MonoBehaviour
{
    public TimelineAsset[] waveTimelines;

    private PlayableDirector playableDirector;
    private int currentWaveIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        if (playableDirector == null)
        {
            Debug.LogError("No PlayableDirector component found on the WaveController game object.");
        }
        else 
        { 
            PlayNextWave();
        }
    }

    public void PlayNextWave()
    {
        if(currentWaveIndex < waveTimelines.Length)
        {
            playableDirector.playableAsset = waveTimelines[currentWaveIndex];
            playableDirector.Play();
            currentWaveIndex++;
        }
        else
        {
            Debug.Log("All waves completed!");
        }
    }
}
