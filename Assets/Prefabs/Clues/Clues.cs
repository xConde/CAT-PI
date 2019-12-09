using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clues : MonoBehaviour
{
    [SerializeField]
    private int _cluesFound;
    [SerializeField]
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
    [SerializeField]
    private Clue[] _potentialClue;
    [SerializeField]
    private List<Clue> _realClues;
    [SerializeField]
    private GameObject clueLight;
    public string findClue
    {
        get
        {
            return clues[_cluesFound++];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Get List of all clues
        _potentialClue = GameObject.FindObjectsOfType<Clue>();
        _realClues = new List<Clue>();
        chooseClues(10);
        Debug.Log("Created clues");
        destroyUnused();
        Debug.Log("Got rid of unused clues");
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
        while (i < numClues)
        {
            int r = Random.Range(0, _potentialClue.Length);
            if (_potentialClue[r].setRealClue(clueLight))
            {
                Debug.Log("Adding clue");
                _realClues.Add(_potentialClue[r]);
                //i++;

            }
            i++;
        }
    }

    private void destroyUnused()
    {
        foreach (Clue clue in _potentialClue)
        {
            clue.destroyFakes();
        }
    }
}