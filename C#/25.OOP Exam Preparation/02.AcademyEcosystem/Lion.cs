using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        public Lion(string name, Point location)
            : base(name, location, 6)
        {
        }

        public override void Update(int timeElapsed)
        {
            if (this.State == AnimalState.Sleeping)
            {
                if (timeElapsed >= sleepRemaining)
                {
                    this.Awake();
                }
                else
                {
                    this.sleepRemaining -= timeElapsed;
                }
            }

            base.Update(timeElapsed);
        }

        public int TryEatAnimal(Animal animal)
        {
            int eatenQuantity = 0;

            if (animal != null)
            {
                if (animal.GetType().Name == "Zombie")
                    return animal.GetMeatFromKillQuantity();

                if (animal.Size <= this.Size * 2)
                {
                    eatenQuantity = animal.GetMeatFromKillQuantity();
                    this.Size++;
                }
            }

            return eatenQuantity;
        }
    }
}