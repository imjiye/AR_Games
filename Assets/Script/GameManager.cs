using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public Text scoreText;

    private int score = 0;

    public GameObject gameoverUI;
    public Text bestScore;
    public Text myScore;

    private int score1 = 0; // ���� ����
    private int score2 = 0; // ���� ����
    private int score3 = 0; // ���� ����

    public Slider Timerbar; //�ð� ��
    public float maxTime = 60;
    public float curTime = 60;

    public GameObject spawner;

    void Awake()
    {
        // �̱��� ���� instance�� ����ִ°�?
        if (instance == null)
        {
            // instance�� ����ִٸ�(null) �װ��� �ڱ� �ڽ��� �Ҵ�
            instance = this;
        }
        else
        {
            // instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ�Ǿ� �ִ� ���

            // ���� �ΰ� �̻��� GameManager ������Ʈ�� �����Ѵٴ� �ǹ�.
            // �̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ� �ڽ��� ���� ������Ʈ�� �ı�
            Debug.LogWarning("���� �ΰ� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Timerbar.value = maxTime;


    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover)
        {
            TimerUpdata();
        }
    }

    public void TimerUpdata()
    {
        if(curTime >= 0)
        {
            curTime -= 3*Time.deltaTime;
            Timerbar.value = (int)curTime;
        }
        else
        {
            Dead();
        }
    }

    public void AddScore(int newScore)
    {
        if(!isGameover)
        {
            if (SceneManager.GetActiveScene().name == "Stage1")
            {
                score1 += newScore; //������ �������϶��� ������ ���ϰ� ��
                PlayerPrefs.SetInt("score1", score1);
                //SoundManager.Instance.PlaySound("score");
                scoreText.text = "score : " + score1;
            }
            else if (SceneManager.GetActiveScene().name == "Stage2")
            {
                score2 += newScore; //������ �������϶��� ������ ���ϰ� ��
                PlayerPrefs.SetInt("score2", score2);
                //SoundManager.Instance.PlaySound("score");
                scoreText.text = "score : " + score2;
            }
            else if (SceneManager.GetActiveScene().name == "Stage3")
            {
                score3 += newScore; //������ �������϶��� ������ ���ϰ� ��
                PlayerPrefs.SetInt("score3", score3);
                //SoundManager.Instance.PlaySound("score");
                scoreText.text = "score : " + score3;
            }
        }
    }

    public void SubScore(int newScore)
    {
        if (!isGameover)
        {
            if (SceneManager.GetActiveScene().name == "Stage1")
            {
                score1 -= newScore; //������ �������϶��� ������ ���� ��
                PlayerPrefs.SetInt("score1", score1);
                SoundManager.Instance.PlaySound("subscore");
                scoreText.text = "score : " + score1;
            }
            else if (SceneManager.GetActiveScene().name == "Stage2")
            {
                score2 -= newScore; //������ �������϶��� ������ ���� ��
                PlayerPrefs.SetInt("score2", score2);
                SoundManager.Instance.PlaySound("subscore");
                scoreText.text = "score : " + score2;
            }
            else if (SceneManager.GetActiveScene().name == "Stage3")
            {
                score3 -= newScore; //������ �������϶��� ������ ���� ��
                PlayerPrefs.SetInt("score3", score3);
                SoundManager.Instance.PlaySound("subscore");
                scoreText.text = "score : " + score3;
            }
        }
    }

    //���������� �ְ����� �����ϱ�
    //��������1
    public int Get_1BestScore()
    {
        int BS = PlayerPrefs.GetInt("1Bestscore");
        return BS;
    }

    public void Set_1BestScore(int cur_score)
    {
        if (cur_score > Get_1BestScore())
        {
            PlayerPrefs.SetInt("1Bestscore", cur_score);
            bestScore.color = Color.red;
            bestScore.fontSize = 45;
            Debug.Log("s1+");
            bestScore.text = "1Best Score : " + cur_score;

        }
        else
        {
            bestScore.color = Color.blue;
            bestScore.fontSize = 30;
            Debug.Log("s1-");
            bestScore.text = "1Best Score : " + Get_1BestScore();
        }
    }
    //��������2
    public int Get_2BestScore()
    {
        int BS = PlayerPrefs.GetInt("2Bestscore");
        return BS;
    }

    public void Set_2BestScore(int cur_score)
    {
        if (cur_score > Get_2BestScore())
        {
            PlayerPrefs.SetInt("2Bestscore", cur_score);
            bestScore.color = Color.red;
            bestScore.fontSize = 45;
            Debug.Log("s2+");
            bestScore.text = "2Best Score : " + cur_score;
        }
        else
        {
            bestScore.color = Color.blue;
            bestScore.fontSize = 25;
            Debug.Log("s2-");
            bestScore.text = "2Best Score : " + Get_2BestScore();
        }
    }
    //��������3
    public int Get_3BestScore()
    {
        int BS = PlayerPrefs.GetInt("3Bestscore");
        return BS;
    }

    public void Set_3BestScore(int cur_score)
    {
        if (cur_score > Get_3BestScore())
        {
            PlayerPrefs.SetInt("3Bestscore", cur_score);
            bestScore.color = Color.red;
            bestScore.fontSize = 45;
            Debug.Log("s3+");
            bestScore.text = "3Best Score : " + cur_score;
        }
        else
        {
            bestScore.color = Color.blue;
            bestScore.fontSize = 25;
            Debug.Log("s3-");
            bestScore.text = "3Best Score : " + Get_3BestScore();
        }
    }

    public void Dead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);

        spawner.gameObject.SetActive(false);

        SoundManager.Instance.PlaySound("end");

        //bsetscore �����ϰ� �ҷ����� �����ִ� �κ�
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            int b = Get_1BestScore();
            int s = PlayerPrefs.GetInt("score1");
            Set_1BestScore(s);

            myScore.text = "ȹ�� ���� : " + score1;

        }
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            int b = Get_2BestScore();
            int s = PlayerPrefs.GetInt("score2");

            Set_2BestScore(s);

            myScore.text = "ȹ�� ���� : " + score2;
        }
        else if (SceneManager.GetActiveScene().name == "Stage3")
        {
            int b = Get_3BestScore();
            int s = PlayerPrefs.GetInt("score3");

            Set_3BestScore(s);

            myScore.text = "ȹ�� ���� : " + score3;

        }

    }



}
