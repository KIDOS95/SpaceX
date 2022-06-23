using UnityEngine;

namespace Assets
{
    public class SecondStep : MonoBehaviour
    {
        public byte length { get; set; }
        public byte width { get; set; }

        public SecondStep(byte length, byte width)
        {
            this.length = length;
            this.width = width;
        }

        public void Detachment()
        {
            print($"\nSecond Step \nдлина: {length} \nвысота: {width}");
        }
    }
}