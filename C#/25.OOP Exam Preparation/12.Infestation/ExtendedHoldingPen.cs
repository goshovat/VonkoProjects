using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infestation
{
    public class ExtendedHoldingPen : HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Dog":
                    var dog = new Dog(commandWords[2]);
                    this.InsertUnit(dog);
                    break;
                case "Human":
                    var human = new Human(commandWords[2]);
                    this.InsertUnit(human);
                    break;

                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;

                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;

                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;

                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;

                default:
                    break;
            }
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            string suppType = commandWords[1];
            string targetId = commandWords[2];
            Unit targetUnit = base.GetUnit(targetId);

            if (targetUnit != null)
            {
                switch (suppType)
                {
                    case "PowerCatalyst":
                        Supplement powerSup = new PowerCatalyst();
                        targetUnit.AddSupplement(powerSup);
                        break;

                    case "HealthCatalyst":
                        Supplement healthSup = new HealthCatalyst();
                        targetUnit.AddSupplement(healthSup);
                        break;

                    case "AggressionCatalyst":
                        Supplement aggressSup = new AggressionCatalyst();
                        targetUnit.AddSupplement(aggressSup);
                        break;

                    case "Weapon":
                        Supplement weapSup = new Weapon();
                        targetUnit.AddSupplement(weapSup);
                        break;
                }
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Attack:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);

                    targetUnit.DecreaseBaseHealth(interaction.SourceUnit.Power);
                    break;

                case InteractionType.Infest:
                    Unit infestUnit = this.GetUnit(interaction.TargetUnit);

                    if (InfestationRequirements.RequiredClassificationToInfest(infestUnit.UnitClassification)
                       == interaction.SourceUnit.UnitClassification)
                    {
                        infestUnit.AddSupplement(new InfestationSpores());
                    }

                    break;

                default:
                    break;
            }
        }
    }
}
