using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace WebApp.Pages.Books
{
    public class UpdateBookModel : PageModel
    {
        public Books book = new Books();
        public string date;
        public void OnGet()
        {
            try
            {
                string BookCode = Request.Query["BookCode"];
                string connectionString = "Data Source=DESKTOP-A1NJHOG;Initial Catalog=LMS;Integrated Security=True;Encrypt=False;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"SELECT BOOK_CODE,BOOK_TITLE,AUTHOR,PUBLICATION,PRICE,PUBLISH_DATE FROM LMS_BOOK_DETAILS WHERE BOOK_CODE='{BookCode}'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Books book = new Books();
                                book.Id = reader.GetString(0);
                                book.BookName = reader.GetString(1);
                                book.Author = reader.GetString(2);
                                book.Publication = reader.GetString(3);
                                book.Price = reader.GetDouble(4);
                                book.Publish_Date = reader.GetDateTime(5);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public void OnPost()
        {
            book.BookName = Request.Form["name"];
            book.Author = Request.Form["author"];
            book.Publication = Request.Form["publication"];
            book.Publish_Date = Convert.ToDateTime(Request.Form["publishDate"]);
            book.Price = Convert.ToDouble(Request.Form["price"]);
            string BookCode = Request.Query["BookCode"];
            string connectionString = "Data Source=DESKTOP-A1NJHOG;Initial Catalog=LMS;Integrated Security=True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"UPDATE LMS_BOOK_DETAILS " +
                    $"SET BOOK_TITLE='{book.BookName}',AUTHOR='{book.Author}',PUBLICATION='{book.Publication}',PRICE={book.Price},PUBLISH_DATE='{book.Publish_Date}' " +
                    $"WHERE BOOK_CODE='{BookCode}'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
