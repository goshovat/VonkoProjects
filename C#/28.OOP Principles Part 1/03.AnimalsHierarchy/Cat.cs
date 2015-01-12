namespace AnimalsHierarchy
{
    using System;

    public abstract class Cat : Animal
    {
        public Cat(int age, string name, string sex)
            :base(age, name, sex) {}

        public string Scratch()
        {
            return string.Format("You are scratched by {0} {1}!", 
                this.GetType(), base.Name);
        }
    }
}
