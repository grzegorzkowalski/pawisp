using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public sealed class GildedRoseTest
{
    [Test]
    public void Normal_item_decreases_quality_and_sell_in()
    {
        var items = new List<Item> { new() { Name = "Normal Item", SellIn = 10, Quality = 20 } };

        new GildedRose(items).UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(19));
        Assert.That(items[0].SellIn, Is.EqualTo(9));
    }

    [Test]
    public void Aged_brie_does_not_exceed_quality_50()
    {
        var items = new List<Item> { new() { Name = "Aged Brie", SellIn = 10, Quality = 50 } };

        new GildedRose(items).UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    [Test]
    public void Backstage_pass_increases_by_two_when_ten_days_or_less_remain()
    {
        var items = new List<Item>
        {
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 }
        };

        new GildedRose(items).UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(22));
        Assert.That(items[0].SellIn, Is.EqualTo(9));
    }

    [Test]
    public void Backstage_pass_drops_to_zero_after_concert()
    {
        var items = new List<Item>
        {
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 }
        };

        new GildedRose(items).UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(0));
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
    }

    [Test]
    public void Sulfuras_does_not_change()
    {
        var items = new List<Item>
        {
            new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 }
        };

        new GildedRose(items).UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(80));
        Assert.That(items[0].SellIn, Is.EqualTo(5));
    }

    [Test]
    public void Conjured_item_is_currently_a_characterization_gap()
    {
        var items = new List<Item>
        {
            new() { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
        };

        new GildedRose(items).UpdateQuality();

        // Aktualne zachowanie startera. Właściwa reguła Conjured ma zostać
        // dopisana podczas refaktoryzacji, a test powinien wtedy zmienić oczekiwanie.
        Assert.That(items[0].Quality, Is.EqualTo(5));
    }
}
