using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace WebApp.Pages.Books
{
   
    public class CreateBookModel : PageModel
    {
        public string message = "";
        Books book = new Books();
        public void OnGet()
        {
           
        }

        public void OnPost()
        {
            book.Id = Request.Form["id"];
            book.BookName = Request.Form["name"];
            book.category = Request.Form["category"];
            book.Author = Request.Form["author"];
            book.Publication = Request.Form["publication"];
            book.Publish_Date =Convert.ToDateTime(Request.Form["publishDate"]);
            book.BookEdition = Request.Form["bookEdition"];
            book.Price =Convert.ToDouble( Request.Form["price"]);
            book.RackNum = "A2";
            book.Date_Arrival = Convert.ToDateTime("2023-08-08");
            book.SupplierId = "S04";
            try
            {
                string connectionString = "Data Source=DESKTOP-A1NJHOG;Initial Catalog=LMS;Integrated Security=True;Encrypt=False;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"INSERT INTO LMS_BOOK_DETAILS " +
                        $"VALUES ('{book.Id}','{book.BookName}','{book.category}','{book.Author}','{book.Publication}'," +
                        $"'{book.Publish_Date}',{book.BookEdition},{book.Price}," +
                        $"'{book.RackNum}','{book.Date_Arrival}','{book.SupplierId}' )";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                message = "book added successfully";
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message = "error in adding book";
            }
        }
    }
}
