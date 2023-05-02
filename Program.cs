using Neo4j.Driver;

var uri = Environment.GetEnvironmentVariable("NEO4J_URI");
var password = Environment.GetEnvironmentVariable("NEO4J_PWD");
var username = "moviesuser";

var driver = GraphDatabase.Driver(uri, AuthTokens.Basic(username, password));

var records = await driver.ExecutableQuery("MATCH(m:Movie) return m.title as moviename LIMIT 1;").ExecuteAsync();

Console.WriteLine(records.Result[0].Values["moviename"]);