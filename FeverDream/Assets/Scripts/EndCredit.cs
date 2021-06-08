using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndCredit : MonoBehaviour
{
    VideoPlayer myVideo;
    private bool RoutineHasStarted = false;
    [FMODUnity.EventRef]
    public string audio;


    void Start()
    {
        
        Bus musicBus = FMODUnity.RuntimeManager.GetBus("bus:/");
        musicBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        StartCoroutine(test());
    }

    IEnumerator test()
    {
        var go = GameObject.Find("FMOD.UnityItegration.RuntimeManager");
        Destroy(go);
        yield return null;
        myVideo = GetComponent<VideoPlayer>();
        myVideo.Play();
        FMODUnity.RuntimeManager.PlayOneShot(audio, this.transform.position);
    }
    private void Update()
    {
        if(myVideo.isPlaying && !RoutineHasStarted)
        {
            StartCoroutine("waitForVideoEnd");
            Debug.Log("Video is Playing!");

            RoutineHasStarted = true;
        }
    }

    IEnumerator waitForVideoEnd()
    {
        yield return new WaitForEndOfFrame();

        while (myVideo.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }

        EndReached();
        Debug.Log("Video Has Finished");
    }

    void EndReached()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Next Scene!");
    }
}
