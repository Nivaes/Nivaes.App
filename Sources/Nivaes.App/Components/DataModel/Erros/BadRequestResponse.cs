namespace Nivaes
{
    public class BadRequestResponse
    {
        public IEnumerable<(string, string[])>? Errors { get; set; }

        public string? Title { get; set; }

        public string? Status { get; set; }
    }
}
