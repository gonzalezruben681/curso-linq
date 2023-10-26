
LinqQueries queries = new LinqQueries();


string formatoTexto = "{0, -60} {1, 15} {2, 15}";

//Libros despues del 2000
// ImprimirValores(queries.LibrosDespuesdel2000());

//Libros que tienen mas de 250 pags y tienen en el titulo la palabra in action
// ImprimirValores(queries.LibrosConMasde250PagConPalabrasInAction());

//Libros de Python 
// ImprimirValores(queries.LibrosdePython());

//Libros de Java ordenados por nombre 
// ImprimirValores(queries.LibrosdeJavaAscendente());

//Libros de 450 paginas ordenados por cantidad de pag. 
// ImprimirValores(queries.Librosmasde450PagPorNumPagDescendente());

//los 3 libros de Java publicados recientemente
// ImprimirValores(queries.TresLibrosOrdenadosPorFecha());

// tercer y cuarto libro con mas de 400 páginas
// ImprimirValores(queries.TerceryCuartoLibroDeMas400Pag());

//tres primeros libros filtrados con Select
// ImprimirValores(queries.TresPrimerosDeLaColeccion());

//libro con menor número de páginas
var libro = queries.LibroConMenorNumeroDePaginas();
// Console.WriteLine($"libro con menor número de páginas: {libro.Title} ,{libro.PageCount}");

//libro con fecha de publicación mas reciente
var libroMasReciente = queries.LibroConMenorNumeroDePaginas();
// Console.WriteLine($"libro con fecha de publicación mas reciente: {libroMasReciente.Title} ,{libroMasReciente.PublishedDate.ToShortDateString()}");

//Libros publicados después del 2015
// Console.WriteLine(queries.TitulosLibrosDespuesDel2015Concatenados());

//Suma de paginas de libros entre 0 y 500
// Console.WriteLine($"Suma total de páginas {queries.SumaDeTodasLasPagsLibrosEntre0y500()}");

//cantidad de libros que tienen entre 200 y 500 paginas
// Console.WriteLine($"Cantidad de libros que tienen entre 200 y 500: pag {queries.CantidadDeLibros200y500Pag()}");

//Fecha de publicación menor de todos los libros
// Console.WriteLine($"Fecha de publicación menor: {queries.FechaDePublicacionMenor()}");

//Mayor número de páginas del libro 
// Console.WriteLine($"Libro con mayor número de páginas: {queries.NumeroDePagLibroMayor()} paginas");

// el promedio de caracteres de los titulos de los libros
// Console.WriteLine($"Promedio caracteres de los titulos: {queries.PromedioCaracteresTitulo()}");

//si algun libro fue pubicado en 2005
// Console.WriteLine($"Algun libro fue pubicado en 2005? - {queries.SiAlgunLibroFuePublicado2005()}");

//t odos los libros tienen Status 
// Console.WriteLine($"Todos los libros tienen status? - {queries.TodosLosLibrosTienenStatus()}");

//Libros publicados a partir del 2000 agrupados por año
ImprimirGrupo(queries.LibrosDespuesDel2000AgrupadosPorYear());

//Diccionarios de libros por agrupados por primera letra del titulo
var diccionarioLookup = queries.DiccionariosDeLibrosPorLetra();
ImprimirDiccionario(diccionarioLookup, 'A');

ImprimirValores(queries.LibrosDespuesdel2005conmasde500Pags());

void ImprimirValores(IEnumerable<Book> listaDeLibros)
{
    Console.WriteLine($"{formatoTexto}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var book in listaDeLibros)
    {
        Console.WriteLine($"{formatoTexto}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
{
    foreach (var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
        }
    }
}

void ImprimirDiccionario(ILookup<char, Book> listBooks, char letter)
{
    char letterUpper = Char.ToUpper(letter);
    if (listBooks[letterUpper].Count() == 0)
    {
        Console.WriteLine($"No hay libros que inicien con la letra '{letterUpper}'");
    } 
    else 
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Título", "Nro. Páginas", "Fecha de Publicación");
        foreach (var book in listBooks[letterUpper])
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
        }
    }

}



//Toda la colección
// ImprimirValores(queries.TodaLaColeccion());