using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitioner : MonoBehaviour
{
    public static Transitioner Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Transition()
    {

    }

}
