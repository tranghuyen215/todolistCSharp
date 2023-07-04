using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace todolist.Pages.TodoLists
{
    public class EditModel : PageModel
    {
        public TodoCard cardInfo = new TodoCard();
        public String errorMessage = "";
        public String succeedMessage = "";

        public void OnGet()
        {
            String id = Request.Query["id"];
            try
            {
                using (SqlConnection connection = new SqlConnection(
                Globals.ConnectionString))
                {
                    connection.Open();
                    String sql = "Select * from Cards where id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id",id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cardInfo.id = "" + reader.GetInt32(0);
                                cardInfo.name = reader.GetString(1);
                                cardInfo.content = reader.GetString(2);
                                cardInfo.create_at = reader.GetDateTime(3).ToString();

                            }
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost()
        {
            cardInfo.id = Request.Form["id"];
            cardInfo.name = Request.Form["name"];
            cardInfo.content = Request.Form["content"];
            if (cardInfo.name.Length == 0)
            {
                errorMessage = "Card name must not be empty";
                return;
            }
            if (cardInfo.content.Length == 0)
            {
                errorMessage = "Card content must not be empty";
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(
                Globals.ConnectionString))
                {
                    connection.Open();

                    String sql = "Select * from Cards where name=@name and id!=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", cardInfo.name);
                        command.Parameters.AddWithValue("@id", cardInfo.id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                errorMessage = "Card " + cardInfo.name + " already exists";
                                return;
                            }
                        }
                    }


                    sql = "Update Cards " +
                                "SET name=@name, content=@content " +
                                "WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", cardInfo.name);
                        command.Parameters.AddWithValue("@content", cardInfo.content);
                        command.Parameters.AddWithValue("@id", cardInfo.id);
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            succeedMessage = "Card updated successfully";

            Response.Redirect("/TodoLists/Index");
        }
    }
}
