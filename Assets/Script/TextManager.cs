using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextManager : MonoBehaviour
{
    public static TextManager instance;

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 매니저 존재");
            Destroy(gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        text1.DOText("갑자기 나타난 몬스터 무리들!\r\n이대로라면 세상이 위험해질거야...!!!\r\n\r\n몬스터를 사냥해 세계를 지키는 영웅이 되어보자!", 3f);
    }

    public void Text2()
    {
        text2.DOText("몬스터 한 마리당 10점 획득 가능!", 2f);
    }
    public void Text3()
    {
        text3.DOText("몬스터와 보석을 먹고 유령을 피하자!!!", 2f);
    }
    public void Text4()
    {
        text4.DOText("나의 Best Score를 높여보자 :)", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
