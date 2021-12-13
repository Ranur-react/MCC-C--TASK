using System;
using System.Collections.Generic;

namespace Manajemen_Kasir_MCC_Ranur

{
    class Program
    {
        public static string[] listMenu = new string[3] { "Input Produk", "Jual Produk", "Exit" };
        public static List<string> product_name = new List<string>();
        public static List<Double> product_price = new List<Double>();
        public static List<int> product_stock = new List<int>();
        public static List<int> kode_jual = new List<int>();
        public static List<int> qty_jual = new List<int>();
        public static List<Double> bayar_jual = new List<Double>();
        static void Main(string[] args)
        {
            Console.WriteLine("--Start Session\n\n");
            MainMenu();
            Console.WriteLine("\n\n--End Sessions---");

        }

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
            int Index = 0;
            String decodeStringMenu = "";


            Console.WriteLine("======================" + AppTitle + "=====================\n");
            foreach (String i in listMenu)
            {
                Index++;
                decodeStringMenu += " " + i + " (" + Index + ")|";
                ;
            }
            Console.WriteLine("____________________________________________________________________\n");
            Console.WriteLine("MENU: | " + decodeStringMenu);
            Console.WriteLine("____________________________________________________________________\n");
            Console.WriteLine("Pres Key Number 1 -" + Index + " to select Menu || press Q for Exit Sessions\n\n");
            Console.Write("Menu: ");
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
                         Console.WriteLine("Aplikasi Akana keluar dengan Sendirinya");
                        state = false;
                        break;
                }
            }

            return state;

        }

        private static void JualProduk()
        {
            FormJualProduk();


            /* Console.WriteLine("\n\n");
             Console.WriteLine("Pilih Produk yang mau kamu Jual:\n");
             ExtrakListProduk();*/
        }
        static void FormJualProduk()
        {
            Console.WriteLine("____________________________________________________________________\n");
            Console.WriteLine("Kamu Memilih Menu Jual Produk");
            Console.WriteLine("____________________________________________________________________\n");

            bool terusInput = true;
            while (terusInput)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Product Available List:\n");
                ExtrakListProduk();
                String[] List_Form = { "No/Code Product Selected", "Qty Produk", "pay value " };
                int kode = 0;
                int qty = 0;
                Double bayar = 0;

                int index = 0;
                int dataKe = 0;
                string get = "";

                Console.WriteLine("\t Purchase order  " + product_name.Count + ".th");
                foreach (var item in List_Form)
                {
                    Console.Write("Entry " + item + " \t:");
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
                                kode = Convert.ToInt32(get) - 1;
                                break;
                            case 1:
                                qty = Convert.ToInt32(get);
                                double ammount = product_price[kode] * qty;
                                Console.WriteLine("");
                                Console.WriteLine("Total Harga : $" + ammount);

                                break;
                            case 2:
                                kode_jual.Add(kode);
                                qty_jual.Add(qty);
                                bayar_jual.Add(Convert.ToInt32(get));
                                Console.WriteLine("____________");
                                product_stock[kode] = product_stock[kode] - qty;
                                double kembalian = bayar_jual[dataKe] - (product_price[kode] * qty);

                                Console.WriteLine("Kembalian : $" + kembalian);
                                Console.WriteLine("----------------------------------");

                                break;
                        }

                    }
                    index++;
                }
                dataKe++;
                index = 0;
            }
            Console.WriteLine("return to menu . .\n\n\n");


        }
        private static void ExtrakListProduk()
        {
            int no = 0;
            for (int i = 0; i < product_name.Count; i++)
            {
                no++;
                Console.WriteLine("" + no + ". " + product_name[i] + "\n\t ~ Price : $" + product_price[i] + " \n [" + product_stock[i] + "] stock left");
                Console.WriteLine("");
            }
        }

        private static void TampilkanHasilInput()
        {
            Console.WriteLine("____________________________________________________________________\n");

            Console.WriteLine("List Produk:");
            int no = 0;
            for (int i = 0; i < product_name.Count; i++)
            {
                no++;
                Console.WriteLine("" + no + ". " + product_name[i]);
                Console.WriteLine("\t -Stock " + product_stock[i] + " item");
                Console.WriteLine("\t -price $" + product_price[i]);
                Console.WriteLine("");
            }
            Console.WriteLine("____________________________________________________________________\n");

        }

        static void InputProduk()
        {
            Console.WriteLine("____________________________________________________________________\n");
            Console.WriteLine("Kamu Memilih Menu Input Produk");
            Console.WriteLine("____________________________________________________________________\n");

            bool terusInput = true;
            while (terusInput)
            {
                String[] List_Form = { "Nama", "Harga", "Stock" };
                String name = "";
                Double price = 0;
                int stock = 0;

                int index = 0;
                int dataKe = 0;
                string get = "";
                dataKe++;
                Console.WriteLine("\t Data Ke [" + product_name.Count + "]");
                foreach (var item in List_Form)
                {
                    Console.Write("Masukan " + item + " Produk \t:");
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

    }
}
