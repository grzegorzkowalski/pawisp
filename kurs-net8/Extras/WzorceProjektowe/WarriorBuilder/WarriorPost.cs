using WarriorFactory;

namespace WarriorBuilder
{
    internal class WarriorPost
    {
        public void WarriorPostassembly(WarriorBuilder warriorBuilder)
        {
            warriorBuilder.goToArmy();
            warriorBuilder.getWeapon();
            warriorBuilder.trainWithWeapon();

        }
    }
}
