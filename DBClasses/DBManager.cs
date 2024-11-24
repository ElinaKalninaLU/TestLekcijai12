using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClasses
{
    public class DBManager
    {
        private string _connectionString;

        private GeometryContext _context;
        public DBManager(string connectionString) { 
        _connectionString = connectionString;
        _context = new GeometryContext(_connectionString);
        }

        public bool AddRectangle(int x, int y)
        {
           return  AddRectangle(new Rectangle() { Height = x, Width = y });
             
        }

        public bool AddRectangle(Rectangle r)
        {
            try
            {
                _context.Rectangles.Add(r);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool RemoveRectangle(Rectangle r)
        {
            try
            {
                _context.Rectangles.Remove(r);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool Update()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public List<Rectangle> GetRectangles() { 
        return _context.Rectangles.ToList();
        }
    }
}
