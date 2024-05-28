using System;
using System.Collections.Generic;

namespace NotepadExample
{
    /// <summary>
    /// Interface defining the operations for a Notepad.
    /// </summary>
    public interface INotepad : ICloneable
    {
        string Text { get; }
        void Write(string newText);
        Memento Save();
        void Restore(Memento memento);
    }

    /// <summary>
    /// The Memento class stores the state of the Notepad.
    /// This is used to implement the undo and redo functionality.
    /// </summary>
    public class Memento
    {
        public string Text { get; }
        public Memento(string text)
        {
            Text = text;
        }
    }

    /// <summary>
    /// The Notepad class represents a simple text editor with undo and redo functionality.
    /// Implements INotepad and ICloneable interfaces.
    /// </summary>
    public class Notepad : INotepad
    {
        public string Text { get; private set; }

        public Notepad()
        {
            Text = string.Empty;
        }

        /// <summary>
        /// Write text to the notepad.
        /// </summary>
        /// <param name="newText">The text to write.</param>
        public void Write(string newText)
        {
            Text += newText;
        }

        /// <summary>
        /// Save the current state of the notepad.
        /// </summary>
        /// <returns>A Memento object containing the current state.</returns>
        public Memento Save()
        {
            return new Memento(Text);
        }

        /// <summary>
        /// Restore the state of the notepad from a Memento object.
        /// </summary>
        /// <param name="memento">The Memento object containing the state to restore.</param>
        public void Restore(Memento memento)
        {
            Text = memento.Text;
        }

        /// <summary>
        /// Create a shallow copy of the current Notepad instance.
        /// </summary>
        /// <returns>A clone of the current Notepad instance.</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    /// <summary>
    /// The Caretaker class is responsible for storing Memento objects
    /// and handling undo and redo operations.
    /// </summary>
    public class Caretaker
    {
        private readonly INotepad _notepad;
        private readonly Stack<Memento> _undoStack;
        private readonly Stack<Memento> _redoStack;

        public Caretaker(INotepad notepad)
        {
            _notepad = notepad;
            _undoStack = new Stack<Memento>();
            _redoStack = new Stack<Memento>();
            SaveState(); // Save the initial state
        }

        /// <summary>
        /// Save the current state of the notepad and clear the redo stack.
        /// </summary>
        public void SaveState()
        {
            _undoStack.Push(_notepad.Save());
            _redoStack.Clear();
        }

        /// <summary>
        /// Undo the last change.
        /// </summary>
        public void Undo()
        {
            if (_undoStack.Count > 1)
            {
                _redoStack.Push(_undoStack.Pop());
                _notepad.Restore(_undoStack.Peek());
            }
        }

        /// <summary>
        /// Redo the last undone change.
        /// </summary>
        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                _undoStack.Push(_redoStack.Pop());
                _notepad.Restore(_undoStack.Peek());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a new notepad instance
            INotepad notepad = new Notepad();

            // Create a caretaker to manage undo/redo operations
            Caretaker caretaker = new Caretaker(notepad);

            // Write text to the notepad and save the state
            notepad.Write("Hello");
            caretaker.SaveState();

            notepad.Write(", World");
            caretaker.SaveState();

            Console.WriteLine("Current text: " + notepad.Text);

            // Undo the last change
            caretaker.Undo();
            Console.WriteLine("After undo: " + notepad.Text);

            // Redo the last undone change
            caretaker.Redo();
            Console.WriteLine("After redo: " + notepad.Text);

            // Further changes and save state
            notepad.Write("! How are you?");
            caretaker.SaveState();
            Console.WriteLine("Current text: " + notepad.Text);

            // Undo twice
            caretaker.Undo();
            caretaker.Undo();
            Console.WriteLine("After two undos: " + notepad.Text);

            // Redo once
            caretaker.Redo();
            Console.WriteLine("After one redo: " + notepad.Text);
        }
    }
}
