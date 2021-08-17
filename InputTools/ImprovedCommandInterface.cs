using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static InputTools.UIFeatures;

namespace ImprovedCommandInterface
{
    // базовый интерфейс для вызова программ со встроенной командной оболочкой
    public interface IProgrammCommandShell
    {
        public void Run();
    }

    // базовый абстрактный класс со встроенной командной оболочкой
    // для разных программ
    public abstract class ProgramCommandShell<C> : IProgrammCommandShell where C : Enum
    {
        protected Dictionary<C, Command> commandList;
        protected Dictionary<C, string> commandDescription;

        protected string about;
        protected abstract string AboutProgram
        {
            get;
            set;
        }

        bool doExit = false;

        public ProgramCommandShell()
        {
            about = "stub for about";
            AddCommandNotes(out commandDescription);
            AddCommands(out commandList);
        }

        protected abstract void AddCommandNotes(out Dictionary<C, string> commandNote);
        protected abstract void AddCommands(out Dictionary<C, Command> commandList);

        // метод для показа списка команд (CommandItem<T,C>[]) и заданных пояснений к ним
        protected void ShowMenu()
        {
            foreach(var command in commandDescription)
            {
                Console.WriteLine($"{command.Key} - {command.Value}");
            }
        }

        public void Run()
        {
            About();
            Menu();
            do
            {
                InputCommand();
                if (doExit) break;
            }
            while (true);
        }

        protected virtual void Menu()
        {
            DrawSymbolLine(50, '-', ConsoleColor.DarkGray);
            ShowMenu();
        }

        protected virtual void About()
        {
            DrawSymbolLine(100, '%', ConsoleColor.DarkYellow);
            Console.WriteLine(about);
            DrawSymbolLine(100, '%', ConsoleColor.DarkYellow);
        }

        protected virtual void Clear()
        {
            Console.Clear();
        }

        protected virtual void Exit()
        {
            doExit = true;
        }

        protected void Stub()
        {
            Console.WriteLine("commandNotImplemented");
        }

        protected virtual void InputCommand()
        {
            DrawSymbolLine(50, '-', ConsoleColor.DarkGray);
            Console.Write("Input command: ");
            string inputCommand = Console.ReadLine();            
            bool IsCommandCorrect = Enum.IsDefined(typeof(C), inputCommand);
               

            if (IsCommandCorrect == false)
            {
                DrawSymbolLine(50, '-', ConsoleColor.DarkGray);
                Console.WriteLine("Input is INCORRECT. Please, do correct command input");
                InputCommand();
            }
            else
            {
                Command currentCommand;
                commandList.TryGetValue((C)Enum.Parse(typeof(C), inputCommand), out currentCommand);
                currentCommand.InvokeCommand();
            }
        }

        protected virtual Command SetCommand(Action method)
        {
            return new Command(method);
        }

        protected virtual Command SetParametrizedCommand(Action<object> method, object parameter)
        {
            return new Command(method, parameter);
        }

        /* класс стал легче, отвечает только за хранение вызываемых методов
         * кроме тог, теперь это внутренний класс
         */
        protected class Command
        {
            /* делегаты для вызова из команды */
            Action handler;
            Action<object> paramHandler;

            /* экземпляр для передачи в команду для выполнения
            * передаваемого метода
            */
            object transmittedParameter;

            /* конструктор для передачи делегата без параметра */
            public Command(Action handler)
            {                
                this.handler += handler;
            }

            /* конструктор для передачи делегата с параметром 
             экземпляр типа параметра передаётся следующим
             */
            public Command(Action<object> handler, object parameter)
            {
                this.paramHandler += handler;
                transmittedParameter = parameter;
            }

            public void InvokeCommand()
            {
                if (handler != null)
                    handler.Invoke();
                if (paramHandler != null)
                    paramHandler.Invoke(transmittedParameter);
            }
        }
    }
}
