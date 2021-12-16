using System;
using System.Collections.Generic;
using System.Text;

namespace ManajemenKasirMccRanur
{
   
    public class ProgramInputProduct
    {
        public String productName { get; set; }
        public int productStock { get; set; }
        public double productPrice { get; set; }
        public static Display print = new Display(60, "left", "space");

        public ProgramInputProduct() { 
        
        }
    public ProgramInputProduct(string productName, int productStock, double productPrice)
        {
            this.productName = productName;
            this.productStock = productStock;
            this.productPrice = productPrice;
        }
        public void DisplayProduct() {
            print.Content($"{this.productName} ~ price: {this.productPrice}  Stock: ({this.productStock} Left)");
        }
        public void DisplayProduct(int no)
        {
            print.Content($"[{no}.] {this.productName} ~ price: {this.productPrice}  Stock: ({this.productStock} Left)");
        }
    }
}
