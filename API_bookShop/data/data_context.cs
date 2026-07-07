using Microsoft.EntityFrameworkCore;

    public class data_context : DbContext
    {
        public DbSet<Book> books { get; set; }
        //string info_connect = @"SERVER=./SQLEXPRESS;" +
        //    "DATABASE=test_db;" +
        //    "Trusted_connection=True;" +
        //    "TrustServerCertificate=True;";
 
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"SERVER=.\SQLEXPRESS;
                    DATABASE=test_db;
                    Trusted_Connection=True;   
                    TrustServerCertificate=True;");
}
    //public void dispaly_book() 
    //{
    //    var book = books.ToList();
    //    foreach (Book tem in  book)
    //    {
    //        //Console.WriteLine(tem.id);
    //        Console.WriteLine(
    //          $"{tem.id,-4} | {tem.Title,-25} | {tem.Author,-20} | {tem.publishYear,-4} | {tem.Price}");
    //    }

    //}



}
