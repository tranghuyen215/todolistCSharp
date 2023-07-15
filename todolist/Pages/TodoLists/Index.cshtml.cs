using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace todolist.Pages.TodoLists
{

    public class IndexModel : PageModel
    {
        public List<TodoCard> listCards = new List<TodoCard>();
        public void OnGet()
        {
            try
            {

                string dbConn = DataProperties.dbConnection;
                using (SqlConnection connection = new SqlConnection(
                dbConn))
                {
                    connection.Open();
                    String getCardsSql = "Select * from Cards";
                    using (SqlCommand command = new SqlCommand(getCardsSql, connection))
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
