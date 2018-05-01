using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


    public int level;
    public SoundManager soundManager;
    public Puzzle[] puzzles;
    public static GameManager instance = null;
    
	void Start () {
        level = 0;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
	}

	private void createPuzzle(int puzzleIndex)
    {
        Instantiate(puzzles[puzzleIndex]);
    }
	
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (level)
            {
                case 0:
                    level = 1;
                    soundManager.startMusic();
                    createPuzzle(0);
                    break;
                case 2:
                    level = 3;
                    soundManager.startMusic();
                    createPuzzle(1);
                    break;
                case 4:
                    level = 0;
                    break;
                default:
                    break;
            }
        }	
	}
}
