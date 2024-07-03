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

    private int score1 = 0; // 게임 점수
    private int score2 = 0; // 게임 점수
    private int score3 = 0; // 게임 점수

    public Slider Timerbar; //시간 바
    public float maxTime = 60;
    public float curTime = 60;

    public GameObject spawner;

    void Awake()
    {
        // 싱글톤 변수 instance가 비어있는가?
        if (instance == null)
        {
            // instance가 비어있다면(null) 그곳에 자기 자신을 할당
            instance = this;
        }
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우

            // 씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미.
            // 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
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
                score1 += newScore; //게임이 진행중일때만 점수를 더하게 됨
                PlayerPrefs.SetInt("score1", score1);
                //SoundManager.Instance.PlaySound("score");
                scoreText.text = "score : " + score1;
            }
            else if (SceneManager.GetActiveScene().name == "Stage2")
            {
                score2 += newScore; //게임이 진행중일때만 점수를 더하게 됨
                PlayerPrefs.SetInt("score2", score2);
                //SoundManager.Instance.PlaySound("score");
                scoreText.text = "score : " + score2;
            }
            else if (SceneManager.GetActiveScene().name == "Stage3")
            {
                score3 += newScore; //게임이 진행중일때만 점수를 더하게 됨
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
                score1 -= newScore; //게임이 진행중일때만 점수를 빼게 됨
                PlayerPrefs.SetInt("score1", score1);
                SoundManager.Instance.PlaySound("subscore");
                scoreText.text = "score : " + score1;
            }
            else if (SceneManager.GetActiveScene().name == "Stage2")
            {
                score2 -= newScore; //게임이 진행중일때만 점수를 빼게 됨
                PlayerPrefs.SetInt("score2", score2);
                SoundManager.Instance.PlaySound("subscore");
                scoreText.text = "score : " + score2;
            }
            else if (SceneManager.GetActiveScene().name == "Stage3")
            {
                score3 -= newScore; //게임이 진행중일때만 점수를 빼게 됨
                PlayerPrefs.SetInt("score3", score3);
                SoundManager.Instance.PlaySound("subscore");
                scoreText.text = "score : " + score3;
            }
        }
    }

    //스테이지별 최고점수 저장하기
    //스테이지1
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
    //스테이지2
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
    //스테이지3
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

        //bsetscore 저장하고 불러내서 보여주는 부분
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            int b = Get_1BestScore();
            int s = PlayerPrefs.GetInt("score1");
            Set_1BestScore(s);

            myScore.text = "획득 점수 : " + score1;

        }
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            int b = Get_2BestScore();
            int s = PlayerPrefs.GetInt("score2");

            Set_2BestScore(s);

            myScore.text = "획득 점수 : " + score2;
        }
        else if (SceneManager.GetActiveScene().name == "Stage3")
        {
            int b = Get_3BestScore();
            int s = PlayerPrefs.GetInt("score3");

            Set_3BestScore(s);

            myScore.text = "획득 점수 : " + score3;

        }

    }



}
