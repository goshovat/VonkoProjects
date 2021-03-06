﻿using System;

namespace DecoratorPattern
{
    public class PepperoniPizza : ToppingDecorator
    {
        public PepperoniPizza(Pizza pizza)
            : base(pizza)
        {
            Console.WriteLine("Adding pepperoni");
        }

        public override string GetDescription()
        {
            return basePizza.GetDescription() + ", Pepperoni";
        }

        public override decimal GetPrice()
        {
            return basePizza.GetPrice() + 1.25M;
        }
    }
}