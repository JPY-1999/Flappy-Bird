using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;

    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;

    private void Awake()
    {
        Application.targetFrameRate = 60;  //锁60帧

        Pause();  //一开始的时候先暂停，开始按后再开始
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false); //隐藏开始按钮
        gameOver.SetActive(false);   //隐藏gameover

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause(); //停止游戏
    }

    public void Pause()
    {
        Time.timeScale = 0f;  //暂停 时间冻结后updata里面的函数就不会执行
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
