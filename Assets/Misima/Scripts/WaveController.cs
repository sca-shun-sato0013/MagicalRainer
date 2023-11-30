using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    //public TimelineAsset[] waveTimelines;
    public GameObject[] waveObject;

    private PlayableDirector playableDirector;
    private int currentWaveIndex = 0;
    bool waveCompleted = false;

    [SerializeField] MainGameController mainGameController;

    public bool WaveCompleted { get { return waveCompleted; } }

    public int WaveNum { get { return currentWaveIndex + 1; } }

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

    public void PlayNextWave()
    {
        if(currentWaveIndex < waveObject.Length)
        {
            mainGameController.WaveDirection(); //WAVEˆÚs‰‰oÄ¶

            //playableDirector.playableAsset = waveTimelines[currentWaveIndex];
            
            //ŽŸ‚ÌWAVE‚ÉˆÚs
            playableDirector = waveObject[currentWaveIndex].GetComponent<PlayableDirector>();
            playableDirector.Play();
            currentWaveIndex++;
        }
        else
        {
            Debug.Log("All waves completed!");
            waveCompleted = true;
        }
    }
}
