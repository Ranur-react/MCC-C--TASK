using System;
using System.Collections.Generic;
using System.Text;

namespace ManajemenKasirMccRanur
{
    public class ProgramInput
    {
        public static int InputIndex { get; set; }
        public static int Limite { get; set; }
        private static List<ProgramInputProduct> product =new List<ProgramInputProduct>();
        public static Display print = new Display(60, "left", "space");
        static String[] listForm = { "Name Product", "Price Product", "Stock Product" };

        public ProgramInput() {
            InputIndex = 0;
            Limite = 1;
            InputOptions();
        }

        public ProgramInput(int inputIndex, int limite)
        {
            InputIndex = inputIndex;
            Limite = limite;
            InputOptions();
        }

        public ProgramInput(int inputIndex)
        {
            InputIndex = inputIndex;
            InputOptions();
        }
        public static void InputOptions() {
            switch (InputIndex)
            {
                case 0:
                    //inputproduk
                    for (int i = 0; i < Limite; i++)
                    {
                        if (EntryProduct()) {
                            break;
                        }
                    }
                    ShowUpList(0,"Product List :");
                    break;
                default:
                    //inputjual
                    break;
            }
        }



        public static bool EntryProduct()
        {
            bool statet = false;
            String name = "";
            Double price = 0;
            int stock = 0;
            for (int i = 0; i < Limite; i++)
            {
                for (int index = 0; index < listForm.Length ; index++) {
                    bool rentry = false;
                    String get = "";
                        try
                        {
                            Console.Write($"\nInput {listForm[index]}  :");
                            get = Console.ReadLine();
                            if (get.ToLower() == "q")
                            {
                                print.Content("Process was stoped");
                                statet = true;
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

                                    catch (Exception e)
                                    {
                                        ExecptionsMessages(get,listForm[index],e);
                                        index -= 1;
                                    }
                                    break;
                                case 2:
                                    try
                                    {
                                        InsertProduct(name,price,Convert.ToInt32(get));
                                    }

                                    catch (Exception e)
                                    {
                                        ExecptionsMessages(get, listForm[index], e);
                                        index -= 1;
                                    }

                                    break;
                            }
                        }

                    }
                        catch (FormatException e)
                        {
                        Console.WriteLine("");
                        Console.WriteLine("\t\t ! ~Erros Messages " + e.Message);
                            rentry = true;
                        }
                   
                }
                if (statet) {
                    break;
                }
            }
            statet = true;
            return statet;

        }

        private static void InsertProduct(string name, double price, int stock)
        {
        ProgramInputProduct inProduct = new ProgramInputProduct();
            inProduct.productName = name;
            inProduct.productPrice = price;
            inProduct.productStock = stock;
            product.Add(inProduct);
        }
        private static void ShowUpList(int menu,string title)
        {
            switch (menu)
            {
                case 0:
                    ExtrakData(product, title);
                    break;
                default:
                    //extrak data order
                    break;
            }
      
        }

        private static void ExtrakData(List<ProgramInputProduct> v, String title)
        {
            print.Box("");
            print.Content(title);
            for (int i = 0; i < product.Count; i++)
            {
                product[i].DisplayProduct(i+1); 
            }
        }

        private static void ExecptionsMessages(string get, string v, Exception e)
        {
            Console.WriteLine("");
            Console.WriteLine($"{get} Wrong typing !! ~ {v} it must a number type");
            Console.WriteLine($"Eror Exception: {e.Message}");
            Console.WriteLine("");
        }
    }
}
