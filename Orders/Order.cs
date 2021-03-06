using System;
using System.Collections.Generic;
//list is in this model ^

namespace Bangazon.Orders
{
  public class Order {
    private List<string> _products = new List<string>();
    //private is only accessabile in this class. The underscore is a convention in the C# community. Other devs will know immediately that it's a private variable

    public List<string> products
    {
      get {
        return _products;
      }
    }

    private Guid _orderNumber = System.Guid.NewGuid();
    
    public Guid orderNumber {
      get {
        return _orderNumber;
      }
    }
    public void addProduct(string product)
    {
      _products.Add(product);
    }

    public string listProducts()
    {
      string output = "";

      foreach (string product in _products)
      //iterating over items in a collection as opposed to an array - there is a guarentee of order - dictionary - unordered
      {
        output += $"\nYou ordered {product}";
      }

      return output;
    }

      public bool removeProduct(string product)
      {
          return _products.Remove(product);
      }

      public void removeProduct()
      {
        _products.Clear();
      }
    }
}