using StealthTech.RayTracer.EasyConsole;
using StealthTech.RayTracer.Library;
using System;

namespace StealthTech.RayTracer.Exercises
{
    public class ChapterThree
    {
        int left;
        int top;
        int indent = 5;

        public ChapterThree()
        {
            StoreCursor();
        }

        public void Run()
        {
            RtMatrix m1 = GenerateRandomMatrix();
            RtMatrix m2 = GenerateRandomMatrix();
            var m2Width = TotalInsideWidth(m2) + 2;

            RtMatrix m3 = m1.Inverse();

            var m1Width = TotalInsideWidth(m1) + 2;
            var op1Indent = indent + m1Width + 1;
            var op2Indent = indent + m1Width + m2Width + 4;
            var m2Indent = indent + m1Width + 3;
            var m3Indent = indent + m1Width + m2Width + 6;

            PrintMatrix(m1, indent);
            PrintOp("*", op1Indent);

            PrintMatrix(m2, m2Indent);
            PrintOp("=", op2Indent);

            PrintM3(m3, m3Indent);
            Console.SetCursorPosition(left, top + 8);
        }

        public void InverseIdentity()
        {
            var value = Input.ReadInt("Enter size of matrix 2, 3, 4, 5, 6, 7, or 8", new int[] { 2, 3, 4, 5, 6, 7, 8 });

            StoreCursor();
            
            RtMatrix m1 = GenerateRandomMatrix(value);
            m1 = m1.Identity();
            
            RtMatrix m2 = m1.Inverse();
            var m2Width = TotalInsideWidth(m2) + 2;
            
            var m1Width = TotalInsideWidth(m1) + 2;
            var op1Indent = indent + m1Width + 1;
            var op3Indent = indent + m1Width + m2Width + 4;
            var m2Indent = indent + m1Width + 3;

            PrintMatrix(m1, indent);
            PrintOp("I", op1Indent);

            PrintMatrix(m2, m2Indent);
            Console.SetCursorPosition(left, top + m1.RowCount + 2);
        }

        public void MultipliedByInverse()
        {
            var value = Input.ReadInt("Enter size of matrix 2, 3, 4, 5, 6, 7, or 8", new int[] { 2, 3, 4, 5, 6, 7, 8 });

            StoreCursor();
            
            RtMatrix m1 = GenerateSimpleMatrix(value);
            var m1Width = TotalInsideWidth(m1) + 2;
            
            RtMatrix m2 = m1.Inverse();
            var m2Width = TotalInsideWidth(m2) + 2;

            RtMatrix m3 = m1 * m2;
            
            var op1Indent = indent + m1Width + 1;
            var op2Indent = indent + m1Width + m2Width + 4;
            var m2Indent = indent + m1Width + 3;
            var m3Indent = indent + m1Width + m2Width + 6;

            PrintMatrix(m1, indent);
            PrintOp("*", op1Indent);

            PrintMatrix(m2, m2Indent);
            PrintOp("=", op2Indent);

            PrintM3(m3, m3Indent);
            Console.SetCursorPosition(left, top + m1.RowCount + 2);
        }

        public void CompareInverseTranspose()
        {
            RtMatrix m3 = GenerateSimpleMatrix();
            RtMatrix m1 = m3.Transpose().Inverse();
            var m1Width = TotalInsideWidth(m1) + 2;
            
            RtMatrix m2 = m3.Inverse().Transpose();

            var op1Indent = indent + m1Width + 1;
            var m2Indent = indent + m1Width + 3;

            PrintMatrix(m3, indent);
            Console.SetCursorPosition(left, top + 6);

            left = Console.CursorLeft;
            top = Console.CursorTop;

            PrintMatrix(m1, indent);
            PrintOp("V", op1Indent);

            PrintMatrix(m2, m2Indent);

            Console.SetCursorPosition(left, top + m1.RowCount + 2);
        }

        private void PrintOp(string op, int opIndent)
        {
            Console.SetCursorPosition(left + opIndent, top + 2);
            Console.Write(op);
            Console.SetCursorPosition(left, top);
        }
        
        private void PrintM3(RtMatrix m3, int m3Indent)
        {
            Console.SetCursorPosition(left, top);
            PrintMatrix(m3, m3Indent);
        }

        private static RtMatrix GenerateRandomMatrix()
        {
            return GenerateRandomMatrix(4);
        }

        private static RtMatrix GenerateRandomMatrix(int size)
        {
            var rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            var matrix = new RtMatrix(size, size);
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] = rnd.Next(20);
                }
            }

            return matrix;
        }

        private static RtMatrix GenerateSimpleMatrix()
        {
            return GenerateSimpleMatrix(4);
        }

        private static RtMatrix GenerateSimpleMatrix(int size)
        {
            var rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            var matrix = new RtMatrix(size, size);
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] = rnd.Next(4);
                }
            }

            return matrix;
        }

        private void PrintMatrix(RtMatrix matrix, int indent)
        {
            var maxWidth = MaxWidth(matrix);
            int totalWidth = TotalInsideWidth(matrix);

            Console.SetCursorPosition(Console.CursorLeft + indent, Console.CursorTop);
            Console.Write("┌");
            Console.Write(new string(' ', totalWidth));
            Console.WriteLine("┐");
            Console.SetCursorPosition(Console.CursorLeft + indent, Console.CursorTop);

            for (int i = 0; i < matrix.RowCount; i++)
            {
                Console.Write("│");
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    Console.Write(' ');
                    Console.Write(Math.Round(matrix[i, j], 3).ToString().PadLeft(maxWidth, ' '));
                    Console.Write(' ');
                }

                Console.WriteLine("│");
                Console.SetCursorPosition(Console.CursorLeft + indent, Console.CursorTop);
            }

            Console.Write("└");
            Console.Write(new string(' ', totalWidth));
            Console.WriteLine("┘");
            Console.SetCursorPosition(left, top);
        }

        private int TotalInsideWidth(RtMatrix matrix)
        {
            return (MaxWidth(matrix) + 2) * matrix.ColumnCount;
        }

        public int MaxWidth(RtMatrix matrix)
        {
            int maxWidth = 0;
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    var stringValue = Math.Round(matrix[i, j], 3).ToString();
                    if (stringValue.ToString().Length > maxWidth)
                        maxWidth = stringValue.ToString().Length;
                }
            }

            return maxWidth;
        }

        private void StoreCursor()
        {
            left = Console.CursorLeft;
            top = Console.CursorTop;
        }
    }
}
