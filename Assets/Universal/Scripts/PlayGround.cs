using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayGround : GameBehaviour
{
    public enum Direction { north, east, south, west }
    public GameObject player;
    public float moveDistance = 2f;
    public float moveTweenTime = 1f;
    public Ease moveEase;
    public float shakeStrength = 0.4f;
    
    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public Ease scoreEase;
    private int score = 0;
    public int scoreBonus = 100;

    public int health = 1000000;

    private float bloom;

    // Start is called before the first frame update
    void Start()
    {
        ExecuteAfterSeconds(2, () =>
        {
            player.transform.localScale = Vector3.one * 2;
        });
        print("game started");
        ExecuteAfterFrames(1, () =>
            {
                print("One frame later");
            });

        player.transform.position = _SAVE.GetLastCheckpoint();
        player.GetComponent<Renderer>().material.color = _SAVE.GetColour();

        highScoreText.text = "HIGHEST SCORE " + _SAVE.GetHighestScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
      

       if(Input.GetKeyDown(KeyCode.W))
        {
            MovePlayer(Direction.north);
           
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MovePlayer(Direction.south);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MovePlayer(Direction.west);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MovePlayer(Direction.east);
        }
    }

    void MovePlayer(Direction _direction)
    {
        switch(_direction)
        {
            case Direction.north:
                player.transform.DOMoveZ(player.transform.position.z + moveDistance, moveTweenTime).SetEase(moveEase).OnComplete(()=>
                {
                    ShakeCamera();
                    TweenX.TweenNumbers(scoreText, score, score + scoreBonus, 1, scoreEase);
                });
                break;
            case Direction.east:
                player.transform.DOMoveX(player.transform.position.x + moveDistance, moveTweenTime).SetEase(moveEase).OnComplete(() => 
                {

                    ShakeCamera();
                    TweenX.TweenNumbers(scoreText, score, score + scoreBonus, 1, scoreEase);
                });
                break;
            case Direction.south:
                player.transform.DOMoveZ(player.transform.position.z + -moveDistance, moveTweenTime).SetEase(moveEase).OnComplete(() => 
                {

                    ShakeCamera();
                    TweenX.TweenNumbers(scoreText, score, score + scoreBonus, 1, scoreEase);
                });
                break;
            case Direction.west:
                player.transform.DOMoveX(player.transform.position.x + -moveDistance, moveTweenTime).SetEase(moveEase).OnComplete(() => 
                {

                    ShakeCamera();
                    IncreaseScore();
                   
                });
                break;


        }
        _SAVE.SetLastPosition(player.transform.position);
        ChangeColour();
    }

    void ShakeCamera()
    {
        Camera.main.DOShakePosition(moveTweenTime / 2, shakeStrength);
        _EFFECTS.TweenVignetteInOut(0.5f, 0.5f);
    }

    void ChangeColour()
    {
        Color c = ColorX.GetRandomColour();
        _SAVE.SetColour(c);
        player.GetComponent<Renderer>().material.DOColor(ColorX.GetRandomColour(), moveTweenTime);
    }

    void IncreaseScore()
    {
        TweenX.TweenNumbers(scoreText, score, score + scoreBonus, 1, scoreEase);
        score = score + scoreBonus;
        _SAVE.SetScore(score);
    }

   

    public void Poison()
    {
        Debug.Log("poison");
        health -= 1;
    }

    public void AddHealth(int _health) => health += _health;


    public void loseHealth(int _health) => health -= _health;
    
}
