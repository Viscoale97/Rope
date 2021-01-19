using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class LevelChange : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;

    public VideoPlayer video; // Drag & Drop the GameObject holding the VideoPlayer component
    public string SceneName;
    public VideoPlayer videoPlayer;
    public VideoPlayer videoPlayer2;
    public VideoPlayer videoPlayer3;
    private void Start()
    {
        videoPlayer.loopPointReached += Load;
        //FadeToNextLevel();
    }

    public void Load(VideoPlayer vp)
    {
        if(SceneManager.GetActiveScene().name == "Video Scuola")
        {
            SceneManager.LoadScene("Video Scuola 1");
        }
        
        if(SceneManager.GetActiveScene().name == "Video Scuola 1")
        {
            SceneManager.LoadScene("Video Scuola 2");
        }

        if (SceneManager.GetActiveScene().name == "Video Scuola 2")
        {
            SceneManager.LoadScene("Bedroom");
        }
        //FadeToNextLevel();
    }

    public void LoadImmediatley()
    {
        SceneManager.LoadScene("Bedroom");
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            FadeToNextLevel();
        }*/
        

    }

    public void StartVideo2()
    {
        videoPlayer2.Play();
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(1);//the scene that you want to load after the video has ended.
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        //animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
