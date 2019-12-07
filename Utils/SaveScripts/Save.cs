using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Save {

    public List<int> livingTargetPositions = new List<int>();
    public List<int> livingTargetsType = new List<int>();
    public List<float> gameobjectX = new List<float>();
    public List<float> gameobjectY = new List<float>();
    public List<float> gameobjectZ = new List<float>();

    public int hits = 0;
    public int shots = 0;


}


