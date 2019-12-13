using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusserS : MonoBehaviour
{
    public Text texter;
    int counting = 0;
    float rand = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(-3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotate = texter.transform.eulerAngles;
        rotate.z += rand * 0.1f;
        rotate.y += rand * 0.2f;
        rotate.x += rand * 0.2f;
        texter.transform.eulerAngles = rotate;
        Vector3 pos = texter.transform.position;
        pos.y += 0.01f;
        pos.x += rand * 0.001f;
        texter.transform.position = pos;
        Color colora = texter.color;
        colora.a -= 0.01f;
        texter.color = colora;
        counting++;
        if (counting == 100)
        {
            Destroy(gameObject);
        }
    }
}
