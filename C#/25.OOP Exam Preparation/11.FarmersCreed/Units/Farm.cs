namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;
    using FarmersCreed.Interfaces;
    using System.Linq;
    using System.Text;

    public class Farm : GameObject, IFarm
    {
        private List<Plant> plants;
        private List<Animal> animals;
        private List<Product> products;

        public Farm(string id)
            : base(id)
        {
            this.plants = new List<Plant>();
            this.animals = new List<Animal>();
            this.products = new List<Product>();
        }

        public List<Plant> Plants
        {
            get { return this.plants; }
        }

        public List<Animal> Animals
        {
            get { return this.animals; }
        }

        public List<Product> Products
        {
            get { return new List<Product>(this.products); }
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentException("Cannot add null product");
            }

            Product oldProduct = this.Products.FirstOrDefault(x => x.Id == product.Id);

            if (oldProduct != null)
            {
                oldProduct.Quantity+= product.Quantity;
            }
            else
            {
                this.products.Add(product);
            }
        }

        public void Exploit(IProductProduceable productProducer)
        {
            Product newProduct = productProducer.GetProduct();
            this.AddProduct(newProduct);
        }

        public void Feed(Animal animal, IEdible edibleProduct, int productQuantity)
        {
            if (animal == null)
            {
                throw new ArgumentException("Cannot feed null animal.");
            }
            if (edibleProduct == null)
            {
                throw new ArgumentException("Cannot feed animal with null product.");
            }

            animal.Eat(edibleProduct, productQuantity);
            edibleProduct.Quantity -= productQuantity;
        }

        public void Water(Plant plant)
        {
            if (plant == null)
            {
                throw new ArgumentException("Cannot water null plant");
            }

            plant.Water();
        }

        public void UpdateFarmState()
        {
            var aliveAnimals = this.animals.Where(a => a.IsAlive);
            foreach (Animal animal in aliveAnimals)
            {
                animal.Starve();
            }

            var alivePlants = this.plants.Where(p => p.IsAlive);
            foreach (Plant plant in alivePlants)
            {
                if (plant.GrowTime > 0)
                {
                    plant.Grow();
                }
                else
                {
                    plant.Wither();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("--{0} {1}", this.GetType().Name, this.Id).AppendLine();

            var sortedAnimals = this.animals.Where(a => a.IsAlive == true).OrderBy(a => a.Id);
            foreach (var animal in sortedAnimals)
            {
                result.AppendLine(animal.ToString());
            }

            var sortedPlants = this.plants.Where(p => p.IsAlive)
                                        .OrderBy(p => p.Health)
                                        .ThenBy(p => p.Id);
            foreach (var plant in sortedPlants)
            {
                result.AppendLine(plant.ToString());
            }

            var sortedProducts = this.products.OrderBy(p => p.ProductType.ToString())
                                              .ThenByDescending(p => p.Quantity)
                                              .ThenBy(p => p.Id);
            foreach (var product in sortedProducts)
            {
                result.AppendLine(product.ToString());
            }

            return result.ToString();
        }
    }
}
