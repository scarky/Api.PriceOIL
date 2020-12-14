# Api.PriceOil
RestFul NetCore for get Oil price with range date .
this is compile with VSS2019 , framework NETCORE 3.1

- For your tests you can use Swagger ui, entering the date range :

this exemple for request 
HTTPGET
https://localhost:44374/api/1/PriceOil/GetOilPriceTrend?_start_date=2020-01-02&_end_date=2020-01-05

- The request only works if the dates are received in iso8086 format(YYYY-MM-DD) 

- This is the response :
{
  "errors": [
    {
      "code": "string",
      "description": "string"
    }
  ],
  "prices": [
    {
      "price": 0,
      "date": "2020-12-14T14:39:05.829Z"
    }
  ]
}

- the application takes all the quotes by querying the available service , you can see in AppSettings :
 "UrlPath": {
    "path_oil": "https://datahub.io/core/oil-prices/r/brent-daily.json"
  }



- The logs of application is configured from AppSettings ,REMEBER CHANGE PATH :

"Logging": {
    "LogLevel": {
      "Default": "Information"
    },
    "File": {
      "Path": "C:\\TMP\\logs.txt",
      "Append": "True",
      "FileSizeLimitBytes": 0, // use to activate rolling file behaviour
      "MaxRollingFiles": 0 // use to specify max number of log files
    }
  }
