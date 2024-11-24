using SQLite;
using System.Diagnostics;

namespace SQLiteClasses
{
    public class DBClass
    {
        SQLiteConnection conn;

        public static string dbFileN = "rectangles.db";
        public static string folderPath
            = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static string dbPath
        {   get
            {
            //    if (DeviceInfo.Platform.ToString() == "Android")
            //    {
            //        Debug.WriteLine(DeviceInfo.Platform);
            //        return Path.Combine(FileSystem.AppDataDirectory, dbFileN);
            //    }
            //    else
            //    {
                    return Path.Combine(folderPath, dbFileN);
            //    }
            }
        }
        //  Path.Combine(FileSystem.AppDataDirectory, dbFileN);

        public bool Init()
        {
            if (conn != null) { return false; }
            try
            {
                conn = new SQLiteConnection(dbPath);
                var r = conn.CreateTable<Rectangle>();
                CreateTestData();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error" + ex);
                return false;
            }
        }

        public bool CreateTestData()
        {
            try
            {
                Init();
                int count = conn?.Table<Rectangle>()?.Count() ?? 0;
                if (count == 0)
                {
                    AddRectangle(new Rectangle { Height = 1, Width = 2});
                    AddRectangle(new Rectangle { Height = 5, Width = 4});
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error" + ex);
                return false;
            }
        }

        public List<Rectangle> GetRectangles()
        {
            try
            {
                Init();
                List<Rectangle> list = conn.Table<Rectangle>().ToList();
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error" + ex);
                return null;
            }

        }

        public bool AddRectangle(int x, int y)
        {
            return AddRectangle(new Rectangle() { Height = x, Width = y });
        }

        public bool AddRectangle(Rectangle r)
        {
            try
            {
                Init();
                int i = conn.Insert(r);
                if (i == 1) { return true; }
                else return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error" + ex);
                return false;
            }
        }

        public bool RemoveRectangle(Rectangle r)
        {
            try
            {
                Init();
                int i = conn.Delete(r);
                if (i == 1) { return true; }
                else return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error" + ex);
                return false;
            }
        }

        public bool UpdateRectangle(Rectangle r)
        {
            try
            {
                Init();
                int i = conn.Update(r);
                if (i == 1) { return true; }
                else return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error" + ex);
                return false;
            }
        }
    }
}
