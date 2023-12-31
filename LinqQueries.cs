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
        return from l in librosCollection where l.PublishedDate.Year > 2000 select l;

    }
    public IEnumerable<Book> LibrosConMasde250PagConPalabrasInAction()
    {
        // extension method
        // return librosCollection.Where(p=> p.PageCount > 250 && p.Title!.Contains("in Action"));

        //query expresion
        return from l in librosCollection where l.PageCount > 250 && l.Title!.Contains("in Action") select l;
    }

    public bool TodosLosLibrosTienenStatus()
    {
        return librosCollection.All(p => p.Status != string.Empty);
    }

    public bool SiAlgunLibroFuePublicado2005()
    {
        return librosCollection.Any(p => p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosdePython()
    {
        return librosCollection.Where(p => p.Categories!.Contains("Python"));
    }

    public IEnumerable<Book> LibrosdeJavaAscendente()
    {
        return librosCollection.Where(p => p.Categories!.Contains("Java")).OrderBy(p => p.Title);
    }
    public IEnumerable<Book> Librosmasde450PagPorNumPagDescendente()
    {
        return librosCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Book> TresLibrosOrdenadosPorFecha()
    {
        return librosCollection.
        Where(p => p.Categories!.Contains("Java"))
        .OrderBy(p => p.PublishedDate)
        .TakeLast(3);
    }

    public IEnumerable<Book> TerceryCuartoLibroDeMas400Pag()
    {
        return librosCollection.Where(p => p.PageCount > 400)
        .Take(5) // tomar los primeros 5
        .Skip(2); // omitir los primeros 2
    }


    public IEnumerable<Book> TresPrimerosDeLaColeccion()
    {
        return librosCollection.Take(3)
        .Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });  //Tipo  
    }

    public int CantidadDeLibros200y500Pag()
    {
        return librosCollection.Count(p => p.PageCount >= 200 && p.PageCount <= 500);
        // return librosCollection.LongCount(p=> p.PageCount >=200 && p.PageCount<=500);
    }

    public DateTime FechaDePublicacionMenor()
    {
        return librosCollection.Min(p => p.PublishedDate);
    }

    public int NumeroDePagLibroMayor()
    {
        return librosCollection.Max(p => p.PageCount);
    }

    public Book LibroConMenorNumeroDePaginas()
    {
        return librosCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount)!;
    }

    public Book LibroFechaPublicacionMasReciente()
    {
        return librosCollection.MaxBy(p => p.PublishedDate)!;
    }

    public int SumaDeTodasLasPagsLibrosEntre0y500()
    {
        return librosCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
    }

    public string TitulosLibrosDespuesDel2015Concatenados()
    {
        return librosCollection
        .Where(p => p.PublishedDate.Year > 2015)
        .Aggregate("", (TitulosLibros, next) =>
        {
            if (TitulosLibros != string.Empty)
                TitulosLibros += "-" + next.Title;
            else
                TitulosLibros += next.Title;
            
            return TitulosLibros;
        });
    }

    public double PromedioCaracteresTitulo()
    {
        return librosCollection.Average( p => (p.Title ?? "").Length);
    } 

    public IEnumerable<IGrouping<int, Book>> LibrosDespuesDel2000AgrupadosPorYear()
    {
        return librosCollection.Where(p=> p.PublishedDate.Year >= 2000).GroupBy(p=> p.PublishedDate.Year);
    }

    public ILookup<char, Book> DiccionariosDeLibrosPorLetra()
    {
        return librosCollection.ToLookup(p=> p.Title![0], p=> p);
    }

    public IEnumerable<Book> LibrosDespuesdel2005conmasde500Pags()
    {
        var LibrosDespuesdel2005 = librosCollection.Where(p=> p.PublishedDate.Year > 2005);
        var librosConMasde500pag = librosCollection.Where(p=> p.PageCount > 500);
        return LibrosDespuesdel2005.Join(librosConMasde500pag, p=> p.Title, x=> x.Title,(p,x)=> p);
    }
}