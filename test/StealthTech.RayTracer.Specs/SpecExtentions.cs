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
        public static RtMatrix ToMatrix(this Table table, bool ignoreHeader = false)
        {
            var rowCount = ignoreHeader ? table.RowCount + 1 : table.RowCount;
            var results = new RtMatrix(rowCount, table.Rows[0].Count);

            table.ToMatrix(results, ignoreHeader);

            return results;
        }

        public static void ToMatrix(this Table table, RtMatrix matrix, bool ignoreHeader = false)
        {
            if (ignoreHeader)
            {
                var rowCount = ignoreHeader ? table.RowCount + 1 : table.RowCount;
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

                return;
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Rows[i].Count; j++)
                {
                    matrix[i, j] = Convert.ToDouble(table.Rows[i][j]);
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
