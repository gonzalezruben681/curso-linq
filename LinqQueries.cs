public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();
    public LinqQueries()
    {
        using StreamReader reader = new("books.json");
        string json = reader.ReadToEnd();
        this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
        public IEnumerable<Book> TodaLaColeccion() 
        {
            return librosCollection;
        }
        public IEnumerable<Book> LibrosDespuesdel2000() 
        {
            // extension method
            // return librosCollection.Where( p=> p.PublishedDate.Year > 2000);

            //query expresion
            return from l in librosCollection  where l.PublishedDate.Year > 2000 select l;

        }
        public IEnumerable<Book> LibrosConMasde250PagConPalabrasInAction()
        {
            // extension method
            // return librosCollection.Where(p=> p.PageCount > 250 && p.Title!.Contains("in Action"));
            
            //query expresion
            return from l in librosCollection  where l.PageCount > 250 && l.Title!.Contains("in Action") select l;
        } 

        public bool TodosLosLibrosTienenStatus() 
        {
            return librosCollection.All(p=> p.Status != string.Empty);
        }

        public bool SiAlgunLibroFuePublicado2005()
        {
            return librosCollection.Any(p=> p.PublishedDate.Year == 2005);
        }

        public IEnumerable<Book> LibrosdePython()
        {
            return librosCollection.Where(p=> p.Categories!.Contains("Python"));
        }

        public IEnumerable<Book> LibrosdeJavaAscendente() 
        {
            return librosCollection.Where(p=> p.Categories!.Contains("Java")).OrderBy(p=> p.Title);
        }
        public IEnumerable<Book> Librosmasde450PagPorNumPagDescendente() 
        {
            return librosCollection.Where(p=> p.PageCount > 450).OrderByDescending(p=> p.PageCount);
        }

        public IEnumerable<Book> TresLibrosOrdenadosPorFecha()
        {
            return librosCollection.
            Where(p=> p.Categories!.Contains("Java"))
            .OrderBy(p=> p.PublishedDate)
            .TakeLast(3);
        }

        public IEnumerable<Book> TerceryCuartoLibroDeMas400Pag()
        {
            return librosCollection.Where(p=> p.PageCount > 400)
            .Take(5) // tomar los primeros 5
            .Skip(2); // omitir los primeros 2
        }

        public IEnumerable<Book> TresPrimerosDeLaColeccion() 
        {
            return librosCollection.Take(3)
            .Select(p=> new Book() {Title =  p.Title, PageCount = p.PageCount});  //Tipo  
        }
}