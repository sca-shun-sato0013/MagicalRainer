using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class WaveController : MonoBehaviour
{
    //public TimelineAsset[] waveTimelines;
    public GameObject[] waveObject;

    private PlayableDirector playableDirector;
    private int currentWaveIndex = 0;
    bool waveCompleted = false;

    public bool WaveCompleted { get { return waveCompleted; } }

    // Start is called before the first frame update
    void Start()
    {
        //playableDirector = GetComponent<PlayableDirector>();
        playableDirector = waveObject[0].GetComponent<PlayableDirector>();
        if (playableDirector == null)
        {
            //Debug.LogError("No PlayableDirector component found on the WaveController game object.");
        }
        else 
        { 
            PlayNextWave();
        }
    }

    private void Update()
    {
        if(currentWaveIndex >= waveObject.Length) { waveCompleted = true; }
        else { waveCompleted = false; }
    }

    public void PlayNextWave()
    {
        if(!waveCompleted)
        {
            //playableDirector.playableAsset = waveTimelines[currentWaveIndex];

            if(currentWaveIndex > 0)
            {
                playableDirector = waveObject[currentWaveIndex - 1].GetComponent<PlayableDirector>();
                playableDirector.Stop();
            }
            
            playableDirector = waveObject[currentWaveIndex].GetComponent<PlayableDirector>();
            playableDirector.Play();
            currentWaveIndex++;
        }
        else
        {
            Debug.Log("All waves completed!");
        }
    }
}
