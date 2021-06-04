using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MovieToNextScene : MonoBehaviour
{
    VideoPlayer myVideo;
    private bool RoutineHasStarted = false;
    
    void Start()
    {
        myVideo = GetComponent<VideoPlayer>();
        myVideo.Play();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Next Scene!");
    }
}
