using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCounter : MonoBehaviour
{
  private int brickCount;

  public void CountBrick()
  {
    brickCount++;
    Debug.Log($"Total Bricks Removed: {brickCount}");
  }
}
