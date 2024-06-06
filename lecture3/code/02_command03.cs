using System;
using System.Collections.Generic;
using System.IO;

// Gränssnitt för kommandon
public interface ICommand
{
    void Execute();
    void Undo();
}

// Mottagarklassen som hanterar filoperationer
public class FileManager
{
    public void CreateFile(string path)
    {
        using (FileStream fs = File.Create(path))
        {
            Console.WriteLine($"File created: {path}");
        }
    }

    public void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            Console.WriteLine($"File deleted: {path}");
        }
    }
}

// Konkret kommando för att skapa en fil
public class CreateFileCommand : ICommand
{
    private FileManager _fileManager;
    private string _path;

    public CreateFileCommand(FileManager fileManager, string path)
    {
        _fileManager = fileManager;
        _path = path;
    }

    public void Execute()
    {
        _fileManager.CreateFile(_path);
    }

    public void Undo()
    {
        _fileManager.DeleteFile(_path);
    }
}

// Konkret kommando för att ta bort en fil
public class DeleteFileCommand : ICommand
{
    private FileManager _fileManager;
    private string _path;

    public DeleteFileCommand(FileManager fileManager, string path)
    {
        _fileManager = fileManager;
        _path = path;
    }

    public void Execute()
    {
        _fileManager.DeleteFile(_path);
    }

    public void Undo()
    {
        _fileManager.CreateFile(_path);
    }
}

// Invoker-klass som hanterar kommandon
public class CommandManager
{
    private Stack<ICommand> _commandHistory = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public void UndoLastCommand()
    {
        if (_commandHistory.Count > 0)
        {
            ICommand command = _commandHistory.Pop();
            command.Undo();
        }
    }
}

// Programklass för att demonstrera filoperationerna
class Program
{
    static void Main()
    {
        FileManager fileManager = new FileManager();
        CommandManager commandManager = new CommandManager();

        string filePath = "testfile.txt";

        // Skapa en fil och visa resultatet
        ICommand createFile = new CreateFileCommand(fileManager, filePath);
        commandManager.ExecuteCommand(createFile);

        // Ta bort filen och visa resultatet
        ICommand deleteFile = new DeleteFileCommand(fileManager, filePath);
        commandManager.ExecuteCommand(deleteFile);

        // Ångra senaste kommandot (återskapa filen)
        commandManager.UndoLastCommand();
    }
}
