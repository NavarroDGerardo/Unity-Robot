using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> bones;

    public static float side = 10.0f;
    float dir = 1.0f; 
    float dirKnee = 1.0f;  
    float rotationX = 0.0f;
    float rotationKnee = 0.0f;
    float delta = 0.5f;  // how much to change rotation on each frame
    float minAngle = -20.0f;  // minimum rotation angle in X
    float maxAngle = 20.0f;   // maximum rotation angle in X


    float minAngleKnee = -20.0f;  // minimum rotation angle in X
    float maxAngleKnee = 0.0f;


    float deltaKnee = 0.25f; 

    public enum BONES
    {
        HIPS,
        TORSO,
        NECK,
        HEAD,

       
        RIGHTTHIGH,
        LEFTTHIGH,
        LEFTCALVE,
        RIGHTCALVE,

        RIGHTFOOT,
        LEFTFOOT,

        SHOULDERRIGHT,
        SHOULDERLEFT,

        LEFTBICEP,
        RIGHTBICEP,
        LEFTFOREARM,
        RIGHTFOREARM,
        LEFTHAND,
        RIGHTHAND,
         
    };

    public static void ApplyTransformations(Matrix4x4 t, GameObject target)
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


    public static void ApplyTransformationsROTATION(Matrix4x4 t, GameObject target, float rotX)
    {
        
        Block b = target.GetComponent<Block>();
        Vector3[] newVerts = new Vector3[8];
        for (int v = 0; v < b.vertices.Length; v++)
        {
            Vector4 temp = b.vertices[v];
            temp.w = 1;

            //Vector4 temp2 = Transformations.Translate(temp1, -side, -side * 1.5f, 0f);
            Vector4 temp2 = Walker.RotateX(temp, -rotX);
            //Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            Vector4 temp3 = Walker.Translate(temp2, -side*2, side*2.5f, side/4);
            newVerts[v] = t * temp;
        
        }
        b.myMesh.vertices = newVerts;
    }


    // Start is called before the first frame update
    void Start()
    {
        bones = new List<GameObject>();

        System.Array values = System.Enum.GetValues(typeof(BONES));
        foreach (BONES bone in values)
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
        Matrix4x4 hipsS = Walker.ScaleM(1, 0.3f, 0.6f);
        //Matrix4x4 hipsR = TransformationSergio.RotateM(rotationX, TransformationSergio.AXIS.AX_Y);
        Matrix4x4 hipsM = hipsS;
        Matrix4x4 hipsI = Matrix4x4.identity;
        ApplyTransformations(hipsM, bones[(int)BONES.HIPS]);

        //TORSO:
        Matrix4x4 torsoT = Walker.TranslateM(0, 0.65f, 0);
        Matrix4x4 torsoR = Walker.RotateM(rotationX/2.0f, Walker.AXIS.AX_Y);
        Matrix4x4 torsoS = Walker.ScaleM(1.0f, 1.0f, 0.5f);
        Matrix4x4 torsoI = hipsI * torsoT*torsoR;
        Matrix4x4 torsoM = torsoI * torsoS;
        //ApplyTransformations(torsoM, bones[(int)BONES.TORSO]);
        ApplyTransformationsROTATION(torsoM, bones[(int)BONES.TORSO], rotationX);

        //RIGHSHOULDER
        Matrix4x4 shoulderTR = Walker.TranslateM(-0.65f, 0.30f, 0);
        Matrix4x4 shoulderSR = Walker.ScaleM(0.4f, 0.4f, 0.4f);
        Matrix4x4 shoulderIR = torsoI * shoulderTR;
        Matrix4x4 shoulderMR = shoulderIR * shoulderSR;
        ApplyTransformations(shoulderMR, bones[(int)BONES.SHOULDERRIGHT]);

        //LEFTSHOULDE:
        Matrix4x4 shoulderTL = Walker.TranslateM(0.65f, 0.30f, 0);
        Matrix4x4 shoulderSL = Walker.ScaleM(0.4f, 0.4f, 0.4f);
        Matrix4x4 shoulderIL = torsoI * shoulderTL;
        Matrix4x4 shoulderML = shoulderIL * shoulderSL;
        ApplyTransformations(shoulderML, bones[(int)BONES.SHOULDERLEFT]);

        //RIGHTBICEP
        Matrix4x4 bicepRR = Walker.RotateM(-rotationX, Walker.AXIS.AX_X);
        Matrix4x4 bicepTR = Walker.TranslateM(0.0f, -0.40f, 0);
        Matrix4x4 bicepSR = Walker.ScaleM(0.2f, 0.4f, 0.2f);
        Matrix4x4 bicepIR = shoulderIR * bicepTR* bicepRR;
        Matrix4x4 bicepMR = bicepIR * bicepSR;
        ApplyTransformations(bicepMR, bones[(int)BONES.RIGHTBICEP]);

        //LEFTBICEP
        Matrix4x4 bicepLR = Walker.RotateM(rotationX, Walker.AXIS.AX_X);
        Matrix4x4 bicepTL = Walker.TranslateM(0.0f, -0.40f, 0);
        Matrix4x4 bicepSL = Walker.ScaleM(0.2f, 0.4f, 0.2f);
        Matrix4x4 bicepIL = shoulderIL * bicepTL * bicepLR;
        Matrix4x4 bicepML = bicepIL * bicepSL;
        ApplyTransformations(bicepML, bones[(int)BONES.LEFTBICEP]);

        //RIGHTFOREARM
        Matrix4x4 forearmRR = Walker.RotateM(-rotationKnee, Walker.AXIS.AX_X);
        Matrix4x4 forearmTR = Walker.TranslateM(0.0f, -0.40f, 0);
        Matrix4x4 forearmSR = Walker.ScaleM(0.2f, 0.4f, 0.2f);
        Matrix4x4 forearmIR = bicepIR * forearmTR * forearmRR;
        Matrix4x4 forearmMR = forearmIR * forearmSR;
        ApplyTransformations(forearmMR, bones[(int)BONES.RIGHTFOREARM]);

        //LEFTFOREARM
        Matrix4x4 forearmLR = Walker.RotateM(-rotationKnee, Walker.AXIS.AX_X);
        Matrix4x4 forearmTL = Walker.TranslateM(0.0f, -0.40f, 0);
        Matrix4x4 forearmSL = Walker.ScaleM(0.2f, 0.4f, 0.2f);
        Matrix4x4 forearmIL = bicepIL * forearmTL * forearmLR;
        Matrix4x4 forearmML = forearmIL * forearmSL;
        ApplyTransformations(forearmML, bones[(int)BONES.LEFTFOREARM]);

        //RIGHTHAND
        Matrix4x4 handTR = Walker.TranslateM(0.0f, -0.30f, 0);
        Matrix4x4 handSR = Walker.ScaleM(0.2f, 0.2f, 0.3f);
        Matrix4x4 handIR = forearmIR * handTR;
        Matrix4x4 handMR = handIR * handSR;
        ApplyTransformations(handMR, bones[(int)BONES.RIGHTHAND]);

        //LEFTHAND
        Matrix4x4 handTL = Walker.TranslateM(0.0f, -0.30f, 0);
        Matrix4x4 handSL = Walker.ScaleM(0.2f, 0.2f, 0.3f);
        Matrix4x4 handIL = forearmIL * handTL;
        Matrix4x4 handML = handIL * handSL;
        ApplyTransformations(handML, bones[(int)BONES.LEFTHAND]);

        //RIGHTHIGH:


        /*
        Vector4 temp1 = Transformations.Scale(input[i], 1f, 1f, 0.5f);
        temp1.w = 1;
        Vector4 temp2 = Transformations.Translate(temp1, -side, -side / 2, 0f);
        Vector4 temp3 = Transformations.RotateX(temp2, rotX);
        Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);

        */

        //Matrix4x4 thighTR = TransformationSergio.TranslateM(-0.25f, -0.4f, 0);
        Matrix4x4 thighTP = Walker.TranslateM(0, -0.2f, 0);
        Matrix4x4 thighRR = Walker.RotateM(rotationX, Walker.AXIS.AX_X);
        Matrix4x4 thighTR = Walker.TranslateM(-0.25f, -0.2f, 0);
        Matrix4x4 thighSR = Walker.ScaleM(0.3f, 0.5f, 0.5f);
        Matrix4x4 thighIR = hipsI * thighTR * thighRR * thighTP;
        Matrix4x4 thighMR = thighIR * thighSR;
        ApplyTransformations(thighMR, bones[(int)BONES.RIGHTTHIGH]);

        //LEFTTHIGH:
        Matrix4x4 thighLP = Walker.TranslateM(0, -0.2f, 0);
        Matrix4x4 thighLR = Walker.RotateM(-rotationX, Walker.AXIS.AX_X);
        Matrix4x4 thighTL = Walker.TranslateM(0.25f, -0.2f, 0);
        Matrix4x4 thighSL = Walker.ScaleM(0.3f, 0.5f, 0.5f);
        Matrix4x4 thighIL = hipsI * thighTL*thighLR * thighLP;
        Matrix4x4 thighML = thighIL * thighSL;
        ApplyTransformations(thighML, bones[(int)BONES.LEFTTHIGH]);

        //RIGHTCALVE:
        
        /*
        if(dir < 0){
            rotationKnee = rotationX;
        }else{
            rotationKnee = rotationX/5f;
        }*/
        Matrix4x4 calveRR = Walker.RotateM(rotationKnee, Walker.AXIS.AX_X);
        Matrix4x4 calveTR = Walker.TranslateM(0.0f, -0.5f, 0);
        Matrix4x4 calveSR = Walker.ScaleM(0.3f, 0.5f, 0.5f);
        Matrix4x4 calveIR = thighIR * calveTR * calveRR;
        Matrix4x4 calveMR = calveIR * calveSR;
        ApplyTransformations(calveMR, bones[(int)BONES.RIGHTCALVE]);

        //LEFTCALVE:
        Matrix4x4 calveLR = Walker.RotateM(rotationKnee, Walker.AXIS.AX_X);
        Matrix4x4 calveTL = Walker.TranslateM(0.0f, -0.5f, 0);
        Matrix4x4 calveSL = Walker.ScaleM(0.3f, 0.5f, 0.5f);
        Matrix4x4 calveIL = thighIL * calveTL * calveLR;
        Matrix4x4 calveML = calveIL * calveSL;
        ApplyTransformations(calveML, bones[(int)BONES.LEFTCALVE]);

        //RIGHTFOOT:
        Matrix4x4 footTR = Walker.TranslateM(0f, -0.35f, -0.1f);
        Matrix4x4 footSR = Walker.ScaleM(0.3f, 0.2f, 0.65f);
        Matrix4x4 footIR = calveIR * footTR;
        Matrix4x4 footMR = footIR * footSR;
        ApplyTransformations(footMR, bones[(int)BONES.RIGHTFOOT]);

        //LEFTFOOT:
        Matrix4x4 footTL = Walker.TranslateM(0.0f, -0.35f, -0.1f);
        Matrix4x4 footSL = Walker.ScaleM(0.3f, 0.2f, 0.65f);
        Matrix4x4 footIL = calveIL * footTL;
        Matrix4x4 footML = footIL * footSL;
        ApplyTransformations(footML, bones[(int)BONES.LEFTFOOT]);
        

        //NECK
        Matrix4x4 neckT = Walker.TranslateM(0, 0.6f, 0);
        Matrix4x4 neckR = Walker.RotateM(rotationX/2.0f, Walker.AXIS.AX_X);
        Matrix4x4 neckS = Walker.ScaleM(0.3f, 0.3f, 0.3f);
        Matrix4x4 neckI = torsoI * neckT * neckR;
        Matrix4x4 neckM = neckI * neckS;
        ApplyTransformations(neckM, bones[(int)BONES.NECK]);

        //HEAD
        Matrix4x4 headT = Walker.TranslateM(0, 0.3f, 0);
        Matrix4x4 headS = Walker.ScaleM(0.5f, 0.5f, 0.5f);
        Matrix4x4 headM = neckI * headT * headS;
        ApplyTransformations(headM, bones[(int)BONES.HEAD]);


        rotationX += dir * delta;
        if (rotationX > maxAngle || rotationX < minAngle) dir = -dir;

        rotationKnee += dirKnee * deltaKnee;
        if (rotationKnee > maxAngleKnee || rotationKnee < minAngleKnee) dirKnee = -dirKnee;

        /*
        if (dir < 0)
        {
            calveMR.vertices = Walker.DoTransformCalveRightFront(vertices, rotationX, side);
            rightFeetMesh.vertices = Walker.DoTransformFootRightFront(vertices, rotationX, side);

            if (rotationX > -25.0f)
            {
                rotationKneeLeft += dirKneeLeft * delta * -2;
            }
            if (rotationX < 25.0f)
            {
                rotationKneeLeft += dirKneeLeft * delta * 2;
            }
            leftCalve.vertices = Walker.DoTransformCalveLeftBack(vertices, -rotationX, side, rotationKneeLeft);
            leftFeetMesh.vertices = Walker.DoTransformFootLeftBack(vertices, -rotationX, side, rotationKneeLeft);
        }
        else
        {
            leftCalve.vertices = Walker.DoTransformCalveLeftFront(vertices, -rotationX, side);
            leftFeetMesh.vertices = Walker.DoTransformFootLeftFront(vertices, -rotationX, side);

            if (rotationX < -25.0f)
            {
                rotationKnee += dirKnee * delta * -2;
            }
            if (rotationX > 25.0f)
            {
                rotationKnee += dirKnee * delta * 2;
            }
            rightCalve.vertices = Walker.DoTransformCalveRightBack(vertices, rotationX, side, rotationKnee);
            rightFeetMesh.vertices = Walker.DoTransformFootRightBack(vertices, rotationX, side, rotationKnee);
        }*/
    }
}
