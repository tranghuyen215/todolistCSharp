using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace todolist.Pages.TodoLists
{
    static class Globals
    {
        // global string
        public static String ConnectionString;
    }
    public class IndexModel : PageModel
    {
        public List<TodoCard> listCards = new List<TodoCard>();
        public void OnGet()
        {
            try
            {
                Globals.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\trangng\\Documents\\testdb.mdf;Integrated Security=True;Connect Timeout=30";
                using (SqlConnection connection = new SqlConnection(
                Globals.ConnectionString))
                {
                    connection.Open();
                    String sql = "Select * from Cards";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while ( reader.Read())
                            {
                                TodoCard cardInfo = new TodoCard();
                                cardInfo.id = "" + reader.GetInt32(0);
                                cardInfo.name = reader.GetString(1);
                                cardInfo.content = reader.GetString(2);
                                cardInfo.create_at = reader.GetDateTime(3).ToString();

                                listCards.Add(cardInfo);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
        }
    }

    public class TodoCard
    {
        public string id;
        public string name;
        public string content;
        public string create_at;

    }
}
