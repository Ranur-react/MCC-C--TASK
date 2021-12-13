using System;
using System.Collections.Generic;

namespace ManajemenKasirMccRanur

{
   public  class ProgramLayout
    {
        public static string[] listMenu = new string[3] { "Input Produk", "Jual Produk", "Exit" };
        public static List<string> productName = new List<string>();
        public static List<Double> productPrice = new List<Double>();
        public static List<int> productStock = new List<int>();
        public static List<int> orderCode = new List<int>();
        public static List<int> orderQty = new List<int>();
        public static List<Double> orderPayCost = new List<Double>();
        public ProgramLayout()
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            bool loopState = true;
            while (loopState)
            {
                //Panggil Methode Menu
                loopState = ShowMenu("EASY SHOP CHASIER APP");
            }
            EachTableLine("Stop App");

        }
        public static bool ShowMenu(string AppTitle)
        {
            bool state = true;
            int index = 0;
            String decodeStringMenu = "";
            EachTableHeader(AppTitle);
            foreach (String i in listMenu)
            {
                index++;
                decodeStringMenu += $" {i} ({index})|";
                ;
            }
            EachTableLine($"MENU: | {decodeStringMenu}");
            EachTableLine($"|Pres Key  1 -{index} to select Menu | press Q for Exit Sessions");

            Console.Write("Select Menu: ");
            String options = Console.ReadLine();
            if (options == "Q" || options == "q")
            {
                EachTableBody("Process was stoped");
                state = false;
                return state;

            }
            else
            {
                switch (Convert.ToInt32(options))
                {
                    case 1:
                        /*Input Produk*/
                        InputProduk();
                        EachTableLine("");
                        TampilkanHasilInput();
                        EachTableLine("");

                        //panggil methode footer menu
                        break;
                    case 2:
                        /*Jual Produk*/
                         JualProduk();
                        break;
                    default:
                        /*exit*/
                        EachTableBody("Exit From App . . .");
                        state = false;
                        break;
                }
            }

            return state;

        }

        private static void EachTableHeader(string v)
        {
            Table tb = new Table();
            tbody tr = new tbody();
            tbodyLine tl = new tbodyLine();
            tbodySpace ts = new tbodySpace();
            tb.setAlign("center");
            tb.setWidth(60);
            tb.fieldHeader(v);
        }
        private static void EachTableLine(string v)
        {
            Table tb = new Table();
            tbody tr = new tbody();
            tbodyLine tl = new tbodyLine();
            tbodySpace ts = new tbodySpace();
            tl.setAlign("center");
            tl.setWidth(60);
            tl.field(v);
        }
        private static void EachTableBody(string v)
        {
            Table tb = new Table();
            tbody tr = new tbody();
            tbodyLine tl = new tbodyLine();
            tbodySpace ts = new tbodySpace();
            ts.setAlign("left");
            ts.setWidth(60);
            ts.field(v);
        }

