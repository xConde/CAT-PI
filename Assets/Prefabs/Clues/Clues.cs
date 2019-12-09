using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clues : MonoBehaviour
{
    private int _cluesFound;
    private string[] clues =
    {
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        ""
    };

    private Clue[] _potentialClue;
    private List<Clue> _realClues;
    public string getClue
    {
        get {
            return clues[_cluesFound];
        }
        set {
            _cluesFound++;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Get List of all clues
        _potentialClue = GameObject.FindObjectsOfType<Clue>();
        _realClues = new List<Clue>();
        //Mark objects as clues
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void chooseClues(int numClues)
    {
        //int[] randomClueNums = new int[numClues];
        int i = 0;
        while(i< numClues)
        {
            int r = Random.Range(0,_potentialClue.Length);
            if (_potentialClue[r].setRealClue())
            {
                _realClues.Add(_potentialClue[r]);
                i++;

            }
        }
    }
}
