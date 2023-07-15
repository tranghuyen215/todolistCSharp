using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace todolist.Pages.TodoLists
{
    public class CreateModel : PageModel
    {
        public TodoCard cardInfo = new TodoCard();
        public String errorMessage = "";
        public String succeedMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            cardInfo.name = Request.Form["name"];
            cardInfo.content = Request.Form["content"];
            if (cardInfo.name.Length == 0)
            {
                errorMessage = DataProperties.CardNameEmptyMessage;
                return;
            }
            if (cardInfo.content.Length == 0)
            {
                errorMessage = DataProperties.CardContentEmptyMessage;
                return;
            }

            try
            {
                string dbConn = DataProperties.dbConnection;
                using (SqlConnection connection = new SqlConnection(
                dbConn))
                {
                    connection.Open();

                    String getCardSql = "Select * from Cards where name=@name";
                    using (SqlCommand command = new SqlCommand(getCardSql, connection))
                    {
                        command.Parameters.AddWithValue("@name", cardInfo.name);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                errorMessage = "Card "+ cardInfo.name+ " already exists";
                                return;
                            }
                        }
                    }

                    String insertCardSql = "INSERT INTO Cards " +
                        "(name, content) VALUES " +
                        "(@name,@content)";
                    using (SqlCommand command = new SqlCommand(insertCardSql, connection))
                    {
                        command.Parameters.AddWithValue("@name", cardInfo.name);
                        command.Parameters.AddWithValue("@content", cardInfo.content);
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            cardInfo.name = ""; cardInfo.content = "";

            Response.Redirect(DataProperties.indexPage);
        }
    }
}
