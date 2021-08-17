using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ImprovedCommandInterface;
using static InputTools.UIFeatures;
using static InputTools.ArrayTools;

using com = Task01.BlockEditCommands;

namespace Task01
{
    public partial class BlockEditor : ProgramCommandShell<BlockEditCommands>
    {
        protected override string AboutProgram
        {
            get { return about; }
            set { about = value; }
        }

        new protected string about = "Учебная программа. Цель - изучение переопределния методов object. " +
            "\n в данном случае - Equals. Метод переопределён в класс Block" +
            "\n В программе уже изначально определён список с 4 экземплярами Block" +
            "\n 3 первых одинаковые, второй - повёрнут на 90 градусов, но всё равно сравнение" +
            "\n производится адекватно";

        protected override void About()
        {
            Console.WriteLine(about);
        }

        protected override void AddCommandNotes(out Dictionary<BlockEditCommands, string> commandNote)
        {
            commandNote = new Dictionary<com, string>
            {
                { com.menu, " - show menu"},
                { com.about, " - some notes about this study program" },
                {com.list, " - view block list" },
                {com.add, " - add new block" },
                //{com.remove, " - remove selected block" },
                //{com.select, " - select block by index in list" },
                //{com.edit, " - set new point positions for selected block" },
                {com.compare, " - compare selected block with another block" },
                {com.clear, " - clear console " },
                {com.exit, " - exit from program" },
            };
        }

        protected override void AddCommands(out Dictionary<BlockEditCommands, Command> commandList)
        {
            commandList = new Dictionary<com, Command>
                {
                    { com.menu, SetCommand(Menu)},
                    { com.about, SetCommand(About)},
                    { com.list, SetCommand(ViewBlockList) },
                    { com.add, SetCommand(AddBlock) },
                    //{ com.remove, SetCommand(RemoveBlock) },
                    //{ com.select, SetCommand(SelectBlock) },
                    //{ com.edit, SetCommand(EditBlock) },
                    { com.compare, SetCommand(CompareBlock) },
                    { com.clear, SetCommand(Clear) },
                    { com.exit, SetCommand(Exit) },
                };
        }
    }

    public enum BlockEditCommands
    {
        menu,
        about,
        list,
        add,
        // излишняя реализация для задачи
        //remove,
        //select,
        //edit,
        compare,
        clear,
        exit,
    }
}
