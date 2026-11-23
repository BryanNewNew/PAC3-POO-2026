namespace Planillas.API.Dtos
{
    public class PageDto<T>
    {
        public int CurrentPage { get; set; }//pagina en la que se encuentra
        public bool HasNextPage { get; set; }//tiene siguiente pagina

        public bool HasPreviousPage { get; set; }//tiene anterior pagina

        public int SizePage { get; set; }//cuantos items contiene cada pagina

        public int TotalItems { get; set; }//cantidad de registros

        public int TotalPages { get; set; }//totalidad de paginas

        public T? Items { get; set; }//listado de cualquier cosa
    }
}