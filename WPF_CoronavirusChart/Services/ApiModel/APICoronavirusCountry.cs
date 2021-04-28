using System.Text.Json.Serialization;

namespace WPF_CoronavirusChart.Services.ApiModel
{
    public class APICoronavirusCountry
    {
        //public long Updated { get; set; }
        public string Country { get; set; }
        public long Cases { get; set; }
        //public int TodayCases { get; set; }
        //public int Deaths { get; set; }
        //public int TodayDeaths { get; set; }
        //public int Recovered { get; set; }
        //public int TodayRecovered { get; set; }
        //public int Active { get; set; }
        //public int Critical { get; set; }
        //public int CasesPerOneMillion { get; set; }
        //public int DeathsPerOneMillion { get; set; }
        //public int Tests { get; set; }
        //public int TestsPerOneMillion { get; set; }
        //public long Population { get; set; }
        //public string Continent { get; set; }
        //public int OneCasePerPeople { get; set; }
        //public int OneDeathPerPeople { get; set; }
        //public int OneTestPerPeople { get; set; }
        //public double ActivePerOneMillion { get; set; }
        //public double RecoveredPerOneMillion { get; set; }
        //public double CriticalPerOneMillion { get; set; }
        [JsonPropertyName("CountryInfo")]
        public APICountryInfo APICountryInfo { get; set; }
    }
}

/* restapi接口返回数据示例
[{
    "updated": 1604491065998,
    "country": "USA",
    "countryInfo": {
      "_id": 840,
      "iso2": "US",
      "iso3": "USA",
      "lat": 38,
      "long": -97,
      "flag": "https://disease.sh/assets/img/flags/us.png"
    },
    "cases": 9694176,
    "todayCases": 1648,
    "deaths": 238656,
    "todayDeaths": 15,
    "recovered": 6237271,
    "todayRecovered": 1101,
    "active": 3218249,
    "critical": 17816,
    "casesPerOneMillion": 29228,
    "deathsPerOneMillion": 720,
    "tests": 150852829,
    "testsPerOneMillion": 454829,
    "population": 331669237,
    "continent": "North America",
    "oneCasePerPeople": 34,
    "oneDeathPerPeople": 1390,
    "oneTestPerPeople": 2,
    "activePerOneMillion": 9703.19,
    "recoveredPerOneMillion": 18805.7,
    "criticalPerOneMillion": 53.72
  },
  {......}
]
*/