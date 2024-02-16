//Microsoft documentation:https://learn.microsoft.com/en-us/dotnet/api/system.collections.frozen?view=net-8.0 

// Suppose you have a list of configuration keys for an application.
// These keys should be unique and remain constant throughout the application's lifecycle.
using BenchmarkDotNet.Running;
using System.Collections.Frozen;


//==============FrozenSet================

var configKeys = new List<string>{ "ApiKey", "ApiSecret", "DatabaseConnectionString" };
var frozenSet = configKeys.ToFrozenSet();

// Checking if the 'ApiKey' exists in the FrozenSet
Console.WriteLine(frozenSet.Contains("ApiKey"));

// Compile-time error when trying to add or remove items from the FrozenSet
// Error: FrozenSet is immutable and cannot be modified.



//=============FrozenDictionary================
// Initialize application settings with default values.
// These settings are read-only and loaded at application start.
var appSettings = new Dictionary<string, object>
{
    { "MaxConcurrentConnections", 100 },
    { "EnableLogging", true },
    { "LogFilePath", "/var/log/app.log" }
};

var frozenAppSettings = appSettings.ToFrozenDictionary();

// Accessing setting is straightforward and fast, but trying to modify the dictionary
// (e.g., frozenAppSettings["EnableLogging"] = false) will cause a compile-time error.

// Accessing the 'MaxConcurrentConnections' setting
Console.WriteLine(frozenAppSettings["MaxConcurrentConnections"]);


// Compile-time error when attempting to modify the FrozenDictionary
// Error: FrozenDictionary is immutable and cannot be modified.