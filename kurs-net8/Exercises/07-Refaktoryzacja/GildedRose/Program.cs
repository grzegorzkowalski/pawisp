using GildedRoseKata;

var items = new List<Item>
{
    new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
    new() { Name = "Aged Brie", SellIn = 2, Quality = 0 },
    new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
    new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 },
    new() { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
};

new GildedRose(items).UpdateQuality();
foreach (var item in items)
{
    Console.WriteLine($"{item.Name}, {item.SellIn}, {item.Quality}");
}
