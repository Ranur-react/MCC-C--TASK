using System;
using System.Collections.Generic;

namespace ManajemenKasirMccRanur

{
    class _Program
    {
        public static string[] listMenu = new string[3] { "Entry Product", "Order Product", "Exit" };
        public static List<string> productName = new List<string>();
        public static List<Double> productPrice = new List<Double>();
        public static List<int> productStock = new List<int>();
        public static List<int> orderCode = new List<int>();
        public static List<int> orderQty = new List<int>();
        public static List<Double> orderPayCost = new List<Double>();
 /*       static void Main(string[] args)
        {
            //MainMenu();
            //new ProgramLayout();
        }*/

        private static void MainMenu()
        {
            bool loopState = true;
            while (loopState)
            {
                //Panggil Methode Menu
                loopState = ShowMenu("EASY SHOP CHASIER APP");
            }
            Console.WriteLine("Stop App");

        }
        public static bool ShowMenu(string AppTitle)
        {
            bool state = true;
            int index = 0;
            String decodeStringMenu = "";


            Console.WriteLine($"=============================================================\n");
            Console.WriteLine($"\t\t{AppTitle}");
            Console.WriteLine($"=============================================================\n");
            foreach (String i in listMenu)
            {
                index++;
                decodeStringMenu += $" {i} ({index})|";
                ;
            }
            Console.WriteLine($"Menu: | {decodeStringMenu}");
            Console.WriteLine("_____________________________________________________________\n");
            Console.WriteLine($"|Pres Key Number 1 -{index} to select Menu \n| press Q for Exit Sessions\n\n");
            Console.Write("Select Menu: ");
            String options = Console.ReadLine();
            if (options == "Q" || options == "q")
            {
                Console.WriteLine("Quit press");
                state = false;
                return state;

            }
            else
            {
                switch (Convert.ToInt32(options))
                {
                    case 1:
                        /*Input Produk*/
                         //panggil Methode Input
                         InputProduk();
                        TampilkanHasilInput();
                        //panggil methode footer menu
                        break;
                    case 2:
                        /*Jual Produk*/
                         JualProduk();
                        break;
                    default:
                        /*exit*/
                         Console.WriteLine("Exit From App . . .");
                        state = false;
                        break;
                }
            }

            return state;

        }

