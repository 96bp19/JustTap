using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
   public static bool CheckColor(Material a  , Material b)
    {
        return a == b;
    }
}
