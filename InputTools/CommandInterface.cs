using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static InputTools.UIFeatures;

namespace CommandInterface
{
    /* Класс, представляющий команду, 
     * к нему можно обратиться из класса-командной оболочки и 
     * вызвать метод, записаный с помощью делегата
     * 
     * в общем случае T будет object, если не требуется другого
     * C - перечисление, enum, для связи со списком команд
     */
    public class CommandItem<T, C> where C : Enum 
    {
        C command;
        string description;

        /* делегаты для вызова из команды */
        Action handler;
        Action<T> paramHandler;

        /* экземпляр для передачи в команду для выполнения
         * передаваемого метода
         */
        T transmitted;

        /* конструктор для передачи делегата без параметра */
        public CommandItem(C command, string description, Action handler)
        {
            this.command = command;
            this.description = description;
            this.handler += handler;
        }

        /* конструктор для передачи делегата с параметром 
         экземпляр типа параметра передаётся следующим
         */
        public CommandItem(C command, string description, Action<T> handler, T instanceType)
        {
            this.command = command;
            this.description = description;
            this.paramHandler += handler;
            transmitted = instanceType;
        }

        public C Command
        {
            get { return command; }
        }

        public string Description
        {
            get { return description; }
        }

        public void InvokeCommand()
        {
            Console.WriteLine(command);
            if (handler != null)
                handler.Invoke();
            if (paramHandler != null)
                paramHandler.Invoke(transmitted);
        }
    } 

    // базовый интерфейс для вызова программ со встроенной командной оболочкой
    public interface IProgrammCommandShell
    {
        public void Run();
    }

    // базовый абстрактный класс со встроенной командной оболочкой
    // для разных программ
    public abstract class ProgramCommandShell<T, C> : IProgrammCommandShell where C : Enum
    {
        protected string[] commandNote;

        protected CommandItem<T, C>[] commandList;

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
            AddCommandNotes(out commandNote);
            AddCommands(out commandList);
        }

        public virtual void Run()
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

        // метод для исолнения выбранной команды - перегрузка с аргументом - массивом CommandItem<T,C>[]
        protected virtual void InputCommand(CommandItem<T, C>[] commandList)
        {
            DrawSymbolLine(50, '-', ConsoleColor.DarkGray);
            Console.Write("Input command: ");
            string inputCommand = Console.ReadLine();
            bool IsCommandCorrect =
                Array.Exists(commandList, x => inputCommand == x.Command.ToString());
            //Array.Exists<CommandItem<object, Commands>>(commandsList, x => inputCommand == x.Command.ToString());

            if (IsCommandCorrect == false)
            {
                DrawSymbolLine(50, '-', ConsoleColor.DarkGray);
                Console.WriteLine("Input is INCORRECT. Please, do correct command input");
                InputCommand(commandList);
            }
            else
            {
                Array.Find(commandList, x => inputCommand == x.Command.ToString()).InvokeCommand();
            }

        }

        // метод для исполнения выбранной команды - перегрузка без аргументов
        protected virtual void InputCommand()
        {
            DrawSymbolLine(50, '-', ConsoleColor.DarkGray);
            Console.Write("Input command: ");
            string inputCommand = Console.ReadLine();
            bool IsCommandCorrect =
                Array.Exists(commandList, x => inputCommand == x.Command.ToString());
            //Array.Exists<CommandItem<object, Commands>>(commandsList, x => inputCommand == x.Command.ToString());

            if (IsCommandCorrect == false)
            {
                DrawSymbolLine(50, '-', ConsoleColor.DarkGray);
                Console.WriteLine("Input is INCORRECT. Please, do correct command input");
                InputCommand(commandList);
            }
            else
            {
                Array.Find(commandList, x => inputCommand == x.Command.ToString()).InvokeCommand();
            }
        }

        // методя для показа списка команд (CommandItem<T,C>[]) и заданных пояснений к ним
        public void ShowMenu()
        {
            for (int i = 0; i < commandList.Length; i++)
            {
                Console.WriteLine($"{commandList[i].Command} - {commandList[i].Description}");
            }
        }

        public abstract void AddCommandNotes(out string[] commandNote);
        public abstract void AddCommands(out CommandItem<T, C>[] commandList);

        protected void Stub()
        {
            Console.WriteLine("all works well, you can replace method implementation");
        }
    }

    public class CommandList<E> where E: Enum
    {
        string[] ar = Enum.GetNames(typeof(E));

        string[] commandNotes = new string[] { };
        Action[] commandHandlers = new Action[] { };
        Action<E>[] parametrizedCommandHandlers = new Action<E>[] { };
        

        //public string this[E enumItem]
        //{
            
        //}

        //public Action this[E enumItem]
        //{
        //    get
        //}

        //public Action<E> this [E enumItem]
        //{

        //}

        
    }

}

