using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager
{
    //public Canvas UI;

    public float GameTime;

    public int Score;

    public bool Mixing;

    public bool discarding;

    //public Vector3 bowlpos;

    public List<string> combo;

    // public List<string> recipe; // TODO need a way to set game recipe before scene starts

    public bool forward;

    public bool back;

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