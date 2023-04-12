using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace WebApp.Pages.Books
{
    public class DeleteBookModel : PageModel
    {
        public void OnGet()
        {
           
            try
            {
                string BookCode = Request.Query["BookCode"];
                string connectionString = "Data Source=DESKTOP-A1NJHOG;Initial Catalog=LMS;Integrated Security=True;Encrypt=False;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"DELETE FROM LMS_BOOK_DETAILS WHERE BOOK_CODE='{BookCode}'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            Response.Redirect("../Books/IndexBook");
        }
    }
}
