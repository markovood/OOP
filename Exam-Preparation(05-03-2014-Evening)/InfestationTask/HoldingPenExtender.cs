using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class HoldingPenExtender : HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            ISupplement supplement;
            switch (commandWords[1])
            {
                case "PowerCatalyst":
                    supplement = new PowerCatalyst();
                    this.GetUnit(commandWords[2]).AddSupplement(supplement);
                    break;
                case "HealthCatalyst":
                    supplement = new HealthCatalyst();
                    this.GetUnit(commandWords[2]).AddSupplement(supplement);
                    break;
                case "AggressionCatalyst":
                    supplement = new AggressionCatalyst();
                    this.GetUnit(commandWords[2]).AddSupplement(supplement);
                    break;
                case "Weapon":
                    supplement = new Weapon();
                    this.GetUnit(commandWords[2]).AddSupplement(supplement);
                    break;
                default:
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    Unit target = this.GetUnit(interaction.TargetUnit);
                    if (interaction.SourceUnit.UnitClassification == InfestationRequirements.RequiredClassificationToInfest(target.UnitClassification))
                    {
                        target.AddSupplement(new InfestationSpores());
                    }

                    break;
                default:
                    base.ExecuteProceedSingleIterationCommand();
                    break;
            }
        }
    }
}
