
using Inventory_Management.Models;
Inventory inventory = new Inventory();

inventory.AddItem("item1", 10, 5.99m);
inventory.AddItem("Item2", 5, 8.49m);

// Вывод информации о товарах на складе
inventory.Display();


inventory.UpgradeItemQuantity("Item1", 15);

// Вывод обновленной информации о товарах на складе
inventory.Display();

// Расчет общей стоимости инвентаря
decimal totalValue = inventory.CalcuatingValue();
Console.WriteLine($"Total Value of Inventory: {totalValue:C}");

// Удаление товара
inventory.RemoveItem("Item2");

// Вывод информации после удаления товара
inventory.Display();
