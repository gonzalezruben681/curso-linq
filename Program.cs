
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
        ImprimirValores(queries.TresPrimerosDeLaColeccion());

        //si algun libro fue pubicado en 2005
        Console.WriteLine($"Algun libro fue pubicado en 2005? - {queries.SiAlgunLibroFuePublicado2005()}");
        
        //t odos los libros tienen Status 
        Console.WriteLine($"Todos los libros tienen status? - {queries.TodosLosLibrosTienenStatus()}");

        void ImprimirValores(IEnumerable<Book> listaDeLibros)
        {
            Console.WriteLine($"{formatoTexto}\n", "Titulo", "N. Paginas", "Fecha publicacion");
            foreach (var book in listaDeLibros)
            {
                Console.WriteLine($"{formatoTexto}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
            }
        }

//Toda la colección
        // ImprimirValores(queries.TodaLaColeccion());