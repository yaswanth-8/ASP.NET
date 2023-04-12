using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace WebApp.Pages.Books
{
    public class IndexBookModel : PageModel
    {
        public List<Books> BookList = new List<Books>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-A1NJHOG;Initial Catalog=LMS;Integrated Security=True;Encrypt=False;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                    using (SqlCommand command = new SqlCommand("ShowBook", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                               Books book = new Books();
                                book.Id = reader.GetString(0);
                                book.BookName = reader.GetString(1);
                                book.Author = reader.GetString(2);
                                book.Publication = reader.GetString(3);
                                book.Price = reader.GetDouble(4);

                                BookList.Add(book);
                            }
                        }
                    }
                }
            }
            catch(Exception ex) { 

            }
            
        }
    }
    public class Books {
        public string Id { get; set; }
        public string BookName { get; set; }
        public string category { get; set; }
        public string Author { get; set; }
        public string Publication { get; set; }
        public DateTime Publish_Date { get; set; }
        public string BookEdition { get; set; }
        public double Price { get; set; }

        public string RackNum { get; set; }
        public DateTime Date_Arrival { get; set; }
        public string SupplierId { get; set; }

    }

}
