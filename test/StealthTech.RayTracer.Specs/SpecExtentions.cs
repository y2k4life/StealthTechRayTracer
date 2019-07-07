﻿//-----------------------------------------------------------------------
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

        public static void SetShapePropertiesFromTable(this Table table, Shape shape)
        {
            var properties = table.ToDictionary();
            foreach (var kv in properties)
            {
                var property = kv.Key;
                var subproperty = "";
                if (kv.Key.Contains('.'))
                {
                    property = kv.Key.Split('.')[0];
                    subproperty = kv.Key.Split('.')[1];
                }

                switch (property)
                {
                    case "material":
                        switch (subproperty)
                        {
                            case "color":
                                string[] colorValues = kv.Value
                                    .Replace('(', ' ')
                                    .Replace(')', ' ')
                                    .Split(',');
                                shape.Material.Color = new RtColor(Convert.ToDouble(colorValues[0]), Convert.ToDouble(colorValues[1]), Convert.ToDouble(colorValues[2]));
                                break;
                            case "diffuse":
                                shape.Material.Diffuse = Convert.ToDouble(kv.Value);
                                break;
                            case "specular":
                                shape.Material.Specular = Convert.ToDouble(kv.Value);
                                break;
                            case "reflective":
                                shape.Material.Reflective = Convert.ToDouble(kv.Value);
                                break;
                            case "RefractiveIndex":
                                shape.Material.RefractiveIndex = Convert.ToDouble(kv.Value);
                                break;
                            case "Ambient":
                                shape.Material.Ambient = Convert.ToDouble(kv.Value);
                                break;
                            case "Transparency":
                                shape.Material.Transparency = Convert.ToDouble(kv.Value);
                                break;
                            case "pattern":
                                if(kv.Value == "TestPatter()")
                                {
                                    shape.Material.Pattern = new TestPattern();
                                }
                                break;
                                
                        }
                        break;
                    case "transform":
                        string transform = kv.Value.Substring(0, kv.Value.IndexOf('('));
                        string[] values = kv.Value.Substring(kv.Value.IndexOf('(') + 1, kv.Value.Length - kv.Value.IndexOf('(') - 2).Split(',');
                        switch (transform)
                        {
                            case "scaling":
                                shape.Transform *= new Transform().Scaling(Convert.ToDouble(values[0]), Convert.ToDouble(values[1]), Convert.ToDouble(values[2]));
                                break;
                            case "translation":
                                shape.Transform *= new Transform().Translation(Convert.ToDouble(values[0]), Convert.ToDouble(values[1]), Convert.ToDouble(values[2]));
                                break;
                        }
                        break;
                }
            }
        }
    }
}
