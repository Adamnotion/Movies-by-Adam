using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies.Services.MovieAPI.Migrations
{
    /// <inheritdoc />
    public partial class addMovieAndSeedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Description", "ImageUrl", "Name", "Price", "category" },
                values: new object[,]
                {
                    { 1, "A thief who enters the dreams of others to steal secrets from their subconscious.", "https://placehold.co/603x403", "Inception", 5.0, "Sci-Fi" },
                    { 2, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "https://placehold.co/603x403", "The Shawshank Redemption", 7.0, "Drama" },
                    { 4, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "https://placehold.co/603x403", "Pulp Fiction", 6.0, "Crime" },
                    { 5, "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", "https://placehold.co/603x403", "Forrest Gump", 4.0, "Drama" },
                    { 6, "A computer programmer discovers a dystopian world inside a simulation and joins a rebellion to overthrow the machines that control it.", "https://placehold.co/603x403", "The Matrix", 10.5, "Sci-Fi" },
                    { 7, "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "https://placehold.co/603x403", "Schindler's List", 2.5, "Drama" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
