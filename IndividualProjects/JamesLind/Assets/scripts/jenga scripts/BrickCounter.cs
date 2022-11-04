using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCounter : MonoBehaviour
{
 private static int brickcount;

 public static void countbrick() //todo: increment when a brick end drag is called.
 {
  brickcount++;
  Debug.Log($"Total bricks moved: {brickcount}");
 }
}
