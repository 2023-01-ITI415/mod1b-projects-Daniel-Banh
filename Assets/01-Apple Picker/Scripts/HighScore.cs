using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI; 


public class HighScore : MonoBehaviour {

    static private Text      _UI_TEXT;                                        // a
    static private int       _SCORE = 1000;                                   // b

    private Text txtCom;  // txtCom is a reference to this GOs Text component

    void Awake () {                                                           // c
        _UI_TEXT = GetComponent<Text>();
        if (PlayerPrefs.HasKey("HighScore")) { 
            SCORE = PlayerPrefs.GetInt("HighScore");         
        }      
        PlayerPrefs.SetInt("HighScore", SCORE);                    
    }

    static public int SCORE {  
        get { return _SCORE; }                                               // e  
        private set {                                                         // f
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            if ( _UI_TEXT != null ) {                                         // g
                _UI_TEXT.text = "High Score: " + value.ToString( "#,0" );
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE( int scoreToTry ) {                 // h
        if ( scoreToTry <= SCORE ) return; // If scoreToTry is too low, return
        SCORE = scoreToTry;
    }
    [Tooltip( "Check this box to reset the HighScore in PlayerPrefs" )]
    public bool resetHighScoreNow = false;

    void OnDrawGizmos() { 
        if ( resetHighScoreNow ) {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt( "HighScore", 1000 );
            Debug.LogWarning( "PlayerPrefs HighScore reset to 1,000." );
        }
    }

}

