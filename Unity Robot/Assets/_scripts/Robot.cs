//Edgar Lopez
//Diego Gerardo Navarro
//Alan Mendoza
//Emiliano Roldan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public float side = 10.0f;

    float rotationX = 0.0f;
    float rotationArm = 0.0f;
    float rotationTorax = 0.0f;
    float dir = 1.0f;    // dir can only be 1 or -1
    float delta = 0.2f;  // how much to change rotation on each frame
    float minAngle = -45.0f;  // minimum rotation angle in X
    float maxAngle = 45.0f;   // maximum rotation angle in X

    float rotationKnee = -40.0f;
    float dirKnee = 1.0f;

    GameObject right_feet;
    GameObject left_feet;
    GameObject right_calve;
    GameObject left_calve;
    GameObject right_thigh;
    GameObject left_thigh;
    GameObject hip;
    GameObject body;
    GameObject head;
    GameObject neck;
    GameObject right_shoulder;
    GameObject right_bicep;
    GameObject right_forearm;
    GameObject right_hand;
    GameObject left_shoulder;
    GameObject left_bicep;
    GameObject left_forearm;
    GameObject left_hand;

    Vector3[] vertices;

    Mesh rightFeetMesh;
    Mesh leftFeetMesh;
    Mesh rightCalve;
    Mesh leftCalve;
    Mesh rightThighMesh;
    Mesh leftThighMesh;
    Mesh hipMesh;
    Mesh bodyMesh;
    Mesh headMesh;
    Mesh neckMesh;
    Mesh rightShoulderMesh;
    Mesh rightBicepMesh;
    Mesh rightForearmMesh;
    Mesh rightHandMesh;
    Mesh leftShoulderMesh;
    Mesh leftBicepMesh;
    Mesh leftForearmMesh;
    Mesh leftHandMesh;

    // Start is called before the first frame update
    void Start()
    {
        right_feet = new GameObject("right feet");
        left_feet = new GameObject("left feet");
        right_calve = new GameObject("right_calve");
        left_calve = new GameObject("left calve");
        right_thigh = new GameObject("right thigh");
        left_thigh = new GameObject("left thigh");
        hip = new GameObject("hip");
        body = new GameObject("body");
        head = new GameObject("head");
        neck = new GameObject("neck");
        right_shoulder = new GameObject("right shoulder");
        right_bicep = new GameObject("right bicep");
        right_forearm = new GameObject("right forearm");
        right_hand = new GameObject("right hand");
        left_shoulder = new GameObject("left shoulder");
        left_bicep = new GameObject("left bicep");
        left_forearm = new GameObject("left forearm");
        left_hand = new GameObject("left hand");
        left_hand = new GameObject("left hand");

        rightFeetMesh = new Mesh();
        leftFeetMesh = new Mesh();
        rightCalve = new Mesh();
        leftCalve = new Mesh();
        rightThighMesh = new Mesh();
        leftThighMesh = new Mesh();
        hipMesh = new Mesh();
        bodyMesh = new Mesh();
        headMesh = new Mesh();
        neckMesh = new Mesh();
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

        //headMesh construction Y = 60 z = 2.5
        Vector3[] headVertices = Construction.translateVerticesY(vertices, side * 6.4f);
        headVertices = Construction.translateVerticesZ(headVertices, side / 4);
        headMesh.vertices = headVertices;

        //neckMesh construction
        Vector3[] neckVertices = Construction.scaleVerticesX(vertices, 0.6f);
        neckVertices = Construction.scaleVerticesY(neckVertices, 0.4f);
        neckVertices = Construction.scaleVerticesZ(neckVertices, 0.6f);
        neckVertices = Construction.translateVerticesY(neckVertices, side * 5.7f);
        neckVertices = Construction.translateVerticesZ(neckVertices, side / 4);
        neckMesh.vertices = neckVertices;

        //rightShoulderMesh construction
        Vector3[] rightShoulderVertices = Construction.translateVerticesX(vertices, side * 2);
        rightShoulderVertices = Construction.translateVerticesY(rightShoulderVertices, side * 5);
        rightShoulderVertices = Construction.translateVerticesZ(rightShoulderVertices, side / 4);
        rightShoulderMesh.vertices = rightShoulderVertices;

        //rightBicepMesh construction
        Vector3[] rightBicepVertices = Construction.scaleVerticesY(vertices, 1.5f);
        rightBicepVertices = Construction.scaleVerticesZ(rightBicepVertices, 0.5f);
        rightBicepVertices = Construction.scaleVerticesX(rightBicepVertices, 0.5f);
        rightBicepVertices = Construction.translateVerticesY(rightBicepVertices, side * 4);
        rightBicepVertices = Construction.translateVerticesZ(rightBicepVertices, side / 4);
        rightBicepVertices = Construction.translateVerticesX(rightBicepVertices, side * 2);
        rightBicepMesh.vertices = rightBicepVertices;

        //rightForearmMesh construction
        Vector3[] rightForearmVertices = Construction.scaleVerticesY(vertices, 0.75f);
        rightForearmVertices = Construction.scaleVerticesZ(rightForearmVertices, 0.75f);
        rightForearmVertices = Construction.scaleVerticesX(rightForearmVertices, 0.65f);
        rightForearmVertices = Construction.translateVerticesY(rightForearmVertices, side * 3);
        rightForearmVertices = Construction.translateVerticesZ(rightForearmVertices, side / 4);
        rightForearmVertices = Construction.translateVerticesX(rightForearmVertices, side * 2);
        rightForearmMesh.vertices = rightForearmVertices;

        //rightHandMesh construction
        Vector3[] rightHandVertices = Construction.scaleVerticesX(vertices, 0.5f);
        rightHandVertices = Construction.scaleVerticesY(rightHandVertices, 0.5f);
        rightHandVertices = Construction.scaleVerticesZ(rightHandVertices, 0.5f);
        rightHandVertices = Construction.translateVerticesX(rightHandVertices, side * 2f);
        rightHandVertices = Construction.translateVerticesY(rightHandVertices, side * 2.5f);
        rightHandVertices = Construction.translateVerticesZ(rightHandVertices, side / 4);
        rightHandMesh.vertices = rightHandVertices;

        //left ShoulderMesh construction
        Vector3[] leftShoulderVertices = Construction.translateVerticesX(vertices, - side * 2);
        leftShoulderVertices = Construction.translateVerticesY(leftShoulderVertices, side * 5);
        leftShoulderVertices = Construction.translateVerticesZ(leftShoulderVertices, side / 4);
        leftShoulderMesh.vertices = leftShoulderVertices;

        //left BicepMesh construction
        Vector3[] leftBicepVertices = Construction.scaleVerticesY(vertices, 1.5f);
        leftBicepVertices = Construction.scaleVerticesZ(leftBicepVertices, 0.5f);
        leftBicepVertices = Construction.scaleVerticesX(leftBicepVertices, 0.5f);
        leftBicepVertices = Construction.translateVerticesX(leftBicepVertices, -side * 2);
        leftBicepVertices = Construction.translateVerticesY(leftBicepVertices, side * 4);
        leftBicepVertices = Construction.translateVerticesZ(leftBicepVertices, side / 6);
        leftBicepMesh.vertices = leftBicepVertices;

        //left ForearmMesh construction
        Vector3[] leftForearmVertices = Construction.scaleVerticesY(vertices, 0.75f);
        leftForearmVertices = Construction.scaleVerticesZ(leftForearmVertices, 0.75f);
        leftForearmVertices = Construction.scaleVerticesX(leftForearmVertices, 0.65f);
        leftForearmVertices = Construction.translateVerticesX(leftForearmVertices, -side * 2);
        leftForearmVertices = Construction.translateVerticesY(leftForearmVertices, side * 3);
        leftForearmVertices = Construction.translateVerticesZ(leftForearmVertices, side / 4);
        leftForearmMesh.vertices = leftForearmVertices;

        //left HandMesh construction
        Vector3[] leftHandVertices = Construction.scaleVerticesX(vertices, 0.5f);
        leftHandVertices = Construction.scaleVerticesY(leftHandVertices, 0.5f);
        leftHandVertices = Construction.scaleVerticesZ(leftHandVertices, 0.5f);
        leftHandVertices = Construction.translateVerticesX(leftHandVertices, -side*2f);
        leftHandVertices = Construction.translateVerticesY(leftHandVertices, side * 2.5f);
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
        headMesh.triangles = tris;
        neckMesh.triangles = tris;
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
        headMesh.normals = normals;
        headMesh.RecalculateNormals();
        neckMesh.normals = normals;
        neckMesh.RecalculateNormals();
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

        //neckMesh Construction
        MeshRenderer meshRenderer18 = neck.AddComponent<MeshRenderer>();
        meshRenderer18.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter meshFilter18 = neck.AddComponent<MeshFilter>();
        meshFilter18.mesh = neckMesh;
    }

    // Update is called once per frame
    void Update()
    {

        rotationX += dir * delta;
        if (rotationX > maxAngle || rotationX < minAngle) dir = -dir;

        rotationArm = rotationX / 3f;

        rightThighMesh.vertices = Walker.DoTransformThighRight(vertices, rotationX, side);
        leftThighMesh.vertices = Walker.DoTransformThighLeft(vertices, -rotationX, side);

        rightBicepMesh.vertices = Walker.DoTransformBicepLeft(vertices, rotationArm, side);
        leftBicepMesh.vertices = Walker.DoTransformBicepRight(vertices, rotationArm, side);

        leftForearmMesh.vertices = Walker.DoTransformForearmLeft(vertices, -rotationX/3f, side);
        rightForearmMesh.vertices = Walker.DoTransformForearmRight(vertices, -rotationX/3f, side);

        leftHandMesh.vertices = Walker.DoTransformHandLeft(vertices, -rotationX/3f, side);
        rightHandMesh.vertices = Walker.DoTransformHandRight(vertices, -rotationX/3f, side);

        rotationTorax = rotationX / 6f;
        bodyMesh.vertices = Walker.DoTransformTorax(vertices, rotationTorax, side);
        rightShoulderMesh.vertices = Walker.ShoulderRight(vertices, rotationTorax, side);
        leftShoulderMesh.vertices = Walker.ShoulderLeft(vertices, rotationTorax, side);

        //rightCalve.vertices = Walker.DoTransformKnee(vertices, -rotationX);

        if (dir < 0)
        {
            rightCalve.vertices = Walker.DoTransformCalveRightFront(vertices, rotationX, side);
        }
        else
        {
            if (rotationX < -25.0f)
            {
                rotationKnee += dirKnee * delta * -2;
            }
            if (rotationX > 25.0f)
            {
                rotationKnee += dirKnee * delta * 2;
                Debug.Log(rotationKnee);
            }
            rightCalve.vertices = Walker.DoTransformCalveRightBack(vertices, rotationX, side, rotationKnee);
        }


    }
}
