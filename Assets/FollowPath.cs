using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class FollowPath : MonoBehaviour
    {

        public enum MovementType
        {
            Moving,
            Lerping
        }
        
        public MovementType Type = MovementType.Moving;
        public MovementPath MyPath;
        public float speed = 1;
        public float maxDistance = 0.1f;

        private IEnumerator<Transform> pointInPath;

        public void RocketLaunch()
        {
            if (MyPath == null)
            {     
                Debug.Log("Примени путь.");
                return;
            }

            pointInPath = MyPath.GetNextPathPoint();

            pointInPath.MoveNext(); // перемещение на одну позицию вперед в контейнере элементов

            if (pointInPath.Current == null) // текущий элемент в контейнере
            {
                Debug.Log("Нужны точки.");
                return;
            }

            transform.position = pointInPath.Current.position;
        }

        private void Update()
        {
            if (pointInPath == null || pointInPath.Current == null)
            {
                return;
            }

            if (Type == MovementType.Moving)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
            }
            else if (Type == MovementType.Lerping)
            {
                transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
            }


            var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude; // Magnitude - увеличена, squared - в квадрате

            if (distanceSqure < maxDistance * maxDistance)
            {
                pointInPath.MoveNext();
            }
        }
    }
}
