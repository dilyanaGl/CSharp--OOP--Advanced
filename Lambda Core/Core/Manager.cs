using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LambdaCore_Skeleton.Contracts;

namespace LambdaCore_Skeleton.Core
{
    public class Manager
    {
        private const string successCoreCreation = "Successfully created Core {0}!";
        private const string failCoreCreation = "Failed to create Core!";
        private const string successCoreRemoval = "Successfully removed Core {0}!";
        private const string failedCoreRemoval = "Failed to remove Core {0}!";
        private const string successCoreSelection = "Currently selected Core {0}!";
        private const string failedCoreSelection = "Failed to select Core {0}!";
        private const string successCoreAttachment = "Successfully attached Fragment {0} to Core {1}!";
        private const string failedCoreAttachment = "Failed to attach Fragment {0}!";

        private const string successCoreDetachment =
            "Successfully detached Fragment {0} from Core {1}!";

        private const string failedCoreDetachment = "Failed to detach Fragment!";
        const char startLetter = 'A';
        private const string fragmentSuffix = "Fragment";
        private const string coreSuffix = "Core";
        private ICore currentlySelectedCore;

        private List<ICore> plants;

        public Manager()
        {
            this.plants = new List<ICore>();
            this.currentlySelectedCore = default(ICore);
        }

        public int FragmentsCount { get => this.plants.Select(p => p.Fragments.Count()).Sum(); }
        public int TotalDurability { get => this.plants.Select(p => p.Durability).Sum(); }
        public int PlantsCount
        {
            get => this.plants.Count;
        }

        public string CreateCore(string type, int durability)
        {
            try
            {
                string plantTypeName = type + coreSuffix;
                var clazz = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(p => p.Name == plantTypeName);
                char name = (char) (startLetter + this.plants.Count);
                object[] ctorParams = new object[] {name, durability};
                var ctor = clazz.GetConstructors()[0];
                ICore core = (ICore) ctor.Invoke(ctorParams);
                plants.Add(core);
                return String.Format(successCoreCreation, name);
            }
            catch (Exception ex)
            {
                return String.Format(failCoreCreation);
            }
        }

        public string RemoveCore(string name)
        {
            try
            {
                var core = this.plants.FirstOrDefault(p => p.Letter == name[0]);
                this.plants.Remove(core);
                if (this.currentlySelectedCore.Letter == name[0])
                {
                    this.currentlySelectedCore = default(ICore);
                }
                return String.Format(successCoreRemoval, core.Letter);

            }
            catch (Exception ex)
            {
                return String.Format(failedCoreRemoval, name);
            }
        }

        public string SelectCore(string name)
        {
            try
            {
                this.currentlySelectedCore = plants.FirstOrDefault(p => p.Letter == name[0]);
                
                return String.Format(successCoreSelection, name);
            }
            catch
            {
                return String.Format(failedCoreSelection, name);
            }
        }

        public string AttachFragment(string type, string name, int pressureAffection)
        {
            try
            {
                var fragmentClassName = type + fragmentSuffix;
                var clazz = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(p => p.Name == fragmentClassName);
                var ctorParams = new object[] { name, pressureAffection};
                var ctor = clazz.GetConstructors()[0];
                var fragment = (IFragment)ctor.Invoke(ctorParams);
                this.currentlySelectedCore.Fragments.Push(fragment);
                this.currentlySelectedCore.CheckPressure();

                return String.Format(successCoreAttachment, name, this.currentlySelectedCore.Letter);
            }
            catch (Exception ex)
            {
                return String.Format(failedCoreAttachment, name);
            }
        }

        public string DetachFragment()
        {
            try
            {
                IFragment fragment = this.currentlySelectedCore.Fragments.Peek();
                this.currentlySelectedCore.Fragments.Pop();
               this.currentlySelectedCore.CheckPressure();
                return String.Format(successCoreDetachment,  fragment.Name, currentlySelectedCore.Letter);
            }
            catch (Exception ex)
            {
                return String.Format(failedCoreDetachment);
            }
        }

        public string Status()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Lambda Core Power Plant Status:");
            sb.AppendLine($"Total Durability: {TotalDurability}");
            sb.AppendLine($"Total Cores: {PlantsCount}");
            sb.AppendLine($"Total Fragments: {FragmentsCount}");
            this.plants.ForEach(p => sb.AppendLine(p.ToString()));
            return sb.ToString().Trim();
        }
    }
}
