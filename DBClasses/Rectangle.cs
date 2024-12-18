﻿using System.ComponentModel.DataAnnotations;
using CommonClasses;

namespace DBClasses
{
    public class Rectangle :IRectangle
    {
        [Key]
        public int ID { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public override string? ToString()
        {
            return $"Rectangle H:{Height}, W:{Width}";
        }
    }
}
