using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMatriz : MonoBehaviour
{
    List<GameObject> BONES;
    
    public enum Bones
    {
        HIPS,
        TORSO,
        NECK,
        HEAD
    };

    void ApplyTransformations(Matrix4x4 t, GameObject target)
    {
        Block b = target.GetComponent<Block>();
        Vector3[] newVerts = new Vector3[8];
        for (int v = 0; v < b.vertices.Length; v++)
        {
            Vector4 temp = b.vertices[v];
            temp.w = 1;
            newVerts[v] = t * temp;
        }
        b.myMesh.vertices = newVerts;
    }
    // Start is called before the first frame update
    void Start()
    {
        bones = new List<GameObject>();

        System.Array values = System.Enum.GetValues(typeof(Bones));
        foreach (Bones bone in values)
        {
            bones.Add(new GameObject(bone.ToString()));
        }

        foreach (GameObject bone in bones)
        {
            bone.AddComponent<Block>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //HIPS:
        Matrix4x4 hipsS = TransformationSergio.ScaleM(1, 0.3f, 1);
        Matrix4x4 hipsM = hipsS;
        Matrix4x4 hipsI = Matrix4x4.identity;
        ApplyTransformations(hipsM, bones[(int)BONES.HIPS]);

        //TORSO:
        Matrix4x4 torsoT = TransformationSergio.TranslateM(0, 0.7f, 0);
        Matrix4x4 torsoS = TransformationSergio.ScaleM(1.0f, 1.0f, 0.5f);
        Matrix4x4 torsoI = hipsI * torsoT;
        Matrix4x4 torsoM = torsoI * torsoS;
        ApplyTransformations(torsoM, bones[(int)BONES.TORSO]);

        //NECK
        Matrix4x4 neckT = TransformationSergio.TranslateM(0, 0.6f, 0);
        Matrix4x4 neckR = TransformationSergio.RotateM(30, ApplyTransformations.AXIS.AX_X);
        Matrix4x4 neckS = TransformationSergio.ScaleM(0.3f, 0.3f, 0.3f);
        Matrix4x4 neckI = torsoI * neckT * neckR;
        Matrix4x4 neckM = neckI * neckS;
        ApplyTransformations(neckM, bones[(int)BONES.NECK]);

        //HEAD
        Matrix4x4 headT = TransformationSergio.TranslateM(0, 0.3f, 0);
        Matrix4x4 headS = TransformationSergio.ScaleM(0.5f, 0.5f, 0.5f);
        Matrix4x4 headM = neckI * headT * headS;
        ApplyTransformations(headM, bones[(int)BONES.HEAD]);
    }
}
