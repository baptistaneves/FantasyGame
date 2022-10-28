namespace FantasyGame.Application.Pagination
{
    public class PaginationParams
    {
        private const int _maxItemsPerPage = 10;
        private int itemsPerPage = 10;

        public int CurrentPage { get; set; } = 1;
        public int ItemsPerPage
        {
            get => itemsPerPage;
            set => itemsPerPage = (value > _maxItemsPerPage) ? _maxItemsPerPage : value;
        }
    }
}
