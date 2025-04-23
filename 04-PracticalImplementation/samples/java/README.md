# Sample

This is a JavaScript sample for an MCP Server

Here's an example of a tool registration where we register a tool:

```java
// Sync tool specification
var schema = """
            {
              "type" : "object",
              "id" : "urn:jsonschema:Operation",
              "properties" : {
                "operation" : {
                  "type" : "string"
                },
                "a" : {
                  "type" : "number"
                },
                "b" : {
                  "type" : "number"
                }
              }
            }
            """;
var syncToolSpecification = new McpServerFeatures.SyncToolSpecification(
    new Tool("calculator", "Basic calculator", schema),
    (exchange, arguments) -> {
        // Tool implementation
        return new CallToolResult(result, false);
    }
);
```

## Install

Run the following command:

```bash
mvn install
```

## Run

```bash
mvn exec:java -Dexec.mainClass="com.example.App"
```