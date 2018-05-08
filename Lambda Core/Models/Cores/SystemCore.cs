namespace LambdaCore_Skeleton.Models.Cores
{
    public class SystemCore : BaseCore
    {
        public SystemCore(char letter, int durability) : base(letter, durability)
        {
            this.InitialDurability = this.Durability;
        }
    }
}
