namespace WPF_CoronavirusChart.Services.ApiModel
{
    public class APICountryInfo
    {
        public int Id { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        //public long Lat { get; set; }
        //public long Long { get; set; }
        public string Flag { get; set; }
    }
}

/*
 *  "countryInfo": {
      "_id": 840,
      "iso2": "US",
      "iso3": "USA",
      "lat": 38,
      "long": -97,
      "flag": "https://disease.sh/assets/img/flags/us.png"
 */