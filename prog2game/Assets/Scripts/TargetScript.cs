using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] private int targetValue;

    public int GetTargetValue()
    {
        return targetValue;
    }


}
