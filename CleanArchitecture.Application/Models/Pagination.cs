namespace CleanArchitecture.Application.Models
{
    public class Pagination<T>
    {
        public int Index { get; set; }

        public int Size { get; set; }

        public int Pages { get; set; }

        public int Count { get; set; }

        public IReadOnlyList<T> Data { get; set; }
    }
}
