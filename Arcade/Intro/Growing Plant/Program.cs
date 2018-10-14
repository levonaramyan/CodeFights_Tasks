using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Each day a plant is growing by upSpeed meters. Each night that plant's height decreases
// by downSpeed meters due to the lack of sun heat. Initially, plant is 0 meters tall.
// We plant the seed at the beginning of a day. We want to know when the height of the plant
// will reach a certain level.

namespace Growing_Plant
{
    class Program
    {
        static void Main(string[] args)
        {
            // testing and printing the result
            Console.WriteLine(growingPlant(100,10,900));
            Console.ReadKey();
        }

        // Returning which day th plant will reach the desired height
        static int growingPlant(int upSpeed, int downSpeed, int desiredHeight)
        {
            int height = upSpeed;
            int days = 1;

            while (height < desiredHeight)
            {
                height += upSpeed - downSpeed;
                days++;
            }

            return days;
        }
    }
}
