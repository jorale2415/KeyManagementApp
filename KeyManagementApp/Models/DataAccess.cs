//This code was generated by a tool.
//Changes to this file will be lost if the code is regenerated.
// See the blog post here for help on using the generated code: http://erikej.blogspot.dk/2014/10/database-first-with-sqlite-in-universal.html
using SQLite;
using System;

namespace KeyManagementApp.Models
{
    public class SQLiteDb
    {
        string _path;
        public SQLiteDb(string path)
        {
            _path = path;
        }
        
         public void Create()
        {
            using (SQLiteConnection db = new SQLiteConnection(_path))
            {
                db.CreateTable<Employee>();
                db.CreateTable<KeyBox>();
                db.CreateTable<LogSheet>();
                db.CreateTable<Owner>();
                db.CreateTable<Properties>();
                db.CreateTable<Slots>();
            }
        }

        internal object Table<T>()
        {
            throw new NotImplementedException();
        }
    }
    public partial class Employee
    {
        [PrimaryKey, AutoIncrement]
        public Int64 EmpId { get; set; }
        
       /* [NotNull]
        public String UserName { get; set; }
        
        [NotNull]
        public String FName { get; set; }
        
        [NotNull]
        public String LName { get; set; }
        
        [NotNull]
        public String IsPass { get; set; }
        */
    }
    
    public partial class KeyBox
    {
        [PrimaryKey, AutoIncrement]
        public Int64 KeyBoxId { get; set; }
        
        /*[NotNull]
        public String KeyBoxName { get; set; }
        
        [NotNull]
        public String KeyBoxLocation { get; set; }
        
        [NotNull]
        public Int64 KeyBoxSize { get; set; }*/     
    }
    public partial class Slots
    {
        [PrimaryKey, AutoIncrement]
        public Int64 SlotsId { get; set; }

        [NotNull, Indexed]
        public Int64 KeyBoxId { get; set; }

        /* [NotNull]
         public Int64 SlotNum { get; set; }

         public Int64? Isfull { get; set; }*/

    }

    public partial class LogSheet
    {
        [PrimaryKey, AutoIncrement]
        public Int64 LogId { get; set; }
        
        [NotNull]
        public Int64 Emp { get; set; }
        
        [NotNull]
        public Int64 Property { get; set; }
        
        /*[NotNull]
        public String DateOut { get; set; }
        
        public String DateIn { get; set; }*/
        
    }
    
    public partial class Owner
    {
        [PrimaryKey, AutoIncrement]
        public long OwnId { get; set; }
        
        /*[NotNull]
        public String FName { get; set; }
        
        [NotNull]
        public String LName { get; set; }*/
        
    }
    
    public partial class Properties
    {
        [PrimaryKey, AutoIncrement]
        public Int64 PropId { get; set; }
        
        [NotNull, Indexed]
        public Int64 Owner { get; set; }
        
        [NotNull, Indexed]
        public Int64 KeyNum { get; set; }
        
        /*[NotNull]
        public String PropAdd { get; set; }
        
        [NotNull]
        public String PropCity { get; set; }
        
        [NotNull]
        public String PropState { get; set; }
        
        [NotNull]
        public String PropZip { get; set; }*/
        
    }  
}
