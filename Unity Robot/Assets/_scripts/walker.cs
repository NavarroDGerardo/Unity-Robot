using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker
{

    public static Vector3[] DoTransformHandLeft(Vector3[] input, float rotX, float side) {
       Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            
            
            //Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            Vector4 temp1 = Transformations.Scale(input[i], 0.5f, 0.5f, 0.5f);
            temp1.w = 1;
            //Vector4 temp2 = Transformations.Translate(temp1, -side, -side * 1.5f, 0f);
            Vector4 temp2 = Transformations.RotateX(temp1, -rotX);
            //Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            Vector4 temp3 = Transformations.Translate(temp2, -side*2, side*2.5f, side/4);
            output[i] = temp3;
        }

        return output; 
    }

    public static Vector3[] DoTransformHandRight(Vector3[] input, float rotX, float side) {
       Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            
            
            //Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            Vector4 temp1 = Transformations.Scale(input[i], 0.5f, 0.5f, 0.5f);
            temp1.w = 1;
            //Vector4 temp2 = Transformations.Translate(temp1, -side, -side * 1.5f, 0f);
            Vector4 temp2 = Transformations.RotateX(temp1, -rotX);
            //Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            Vector4 temp3 = Transformations.Translate(temp2, side*2, side*2.5f, side/4);
            output[i] = temp3;
        }

        return output; 
    }

    public static Vector3[] DoTransformForearmLeft(Vector3[] input, float rotX, float side) {
       Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            
            
            //Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            Vector4 temp1 = Transformations.Scale(input[i], 0.65f, 0.75f, 0.75f);
            temp1.w = 1;
            //Vector4 temp2 = Transformations.Translate(temp1, -side, -side * 1.5f, 0f);
            Vector4 temp2 = Transformations.RotateX(temp1, -rotX);
            //Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            Vector4 temp3 = Transformations.Translate(temp2, -side*2, side*3, side/4);
            output[i] = temp3;
        }

        return output; 
    }

     public static Vector3[] DoTransformForearmRight(Vector3[] input, float rotX, float side) {
       Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            
            
            //Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            Vector4 temp1 = Transformations.Scale(input[i], 0.65f, 0.75f, 0.75f);
            temp1.w = 1;
            //Vector4 temp2 = Transformations.Translate(temp1, -side, -side * 1.5f, 0f);
            Vector4 temp2 = Transformations.RotateX(temp1, -rotX);
            //Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            Vector4 temp3 = Transformations.Translate(temp2, side*2, side*3, side/4);
            output[i] = temp3;
        }

        return output; 
    }

    public static Vector3[] DoTransformBicepLeft(Vector3[] input, float rotX, float side)
    {
        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            
            
            //Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            Vector4 temp1 = Transformations.Scale(input[i], 0.5f, 1.5f, 0.5f);
            temp1.w = 1;
            //Vector4 temp2 = Transformations.Translate(temp1, -side, -side * 1.5f, 0f);
            Vector4 temp3 = Transformations.RotateX(temp1, rotX);
            //Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            Vector4 temp5 = Transformations.Translate(temp3, side*2, side*4, side/6);
            output[i] = temp5;
        }

        return output;
    }

    public static Vector3[] DoTransformBicepRight(Vector3[] input, float rotX, float side)
    {
        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            //Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            Vector4 temp1 = Transformations.Scale(input[i], 0.5f, 1.5f, 0.5f);
            temp1.w = 1;
            //Vector4 temp2 = Transformations.Translate(temp1, -side, -side * 1.5f, 0f);
            Vector4 temp3 = Transformations.RotateX(temp1, rotX);
            //Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            Vector4 temp5 = Transformations.Translate(temp3, -side*2, side*4, side/4);
            output[i] = temp5;
           
        }

        return output;
    }
    public static Vector3[] DoTransformThighRight(Vector3[] input, float rotX, float side)
    {
        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            Vector4 temp1 = Transformations.Scale(input[i], 1f, 1f, 0.5f);
            temp1.w = 1;
            Vector4 temp2 = Transformations.Translate(temp1, -side, -side / 2, 0f);
            Vector4 temp3 = Transformations.RotateX(temp2, rotX);
            Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            output[i] = temp4;
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

    public static Vector3[] DoTransformTorax(Vector3[] input, float rotY, float side)
    {

        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            Vector4 temp1 = Transformations.Scale(input[i], 3f, 2f, 2f);
            temp1.w = 1;
            Vector4 temp2 = Transformations.Translate(temp1, 0.0f, side * 4 + side / 2, 0.0f);
            Vector4 temp3 = Transformations.RotateY(temp2, rotY);
            output[i] = temp3;
            ;
        }

        return output;

    }

    public static Vector3[] ShoulderRight(Vector3[] input, float rotY, float side)
    {

        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            Vector4 temp1 = Transformations.Scale(input[i], 1f, 1f, 1f);
            temp1.w = 1;
            Vector4 temp2 = Transformations.Translate(temp1, side * 2, side * 5, side / 4);
            Vector4 temp3 = Transformations.RotateY(temp2, rotY);
            output[i] = temp3;
            ;
        }

        return output;

    }

    public static Vector3[] ShoulderLeft(Vector3[] input, float rotY, float side)
    {

        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            Vector4 temp1 = Transformations.Scale(input[i], 1f, 1f, 1f);
            temp1.w = 1;
            Vector4 temp2 = Transformations.Translate(temp1, -side * 2, side * 5, side / 4);
            Vector4 temp3 = Transformations.RotateY(temp2, rotY);
            output[i] = temp3;
            ;
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
            Vector4 temp2 = Transformations.Translate(temp1, -side, -side * 1.5f, 0f);
            Vector4 temp3 = Transformations.RotateX(temp2, rotX);
            Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            output[i] = temp4;
        }

        return output;
    }

    public static Vector3[] DoTransformCalveRightBack(Vector3[] input, float rotX, float side)
    {
        Vector3[] output = new Vector3[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            Vector4 temp1 = Transformations.Scale(input[i], 1f, 1f, 0.5f);
            temp1.w = 1;
            Vector4 temp2 = Transformations.Translate(temp1, -side, -side * 1.5f, 0f);
            Vector4 temp3 = Transformations.RotateX(temp2, rotX);
            Vector4 temp4 = Transformations.Translate(temp3, 0, side * 2.5f, side / 4);
            output[i] = temp4;
        }

        return output;
    }
}
