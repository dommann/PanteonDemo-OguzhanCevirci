using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankText : MonoBehaviour
{

    public Text rankText;
    public static int Ranking;
    public GameObject Player;
    public GameObject Opponent1;
    public GameObject Opponent2;
    public GameObject Opponent3;
    public GameObject Opponent4;
    public GameObject Opponent5;
    public GameObject Opponent6;
    public GameObject Opponent7;
    public GameObject Opponent8;
    public GameObject Opponent9;
    public GameObject Opponent10;

    List<GameObject> players = new List<GameObject>();

    void Start()
    {
        players.Add(Player);
        players.Add(Opponent1);
        players.Add(Opponent2);
        players.Add(Opponent3);
        players.Add(Opponent4);
        players.Add(Opponent5);
        players.Add(Opponent6);
        players.Add(Opponent7);
        players.Add(Opponent8);
        players.Add(Opponent9);
        players.Add(Opponent10);
    }

    void Update()
    {
        if (Player.transform.position.z < 400)
        {
            players.Sort(SortingFunction); 
            int rank = players.FindIndex(x => x == Player) + 1;
            rankText.text = "" + rank + " / 11";  
            Ranking = rank;
        }

    }

    private int SortingFunction(GameObject first, GameObject second) 
    {
        if (first.transform.position.z < second.transform.position.z)
        {
            return 1;
        }
        else if (first.transform.position.z > second.transform.position.z)
        {
            return -1;
        }

        return 0;
    }
}
