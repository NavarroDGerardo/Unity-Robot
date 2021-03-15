using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker
{
    public static Vector3[] DoTransformThighRight(Vector3[] input, float rotX, float side)
    {
        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            Vector4 temp1 = Transformations.Scale(input[i], 1f, 1f, 0.5f);
            temp1.w = 1;
            Vector4 temp2 = Transformations.Translate(temp1, 0.0f, -side / 2, 0.0f);
            Vector4 temp3 = Transformations.RotateX(temp2, rotX);
            Vector4 temp4 = Transformations.Translate(temp3, -side, 0.0f, 0.0f);
            Vector4 temp5 = Transformations.Translate(temp4, 0.0f, side * 2.5f, 0.0f);
            Vector4 temp6 = Transformations.Translate(temp5, 0.0f, 0.0f, side / 4);
            output[i] = temp6;
        }

        return output;
    }

    public static Vector3[] DoTransformThighLeft(Vector3[] input, float rotX, float side)
    {
        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            Vector4 temp1 = Transformations.Scale(input[i], 1f, 1f, 0.5f);
            temp1.w = 1;
            Vector4 temp2 = Transformations.Translate(temp1, 0.0f, -side / 2, 0.0f);
            Vector4 temp3 = Transformations.RotateX(temp2, rotX);
            Vector4 temp4 = Transformations.Translate(temp3, side, 0.0f, 0.0f);
            Vector4 temp5 = Transformations.Translate(temp4, 0.0f, side * 2.5f, 0.0f);
            Vector4 temp6 = Transformations.Translate(temp5, 0.0f, 0.0f, side / 4);
            output[i] = temp6;
        }

        return output;
    }

    public static Vector3[] DoTransformCalveRightFront(Vector3[] input, float rotX, float side)
    {
        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            Vector4 temp1 = Transformations.Scale(input[i], 1f, 1f, 0.5f);
            temp1.w = 1;
            Vector4 temp2 = Transformations.Translate(temp1, 0.0f, -side * 2.5f, 0.0f);
            Vector4 temp4 = Transformations.Translate(temp2, -side, 0.0f, 0.0f);
            Vector4 temp5 = Transformations.Translate(temp4, 0.0f, 0.0f, side / 4);
            Vector4 temp6 = Transformations.RotateX(temp5, rotX);
            output[i] = temp6;
            ;
        }

        return output;
    }
}
