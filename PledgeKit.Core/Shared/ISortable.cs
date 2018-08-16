namespace PledgeKit.Core.Shared
{
    public interface ISortable
    {
        bool Descending { get; set; }
        string SortColumn { get; set; }
    }
}
