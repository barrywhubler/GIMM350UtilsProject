using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildMetal : MonoBehaviour
{

    public int yourID = 0;
    public bool trueSword = true;
    private bool objectBool = true;
    private float floater;
    public float swordPoints = 0f;
    public float wasSwordPoints = 0f;
    public Text attackPoints;
    public bool stateNumber = false;
    //public Vector3 mountPos;
    public bool mounted = false;
    private int counter = 0;
    public GameObject adder;
    public bool isHome;


    //private bool hsABool = false;
    //private bool hsBBool = false;
    //private bool hsCBool = false;
    //private bool hsDBool = false;
    //private bool hsEBool = false;
    //private bool hsFBool = false;
    //private bool hsGBool = false;
    //private bool hsHBool = false;
    //private bool hsIBool = false;
    //private bool hsJBool = false;
    //private bool hsKBool = false;

    public Vector3 cornerZero = new Vector3(-1, 1, 1);
    public Vector3 cornerOne = new Vector3(0, 1, 1);
    public Vector3 cornerTwo = new Vector3(-1, 0, 1);
    public Vector3 cornerThree = new Vector3(0, 0, 1);
    public Vector3 cornerFour = new Vector3(0, 1, -1);
    public Vector3 cornerFive = new Vector3(-1, 1, -1);
    public Vector3 cornerSix = new Vector3(0, 0, -1);
    public Vector3 cornerSeven = new Vector3(-1, 0, -1);
    public Vector3 cornerEight = new Vector3(1, 1, 1);
    public Vector3 cornerNine = new Vector3(1, 0, 1);
    public Vector3 cornerTen = new Vector3(1, 1, -1);
    public Vector3 cornerEleven = new Vector3(1, 0, -1);
    public Vector3 cornerTwelve = new Vector3(-1, 2, 1);
    public Vector3 cornerThirteen = new Vector3(0, 2, 1);
    public Vector3 cornerFourteen = new Vector3(0, 2, -1);
    public Vector3 cornerFifteen = new Vector3(-1, 2, -1);
    public Vector3 cornerSixteen = new Vector3(1, 2, 1);
    public Vector3 cornerSeventeen = new Vector3(1, 2, -1);
    public Vector3 cornerEighteen = new Vector3(0, 3, 1);
    public Vector3 cornerNineteen = new Vector3(0, 3, -1);

    public GameObject hsA;
    public GameObject hsB;
    public GameObject hsC;
    public GameObject hsD;
    public GameObject hsE;
    public GameObject hsF;
    public GameObject hsG;
    public GameObject hsH;
    public GameObject hsI;
    public GameObject hsJ;
    public GameObject hsK;
    public GameObject hsL;

    [SerializeField]
    private Shader shader;
    [SerializeField]
    private Material mat;
    //private Texture texture;
    [SerializeField]
    private Color colorA;
    [SerializeField]
    private Color colorB;
    [SerializeField]
    private Color colorC;
    [SerializeField]
    private Color colorD;

    private Color colorE;
    private Color colorF;
    public float floatery = 0.01f;


    //private GameObject activeObject;

    float waitN = 3f;
    float waitD = 3f;
    public int shapeN = 0;

    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {


        MakeMat();

        RenderThis();

    }

    public void MakeMat()
    {
        rend = GetComponent<Renderer>();
        //Renderer rend = GetComponent<Renderer>();

        //print("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@" + rend.material.mainTexture);
        rend.material = new Material(shader);
       rend.material.CopyPropertiesFromMaterial(mat);
        //rend.material.mainTexture = texture;
        rend.material.color = colorA;
        rend.material.SetColor("_EmissionColor", colorB);
        rend.material.SetFloat("_Glossiness", 0f);
    }
    public void Coloror()
    {
        rend.material.color = Color.Lerp(colorA, colorC, floatery);
        rend.material.SetColor("_EmissionColor", Color.Lerp(colorB, colorD, floatery));
        rend.material.SetFloat("_Glossiness", floatery);
    }

    public void StartAgain()
    {
        MakeMat();
        Coloror();
        RenderThis();
    }
    public void WhetColor()
    {

        print("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
        if (floatery < 1.01)
        {
            print("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            Coloror();

            floatery += 0.01f;
        }else if (objectBool)
        {
            Destroyer();

        }
    }

    public void HoldPosition()
    {
        //mountPos = gameObject.transform.position;
        mounted = true;
        swordPoints = swordPoints + swordPoints * floatery;
    }

    public void Destroyer()
    {
            Destroy(hsA);
            Destroy(hsB);
            Destroy(hsC);
            Destroy(hsD);
            Destroy(hsE);
            Destroy(hsF);
            Destroy(hsG);
            Destroy(hsH);
            Destroy(hsI);
            Destroy(hsJ);
            Destroy(hsK);

            objectBool = false;
        gameObject.AddComponent<MeshCollider>();
    }


    private void RenderThis(){
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = mf.mesh;

        //verticies
        Vector3[] vertices = new Vector3[]{
            //front
            cornerZero,//0
            cornerOne,//1
            cornerTwo,//2
            cornerThree,//3

            //back
            cornerFour,//4
            cornerFive,//5
            cornerSix,//6
            cornerSeven,//7

            //left
            cornerEight,//5 8
            cornerNine,//0  9
            cornerTen,//7 10
            cornerEleven,//2  11

            //right
            cornerTwelve,//1   12
            cornerThirteen,//4  13
            cornerFourteen,//3  14
            cornerFifteen,//6 15

            //top
            
            cornerSixteen,//5 16
            cornerSeventeen,//4  17
            cornerEighteen,//0  18
            cornerNineteen,//1   19


            ////back
            //cornerTwo,//2  20
            //cornerThree,//3   21 
            //cornerSeven,//7 22
            //cornerSix,//6  23




        };
        //triangles
        int[] triangles = new int[]
        {
            ///baseLeftCube
            
            1,0,2, 2,3,1,
            4,6,7, 7,5,4,
            5,7,2, 2,0,5,
            2,7,6, 6,3,2,

            //baseRightCube

            1,3,9,9,8,1,
            4,10,11,11,6,4,
            10,8,9,9,11,10,
            6,11,9,9,3,6,

            //second Tier left

            13,12,0,0,1,13,
            14,4,5,5,15,14,
            15,5,0,0,12,15,


            //second Tier Right

            13,1,8,8,16,13,
            14,17,10,10,4,14,
            17,16,8,8,10,17,

            //TopTier

            18,12,13, 13,16,18,
            19,17,14, 14,15,19,
            19,15,12, 12,18,19,
            18,16,17, 17,19,18,

            
            
            
            
            ////front
            //0,2,3,
            //3,1,0,
            ////back
            //4,6,7,
            //7,5,4,

            ////left,right,top,bottom

            //5,7,2,2,0,5,
            //1,3,6,6,4,1,
            //5,0,1,1,4,5,
            //2,7,6,6,3,2


            //8,10,11,11,9,8,
            //12,14,15,15,13,12,
            //16,18,19,19,17,16,
            //20,22,23,23,21,20,


            //FIX IN VERTICES


        };

        Vector2[] uvs = new Vector2[]
        {
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),


        };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.Optimize();
        mesh.RecalculateNormals();
        
}

    public void UnusedWarper()
    {

        if (waitN > 0f)
        {
            waitN -= Time.deltaTime;
        }
        else
        {
            waitN = waitD;
            shapeN++;
            if (shapeN > 3)
            {
                shapeN = 0;
            }
        }
        if (shapeN == 0)
        {
            cornerZero = Vector3.Lerp(cornerZero, new Vector3(-1, 1, 1), Time.deltaTime);
            cornerOne = Vector3.Lerp(cornerOne, new Vector3(1, 1, 1), Time.deltaTime);
            cornerFour = Vector3.Lerp(cornerFour, new Vector3(1, 1, -1), Time.deltaTime);
            cornerFive = Vector3.Lerp(cornerFive, new Vector3(-1, 1, -1), Time.deltaTime);
        }
        if (shapeN == 1)
        {
            cornerZero = Vector3.Lerp(cornerZero, new Vector3(0, 1, 0), Time.deltaTime);
            cornerOne = Vector3.Lerp(cornerOne, new Vector3(0, 1, 0), Time.deltaTime);
            cornerFour = Vector3.Lerp(cornerFour, new Vector3(0, 1, 0), Time.deltaTime);
            cornerFive = Vector3.Lerp(cornerFive, new Vector3(0, 1, 0), Time.deltaTime);
        }
        if (shapeN == 2)
        {
            cornerZero = Vector3.Lerp(cornerZero, new Vector3(-1, 1, 2), Time.deltaTime);
            cornerOne = Vector3.Lerp(cornerOne, new Vector3(1, 1, 2), Time.deltaTime);
            cornerFour = Vector3.Lerp(cornerFour, new Vector3(1, 0.5f, -1), Time.deltaTime);
            cornerFive = Vector3.Lerp(cornerFive, new Vector3(-1, 0.5f, -1), Time.deltaTime);
        }
        if (shapeN == 3)
        {
            cornerZero = Vector3.Lerp(cornerZero, new Vector3(-1, 0.2f, 0), Time.deltaTime);
            cornerOne = Vector3.Lerp(cornerOne, new Vector3(1, 0.2f, 0), Time.deltaTime);
            cornerFour = Vector3.Lerp(cornerFour, new Vector3(1, 0.2f, -1), Time.deltaTime);
            cornerFive = Vector3.Lerp(cornerFive, new Vector3(-1, 0.2f, -1), Time.deltaTime);
        }
        RenderThis();
    }

    // for hammering
    public void Hammered(string pointOfStrike, GameObject activeObject, float hammerValue, bool maxSharp)//name of hamerstrike object
    {
        Vector3 vecPosA = cornerThree;
        Vector3 vecPosB = cornerThree;
        Vector3 vecPosC = cornerThree;
        Vector3 vecPosD = cornerThree;

        if (pointOfStrike == "hammerPointA")
        {
            vecPosA = cornerNine;
            vecPosB = cornerEleven;
            vecPosC = cornerNine;
            vecPosD = cornerEleven;
        }
        else if (pointOfStrike == "hammerPointB")
        {
            vecPosA = cornerNine;
            vecPosB = cornerEleven;
            vecPosC = cornerEight;
            vecPosD = cornerTen;
        }
        else if (pointOfStrike == "hammerPointC")
        {
            vecPosA = cornerEight;
            vecPosB = cornerTen;
            vecPosC = cornerEight;
            vecPosD = cornerTen;
        }
        else if (pointOfStrike == "hammerPointD")
        {
            vecPosA = cornerEight;
            vecPosB = cornerTen;
            vecPosC = cornerSixteen;
            vecPosD = cornerSeventeen;
        }
        else if (pointOfStrike == "hammerPointE")
        {
            vecPosA = cornerSixteen;
            vecPosB = cornerSeventeen;
            vecPosC = cornerSixteen;
            vecPosD = cornerSeventeen;
        }
        else if (pointOfStrike == "hammerPointF")
        {
            vecPosA = cornerTwo;
            vecPosB = cornerSeven;
            vecPosC = cornerTwo;
            vecPosD = cornerSeven;
        }
        else if (pointOfStrike == "hammerPointG")
        {
            vecPosA = cornerTwo;
            vecPosB = cornerSeven;
            vecPosC = cornerZero;
            vecPosD = cornerFive;
        }
        else if (pointOfStrike == "hammerPointH")
        {
            vecPosA = cornerZero;
            vecPosB = cornerFive;
            vecPosC = cornerZero;
            vecPosD = cornerFive;
        }
        else if (pointOfStrike == "hammerPointI")
        {
            vecPosA = cornerZero;
            vecPosB = cornerFive;
            vecPosC = cornerTwelve;
            vecPosD = cornerFifteen;
        }
        else if (pointOfStrike == "hammerPointJ")
        {
            vecPosA = cornerTwelve;
            vecPosB = cornerFifteen;
            vecPosC = cornerTwelve;
            vecPosD = cornerFifteen;
        }
        else if (pointOfStrike == "hammerPointK")
        {
            vecPosA = cornerEighteen;
            vecPosB = cornerNineteen;
            vecPosC = cornerEighteen;
            vecPosD = cornerNineteen;
        }

        if (maxSharp == false)
        {
            //vecPosA = new Vector3 ()//(vecPosA.x, vecPosA.y, vecPosA.z);




            if (vecPosA.z > .05)
            {
                vecPosA.z -= (0.1f * hammerValue);
                vecPosB.z += (0.1f * hammerValue);
                swordPoints += 0.1f;
            }
            

             if (vecPosC.z > .05)
            {
                vecPosC.z -= (0.1f * hammerValue);
                vecPosD.z += (0.1f * hammerValue);
                swordPoints += 0.1f;
            }

            //print("!!!!!!!!!!!!!!!!!!!!!!!!!" + vecPosA);

            if(vecPosA.z < .05)
            {
                vecPosA.z = 0;
                vecPosB.z = 0;
            }
 
            if (vecPosC.z < .05)
            {
                vecPosC.z = 0;
                vecPosD.z = 0;
            }
        }


        if (pointOfStrike == "hammerPointA")
        {
            cornerNine = vecPosA;
            cornerEleven = vecPosB;
            //vecPosC = cornerNine;
            //vecPosD = cornerEleven;
        }
        else if (pointOfStrike == "hammerPointB")
        {
            cornerNine = vecPosA;
            cornerEleven = vecPosB;
            cornerEight = vecPosC;
            cornerTen = vecPosD;
        }
        else if (pointOfStrike == "hammerPointC")
        {
            cornerEight = vecPosA;
            cornerTen = vecPosB;
            //vecPosC = cornerEight;
            //vecPosD = cornerTen;
        }
        else if (pointOfStrike == "hammerPointD")
        {
            cornerEight = vecPosA;
            cornerTen = vecPosB;
            cornerSixteen = vecPosC;
            cornerSeventeen = vecPosD;
        }
        else if (pointOfStrike == "hammerPointE")
        {
            cornerSixteen = vecPosA;
            cornerSeventeen = vecPosB;
            //vecPosC = cornerSixteen;
            //vecPosD = cornerSeventeen;
        }
        else if (pointOfStrike == "hammerPointF")
        {
            cornerTwo = vecPosA;
            cornerSeven = vecPosB;
            //vecPosC = cornerTwo;
            //vecPosD = cornerSeven;
        }
        else if (pointOfStrike == "hammerPointG")
        {
            cornerTwo = vecPosA;
            cornerSeven = vecPosB;
            cornerZero = vecPosC;
            cornerFive = vecPosD;
        }
        else if (pointOfStrike == "hammerPointH")
        {
            cornerZero = vecPosA;
            cornerFive = vecPosB;
            //vecPosC = cornerZero;
            //vecPosD = cornerFive;
        }
        else if (pointOfStrike == "hammerPointI")
        {
            cornerZero = vecPosA;
            cornerFive = vecPosB;
            cornerTwelve = vecPosC;
            cornerFifteen = vecPosD;
        }
        else if (pointOfStrike == "hammerPointJ")
        {
            cornerTwelve = vecPosA;
            cornerFifteen = vecPosB;
            //cornerTwelve = vecPosC;
            //cornerThirteen = vecPosD;
        }
        else if (pointOfStrike == "hammerPointK")
        {
            cornerEighteen = vecPosA;
            cornerNineteen = vecPosB;
            //cornerEighteen = vecPosC;
            //cornerNineteen = vecPosD;
        }
        RenderThis();
    }


    // Update is called once per frame
    void Update()
    {
        counter++;
        if (stateNumber)
        {
            stateNumber = false;
            StartAgain();
        }
        if(swordPoints - wasSwordPoints > 0.00001f)
        {
            wasSwordPoints = swordPoints;
            attackPoints.text = "" + wasSwordPoints;
            if (counter > 15)
            {
                Instantiate(adder);
                adder.transform.position = transform.position;
                counter = 0;
                //gameObject.transform.position = mountPos;
            }
        }

        if (mounted)
        {
            if (counter > 15)
            {
                //gameObject.transform.position = mountPos;
            }
        }
        //Vector3 tempper = cornerEight;
        //print("!!!!!!!!!!!!!!!!!" + tempper);
        //tempper.z += 0.1f;
        //print("!!!!!!!!!!!!!!!!!" + tempper);
        //floater = .1f;
        //transform.Rotate(floater, 0, 0);
    }
}
