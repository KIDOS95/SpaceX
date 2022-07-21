using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Assets
{
    public class TurnRocket : MonoBehaviour
    {
        [SerializeField] private Transform SpaceX;
        [SerializeField] private Transform FrontPath;
        [SerializeField] private Transform EndPath;
        [SerializeField] private MovementPath MyPath;

        public float rocketX { get; set; }
        public float rocketY { get; set; }
        public float pathX { get; set; }
        public float pathY { get; set; }
        public float verticalX { get; set; }
        public float verticalY { get; set; }
        public float vectorPathX { get; set; }
        public float vectorPathY { get; set; }
        public float verticalVectorX { get; set; }
        public float verticalVectorY { get; set; }
        public float radian { get; set; }
        public float gradus;
        public float speedRotate;

        public int numberPoint { get; set; }
        public int positionPoitnX { get; set; }
        public int positionPoitnY { get; set; }
        public int positionSpasexX { get; set; }
        public int positionSpasexY { get; set; }
        public int endPathX { get; set; }
        public int endPathY { get; set; }
        public int frontPathX { get; set; }
        public int frontPathY { get; set; }

        public bool backwardMovement { get; set; }

        public float angel;

        private void Start()
        {
            GettingStaticPositions();

            
        }

        private void FixedUpdate()
        {
            GettingPosition();
            CounterPoint();
            VectorSearch();
            AngleCountSinus();
        }

        private void GettingPosition()
        {
            positionSpasexX = Mathf.RoundToInt(SpaceX.position.x);
            positionSpasexY = Mathf.RoundToInt(SpaceX.position.y);
            positionPoitnX = Mathf.RoundToInt(MyPath.PathElements[numberPoint].position.x);
            positionPoitnY = Mathf.RoundToInt(MyPath.PathElements[numberPoint].position.y);
        }

        private void CounterPoint()
        {
            if (positionPoitnX == positionSpasexX && positionPoitnY == positionSpasexY)
            {
                if (frontPathX == positionSpasexX && frontPathY == positionSpasexY)
                    backwardMovement = false;
                if (endPathX == positionSpasexX && endPathY == positionSpasexY)
                    backwardMovement = true;

                if (backwardMovement)
                {
                    numberPoint--;
                }
                else
                {
                    numberPoint++;
                }
            }
        }

        private void VectorSearch()
        {
            rocketX = SpaceX.position.x;
            rocketY = SpaceX.position.y;
            pathX = MyPath.PathElements[numberPoint].position.x;
            pathY = MyPath.PathElements[numberPoint].position.y;
            verticalX = SpaceX.position.x;
            verticalY = SpaceX.position.y + 10;

            vectorPathX = pathX - rocketX;
            vectorPathY = pathY - rocketY;
            verticalVectorX = verticalX - rocketX;
            verticalVectorY = verticalY - rocketY;
        }

        private void AngleCountSinus()
        {
            radian = (vectorPathX * verticalVectorX + verticalVectorY * vectorPathY) / (Mathf.Sqrt(Mathf.Pow(vectorPathX, 2) + Mathf.Pow(vectorPathY, 2)) * Mathf.Sqrt(Mathf.Pow(verticalVectorX, 2) + Mathf.Pow(verticalVectorY, 2)));
            gradus = Mathf.Acos(radian) * 180 / Mathf.PI;

            if (vectorPathX < 0 && vectorPathY > 0 || vectorPathX < 0 && vectorPathY < 0)
            {
                //SpaceX.rotation = Quaternion.Euler(0, 0, gradus);
                SpaceX.transform.DORotate(new Vector3(0, 0, gradus), speedRotate);
            }
            else
            {
                //SpaceX.rotation = Quaternion.Euler(0, 0, -gradus);
                SpaceX.transform.DORotate(new Vector3(0, 0, -gradus), speedRotate);
            }
        }

        
        public void GettingStaticPositions()
        {
            numberPoint = 1;
            endPathX = Mathf.RoundToInt(EndPath.position.x);
            endPathY = Mathf.RoundToInt(EndPath.position.y);
            frontPathX = Mathf.RoundToInt(FrontPath.position.x);
            frontPathY = Mathf.RoundToInt(FrontPath.position.y);
        }
    }
}