        private static void JualProduk()
        {
            FormJualProduk();
        }
        static void FormJualProduk()
        {
            bool terusInput = true;
            while (terusInput)
            {
                EachTableBody("Product Available List:");
                ExtrakListProduk();
                EachTableLine("");
                String[] listForm = { "No/Code Product Selected", "Qty Product", "Pay value " };
                int kode = 0;
                int qty = 0;
                Double bayar = 0;

                int dataKe = 0;
                string get = "";

                EachTableBody($" Purchase order  {productName.Count}.th");
                for (int index = 0; index < listForm.Length; index++)
                {
                    //pseudocode - Input

                    EachTableBody($"Entry {listForm[index]} :");

                    get = Console.ReadLine();
                    if (get == "Q" || get == "q")
                    {
                        terusInput = false;
                        EachTableBody("End Input");
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

                                    EachTableBody($"{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    EachTableBody($"Eror Exception: {e.Message}");
                                    EachTableBody("");
                                    index -= 1;
                                }
                                catch (Exception e) {
                                    EachTableBody($"{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    EachTableBody($"Eror Exception: {e.Message}");
                                    EachTableBody("");
                                    index -= 1;
                                }
                                break;
                            case 1:
                               
                                try
                                {
                                    qty = Convert.ToInt32(get);
                                    double ammount = productPrice[kode] * qty;
                                    EachTableBody("");
                                    EachTableBody($"Order Ammount : ${ammount}");
                                }
                                catch (FormatException e)
                                {

                                    EachTableBody($"{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    EachTableBody($"Eror Exception: {e.Message}");
                                    EachTableBody("");
                                    index -= 1;
                                }
                                catch (Exception e)
                                {
                                    EachTableBody($"{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    EachTableBody($"Eror Exception: {e.Message}");
                                    EachTableBody("");
                                    index -= 1;
                                }

                                break;
                            case 2:
                                try
                                {
                                    orderCode.Add(kode);
                                    orderQty.Add(qty);
                                    orderPayCost.Add(Convert.ToInt32(get));

                                    productStock[kode] = productStock[kode] - qty;
                                    //pseudocode - Process
                                    double kembalian = orderPayCost[dataKe] - (productPrice[kode] * qty);
                                    //pseudocode - Output
                                    EachTableBody($"Returned : ${kembalian}");
                                }
                                catch (FormatException e)
                                {

                                    EachTableBody($"{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    EachTableBody($"Eror Exception: {e.Message}");
                                    EachTableBody("");
                                    index -= 1;
                                }
                                catch (Exception e)
                                {

                                    EachTableBody($"{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    EachTableBody($"Eror Exception: {e.Message}");
                                    EachTableBody("");
                                    index -= 1;
                                }
                               

                                break;
                        }

                    }
                }
                dataKe++;
            }
            EachTableBody("Back to menu . .");



        }
        private static void ExtrakListProduk()
        {
            int no = 0;
            for (int i = 0; i < productName.Count; i++)
            {
                no++;
                EachTableBody($"{no}. {productName[i] } ~ Price : ${productPrice[i]}  [{productStock[i]}] stock left");
                EachTableBody("");
            }
        }

        private static void TampilkanHasilInput()
        {
            EachTableBody("Product List:");
            int no = 0;
            for (int i = 0; i < productName.Count; i++)
            {
                no++;
                EachTableBody($"{no}. { productName[i]}");
                EachTableBody($" -Stock {productStock[i]} item");
                EachTableBody($" -price ${productPrice[i]}");
                EachTableBody("");
            }

        }

        static void InputProduk()
        {

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
                EachTableBody($" [{productName.Count}] th Product Entry");
                
                    for(int index = 0; index < listForm.Length; index++)
                {
                    Console.Write($"Enter Product {listForm[index]}  :");
                    get = Console.ReadLine();
                    if (get == "Q" || get == "q")
                    {
                        terusInput = false;
                        EachTableBody("End Input");
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
                                    EachTableBody($"{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    EachTableBody($"Eror Exception: {e.Message}");
                                    EachTableBody("");
                                    index -= 1;
                                }
                                catch (Exception e)
                                {
                                    EachTableBody($"{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    EachTableBody($"Eror Exception: {e.Message}");
                                    EachTableBody("");
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
                                    EachTableBody($"{get} Wrong typing !! ~ {listForm[index]} it must a number type");
                                    EachTableBody($"Eror Exception: {e.Message}");
                                    EachTableBody("");
                                    index -= 1;
                                }
                                catch (Exception e)
                                {

                                    EachTableBody($"{get} Wrong typing !! ~ {listForm[index]} it must number as money type");
                                    EachTableBody($"Error Exception: {e.Message}");
                                    EachTableBody("");
                                    index -= 1;
                                }

                                break;
                        }
                    }
                    //index++;
                }
               // index = 0;
            }
            EachTableBody("return to menu . .");


        }

    }
}
