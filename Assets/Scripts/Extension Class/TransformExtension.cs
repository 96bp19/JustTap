
using UnityEngine;

public static  class TransformExtension
{
   
    public static Vector3 DirectionTo(this Transform source, Transform destination)
    {
        return source.position.DirectionTo(destination.position);
    }
}
