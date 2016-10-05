using System;

namespace Bangazon.Customers
{
  public class Customer
  {
    public string firstName { get; set; }
    public string lastName { get; set; }

    public void greet() 
    {
      //VOID MEANS NO RETURN
      Console.WriteLine($"Welcome {this.firstName} {this.lastName}!");
    }
  }
}