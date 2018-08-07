using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallController : MonoBehaviour
{


    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject scoreText;

    private int score = 0;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");


    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.z < this.visiblePosZ){
            //GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }


    }

    void OnCollisionEnter(Collision other){

        if (other.gameObject.tag == "SmallStarTag"){
            this.scoreText.GetComponent<Text>().text = "Score:" + (score += 1);
        }else if(other.gameObject.tag == "SmallCloudTag"){
            this.scoreText.GetComponent<Text>().text = "Score:" + (score += 5);
        }else if(other.gameObject.tag == "LargeCloudTag"){
            this.scoreText.GetComponent<Text>().text = "Score:" + (score += 20);
        }else if(other.gameObject.tag == "LargeStarTag"){
            this.scoreText.GetComponent<Text>().text = "Score:" + (score += 10);
        }

    }

}
