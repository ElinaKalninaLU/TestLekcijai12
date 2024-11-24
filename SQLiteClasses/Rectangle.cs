using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using CommonClasses;

namespace SQLiteClasses
{
    public class Rectangle : IRectangle
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public override string? ToString()
        {
            return $"Rectangle H:{Height}, W:{Width}";
        }
    }
}
