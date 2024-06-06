using System;
using System.Collections.Generic;

// Gränssnitt för kommandon
public interface ICommand
{
    void Execute();
    void Undo();
}

// Mottagarklassen som hanterar texten
public class TextEditor
{
    private string _text = "";

    public void AppendText(string text)
    {
        _text += text;
    }

    public void RemoveText(int length)
    {
        if (length > _text.Length)
        {
            length = _text.Length;
        }
        _text = _text.Substring(0, _text.Length - length);
    }

    public string GetText()
    {
        return _text;
    }
}

// Konkret kommando för att lägga till text
public class AppendTextCommand : ICommand
{
    private TextEditor _editor;
    private string _text;

    public AppendTextCommand(TextEditor editor, string text)
    {
        _editor = editor;
        _text = text;
    }

    public void Execute()
    {
        _editor.AppendText(_text);
    }

    public void Undo()
    {
        _editor.RemoveText(_text.Length);
    }
}

// Invoker-klass som hanterar kommandon och undo/redo
public class CommandManager
{
    private Stack<ICommand> _undoStack = new Stack<ICommand>();
    private Stack<ICommand> _redoStack = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _undoStack.Push(command);
        _redoStack.Clear();
    }

    public void Undo()
    {
        if (_undoStack.Count > 0)
        {
            var command = _undoStack.Pop();
            command.Undo();
            _redoStack.Push(command);
        }
    }

    public void Redo()
    {
        if (_redoStack.Count > 0)
        {
            var command = _redoStack.Pop();
            command.Execute();
            _undoStack.Push(command);
        }
    }
}

// Programklass för att demonstrera textredigeraren med undo/redo
class Program
{
    static void Main()
    {
        TextEditor editor = new TextEditor();
        CommandManager commandManager = new CommandManager();

        // Lägg till text och visa resultatet
        ICommand appendCommand1 = new AppendTextCommand(editor, "Hello ");
        commandManager.ExecuteCommand(appendCommand1);
        Console.WriteLine("Text: " + editor.GetText());

        // Lägg till mer text och visa resultatet
        ICommand appendCommand2 = new AppendTextCommand(editor, "World!");
        commandManager.ExecuteCommand(appendCommand2);
        Console.WriteLine("Text: " + editor.GetText());

        // Ångra senaste kommandot och visa resultatet
        commandManager.Undo();
        Console.WriteLine("Text efter Undo: " + editor.GetText());

        // Gör om senaste kommandot och visa resultatet
        commandManager.Redo();
        Console.WriteLine("Text efter Redo: " + editor.GetText());
    }
}
