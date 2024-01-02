using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inventory_Management.Models
{
    public class Inventory
    {
        List<Item> items = new List<Item>();



        /// <summary>
        /// Добавление товара
        /// </summary>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <exception cref="ArgumentException"></exception>

        public void AddItem(string name, int quantity, decimal price)
        {
            if (quantity < 0 || price < 0)

                throw new ArgumentException("Quantity and price must be non-negative.");


            Item newItem = new Item
            {
                Name = name,
                Quantity = quantity,
                Price = price,
            };

            items.Add(newItem);
        }



        /// <summary>
        /// Удаление товара по названию
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException"></exception>

        public void RemoveItem(string name)
        {
            Item ItemReomove = items.Find(item => item.Name.Equals( name, StringComparison.OrdinalIgnoreCase));

            if (ItemReomove != null)
            {
                items.Remove(ItemReomove);
            }
            else
            {
                throw new ArgumentException("Items not found");
            }
        }



        /// <summary>
        /// Обновление кол-во товара
        /// </summary>
        /// <param name="quantity"></param>
        public void UpgradeItemQuantity(string name, int quantity)
        {
            Item ItemUpdate = items.Find(item => item.Name.Equals( name,StringComparison.OrdinalIgnoreCase));

            if (ItemUpdate != null)
            {
                ItemUpdate.Quantity = quantity;
            }

            else
            {
                throw new ArgumentException("Item not found.");
            }
        }


        /// <summary>
        ///  Расчет общей стоимости инвентаря 
        /// </summary>
        /// <returns></returns>

        public decimal CalcuatingValue()
        {
            decimal totalValue = 0;
            foreach (Item item in items)
            {
                totalValue += item.Quantity * item.Price;

            }
            return totalValue;
        }
         

        /// <summary>
        ///  Вывод в консоль 
        /// </summary>

        public void Display()
        {
            Console.WriteLine("Inventory:");

            foreach (Item item in items)
            {
                Console.WriteLine($"{item.Name} - Quantity: {item.Quantity} - Price:{item.Price:C}");
            }

            Console.WriteLine($"Total Value of Inventory: {CalcuatingValue():C}");
        }
    }
}
