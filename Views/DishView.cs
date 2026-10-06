using wt_lab3_3mvc_savostikova.Models;

namespace wt_lab3_3mvc_savostikova.Views;

public class DishView
{
    public void ShowDishes(List<Dish> dishes)
    {
        Console.WriteLine("=== СПИСОК БЛЮД ===");
        foreach (var dish in dishes)
        {
            Console.WriteLine(
                $"{dish.Id}. " +
                $"{dish.Name} | " +
                $"{dish.Category} | " +
                $"{dish.Price} руб. | " +
                $"Доступно: {dish.IsAvailable}");
        }
    }

    public void ShowDish(Dish dish)
    {
        Console.WriteLine("=== БЛЮДО ===");
        Console.WriteLine($"ID: {dish.Id}");
        Console.WriteLine($"Название: {dish.Name}");
        Console.WriteLine($"Категория: {dish.Category}");
        Console.WriteLine($"Цена: {dish.Price} руб.");
        Console.WriteLine($"Доступно: {dish.IsAvailable}");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}