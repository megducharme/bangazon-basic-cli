using Xunit;
using Bangazon.Orders;
using System;
using System.Collections.Generic;

namespace Bangazon.Tests
{
    public class OrderTests
    {
        [Fact]
        public void TestTheTestingFramework()
        {
            Assert.True(true);
        }

        [Fact]
        public void OrdersCanExist()
        {
            Order ord = new Order();
            Assert.NotNull(ord);
        }

        [Fact]
        public void NewOrdersHaveAGuidOfTypeGuid()
        {
            Order ord = new Order();
            Assert.NotNull(ord.orderNumber);
            Assert.IsType<Guid>(ord.orderNumber); 
        }

        [Fact]
        public void NewOrdersShouldHaveAnyEmptyProductListOfStrings()
        {
            Order ord = new Order();
            Assert.NotNull(ord.products);
            Assert.IsType<List<string>>(ord.products);
            Assert.Empty(ord.products);
        }

        [Theory]
        [InlineData("Banana")]
        [InlineDataAttribute("93248932")]
        [InlineDataAttribute("A product with a space")]
        [InlineDataAttribute("Product, that has a comma?")]
        public void OrdersCanHaveAProductsAddedToThem(string product)
        {
            Order ord = new Order();
            ord.addProduct(product);
            Assert.Equal(1, ord.products.Count);
            Assert.Contains<string>(product, ord.products);
        }

        //YOU CANT DO THIS - PASSING IN AN ARRAY
        //YOU CANT DO THIS - PASSING IN AN ARRAY
        //YOU CANT DO THIS - PASSING IN AN ARRAY
        // [Theory]
        // [InlineDataAttribute("Prodct")]
        // [InlineDataAttribute("product", "another product")]
        // [InlineDataAttribute("a first product", "something,yet another")]
        // [InlineDataAttribute("prod 1", "prod 2", "prd 3")]
        // public void OrdersCanHaveMultipleProductsAddedToThem(string[] products)
        // {
        //     Order ord = new Order();
        //     foreach (string product in products)
        //     {
        //         ord.addProduct(product);
        //     }
        //     Assert.Equal(products.Length, ord.products.Count);
        //     foreach (string product in products)
        //     {
        //         Assert.Contains<string>(product, ord.products);
        //     }
        // }

        [Theory]
        [InlineDataAttribute("Prodct")]
        [InlineDataAttribute("product,another product")]
        [InlineDataAttribute("a first product,something,yet another")]
        [InlineDataAttribute("prod 1,prod 2,prod 3")]
        public void OrdersCanHaveMultipleProductsAddedToThem(string productsStr)
        {
            string[] products = productsStr.Split(new char[] { ',' });
             Order ord = new Order();
            foreach (string product in products)
            {
                ord.addProduct(product);
            }
            Assert.Equal(products.Length, ord.products.Count);
            foreach (string product in products)
            {
                Assert.Contains<string>(product, ord.products);
            }
        }

        [Theory]
        [InlineDataAttribute("Prodct")]
        [InlineDataAttribute("product,another product")]
        [InlineDataAttribute("a first product,something,yet another")]
        [InlineDataAttribute("prod 1,prod 2,prod 3")]
        public void OrdersCanHaveMultipleProductsForTerminalDisplay(string productsStr)
        {
            string[] products = productsStr.Split(new char[] { ',' });
             Order ord = new Order();
            foreach (string product in products)
            {
                ord.addProduct(product);
            }
            foreach (string product in products)
            {
                Assert.Contains($"\nYou ordered {product}", ord.listProducts());
            }
        }

        [Fact]
        public void OrdersCanHaveAProductRemovedFromThem()
        {
            Order ord = new Order();
            ord.addProduct("Product");
            ord.addProduct("Banana");
            ord.addProduct("Honeydew Melon");

            ord.removeProduct("Banana");
            
            Assert.Equal(2, ord.products.Count);
            Assert.DoesNotContain<string>("Banana", ord.products);

        }

        [Fact]
        public void OrdersCanNotRemoveAProductThatDoesNotExistFromThem()
        {
            Order ord = new Order();
            ord.addProduct("Product");
            ord.addProduct("Banana");
            ord.addProduct("Honeydew Melon");

            ord.removeProduct("Pineapple");
            
            Assert.Equal(3, ord.products.Count);
        }
        
       [Theory]
       [InlineDataAttribute("Banana")]
       [InlineDataAttribute("Pineapple")]
       public void RemoveMethodReturnsBooleanIndicatingProductWasRemoved(string product)
       {
           Order ord = new Order();
           ord.addProduct("Product");
           ord.addProduct("Banana Bread");
           ord.addProduct("Banana");
           ord.addProduct("Honeydew Melon");

           bool removed = ord.removeProduct(product);

           if (product == "Banana")
           {
               Assert.True(removed);
           }
           if (product == "Pineapple")
           {
               Assert.False(removed);
           }
       }
       [Fact]
       public void AllProductsFromAnOrderCanBeDeleted()
       {
           Order ord = new Order();
           ord.addProduct("Product");
           ord.addProduct("Banana Bread");
           ord.addProduct("Banana");
           ord.addProduct("Honeydew Melon");

           ord.removeProduct();

           Assert.Empty(ord.products);
       }
    }
}