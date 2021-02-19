using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameControl : MonoBehaviour
{
    private bool firstPlayerCanMove=true;
    private bool secondPlayerCanMove=true;
    [SerializeField] private Text firstPlayerScore;
    [SerializeField] private Text secondPlayerScore;
    int score1, score2;
    [SerializeField] private float timing;
    [SerializeField] private GameObject startText, readyText, nowPressText;
    [SerializeField] private Text startingText;
    [SerializeField] private float pressTime;
    private bool timeCanFlow=false;
    private bool playerCanPress=false;
    [SerializeField] private GameObject winRound1, winRound2;
    [SerializeField] private GameObject victory1, victory2;
    private bool newRound=true;

    
    // Start is called before the first frame update
    void Start()
    {
        pressTime=Random.Range(3.1f,8.2f);
        
        

    }

    // Update is called once per frame
    void Update()
    {
        timing+=Time.deltaTime;
        playerControls();
        
        
        
    }

    private void playerControls () {
        if(Input.GetKeyDown(KeyCode.G) && firstPlayerCanMove && playerCanPress)
        {
            firstPlayerCanMove=false;
            secondPlayerCanMove=false;
            score1++;
            firstPlayerScore.text=""+score1;
            nowPressText.SetActive(false);
            winRound1.SetActive(true);
            Debug.Log("Player 1");

        }
        if(Input.GetKeyDown(KeyCode.L) && secondPlayerCanMove && playerCanPress)
        {
            secondPlayerCanMove=false;
            firstPlayerCanMove=false;
            score2++;
            secondPlayerScore.text=""+score2;
            nowPressText.SetActive(false);
            winRound2.SetActive(true);
            Debug.Log("Player 2");
        }
        if(Input.GetKeyDown(KeyCode.S) && newRound)
        {
            timing=0;
            startingText.text="Starting...";
            startText.SetActive(true);
            readyText.SetActive(false);
            nowPressText.SetActive(false);
            timeCanFlow=true;
            firstPlayerCanMove=true;
            secondPlayerCanMove=true;
            playerCanPress=false;
            victory1.SetActive(false);
            victory2.SetActive(false);
            winRound1.SetActive(false);
            winRound2.SetActive(false);
            
            
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("game");
        }
        if(timing>=2.1f & timeCanFlow)
        {
            startText.SetActive(false);
            readyText.SetActive(true);
            playerCanPress=false;
            

        }
        if(timing>=pressTime && timeCanFlow)
        {
            readyText.SetActive(false);
            nowPressText.SetActive(true);
            playerCanPress=true;
            
        }
        if(score1>=3)
        {
            victory1.SetActive(true);
            victory2.SetActive(false);
            winRound1.SetActive(false);
            newRound=false;            
        }
        else if(score2>=3)
        {
            victory2.SetActive(true);
            victory1.SetActive(false);
            winRound2.SetActive(false);
            newRound=false;
        }
        
        
    }

    
}
