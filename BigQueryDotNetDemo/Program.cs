using Google.Cloud.BigQuery.V2;
using Google.Apis.Auth.OAuth2;

class Program
{
    static async Task Main(string[] args)
    {
        // Path to the JSON key file
        string jsonKeyFilePath = @"path\to\your\service-account-key.json";

        // Load the JSON key file and create a credentials object
        GoogleCredential credentials;
        using (var jsonStream = new FileStream(jsonKeyFilePath, FileMode.Open, FileAccess.Read))
        {
            credentials = GoogleCredential.FromStream(jsonStream);
        }

        var client = BigQueryClient.Create(projectId: "your-project-id", credentials);

        var options = new QueryOptions();
        options.Priority = QueryPriority.Batch;

        var queryResultOptions = new GetQueryResultsOptions();
        queryResultOptions.Timeout = TimeSpan.FromSeconds(10);

        var bigQueryParameters = new List<BigQueryParameter>();

        var query = "SELECT * FROM your_dataset.your_table";
        var result = await client.ExecuteQueryAsync(query, bigQueryParameters, options, queryResultOptions);

        // Process the query result...
    }
}
