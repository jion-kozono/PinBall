using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;
    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;
    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

    }

    // Update is called once per frame
    void Update()
    {
        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        if (Input.touchCount > 0 && Input.touchCount <= 2)
        {
            //このフレームでのタッチ情報を取得
            Touch[] myTouches = Input.touches;
            //検出されている指の数だけ回して
            //指の位置に応じてフリッパーを動かす
            for (int i = 0; i < myTouches.Length; i++)
            {
                // 右側をタップ
                if (myTouches[i].position.x > Screen.width * 0.5f && myTouches[i].phase == TouchPhase.Stationary && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                // 左側をタップ
                if (mmyTouches[i].position.x < Screen.width * 0.5f && myTouches[i].phase == TouchPhase.Stationary && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                // 右側のタップを離す
                if (myTouches[i].position.x > Screen.width * 0.5f && myTouches[i].phase == TouchPhase.Ended && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
                // 左側のタップを離す
                if (myTouches[i].position.x < Screen.width * 0.5f && myTouches[i].phase == TouchPhase.Ended && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }

        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
