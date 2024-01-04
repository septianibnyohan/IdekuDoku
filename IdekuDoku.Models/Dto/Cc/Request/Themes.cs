using Newtonsoft.Json;

namespace IdekuDoku.Models.Dto.Cc.Request;

public class Themes
{
    [JsonProperty("language")]
    public string? Language { get; set; }
    
    [JsonProperty("background_color")]
    public string? BackgroundColor { get; set; }
    
    [JsonProperty("font_color")]
    public string? FontColor { get; set; }
    
    [JsonProperty("button_background_color")]
    public string? ButtonBackgroundColor { get; set; }
    
    [JsonProperty("button_font_color")]
    public string? ButtonFontColor { get; set; }
}