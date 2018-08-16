namespace PledgeKit.Core.Shared
{
    public interface IPageable
    {
        int PageSize { get; set; }
        int PageNumber { get; set; }
    }
}