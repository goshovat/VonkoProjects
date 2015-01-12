﻿using System;

namespace Animals
{
    public class Frog: Animal
    {
        public Frog(string name, int age, string gender)
        {
            if (gender != "Male" && gender != "Female")
                throw new ApplicationException(string.Format("Error! Invalid gender '{0}'.", gender));

            byte ageInByte = 0;
            if (!byte.TryParse(age.ToString(), out ageInByte))
                throw new ApplicationException(string.Format("Error! Invalid age: {0}", age));

                base.name = name;
                base.age = ageInByte;
                base.gender = gender;     
        }

        public override string MakeSpecificSound()
        {
            return "Quiik, Quiik, baby!";
        }
    }
}
