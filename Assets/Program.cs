using UnityEngine;

namespace Assets
{
    public class Program : MonoBehaviour
    {

        public SecondStep secondStep;
        public byte length;
        public byte width;
        public FirstStage firstStage;
        public byte maximumAmountFuel;
        public byte rightAmountFuel;

  
        public void Start()
        {
            this.secondStep.length = length;
            this.secondStep.width = width;
            this.firstStage.maximumAmountFuel = maximumAmountFuel;
            this.firstStage.rightAmountFuel = rightAmountFuel;
        }  

        public void ButtonDetachment()
        {
            
            secondStep.Detachment();
        }

        public void ButtonTankAndLaunch()
        {
            firstStage.TankFilling();
        }

        public void ButtonRocketLaunch()
        {

            
        }
    }
}
