using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreTextLeft;
    public Text scoreTextRight;
    public GameObject ball;
    private bool started = false;
    private int scoreRight = 0;
    private int scoreLeft = 0;
    private BallController ballController;
    private Vector3 startingPosition;
    void Start()
    {
        this.ballController = this.ball.GetComponent<BallController>();
        this.startingPosition = this.ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.started)
            return;
        if (Input.GetKey(KeyCode.Space))
        {
            this.started = true;
            this.ballController.Go();
        }    
    }
    public void ScoreGoalLeft()
    {
        Debug.Log("ScoreGoalLeft");
        this.scoreRight += 1;
        UpdateUI();
        ResetBall();
    }
    public void ScoreGoalRight()
    {
        Debug.Log("ScoreGoalRight");
        this.scoreLeft += 1;
        UpdateUI();
        ResetBall();
    }
    private void UpdateUI()
    {
        this.scoreTextLeft.text = this.scoreTextLeft.ToString();
        this.scoreTextRight.text = this.scoreTextRight.ToString();
    }    
    private void ResetBall()
    {
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        this.ballController.Go();
    }    

}

