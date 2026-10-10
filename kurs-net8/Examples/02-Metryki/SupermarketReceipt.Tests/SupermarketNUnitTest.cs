using System.Collections.Generic;
using NUnit;
using NUnit.Framework;

namespace SupermarketReceipt.Test
{
    public class SupermarketNUnitTest
    {
        [TestCase]
        public void TenPercentDiscount()
        {
            // ARRANGE
            SupermarketCatalog catalog = new FakeCatalog();
            var toothbrush = new Product("toothbrush", ProductUnit.Each);
            catalog.AddProduct(toothbrush, 0.99);
            var apples = new Product("apples", ProductUnit.Kilo);
            catalog.AddProduct(apples, 1.99);

            var cart = new ShoppingCart();
            cart.AddItemQuantity(apples, 2.5);

            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TenPercentDiscount, toothbrush, 10.0);

            // ACT
            var receipt = teller.ChecksOutArticlesFrom(cart);

            // ASSERT
            NUnit.Framework.Assert.AreEqual(4.975, receipt.GetTotalPrice());
            NUnit.Framework.CollectionAssert.IsEmpty(receipt.GetDiscounts());
            NUnit.Framework.Assert.AreEqual(1, receipt.GetItems().Count);
            var receiptItem = receipt.GetItems()[0];
            NUnit.Framework.Assert.AreEqual(apples, receiptItem.Product);
            NUnit.Framework.Assert.AreEqual(1.99, receiptItem.Price);
            NUnit.Framework.Assert.AreEqual(2.5 * 1.99, receiptItem.TotalPrice);
            NUnit.Framework.Assert.AreEqual(2.5, receiptItem.Quantity);
        }
    }
}
