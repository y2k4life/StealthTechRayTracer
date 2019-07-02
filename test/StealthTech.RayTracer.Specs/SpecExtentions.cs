//-----------------------------------------------------------------------
// <copyright file="SpecExtentions.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace StealthTech.RayTracer.Specs
{
    public static class SpecExtentions
    {
        public static RtMatrix ToMatrix(this Table table)
        {
            RtMatrix matrix = new RtMatrix(table.RowCount + 1, table.Header.Count);
            var rowCount = table.RowCount + 1;
            int j = 0;
            foreach (var header in table.Header)
            {
                matrix[0, j] = Convert.ToDouble(header);
                j++;
            }

            for (int i = 1; i < rowCount; i++)
            {
                for (int j1 = 0; j1 < table.Rows[0].Count; j1++)
                {
                    matrix[i, j1] = Convert.ToDouble(table.Rows[i - 1][j1]);
                }
            }

            return matrix;
        }

        public static void FillMatrix(this Table table, RtMatrix matrix)
        {
            var rowCount = table.RowCount + 1;
            int j = 0;
            foreach (var header in table.Header)
            {
                matrix[0, j] = Convert.ToDouble(header);
                j++;
            }

            for (int i = 1; i < rowCount; i++)
            {
                for (int j1 = 0; j1 < table.Rows[0].Count; j1++)
                {
                    matrix[i, j1] = Convert.ToDouble(table.Rows[i - 1][j1]);
                }
            }
        }

        public static Dictionary<string, string> ToDictionary(this Table table)
        {
            var dictionary = new Dictionary<string, string>();

            var header = table.Header.ToArray();

            dictionary.Add(header[0], header[1]);

            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }

            return dictionary;
        }
    }
}
