using wt_lab3_3mvc_savostikova.Models;
using wt_lab3_3mvc_savostikova.Views;

namespace wt_lab3_3mvc_savostikova.Controllers;

public class DishController
{
    private readonly List<Dish> dishes;
    private readonly DishView view;

    public DishController()
    {
        dishes = new List<Dish>
        {
            new Dish
            {
                Id = 1,
                Name = "Пицца Маргарита",
                Category = "Пицца",
                Price = 450,
                IsAvailable = true
            },
            new Dish
            {
                Id = 2,
                Name = "Борщ",
                Category = "Супы",
                Price = 250,
                IsAvailable = true
            },
            new Dish
            {
                Id = 3,
                Name = "Тирамису",
                Category = "Десерты",
                Price = 300,
                IsAvailable = false
            }
        };
        view = new DishView();
    }

    public void Index()
    {
        view.ShowDishes(dishes);
    }

    public void Show(int id)
    {
        var dish = dishes.FirstOrDefault(d => d.Id == id);
        if (dish == null)
        {
            view.ShowMessage("Блюдо не найдено.");
            return;
        }
        view.ShowDish(dish);
    }

    public void Add(Dish dish)
    {
        dishes.Add(dish);
        view.ShowMessage("Блюдо успешно добавлено.");
    }

    public void Delete(int id)
    {
        var dish = dishes.FirstOrDefault(d => d.Id == id);
        if (dish == null)
        {
            view.ShowMessage("Блюдо не найдено.");
            return;
        }
        dishes.Remove(dish);
        view.ShowMessage("Блюдо успешно удалено.");
    }

    // Раздел 11 методички — пользовательское меню
    public void Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== МЕНЮ ===");
            Console.WriteLine("1. Показать блюда");
            Console.WriteLine("2. Найти блюдо");
            Console.WriteLine("3. Добавить блюдо");
            Console.WriteLine("4. Удалить блюдо");
            Console.WriteLine("5. Поиск по названию");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            var command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    Index();
                    break;
                case "2":
                    ShowDishByUserInput();
                    break;
                case "3":
                    AddDishByUserInput();
                    break;
                case "4":
                    DeleteDishByUserInput();
                    break;
                case "5":
                    SearchByName();
                    break;
                case "0":
                    return;
                default:
                    view.ShowMessage("Неизвестная команда.");
                    break;
            }
        }
    }

    private void ShowDishByUserInput()
    {
        Console.Write("Введите ID блюда: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Show(id);
    }

    private void AddDishByUserInput()
    {
        Console.Write("Введите ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Console.Write("Введите название: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Введите категорию: ");
        string category = Console.ReadLine() ?? "";

        Console.Write("Введите цену: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            view.ShowMessage("Некорректная цена.");
            return;
        }

        Console.Write("Доступно? (y/n): ");
        bool isAvailable = Console.ReadLine()?.ToLower() == "y";

        Add(new Dish
        {
            Id = id,
            Name = name,
            Category = category,
            Price = price,
            IsAvailable = isAvailable
        });
    }

    private void DeleteDishByUserInput()
    {
        Console.Write("Введите ID блюда для удаления: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Delete(id);
    }

    // Раздел 14 методички — дополнительная операция
    private void SearchByName()
    {
        Console.Write("Введите текст для поиска: ");
        string text = Console.ReadLine() ?? "";

        var result = dishes
            .Where(d => d.Name.Contains(text, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (result.Count == 0)
        {
            view.ShowMessage("Ничего не найдено.");
            return;
        }
        view.ShowDishes(result);
    }
}