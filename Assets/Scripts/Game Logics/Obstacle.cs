using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public enum ObstaclePosition
    {
        Bot,
        Mid,
        Top
    }
    [SerializeField] ObstaclePosition startPosition;
    [SerializeField] ObstaclePosition endPosition;
    public int getEndPosition()
    {
        return (int)endPosition;
    }
}


