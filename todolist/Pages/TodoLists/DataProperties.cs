using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todolist.Pages.TodoLists
{
    public interface DataProperties
    {
        public static string AddCardSucceedMessage = "New card added successfully";
        
        public static string CardNameEmptyMessage = "Card name must not be empty";

        public static string CardContentEmptyMessage = "Card content must not be empty";

        public static string dbConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\trangng\\Documents\\testdb.mdf;Integrated Security=True;Connect Timeout=30";
        
        public static string indexPage = "/TodoLists/Index";

    }

}
