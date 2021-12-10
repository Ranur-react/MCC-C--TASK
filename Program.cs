using System;
using System.Collections.Generic;

namespace Manajemen_Kasir_MCC_Ranur

{
    class Program
    {
        public static string[] listMenu = new string[3] { "Input Produk", "Jual Produk", "Exit" };
        public static List<string> product_name=new List<string>();
        public static List<Double> product_price = new List<Double>();
        public static List<int> product_stock = new List<int>();
        static void Main(string[] args)
        {
           
            //Panggil Methode Menu
            ShowMenu("EASY SHOP CHASIER APP");
            //panggil Methode Input
                InputProduk();
                TampilkanHasilInput();
            //panggil methode footer menu

        }

        private static void TampilkanHasilInput()
        {
            Console.WriteLine("List Produk:");
            int no = 0;
            for (int i = 0; i < product_name.Count; i++) {
                no++;
                Console.WriteLine(""+no+". "+product_name[i]);
                Console.WriteLine("\t -Stock " + product_stock[i]+" item");
                Console.WriteLine("\t -price $" + product_price[i]);
                Console.WriteLine("");
            }
        }

        static void InputProduk()
        {
            bool terusInput = true;
            while (terusInput) {
                String[] List_Form = { "Nama", "Harga", "Stock" };
                String name="";
                Double price=0;
                int stock=0;

                int index = 0;
                int dataKe = 0;
                string get = "";
                dataKe++;
                Console.WriteLine("\t Data Ke [" + product_name.Count + "]");
                foreach (var item in List_Form)
                {
                    Console.Write("Masukan " + item + " Produk \t:");
                    get = Console.ReadLine();
                    if (get=="Q"||get =="q")
                    {
                        terusInput = false;
                        Console.WriteLine("End Input");
                        break;
                    }
                    else {
                        switch (index)
                        {
                            case 0:
                                name = get;
                                break;
                            case 1:
                                price = Convert.ToDouble(get);
                                break;
                            case 2:
                                product_name.Add(name);
                                product_price.Add(price);
                                product_stock.Add(Convert.ToInt32(get));
                                break;
                        }
                    }
                    index++;
                }
                index = 0;
            }
            Console.WriteLine("return to menu . .\n\n\n");


        }
        public static void ShowMenu(string AppTitle)
        {
            Console.WriteLine("======================"+AppTitle+"=====================");
            Console.WriteLine("");
            //tes
            String decodeStringMenu = "";
            int Index = 0;
            foreach (String i in listMenu) {
                Index++;
                decodeStringMenu +=" "+i+" ("+Index+")|";
                ;
            }
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine("MENU: | "+decodeStringMenu);
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine("");
            Console.WriteLine("Pres Key Number 1 -"+Index+" to select Menu || press Q for Exit Sessions");

        }
    }
}
