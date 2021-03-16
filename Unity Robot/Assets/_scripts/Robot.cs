using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public float side = 10.0f;

    float rotationX = 0.0f;
    float rotationY = 0.0f;
    float dir = 1.0f;    // dir can only be 1 or -1
    float delta = 0.3f;  // how much to change rotation on each frame
    float minAngle = -45.0f;  // minimum rotation angle in X
    float maxAngle = 45.0f;   // maximum rotation angle in X

    public GameObject right_feet;
    public GameObject left_feet;
    public GameObject right_calve;
    public GameObject left_calve;
    public GameObject right_thigh;
    public GameObject left_thigh;
    public GameObject hip;
    public GameObject body;
    public GameObject neck;
    public GameObject head;
    public GameObject right_shoulder;
    public GameObject right_bicep;
    public GameObject right_forearm;
    public GameObject right_hand;
    public GameObject left_shoulder;
    public GameObject left_bicep;
    public GameObject left_forearm;
    public GameObject left_hand;

    Vector3[] vertices;

    public Mesh rightFeetMesh;
    public Mesh leftFeetMesh;
    public Mesh rightCalve;
    public Mesh leftCalve;
    public Mesh rightThighMesh;
    public Mesh leftThighMesh;
    public Mesh hipMesh;
    public Mesh bodyMesh;
    public Mesh neckMesh;
    public Mesh headMesh;
    public Mesh rightShoulderMesh;
    public Mesh rightBicepMesh;
    public Mesh rightForearmMesh;
    public Mesh rightHandMesh;
    public Mesh leftShoulderMesh;
    public Mesh leftBicepMesh;
    public Mesh leftForearmMesh;
    public Mesh leftHandMesh;

    // Start is called before the first frame update
    void Start()
    {
        rightFeetMesh = new Mesh();
        leftFeetMesh = new Mesh();
        rightCalve = new Mesh();
        leftCalve = new Mesh();
        rightThighMesh = new Mesh();
        leftThighMesh = new Mesh();
        hipMesh = new Mesh();
        bodyMesh = new Mesh();
        neckMesh = new Mesh();
        headMesh = new Mesh();
        rightShoulderMesh = new Mesh();
        rightBicepMesh = new Mesh();
        rightForearmMesh = new Mesh();
        rightHandMesh = new Mesh();
        leftShoulderMesh = new Mesh();
        leftBicepMesh = new Mesh();
        leftForearmMesh = new Mesh();
        leftHandMesh = new Mesh();

        float hSide = side / 2.0f;

        vertices = new Vector3[8]
        {
            new Vector3(-hSide, -hSide, hSide),
            new Vector3(hSide, -hSide, hSide),
            new Vector3(hSide, hSide, hSide),
            new Vector3(-hSide, hSide, hSide),

            new Vector3(hSide, -hSide, -hSide),
            new Vector3(hSide, hSide, -hSide),
            new Vector3(-hSide, -hSide, -hSide),
            new Vector3(-hSide, hSide, -hSide)
        };

        //rigthFoot transformatiosn
        Vector3[] rightFootVertices = Construction.scaleVerticesY(vertices, 0.5f);
        rightFootVertices = Construction.translateVerticesX(rightFootVertices, -side);
        rightFootVertices = Construction.translateVerticesY(rightFootVertices, side/4);
        rightFeetMesh.vertices = rightFootVertices;

        //leftFoot construction
        Vector3[] leftFootVertices = Construction.scaleVerticesY(vertices, 0.5f);
        leftFootVertices = Construction.translateVerticesX(leftFootVertices, side);
        leftFootVertices = Construction.translateVerticesY(leftFootVertices, side/4);
        leftFeetMesh.vertices = leftFootVertices;


        //rightCalve construction 
        Vector3[] rightCalveVertices = Construction.scaleVerticesZ(vertices, 0.5f);
        rightCalveVertices = Construction.translateVerticesX(rightCalveVertices, -side);
        rightCalveVertices = Construction.translateVerticesY(rightCalveVertices, side);
        rightCalveVertices = Construction.translateVerticesZ(rightCalveVertices, side/4);
        rightCalve.vertices = rightCalveVertices;

        //leftCalve construction 
        Vector3[] leftCalveVertices = Construction.scaleVerticesZ(vertices, 0.5f);
        leftCalveVertices = Construction.translateVerticesX(leftCalveVertices, side);
        leftCalveVertices = Construction.translateVerticesY(leftCalveVertices, side);
        leftCalveVertices = Construction.translateVerticesZ(leftCalveVertices, side / 4);
        leftCalve.vertices = leftCalveVertices;

        //rightThighMesh construction
        /*Vector3[] rightThighVertices = Construction.scaleVerticesZ(vertices, 0.5f);
        rightThighVertices = Construction.translateVerticesX(rightThighVertices, -side);
        rightThighVertices = Construction.translateVerticesY(rightThighVertices, side*2);
        rightThighVertices = Construction.translateVerticesZ(rightThighVertices, side / 4);*/
        rightThighMesh.vertices = vertices;


        //leftThighMesh construction
        Vector3[] leftThighVertices = Construction.scaleVerticesZ(vertices, 0.5f);
        leftThighVertices = Construction.translateVerticesX(leftThighVertices, side);
        leftThighVertices = Construction.translateVerticesY(leftThighVertices, side * 2);
        leftThighVertices = Construction.translateVerticesZ(leftThighVertices, side / 4);
        leftThighMesh.vertices = leftThighVertices;

        //hipMesh construction Y = 30, Z = 2.5 -> scale x = 3
        Vector3[] hipVertices = Construction.scaleVerticesX(vertices, 3f);
        hipVertices = Construction.translateVerticesY(hipVertices, side * 3);
        hipVertices = Construction.translateVerticesZ(hipVertices, side / 4);
        hipMesh.vertices = hipVertices;

        //bodyMesh construction Y = 45, Z = 2.5 -> scale x = 3 y = 2 z = 2
        Vector3[] bodyVertices = Construction.scaleVerticesX(vertices, 3f);
        bodyVertices = Construction.scaleVerticesY(bodyVertices, 2f);
        bodyVertices = Construction.scaleVerticesZ(bodyVertices, 2f);
        bodyVertices = Construction.translateVerticesY(bodyVertices, side * 4 + side / 2);
        bodyVertices = Construction.translateVerticesZ(bodyVertices, side / 4);
        bodyMesh.vertices = bodyVertices;

        //neckMesh construction Y = 60 z = 2.5
        Vector3[] neckVertices = Construction.scaleVerticesX(vertices, 0.6f);
        neckVertices = Construction.scaleVerticesY(neckVertices, 0.4f);
        neckVertices = Construction.scaleVerticesZ(neckVertices, 0.6f);
        neckVertices = Construction.translateVerticesY(neckVertices, side * 5.7f);
        neckVertices = Construction.translateVerticesZ(neckVertices, side / 4);
        neckMesh.vertices = neckVertices;

        //headMesh construction Y = 60 z = 2.5
      /*Vector3[] headVertices = Construction.translateVerticesY(vertices, side * 6.4f);
      headVertices = Construction.translateVerticesZ(headVertices, side / 4);
        headVertices = Construction.DoTransformsHead(headVertices, rotationY);*/
        headMesh.vertices = vertices;

        //rightShoulderMesh construction
        Vector3[] rightShoulderVertices = Construction.translateVerticesX(vertices, side * 2);
        rightShoulderVertices = Construction.translateVerticesY(rightShoulderVertices, side * 5);
        rightShoulderVertices = Construction.translateVerticesZ(rightShoulderVertices, side / 4);
        rightShoulderMesh.vertices = rightShoulderVertices;

        //rightBicepMesh construction
        Vector3[] rightBicepVertices = Construction.scaleVerticesY(vertices, 0.5f);
        rightBicepVertices = Construction.scaleVerticesZ(rightBicepVertices, 0.5f);
        rightBicepVertices = Construction.translateVerticesY(rightBicepVertices, side * 5);
        rightBicepVertices = Construction.translateVerticesZ(rightBicepVertices, side / 4);
        rightBicepVertices = Construction.translateVerticesX(rightBicepVertices, side * 3);
        rightBicepMesh.vertices = rightBicepVertices;

        //rightForearmMesh construction
        Vector3[] rightForearmVertices = Construction.scaleVerticesY(vertices, 0.75f);
        rightForearmVertices = Construction.scaleVerticesZ(rightForearmVertices, 0.75f);
        rightForearmVertices = Construction.translateVerticesY(rightForearmVertices, side * 5);
        rightForearmVertices = Construction.translateVerticesZ(rightForearmVertices, side / 4);
        rightForearmVertices = Construction.translateVerticesX(rightForearmVertices, side * 4);
        rightForearmMesh.vertices = rightForearmVertices;

        //rightHandMesh construction
        Vector3[] rightHandVertices = Construction.scaleVerticesX(vertices, 0.5f);
        rightHandVertices = Construction.scaleVerticesY(rightHandVertices, 0.5f);
        rightHandVertices = Construction.scaleVerticesZ(rightHandVertices, 0.5f);
        rightHandVertices = Construction.translateVerticesY(rightHandVertices, side * 5);
        rightHandVertices = Construction.translateVerticesZ(rightHandVertices, side / 4);
        rightHandVertices = Construction.translateVerticesX(rightHandVertices, side * 4 + side / 2 + side / 4);
        rightHandMesh.vertices = rightHandVertices;

        //rightShoulderMesh construction
        Vector3[] leftShoulderVertices = Construction.translateVerticesX(vertices, - side * 2);
        leftShoulderVertices = Construction.translateVerticesY(leftShoulderVertices, side * 5);
        leftShoulderVertices = Construction.translateVerticesZ(leftShoulderVertices, side / 4);
        leftShoulderMesh.vertices = leftShoulderVertices;

        //rightBicepMesh construction
        Vector3[] leftBicepVertices = Construction.scaleVerticesY(vertices, 0.5f);
        leftBicepVertices = Construction.scaleVerticesZ(leftBicepVertices, 0.5f);
        leftBicepVertices = Construction.translateVerticesX(leftBicepVertices, -side * 3);
        leftBicepVertices = Construction.translateVerticesY(leftBicepVertices, side * 5);
        leftBicepVertices = Construction.translateVerticesZ(leftBicepVertices, side / 4);
        leftBicepMesh.vertices = leftBicepVertices;

        //rightForearmMesh construction
        Vector3[] leftForearmVertices = Construction.scaleVerticesY(vertices, 0.75f);
        leftForearmVertices = Construction.scaleVerticesZ(leftForearmVertices, 0.75f);
        leftForearmVertices = Construction.translateVerticesX(leftForearmVertices, -side * 4);
        leftForearmVertices = Construction.translateVerticesY(leftForearmVertices, side * 5);
        leftForearmVertices = Construction.translateVerticesZ(leftForearmVertices, side / 4);
        leftForearmMesh.vertices = leftForearmVertices;

        //rightHandMesh construction
        Vector3[] leftHandVertices = Construction.scaleVerticesX(vertices, 0.5f);
        leftHandVertices = Construction.scaleVerticesY(leftHandVertices, 0.5f);
        leftHandVertices = Construction.scaleVerticesZ(leftHandVertices, 0.5f);
        leftHandVertices = Construction.translateVerticesX(leftHandVertices, - (side * 4 + side / 2 + side / 4));
        leftHandVertices = Construction.translateVerticesY(leftHandVertices, side * 5);
        leftHandVertices = Construction.translateVerticesZ(leftHandVertices, side / 4);
        leftHandMesh.vertices = leftHandVertices;


        // Topology:
        int[] tris = new int[]
        {
            0, 1, 2,
            0, 2, 3,
            1, 4, 5,
            1, 5, 2,
            4, 6, 7,
            4, 7, 5,
            6, 0, 3,
            6, 3, 7,
            3, 2, 5,
            3, 5, 7,
            1, 0, 6,
            1, 6, 4
        };
        rightFeetMesh.triangles = tris;
        leftFeetMesh.triangles = tris;
        rightCalve.triangles = tris;
        leftCalve.triangles = tris;
        rightThighMesh.triangles = tris;
        leftThighMesh.triangles = tris;
        hipMesh.triangles = tris;
        bodyMesh.triangles = tris;
        neckMesh.triangles = tris;
        headMesh.triangles = tris;
        rightShoulderMesh.triangles = tris;
        rightBicepMesh.triangles = tris;
        rightForearmMesh.triangles = tris;
        rightHandMesh.triangles = tris;
        leftShoulderMesh.triangles = tris;
        leftBicepMesh.triangles = tris;
        leftForearmMesh.triangles = tris;
        leftHandMesh.triangles = tris;

        // Normals:
        Vector3[] normals = new Vector3[]
        {
            new Vector3(0,0,-1),
            new Vector3(0,0,-1),
            new Vector3(0,0,-1),
            new Vector3(0,0,-1),
            new Vector3(0,0,-1),
            new Vector3(0,0,-1),
            new Vector3(0,0,-1),
            new Vector3(0,0,-1)
        };

        rightFeetMesh.normals = normals;
        rightFeetMesh.RecalculateNormals();
        leftFeetMesh.normals = normals;
        leftFeetMesh.RecalculateNormals();
        rightCalve.normals = normals;
        rightCalve.RecalculateNormals();
        leftCalve.normals = normals;
        leftCalve.RecalculateNormals();
        rightThighMesh.normals = normals;
        rightThighMesh.RecalculateNormals();
        leftThighMesh.normals = normals;
        leftThighMesh.RecalculateNormals();
        hipMesh.normals = normals;
        hipMesh.RecalculateNormals();
        bodyMesh.normals = normals;
        bodyMesh.RecalculateNormals();
        neckMesh.normals = normals;
        neckMesh.RecalculateNormals();
        headMesh.normals = normals;
        headMesh.RecalculateNormals();
        rightShoulderMesh.normals = normals;
        rightShoulderMesh.RecalculateNormals();
        rightBicepMesh.normals = normals;
        rightBicepMesh.RecalculateNormals();
        rightForearmMesh.normals = normals;
        rightForearmMesh.RecalculateNormals();
        rightHandMesh.normals = normals;
        rightHandMesh.RecalculateNormals();
        leftShoulderMesh.normals = normals;
        leftShoulderMesh.RecalculateNormals();
        leftBicepMesh.normals = normals;
        leftBicepMesh.RecalculateNormals();
        leftForearmMesh.normals = normals;
        leftForearmMesh.RecalculateNormals();
        leftHandMesh.normals = normals;
        leftHandMesh.RecalculateNormals();


        // right foot:
        MeshRenderer meshRenderer1 = right_feet.AddComponent<MeshRenderer>();
        meshRenderer1.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter1 = right_feet.AddComponent<MeshFilter>();
        meshFilter1.mesh = rightFeetMesh;

        //left foot
        MeshRenderer meshRenderer2 = left_feet.AddComponent<MeshRenderer>();
        meshRenderer2.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter2 = left_feet.AddComponent<MeshFilter>();
        meshFilter2.mesh = leftFeetMesh;

        //right calve
        MeshRenderer meshRenderer3 = right_calve.AddComponent<MeshRenderer>();
        meshRenderer3.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter3 = right_calve.AddComponent<MeshFilter>();
        meshFilter3.mesh = rightCalve;

        //left calve
        MeshRenderer meshRenderer4 = left_calve.AddComponent<MeshRenderer>();
        meshRenderer4.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter4 = left_calve.AddComponent<MeshFilter>();
        meshFilter4.mesh = leftCalve;

        //right thigh
        MeshRenderer meshRenderer5 = right_thigh.AddComponent<MeshRenderer>();
        meshRenderer5.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter5 = right_thigh.AddComponent<MeshFilter>();
        meshFilter5.mesh = rightThighMesh;

        //left thigh
        MeshRenderer meshRenderer6 = left_thigh.AddComponent<MeshRenderer>();
        meshRenderer6.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter6 = left_thigh.AddComponent<MeshFilter>();
        meshFilter6.mesh = leftThighMesh;

        //hipMesh construction
        MeshRenderer meshRenderer7 = hip.AddComponent<MeshRenderer>();
        meshRenderer7.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter7 = hip.AddComponent<MeshFilter>();
        meshFilter7.mesh = hipMesh;

        //bodyMeshConstruction 
        MeshRenderer meshRenderer8 = body.AddComponent<MeshRenderer>();
        meshRenderer8.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter8 = body.AddComponent<MeshFilter>();
        meshFilter8.mesh = bodyMesh;

        //headMesh Construciton 
        MeshRenderer meshRenderer9 = head.AddComponent<MeshRenderer>();
        meshRenderer9.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter9 = head.AddComponent<MeshFilter>();
        meshFilter9.mesh = headMesh;

        //rightShoulderMesh Construciton 
        MeshRenderer meshRenderer10 = right_shoulder.AddComponent<MeshRenderer>();
        meshRenderer10.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter10 = right_shoulder.AddComponent<MeshFilter>();
        meshFilter10.mesh = rightShoulderMesh;

        //rightBicepMesh Construciton 
        MeshRenderer meshRenderer11 = right_bicep.AddComponent<MeshRenderer>();
        meshRenderer11.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter11 = right_bicep.AddComponent<MeshFilter>();
        meshFilter11.mesh = rightBicepMesh;

        //rightForearmMesh Construciton 
        MeshRenderer meshRenderer12 = right_forearm.AddComponent<MeshRenderer>();
        meshRenderer12.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter12 = right_forearm.AddComponent<MeshFilter>();
        meshFilter12.mesh = rightForearmMesh;

        //rightHandMesh Construciton 
        MeshRenderer meshRenderer13 = right_hand.AddComponent<MeshRenderer>();
        meshRenderer13.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter13 = right_hand.AddComponent<MeshFilter>();
        meshFilter13.mesh = rightHandMesh;

        //rightShoulderMesh Construciton 
        MeshRenderer meshRenderer14 = left_shoulder.AddComponent<MeshRenderer>();
        meshRenderer14.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter14 = left_shoulder.AddComponent<MeshFilter>();
        meshFilter14.mesh = leftShoulderMesh;

        //rightBicepMesh Construciton 
        MeshRenderer meshRenderer15 = left_bicep.AddComponent<MeshRenderer>();
        meshRenderer15.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter15 = left_bicep.AddComponent<MeshFilter>();
        meshFilter15.mesh = leftBicepMesh;

        //rightForearmMesh Construciton 
        MeshRenderer meshRenderer16 = left_forearm.AddComponent<MeshRenderer>();
        meshRenderer16.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter16 = left_forearm.AddComponent<MeshFilter>();
        meshFilter16.mesh = leftForearmMesh;

        //rightHandMesh Construciton 
        MeshRenderer meshRenderer17 = left_hand.AddComponent<MeshRenderer>();
        meshRenderer17.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter17 = left_hand.AddComponent<MeshFilter>();
        meshFilter17.mesh = leftHandMesh;

        //neckMesh Construciton 
        MeshRenderer meshRenderer18 = neck.AddComponent<MeshRenderer>();
        meshRenderer18.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter18 = neck.AddComponent<MeshFilter>();
        meshFilter18.mesh = neckMesh;
    }

    // Update is called once per frame
    void Update()
    {
        rotationY += dir * delta;
        if (rotationY > maxAngle || rotationY < minAngle) dir = -dir;

        headMesh.vertices = Walker.DoTransformsHead(vertices, rotationY, side);

        rotationX += dir * delta;
        if (rotationX > maxAngle || rotationX < minAngle) dir = -dir;

        rightThighMesh.vertices = Walker.DoTransformThighRight(vertices, rotationX, side);
        leftThighMesh.vertices = Walker.DoTransformThighLeft(vertices, -rotationX, side);


        //CALVE ENFRENTE
        if (dir < 0)
        {
            rightCalve.vertices = Walker.DoTransformCalveRightFront(vertices, rotationX, side);
        }
        else
        {
            rightCalve.vertices = Walker.DoTransformCalveRightFront(vertices, rotationX, side);
        }
    }
}