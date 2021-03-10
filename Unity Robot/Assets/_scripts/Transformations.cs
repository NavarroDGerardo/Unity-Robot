using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformations
{
    public static Vector4 Translate(Vector4 original, float x, float y, float z)
    {
        Matrix4x4 t = Matrix4x4.identity;
        /*
         0 1 2 3 
         
         1 0 0 0 tx 0
         0 1 0 0 ty 1
         0 0 1 0 tz 2
         0 0 0 1  1 3
         */

        Vector4 translation = new Vector4(x, y, z, 1);

        //Row 0 and Column 3
        t[0, 3] = translation.x;
        t[1, 3] = translation.y;
        t[2, 3] = translation.z;

        return t * original;

        /*Puede ser asi igual
         Vector4 result = t * original;
        
        return result*/
    }

    public static Vector4 TranslateV(Vector4 original, Vector4 translation)
    {
        Matrix4x4 t = Matrix4x4.identity;

        //Row 0 and Column 3
        t[0, 3] = translation.x;
        t[1, 3] = translation.y;
        t[2, 3] = translation.z;
        t[3, 3] = translation.w;

        return t * original;

    }

    public static Vector4 Scale(Vector4 original, float x, float y, float z)
    {
        Matrix4x4 s = Matrix4x4.identity;

        s[0, 0] = x;
        s[1, 1] = y;
        s[2, 2] = z;

        return s * original;

    }

    public static Vector4 RotateX(Vector4 original, float degrees)
    {
        float radians = Mathf.Deg2Rad * degrees;

        Matrix4x4 rx = Matrix4x4.identity;
        float cos = Mathf.Cos(radians);
        float sin = Mathf.Sin(radians);

        rx[1, 1] = cos;
        rx[1, 2] = -sin;
        rx[2, 1] = sin;
        rx[2, 2] = cos;

        return rx * original;

    }

    public static Vector4 RotateY(Vector4 original, float degrees)
    {
        float radians = Mathf.Deg2Rad * degrees;

        Matrix4x4 ry = Matrix4x4.identity;
        float cos = Mathf.Cos(radians);
        float sin = Mathf.Sin(radians);

        ry[0, 0] = cos;
        ry[0, 2] = sin;
        ry[2, 0] = -sin;
        ry[2, 2] = cos;

        return ry * original;

    }


    public static Vector4 RotateZ(Vector4 original, float degrees)
    {
        float radians = Mathf.Deg2Rad * degrees;

        Matrix4x4 rz = Matrix4x4.identity;
        float cos = Mathf.Cos(radians);
        float sin = Mathf.Sin(radians);

        rz[0, 0] = cos;
        rz[0, 1] = -sin;
        rz[1, 0] = sin;
        rz[1, 1] = cos;

        return rz * original;

    }


}
