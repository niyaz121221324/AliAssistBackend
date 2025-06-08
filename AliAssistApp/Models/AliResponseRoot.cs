using System.Text.Json.Serialization;

namespace AliAssistApp.Models;

public class AliResponseRoot
{
    [JsonPropertyName("current_record_count")]
    public int CurrentRecordCount { get; set; }

    [JsonPropertyName("total_record_count")]
    public int TotalRecordCount { get; set; }

    [JsonPropertyName("current_page_no")]
    public int CurrentPageNo { get; set; }

    [JsonPropertyName("products")]
    public ProductsContainer Products { get; set; }
}

public class ProductsContainer
{
    [JsonPropertyName("product")]
    public List<ProductItem> Product { get; set; }
}

public class ProductItem
{
    [JsonPropertyName("app_sale_price")]
    public string AppSalePrice { get; set; }

    [JsonPropertyName("original_price")]
    public string OriginalPrice { get; set; }

    [JsonPropertyName("product_detail_url")]
    public string ProductDetailUrl { get; set; }

    [JsonPropertyName("product_small_image_urls")]
    public ProductSmallImageUrls ProductSmallImageUrls { get; set; }

    [JsonPropertyName("second_level_category_name")]
    public string SecondLevelCategoryName { get; set; }

    [JsonPropertyName("target_sale_price")]
    public string TargetSalePrice { get; set; }

    [JsonPropertyName("second_level_category_id")]
    public long SecondLevelCategoryId { get; set; }

    [JsonPropertyName("discount")]
    public string Discount { get; set; }

    [JsonPropertyName("product_main_image_url")]
    public string ProductMainImageUrl { get; set; }

    [JsonPropertyName("first_level_category_id")]
    public long FirstLevelCategoryId { get; set; }

    [JsonPropertyName("target_sale_price_currency")]
    public string TargetSalePriceCurrency { get; set; }

    [JsonPropertyName("target_app_sale_price_currency")]
    public string TargetAppSalePriceCurrency { get; set; }

    [JsonPropertyName("tax_rate")]
    public string TaxRate { get; set; }

    [JsonPropertyName("original_price_currency")]
    public string OriginalPriceCurrency { get; set; }

    [JsonPropertyName("shop_url")]
    public string ShopUrl { get; set; }

    [JsonPropertyName("target_original_price_currency")]
    public string TargetOriginalPriceCurrency { get; set; }

    [JsonPropertyName("product_id")]
    public long ProductId { get; set; }

    [JsonPropertyName("target_original_price")]
    public string TargetOriginalPrice { get; set; }

    [JsonPropertyName("product_video_url")]
    public string ProductVideoUrl { get; set; }

    [JsonPropertyName("first_level_category_name")]
    public string FirstLevelCategoryName { get; set; }

    [JsonPropertyName("sku_id")]
    public long SkuId { get; set; }

    [JsonPropertyName("shop_name")]
    public string ShopName { get; set; }

    [JsonPropertyName("sale_price")]
    public string SalePrice { get; set; }

    [JsonPropertyName("product_title")]
    public string ProductTitle { get; set; }

    [JsonPropertyName("hot_product_commission_rate")]
    public string HotProductCommissionRate { get; set; }

    [JsonPropertyName("shop_id")]
    public long ShopId { get; set; }

    [JsonPropertyName("app_sale_price_currency")]
    public string AppSalePriceCurrency { get; set; }

    [JsonPropertyName("sale_price_currency")]
    public string SalePriceCurrency { get; set; }

    [JsonPropertyName("lastest_volume")]
    public int LastestVolume { get; set; }

    [JsonPropertyName("target_app_sale_price")]
    public string TargetAppSalePrice { get; set; }

    [JsonPropertyName("commission_rate")]
    public string CommissionRate { get; set; }
}

public class ProductSmallImageUrls
{
    [JsonPropertyName("string")]
    public List<string> String { get; set; }
}
