using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Last_Army.Entities;
using Last_Army.Entities.Mission;
using Last_Army.Factory;
using Last_Army.Interfaces;

namespace Last_Army.Core
{
    public class GameController
    {
        private MissionController missionControllerField;
        private IArmy army;
        private IWareHouse wareHouse;
        private SoldiersFactory soldiersFactory;
        private AmmunitionFactory ammunitionFactory;
        private MissionFactory missionFactory;
        private SoldierController soldierController;
        private StringBuilder result;
        private Output output;

        private const string suffix = "Command";
        
        public GameController()
        {
            this.wareHouse = new WareHouse();
            this.army = new Army(this.WareHouse);
            this.soldiersFactory = new SoldiersFactory();
            this.ammunitionFactory = new AmmunitionFactory();
            this.missionFactory = new MissionFactory();
            this.soldierController = new SoldierController(this.Army, this.WareHouse);
            this.MissionControllerField = new MissionController(this.Army, this.WareHouse);
            this.result = new StringBuilder();
            this.output = new Output(this.Army, this.WareHouse, result);
        }

        public IArmy Army
        {
            get { return army; }
            set { army = value; }
        }

        public IWareHouse WareHouse
        {
            get { return wareHouse; }
            set { wareHouse = value; }
        }

        public MissionController MissionControllerField
        {
            get { return missionControllerField; }
            set { missionControllerField = value; }
        }

        public void GiveInputToGameController(string input)
        {
            var data = input.Split();

            string commandName = data[0] + suffix;
            if (data[1] == "Regenerate")
            {
                commandName = data[1] + suffix;

            }
            string[] parameters = data.Skip(1).ToArray();

           this
                .GetType()
                .GetMethod(commandName, BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(this, new object[]{parameters});
        }

        public string RequestResult(string addedResult)
        {
            this.MissionControllerField.FailMissionsOnHold();
            return output.GiveOutput(addedResult, this.missionControllerField.FailedMissionCounter, this.missionControllerField.SuccessMissionCounter);
        }

        private void SoldierCommand(string[] data)
        {
            ISoldier soldier = soldiersFactory.CreateSoldier(data);
            this.army.AddSoldier(soldier, result);
        }

        private void RegenerateCommand(string[] data)
        {
            soldierController.TeamRegenerate(data[1]);
        }

        private void WareHouseCommand(string[] data)
        {
            string name = data[0];
            int number = int.Parse(data[1]);
            this.WareHouse.AddAmmunition(name, number);
        }

        private void MissionCommand(string[] data)
        {
            var mission = missionFactory.CreateMission(data[0], double.Parse(data[1]));
            result.AppendLine(this.MissionControllerField.PerformMission(mission).Trim());
        }
    }
}