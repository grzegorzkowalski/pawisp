using WarriorBuilder;
using WarriorFactory;

var post = new WarriorPost();

var pB = new PiechurBuilder("Jan", 18);
post.WarriorPostassembly(pB);
Console.WriteLine(pB.Warrior.GetType());

var pK = new KonnyBuilder("Tomasz", 20);
post.WarriorPostassembly(pK);
Console.WriteLine(pK.Warrior.GetType());

var pS = new StrzelecBuilder("Mateusz", 24);
post.WarriorPostassembly(pS);
Console.WriteLine(pS.Warrior.GetType());

List<IWarrior> nowaArmia = new();

nowaArmia.Add(pB.Warrior);
nowaArmia.Add(pK.Warrior);
nowaArmia.Add(pS.Warrior);

foreach (var item in nowaArmia)
{
    Console.WriteLine($"Cześć mam na imię {item.Name} i moja specjalność to {item.GetType()}");
}
