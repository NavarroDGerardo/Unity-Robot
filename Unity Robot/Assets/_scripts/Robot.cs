using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public GameObject right_feet;
    public GameObject left_feet;
    public GameObject right_calve;
    public GameObject left_calve;
    float side = 10.0f;

    Vector3[] vertices;
    Mesh rightFeetMesh;
    Mesh leftFeetMesh;
    Mesh rightCalve;
    Mesh leftCalve;

    Vector3[] scaleVerticesZ(Vector3[] input, float scale)
    {
        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            Vector4 temp1 = input[i];
            temp1.w = 1;
            output[i] = Transformations.Scale(temp1, 1f, 1f, scale);
        }

        return output;
    }

    Vector3[] scaleVerticesY(Vector3[] input, float scale)
    {
        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            Vector4 temp1 = input[i];
            temp1.w = 1;
            output[i] = Transformations.Scale(temp1, 1f, scale, 1f);
        }

        return output;
    }

    Vector3[] translateVerticesY(Vector3[] input, float translation)
    {
        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            Vector4 temp1 = input[i];
            temp1.w = 1;
            output[i] = Transformations.Translate(temp1, 0, translation, 0);
        }

        return output;
    }

    Vector3[] translateVerticesX(Vector3[] input, float translation)
    {
        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            Vector4 temp1 = input[i];
            temp1.w = 1;
            output[i] = Transformations.Translate(temp1, translation, 0, 0);
        }

        return output;
    }

    Vector3[] translateVerticesZ(Vector3[] input, float translation)
    {
        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            Vector4 temp1 = input[i];
            temp1.w = 1;
            output[i] = Transformations.Translate(temp1, 0, 0, translation);
        }

        return output;
    }


    // Start is called before the first frame update
    void Start()
    {
        rightFeetMesh = new Mesh();
        leftFeetMesh = new Mesh();
        rightCalve = new Mesh();
        leftCalve = new Mesh();

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
        Vector3[] rightFootVertices = scaleVerticesY(vertices, 0.5f);
        rightFootVertices = translateVerticesY(rightFootVertices, side/4);
        rightFootVertices = translateVerticesX(rightFootVertices, -side);
        rightFeetMesh.vertices = rightFootVertices;

        //leftFoot construction
        Vector3[] leftFootVertices = scaleVerticesY(vertices, 0.5f);
        leftFootVertices = translateVerticesY(leftFootVertices, side/4);
        leftFootVertices = translateVerticesX(leftFootVertices, side);
        leftFeetMesh.vertices = leftFootVertices;


        //rightCalve construction 
        Vector3[] rightCalveVertices = scaleVerticesZ(vertices, 0.5f);
        rightCalveVertices = translateVerticesX(rightCalveVertices, -side);
        rightCalveVertices = translateVerticesY(rightCalveVertices, side);
        rightCalveVertices = translateVerticesZ(rightCalveVertices, side/4);
        rightCalve.vertices = rightCalveVertices;

        //leftCalve construction 
        Vector3[] leftCalveVertices = scaleVerticesZ(vertices, 0.5f);
        leftCalveVertices = translateVerticesX(leftCalveVertices, side);
        leftCalveVertices = translateVerticesY(leftCalveVertices, side);
        leftCalveVertices = translateVerticesZ(leftCalveVertices, side / 4);
        leftCalve.vertices = leftCalveVertices;


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
    }

    // Update is called once per frame
    void Update()
    {

    }
}