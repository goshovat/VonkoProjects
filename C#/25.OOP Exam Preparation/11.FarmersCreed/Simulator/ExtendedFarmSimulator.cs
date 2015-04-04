using FarmersCreed.Interfaces;
using FarmersCreed.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersCreed.Simulator
{
    public class ExtendedFarmSimulator : FarmSimulator
    {
        protected override void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "Grain":
                    {
                        var food = new Food(id, ProductType.Grain, FoodType.Organic, 10, 2);
                        this.farm.AddProduct(food);
                    }
                    break;

                case "CherryTree":
                    {
                        var cherryTree = new CherryTree(id);
                        this.farm.Plants.Add(cherryTree);
                    }
                    break;

                case "TobaccoPlant":
                    {
                        var tobaccoPlant = new TobaccoPlant(id);
                        this.farm.Plants.Add(tobaccoPlant);
                    }
                    break;

                case "Cow":
                    {
                        var cow = new Cow(id);
                        this.farm.Animals.Add(cow);
                    }
                    break;

                case "Swine":
                    {
                        var swine = new Swine(id);
                        this.farm.Animals.Add(swine);
                    }
                    break;
                default:
                    break;
            }
        }

        protected override void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');

            string action = inputCommands[0];

            switch (action)
            {
                case "create":
                    {
                        string farmId = inputCommands[1];
                        this.farm = new Farm(farmId);
                    }
                    break;

                case "add":
                    {
                        this.AddObjectToFarm(inputCommands);
                    }
                    break;

                case "status":
                    {
                        this.PrintObjectStatus(inputCommands);
                    }
                    break;

                case "feed":
                    {
                        string animalId = inputCommands[1];
                        string foodId = inputCommands[2];
                        int quantity = int.Parse(inputCommands[3]);

                        Animal animal = this.GetAnimalById(inputCommands[1]);
                        Food food = this.GetProductById(foodId) as Food;

                        this.farm.Feed(animal, food , quantity);
                    }
                    break;

                case "water":
                    {
                        string plantId = inputCommands[1];

                        Plant plant = this.GetPlantById(plantId);
                        this.farm.Water(plant);
                    }
                    break;

                case "exploit":
                    {
                        string type = inputCommands[1];
                        string unitId = inputCommands[2];

                        if (type == "animal")
                        {
                            Animal animal = this.GetAnimalById(unitId);
                            this.farm.Exploit(animal);
                        }
                        else if (type == "plant")
                        {
                            Plant plant = this.GetPlantById(unitId);
                            this.farm.Exploit(plant);
                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
