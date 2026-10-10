
using System.Text.Json;

const string FilePath = "tasks.json";

var jsonOptions = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNameCaseInsensitive = true
};

while (true)
{
    Console.WriteLine("\n=== JSON TASK MANAGER ===");
    Console.WriteLine("1. Add task");
    Console.WriteLine("2. View tasks");
    Console.WriteLine("3. Mark task completed");
    Console.WriteLine("4. Exit");
    Console.Write("Choose an option: ");

    string? choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                await AddTaskAsync();
                break;

            case "2":
                await ViewTasksAsync();
                break;

            case "3":
                await CompleteTaskAsync();
                break;

            case "4":
                return;

            default:
                Console.WriteLine("Invalid option. Choose 1-4.");
                break;
        }
    }
    catch (IOException ex)
    {
        Console.WriteLine($"File error: {ex.Message}");
    }
    catch (JsonException ex)
    {
        Console.WriteLine($"Invalid JSON data: {ex.Message}");
    }
}

async Task AddTaskAsync()
{
    Console.Write("Enter task title: ");
    string? title = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(title))
    {
        Console.WriteLine("Task title cannot be empty.");
        return;
    }

    List<TaskItem> tasks = await LoadTasksAsync();

    int nextId = tasks.Count == 0
        ? 1
        : tasks.Max(t => t.Id) + 1;

    tasks.Add(new TaskItem
    {
        Id = nextId,
        Title = title.Trim(),
        IsCompleted = false,
        CreatedAt = DateTime.UtcNow
    });

    await SaveTasksAsync(tasks);

    Console.WriteLine("Task saved successfully.");
}

async Task ViewTasksAsync()
{
    List<TaskItem> tasks = await LoadTasksAsync();

    if (tasks.Count == 0)
    {
        Console.WriteLine("No tasks found.");
        return;
    }

    foreach (TaskItem task in tasks)
    {
        string status = task.IsCompleted ? "Completed" : "Pending";

        Console.WriteLine(
            $"{task.Id}. {task.Title} | {status} | {task.CreatedAt:yyyy-MM-dd}");
    }
}

async Task CompleteTaskAsync()
{
    List<TaskItem> tasks = await LoadTasksAsync();

    Console.Write("Enter task ID: ");
    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int id))
    {
        Console.WriteLine("Please enter a valid number.");
        return;
    }

    TaskItem? task = tasks.FirstOrDefault(t => t.Id == id);

    if (task == null)
    {
        Console.WriteLine("Task not found.");
        return;
    }

    task.IsCompleted = true;

    await SaveTasksAsync(tasks);

    Console.WriteLine("Task marked as completed.");
}

async Task<List<TaskItem>> LoadTasksAsync()
{
    if (!File.Exists(FilePath))
    {
        return new List<TaskItem>();
    }

    await using FileStream stream = new(
        FilePath,
        FileMode.Open,
        FileAccess.Read,
        FileShare.Read);

    return await JsonSerializer.DeserializeAsync<List<TaskItem>>(
        stream,
        jsonOptions) ?? new List<TaskItem>();
}

async Task SaveTasksAsync(List<TaskItem> tasks)
{
    await using FileStream stream = new(
        FilePath,
        FileMode.Create,
        FileAccess.Write,
        FileShare.None);

    await JsonSerializer.SerializeAsync(
        stream,
        tasks,
        jsonOptions);
}

public class TaskItem
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }

    public DateTime CreatedAt { get; set; }
}