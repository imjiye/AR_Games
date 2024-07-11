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
            Debug.LogWarning("���� �ΰ� �̻��� �Ŵ��� ����");
            Destroy(gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        text1.DOText("���ڱ� ��Ÿ�� ���� ������!\r\n�̴�ζ�� ������ ���������ž�...!!!\r\n\r\n���͸� ����� ���踦 ��Ű�� ������ �Ǿ��!", 3f);
    }

    public void Text2()
    {
        text2.DOText("���� �� ������ 10�� ȹ�� ����!", 2f);
    }
    public void Text3()
    {
        text3.DOText("���Ϳ� ������ �԰� ������ ������!!!", 2f);
    }
    public void Text4()
    {
        text4.DOText("���� Best Score�� �������� :)", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
