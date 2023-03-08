using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager
{
    //public Canvas UI;

    public float GameTime;

    public int Score;

    public float ScoreMult = 1f;

    public int totalScore;

    public bool paused = true; // pause the game if tutorial is playing

    public bool Mixing = false;

    public bool discarding = false;

    //public Vector3 bowlpos;

    public List<string> combo;

    public bool left, right;

    public int bowltest;

    private static Manager _Instance;
    public static Manager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new Manager();
            }
            return _Instance;
        }
    }
}