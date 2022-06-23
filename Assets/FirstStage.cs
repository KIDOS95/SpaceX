using UnityEngine;

namespace Assets
{
    public class FirstStage : MonoBehaviour
    {
        public byte maximumAmountFuel { get; set; }
        public byte rightAmountFuel { get; set; }
        [SerializeField] private ParticleSystem _RocketPath;
        [SerializeField] private ParticleSystem _RocketExplosion;

        [SerializeField] private FollowPath followPathSecond;
        [SerializeField] private FollowPath followPathFirst;


        public FirstStage(byte maximumAmountFuel, byte rightAmountFuel)
        {
            this.maximumAmountFuel = maximumAmountFuel;
            this.rightAmountFuel = rightAmountFuel;
        }

        ParticleSystem system
        {
            get
            {
                if (_RocketPath == null) 
                {
                    _RocketPath = GetComponent<ParticleSystem>();
                }
                return _RocketPath;
            }     
        }
       ParticleSystem rocketExplosion
       {    
           get
            {
                if (_RocketExplosion == null) 
                {
                    _RocketExplosion = GetComponent<ParticleSystem>();
                }              
                return _RocketExplosion;
            }
       }

        public void TankFilling()
        {
            int currentNumber = Random.Range(0,maximumAmountFuel);
            if (currentNumber >= rightAmountFuel)
            {
                LaunchRocket();
            }
            else 
            {
                if (rocketExplosion)
                {
                    rocketExplosion.Play(true);
                }
            }

            print($"\nРакета наполнена: {currentNumber} \nОбъём бака: {rightAmountFuel} ");
        }

        private void LaunchRocket()
        {
            if (system)
            {
                system.Play(true);
            }
            followPathSecond.RocketLaunch();
            followPathFirst.RocketLaunch();
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            Debug.Log("mmmmm");
            if (system)
            {
                system.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
        }


        

        

        

    }
}
