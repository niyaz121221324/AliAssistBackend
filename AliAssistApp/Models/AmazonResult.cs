using System.Net;

namespace AliAssistApp.Models;

public class AmazonResult
{
    public string ResponseStatus { get; set; }
    public string ResponseMessage { get; set; }
    public string SortStrategy { get; set; }
    public string DomainCode { get; set; }
    public string Keyword { get; set; }
    public int NumberOfProducts { get; set; }
    public int NumberOfSponsoredProducts { get; set; }
    public int ResultCount { get; set; }
    public string SelectedCategory { get; set; }
    public List<object> FoundSponsoredProducts { get; set; }
    public List<string> FoundProducts { get; set; }
    public List<SearchProductDetail> SearchProductDetails { get; set; }
    public List<string> Categories { get; set; }
    public StarFilterParam StarFilterParam { get; set; }
    public List<SimilarKeyword> SimilarKeywords { get; set; }
}

public class SearchProductDetail
{
    private string _dpUrl;
    
    public string ProductDescription { get; set; }
    public string Asin { get; set; }
    public int CountReview { get; set; }
    public string ImgUrl { get; set; }
    public decimal Price { get; set; }
    public decimal RetailPrice { get; set; }
    public string ProductRating { get; set; }
    public bool Prime { get; set; }
    public object Series { get; set; }
    public object DeliveryMessage { get; set; }
    public List<object> Variations { get; set; }

    public string DpUrl
    {
        get => _dpUrl;
        set => _dpUrl = string.IsNullOrEmpty(value) ? null : WebUtility.UrlDecode(value);
    }
}

public class StarFilterParam
{
    public string OneStarAndUp { get; set; }
    public string ThreeStarsAndUp { get; set; }
    public string TwoStarsAndUp { get; set; }
    public string FourStarsAndUp { get; set; }
}

public class SimilarKeyword
{
    public string Keyword { get; set; }
    public string Url { get; set; }
}
