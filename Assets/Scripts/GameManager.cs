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
        Application.targetFrameRate = 60;  //��60֡

        Pause();  //һ��ʼ��ʱ������ͣ����ʼ�����ٿ�ʼ
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false); //���ؿ�ʼ��ť
        gameOver.SetActive(false);   //����gameover

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

        Pause(); //ֹͣ��Ϸ
    }

    public void Pause()
    {
        Time.timeScale = 0f;  //��ͣ ʱ�䶳���updata����ĺ����Ͳ���ִ��
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
