using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction
{
    public static Vector3[] scaleVerticesZ(Vector3[] input, float scale)
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

    public static Vector3[] scaleVerticesY(Vector3[] input, float scale)
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

    public static Vector3[] scaleVerticesX(Vector3[] input, float scale)
    {
        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            Vector4 temp1 = input[i];
            temp1.w = 1;
            output[i] = Transformations.Scale(temp1, scale, 1f, 1f);
        }

        return output;
    }

    public static Vector3[] translateVerticesY(Vector3[] input, float translation)
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

    public static Vector3[] translateVerticesX(Vector3[] input, float translation)
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

    public static Vector3[] translateVerticesZ(Vector3[] input, float translation)
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
}