        private static void JualProduk()
        {
            FormJualProduk();
        }
        //ini dokumentasi form jual profuk
        static void FormJualProduk()
        {
            Console.WriteLine("_____________________________________________________________\n");
            Console.WriteLine("\t\t~Product Order Selected ~");
            Console.WriteLine("_____________________________________________________________\n");


            bool terusInput = true;
            while (terusInput)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Product Available List:\n");
                ExtrakListProduk();
                String[] listForm = { "No/Code Product Selected", "Qty Product", "Pay value " };
                int kode = 0;
                int qty = 0;
                Double bayar = 0;

                int dataKe = 0;
                string get = "";

                Console.WriteLine($"\t Purchase order  {productName.Count}.th");
                for (int index = 0; index < listForm.Length; index++)
                {
                    //pseudocode - Input

                    Console.Write($"Entry {listForm[index]} \t:");

                    get = Console.ReadLine();
                    if (get == "Q" || get == "q")
                    {
                        terusInput = false;
                        Console.WriteLine("End Input");
                        break;
                    }
                    else
                    {
                        switch (index)
                        {
                            case 0:
                                try
                                {
                                    kode = Convert.ToInt32(get) - 1;

                                }
                                catch (FormatException e)
                                {

                                    Console.WriteLine($"\t\t{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    Console.WriteLine($"Eror Exception: {e.Message}");
                                    Console.WriteLine("");
                                    index -= 1;
                                }
                                catch (Exception e) {
                                    Console.WriteLine($"\t\t{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    Console.WriteLine($"Eror Exception: {e.Message}");
                                    Console.WriteLine("");
                                    index -= 1;
                                }
                                break;
                            case 1:
                               
                                try
                                {
                                    qty = Convert.ToInt32(get);
                                    double ammount = productPrice[kode] * qty;
                                    Console.WriteLine("");
                                    Console.WriteLine($"Order Ammount : ${ammount}");
                                }
                                catch (FormatException e)
                                {

                                    Console.WriteLine($"\t\t{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    Console.WriteLine($"Eror Exception: {e.Message}");
                                    Console.WriteLine("");
                                    index -= 1;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"\t\t{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    Console.WriteLine($"Eror Exception: {e.Message}");
                                    Console.WriteLine("");
                                    index -= 1;
                                }

                                break;
                            case 2:
                                try
                                {
                                    orderCode.Add(kode);
                                    orderQty.Add(qty);
                                    orderPayCost.Add(Convert.ToInt32(get));
                                    Console.WriteLine("_____________________________________________________________\n");

                                    productStock[kode] = productStock[kode] - qty;
                                    //pseudocode - Process
                                    double kembalian = orderPayCost[dataKe] - (productPrice[kode] * qty);
                                    //pseudocode - Output
                                    Console.WriteLine($"Returned : ${kembalian}");
                                    Console.WriteLine("----------------------------------\n\n");
                                }
                                catch (FormatException e)
                                {

                                    Console.WriteLine($"\t\t{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    Console.WriteLine($"Eror Exception: {e.Message}");
                                    Console.WriteLine("");
                                    index -= 1;
                                }
                                catch (Exception e)
                                {

                                    Console.WriteLine($"\t\t{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    Console.WriteLine($"Eror Exception: {e.Message}");
                                    Console.WriteLine("");
                                    index -= 1;
                                }
                               

                                break;
                        }

                    }
                }
                dataKe++;
            }
            Console.WriteLine("Back to menu . .\n\n\n");



        }
        private static void ExtrakListProduk()
        {
            int no = 0;
            for (int i = 0; i < productName.Count; i++)
            {
                no++;
                Console.WriteLine($"{no}. {productName[i] }\n\t ~ Price : ${productPrice[i]} \n [{productStock[i]}] stock left");
                Console.WriteLine("");
            }
        }

        private static void TampilkanHasilInput()
        {
            Console.WriteLine("_____________________________________________________________\n");
            Console.WriteLine("Product List:");
            int no = 0;
            for (int i = 0; i < productName.Count; i++)
            {
                no++;
                Console.WriteLine($"{no}. { productName[i]}");
                Console.WriteLine($"\t -Stock {productStock[i]} item");
                Console.WriteLine($"\t -Price ${productPrice[i]}");
                Console.WriteLine("");
            }
            Console.WriteLine("_____________________________________________________________\n");

        }

        static void InputProduk()
        {
            Console.WriteLine("_____________________________________________________________\n");
            Console.WriteLine("\t\t~Product Entry Selected ~");
            Console.WriteLine("_____________________________________________________________\n");
            bool terusInput = true;
            while (terusInput)
            {
                String[] listForm = { "Name", "Price", "Stock" };
                String name = "";
                Double price = 0;
                int stock = 0;

                /*int index = 0;*/
                int dataKe = 0;
                string get = "";
                dataKe++;
                Console.WriteLine($"\t [{productName.Count}] th Product Entry");
                
                    for(int index = 0; index < listForm.Length; index++)
                {
                    Console.Write($"Enter Product {listForm[index]}  \t:");
                    get = Console.ReadLine();
                    /*if (get == "Q" || get == "q")*/
                        /*if (get.ToLower() =="q")*/
                    if (get.Equals("q",StringComparison.OrdinalIgnoreCase))
                    {
                        terusInput = false;
                        Console.WriteLine("End Input");
                        break;
                    }
                    else
                    {
                        switch (index)
                        {
                            case 0:
                                name = get;
                                break;
                            case 1:

                                try
                                {
                                    price = Convert.ToDouble(get);
                                }
                                catch (FormatException e) {
                                    Console.WriteLine($"\t\t{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    Console.WriteLine($"Eror Exception: {e.Message}");
                                    Console.WriteLine("");
                                    index -= 1;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"\t\t{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    Console.WriteLine($"Eror Exception: {e.Message}");
                                    Console.WriteLine("");
                                    index -= 1;
                                }
                                break;
                            case 2:
                                try
                                {
                                    productName.Add(name);
                                    productPrice.Add(price);
                                    productStock.Add(Convert.ToInt32(get));
                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine($"\t\t{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    Console.WriteLine($"Eror Exception: {e.Message}");
                                    Console.WriteLine("");
                                    index -= 1;
                                }
                                catch (Exception e)
                                {

                                    Console.WriteLine($"\t\t{get} Wrong typing !! ~ {listForm[index]} it must number as money type");
                                    Console.WriteLine($"Error Exception: {e.Message}");
                                    Console.WriteLine("");
                                    index -= 1;
                                }

                                break;
                        }
                    }
                    //index++;
                }
               // index = 0;
            }
            Console.WriteLine("return to menu . .\n\n\n");


        }

    }
}
