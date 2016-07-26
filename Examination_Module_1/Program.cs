using System;

namespace Examination_Module_1
{
    class Program
    {
        static void Main(string[] args)
        {
            String _sActionInput, _sQuantityInput, _sDiscountInput, _sKeyCharacter;
            Int32 _iAction = 0;
            Decimal _dQuantity, _dDiscount;
            Product product;

            ProductList.CreateFooList();

            ShoppingCart shoppingCart = new ShoppingCart();

            Console.WriteLine("Choose products you want to by (enter a corresponding number):\n");
            ProductList.Print();
            Int32 _iCheckoutNumber = ProductList.GetProductsCount() + 1;
            Console.WriteLine("\n{0,2}. Checkout", _iCheckoutNumber);
            Console.WriteLine(new String('-', 30));

            while (true)
            {
                Console.Write("Enter a number (1 - {0}): ", _iCheckoutNumber);
                _sActionInput = Console.ReadLine();
                if (Int32.TryParse(_sActionInput, out _iAction) && _iAction > 0 && _iAction <= _iCheckoutNumber)
                {
                    if (_iAction == _iCheckoutNumber)
                    {
                        break;
                    }
                    else
                    {
                        product = ProductList.GetProductByIndex(_iAction - 1);
                        if (product != null)
                        {
                            Console.Write("Product: {0,-10}\tQuantity: ", product.Name);
                            _sQuantityInput = Console.ReadLine();
                            if (Decimal.TryParse(_sQuantityInput, out _dQuantity))
                            {
                                try
                                {
                                    shoppingCart.AddItem(product, _dQuantity);
                                    Console.WriteLine("You have {0} item(s) in your cart. Total is {1:N2}",
                                        shoppingCart.GetItemsCount(), shoppingCart.GetTotal());
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong input. Please enter a decimal number for the product's quantity.");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input. Please enter a number corresponding to a list item.");
                }
            }
            if (shoppingCart.GetItemsCount() > 0)
            {
                Console.Write("\nDo you have a discount (y/n): ");
                _sKeyCharacter = Console.ReadLine();
                if (_sKeyCharacter[0] == 'y' || _sKeyCharacter[0] == 'Y')
                {
                    Console.Write("Enter a value of discount (percentage): ");
                    _sDiscountInput = Console.ReadLine();
                    if (Decimal.TryParse(_sDiscountInput, out _dDiscount))
                    {
                        if (_dDiscount >= 0 && _dDiscount < 100)
                        {
                            shoppingCart.Discount = _dDiscount;
                        }
                    }
                }
                shoppingCart.Print();
            }
            Console.WriteLine("Bye!");
            Console.ReadKey();
        }
    }
}
