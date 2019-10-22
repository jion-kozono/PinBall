using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    //点数を格納する変数
    public int score = 0;

    //ポイントを表示するテキスト
    private GameObject PointText;
    // Use this for initialization
    void Start()
    {
        //シーン中の10pTextオブジェクトを取得
        this.PointText = GameObject.Find("PointText");
    }

    // Update is called once per frame
    void Update()
    {
        this.PointText.GetComponent<Text>().text = "点数" + this.score + "点";
    }
}
