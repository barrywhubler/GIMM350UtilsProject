using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

	// Materials functions: returns list of all materials for a game object param - static so we can access it anywhere !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    static public Material[]GetAllMaterials(GameObject go)
    {
        Renderer[] rends = go.GetComponentsInChildren<Renderer>();
        List<Material> mats = new List<Material>(); 
        foreach(Renderer rend in rends) 
        {
            mats.Add(rend.material);
        }
        return (mats.ToArray()); //convert the list to an array
    }
}


