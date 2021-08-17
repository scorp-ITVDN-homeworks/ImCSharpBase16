using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using static InputTools.UIFeatures;

namespace Task01
{
    public partial class  BlockEditor
    {

        List<Block> blockCollection = new List<Block>()
        {
            Block.CreateBlock("point a", 4,3,new Point(5,5)),
            Block.CreateBlock("point b", 3,4, new Point(10,10)),
            Block.CreateBlock("point c", 4,3, new Point()),
            Block.CreateBlock("point d", 2,10, new Point(8,8)),
        };

        private void ViewBlockList()
        {
            int counter = 0;
            foreach(var block in blockCollection)
            {
                ViewBlock(counter,block);
                counter++;
            }
        }

        private void ViewBlock(int index, Block block)
        {
            DrawSymbolLine(50, '-', ConsoleColor.Green);
            Console.WriteLine($"[{index}]{block.Name} ");
            Console.Write("Points:");
            Console.Write($"A [{block.Points[0].X},{block.Points[0].Y}] ");
            Console.Write($"B [{block.Points[1].X},{block.Points[1].Y}] ");
            Console.Write($"C [{block.Points[2].X},{block.Points[2].Y}]");
            Console.WriteLine($"D [{block.Points[3].X},{block.Points[3].Y}]");
            Console.Write("Sides: ");
            Console.Write($"AB [{block.Sides[0].SideLength}] ");
            Console.Write($"BC [{block.Sides[1].SideLength}] ");
            Console.Write($"CD [{block.Sides[2].SideLength}] ");
            Console.WriteLine($"AD [{block.Sides[3].SideLength}]");
        }

        private void AddBlock()
        {
            Console.WriteLine("Define new block");
            int width = 0;
            int heigth = 0;

            int startX = 0;
            int startY = 0;

            string inputText = "Input block WIDTH: ";
            Console.Write(inputText);
            string exceptionText = "width value input error - input integer value. Value must be greater, then 0";
            CheckIntegerValue(ref width, exceptionText, exceptionText, inputText);

            inputText = "Input block HEIGHT: ";
            Console.Write(inputText);
            exceptionText = "heigth value input error - input integer value. Value must be greater, then 0";
            CheckIntegerValue(ref heigth, exceptionText, exceptionText, inputText);

            inputText = "Input start point X coordinate: ";
            Console.Write(inputText);
            exceptionText = "coordinate X value input error - input integer value";
            CheckIntegerPointInput(ref startX, exceptionText, inputText);

            inputText = "Input start point Y coordinate: ";
            Console.Write(inputText);
            exceptionText = "coordinate Y value input error - input integer value";
            CheckIntegerPointInput(ref startY, exceptionText, inputText);

            Console.Write("Input new block name: ");
            string blockName = Console.ReadLine();
            blockCollection.Add(Block.CreateBlock(blockName, width, heigth, new Point(startX, startY)));
        }

        private void CheckIntegerValue
            (
            ref int value, 
            string exceptionTextTry, 
            string execeptionTextCatch,
            string input)
        {
            while (true)
            {
                try
                {
                    value = Convert.ToInt32(Console.ReadLine());
                    if (value <= 0)
                    {
                        Console.WriteLine(exceptionTextTry);
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine(execeptionTextCatch);
                    Console.Write(input);
                }
            }
        }

        private void CheckIntegerPointInput(
            ref int value, 
            string exceptionText,
            string input)
        {
            while (true)
            {
                try
                {
                    value = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine(exceptionText);
                    Console.Write(input);
                }
            }
        }

        private void RemoveBlock()
        {
            Stub();
        }

        private void SelectBlock(ref Block selectedBlock)
        {
            Console.Write("Input index of block: ");
            int index = 0;

            while (true)
            {
                try
                {
                    index = Convert.ToInt32(Console.ReadLine());
                    if(index < 0 || index > blockCollection.Count)
                    {
                        Console.WriteLine("index out of range");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Input error - integer value input is expected");
                    Console.Write("Input index of block: ");
                }
            }

            selectedBlock = blockCollection[index];
        }

        private void EditBlock()
        {
            Stub();
        }

        private void CompareBlock()
        {
            Block firstBlock = null;
            Block secondBlock = null;
            Console.WriteLine("Select first block to compare: ");
            SelectBlock(ref firstBlock);
            DrawSymbolLine(50, '-', ConsoleColor.Red);
            Console.WriteLine("Select second block to compare: ");
            SelectBlock(ref secondBlock);

            Console.WriteLine(firstBlock.Equals(secondBlock) ? "Blocks are equals" : "Blocks not equals");
        }
    }
}
