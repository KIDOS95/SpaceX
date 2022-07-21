using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementPath : MonoBehaviour
{
    public enum PathTypes
    {
        linear,
        loop
    }

    public PathTypes pathType;
    public int movementDirection = 1;
    public int moveingTo = 0;
    public bool backwardMovement;
    public Transform[] PathElements;
    private bool activeCounter = true;



    public void OnDrawGizmos()
    {
        if (PathElements == null || PathElements.Length < 2)
        {
            return;
        }

        for (int i = 1; i < PathElements.Length; i++)
        {
            Gizmos.DrawLine(PathElements[i - 1].position, PathElements[i].position);
        }

        if (pathType == PathTypes.loop)
        {
            Gizmos.DrawLine(PathElements[0].position, PathElements[PathElements.Length - 1].position);
        }
    }

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (PathElements == null || PathElements.Length < 1)
        {
            yield break; // Указывает, что последовательность больше не имеет элементов.
        }

        while (true)
        {
            yield return PathElements[moveingTo]; // Определяет возвращаемый элемент.



            if (PathElements.Length == 1)
            {
                continue; // Данный оператор позволяет перейти к следующей итерации, не завершив до конца текущую.
            }

            if (pathType == PathTypes.linear)
            {
                if (moveingTo <= 0)
                {
                    movementDirection = 1;
                }
                else if (moveingTo >= PathElements.Length - 1)
                {
                    movementDirection = -1;
                    if (!backwardMovement) activeCounter = false;
                }
            }
            if (activeCounter)
            {
                moveingTo = moveingTo + movementDirection;
            }
            if (pathType == PathTypes.loop)
            {
                if (moveingTo >= PathElements.Length)
                {
                    moveingTo = 0;
                    if (!backwardMovement) activeCounter = false;
                }
                if (moveingTo < 0)
                {
                    moveingTo = PathElements.Length - 1;
                }
            }
        }
    }
}
