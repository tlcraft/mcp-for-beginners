<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6e190a963029f156b7ecffad7093b8ce",
  "translation_date": "2025-05-17T15:50:03+00:00",
  "source_file": "06-CommunityContributions/README.md",
  "language_code": "ne"
}
-->
# समुदाय र योगदानहरू

## अवलोकन

यस पाठले MCP समुदायसँग कसरी संलग्न हुने, MCP पारिस्थितिकी तन्त्रमा योगदान गर्ने, र सहकारी विकासको लागि उत्तम अभ्यासहरू पालना गर्ने कुरामा केन्द्रित छ। खुला स्रोत MCP परियोजनाहरूमा कसरी भाग लिन सकिन्छ भन्ने बुझ्न यो प्रविधिको भविष्यलाई आकार दिन चाहनेहरूको लागि अत्यावश्यक छ।

## सिकाइका उद्देश्यहरू

यस पाठको अन्त्यमा, तपाईंले निम्न कार्यहरू गर्न सक्नुहुनेछ:
- MCP समुदाय र पारिस्थितिकी तन्त्रको संरचना बुझ्न
- MCP समुदायका फोरम र छलफलहरूमा प्रभावकारी रूपमा भाग लिन
- MCP खुला स्रोत रिपोजिटोरीहरूमा योगदान गर्न
- अनुकूलित MCP उपकरणहरू सिर्जना र साझेदारी गर्न
- MCP विकास र सहकार्यको लागि उत्तम अभ्यासहरू पालना गर्न

## MCP समुदाय पारिस्थितिकी तन्त्र

MCP पारिस्थितिकी तन्त्रमा प्रोटोकललाई अघि बढाउन सँगै काम गर्ने विभिन्न घटकहरू र सहभागीहरू छन्।

### प्रमुख सामुदायिक घटकहरू

1. **कोर प्रोटोकल मर्मतकर्ता**: Microsoft र अन्य संस्थाहरू जसले कोर MCP विशिष्टताहरू र सन्दर्भ कार्यान्वयनहरू मर्मत गर्छन्
2. **उपकरण विकासकर्ता**: व्यक्तिहरू र टोलीहरू जसले MCP उपकरणहरू सिर्जना गर्छन्
3. **एकीकरण प्रदायकहरू**: कम्पनीहरू जसले आफ्ना उत्पादनहरू र सेवाहरूमा MCP एकीकरण गर्छन्
4. **अन्तिम प्रयोगकर्ता**: विकासकर्ता र संस्थाहरू जसले आफ्ना अनुप्रयोगहरूमा MCP प्रयोग गर्छन्
5. **योगदानकर्ता**: कोड, दस्तावेज, वा अन्य स्रोतहरूमा योगदान गर्ने सामुदायिक सदस्यहरू

### सामुदायिक स्रोतहरू

#### आधिकारिक च्यानलहरू

- [MCP GitHub रिपोजिटोरी](https://github.com/modelcontextprotocol)
- [MCP दस्तावेज](https://modelcontextprotocol.io/)
- [MCP विशिष्टता](https://spec.modelcontextprotocol.io/)
- [GitHub छलफलहरू](https://github.com/orgs/modelcontextprotocol/discussions)

#### समुदायद्वारा सञ्चालित स्रोतहरू

- भाषा-विशिष्ट SDK कार्यान्वयनहरू
- सर्भर कार्यान्वयनहरू र उपकरण पुस्तकालयहरू
- ब्लग पोस्टहरू र ट्युटोरियलहरू
- सामुदायिक फोरमहरू र सामाजिक मिडिया छलफलहरू

## MCP मा योगदान

### योगदानका प्रकारहरू

MCP पारिस्थितिकी तन्त्र विभिन्न प्रकारका योगदानहरूलाई स्वागत गर्छ:

1. **कोड योगदानहरू**:
   - कोर प्रोटोकल सुधारहरू
   - बग फिक्सहरू
   - उपकरण कार्यान्वयनहरू
   - विभिन्न भाषाहरूमा क्लाइन्ट/सर्भर पुस्तकालयहरू

2. **दस्तावेज**:
   - अवस्थित दस्तावेज सुधार गर्दै
   - ट्युटोरियलहरू र मार्गदर्शिकाहरू सिर्जना गर्दै
   - दस्तावेज अनुवाद गर्दै
   - उदाहरणहरू र नमूना अनुप्रयोगहरू सिर्जना गर्दै

3. **सामुदायिक समर्थन**:
   - फोरमहरूमा प्रश्नहरूको उत्तर दिने
   - परीक्षण र समस्याहरू रिपोर्ट गर्ने
   - सामुदायिक कार्यक्रमहरूको आयोजना गर्ने
   - नयाँ योगदानकर्ताहरूलाई परामर्श दिने

### योगदान प्रक्रिया: कोर प्रोटोकल

कोर MCP प्रोटोकल वा आधिकारिक कार्यान्वयनहरूमा योगदान गर्न:

#### .NET उदाहरण: प्रोटोकल सुधार योगदान गर्ने

```csharp
// Example contribution to MCP protocol: Adding support for binary data streams
// This would be part of a pull request to the core MCP repository

namespace Microsoft.Mcp.Protocol
{
    // New interface for binary data handling in MCP
    public interface IBinaryDataHandler
    {
        /// <summary>
        /// Processes a binary data stream
        /// </summary>
        /// <param name="binaryDataStream">The binary data stream to process</param>
        /// <param name="metadata">Metadata about the binary data</param>
        /// <returns>A result indicating the processing outcome</returns>
        Task<BinaryProcessingResult> ProcessBinaryDataAsync(
            Stream binaryDataStream, 
            BinaryDataMetadata metadata);
    }
    
    // New metadata class for binary data
    public class BinaryDataMetadata
    {
        /// <summary>
        /// MIME type of the binary data
        /// </summary>
        public string ContentType { get; set; }
        
        /// <summary>
        /// Size of the binary data in bytes
        /// </summary>
        public long ContentLength { get; set; }
        
        /// <summary>
        /// Optional filename for the binary data
        /// </summary>
        public string Filename { get; set; }
        
        /// <summary>
        /// Additional metadata as key-value pairs
        /// </summary>
        public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
    }
    
    // Result class for binary processing
    public class BinaryProcessingResult
    {
        /// <summary>
        /// Whether the processing was successful
        /// </summary>
        public bool Success { get; set; }
        
        /// <summary>
        /// Any error message if processing failed
        /// </summary>
        public string ErrorMessage { get; set; }
        
        /// <summary>
        /// Results of the processing as key-value pairs
        /// </summary>
        public IDictionary<string, object> Results { get; set; } = new Dictionary<string, object>();
    }
}
```

#### Java उदाहरण: बग फिक्स योगदान गर्ने

```java
package com.mcp.tools;

// Original code with bug
public class ToolParameterValidator {
    public boolean validateParameters(Map<String, Object> parameters, Object schema) {
        if (schema == null) {
            return true; // No schema means no validation needed
        }
        
        // Bug: This doesn't properly validate nested objects
        // Original implementation:
        for (Map.Entry<String, Object> entry : parameters.entrySet()) {
            String key = entry.getKey();
            Object value = entry.getValue();
            
            if (!validateSingleParameter(key, value, schema)) {
                return false;
            }
        }
        
        return true;
    }
    
    // Other methods...
}

// Fixed implementation in a contribution
public class ToolParameterValidator {
    public boolean validateParameters(Map<String, Object> parameters, Object schema) {
        if (schema == null) {
            return true; // No schema means no validation needed
        }
        
        // Get required properties from schema
        List<String> required = new ArrayList<>();
        if (schema instanceof Map) {
            Map<String, Object> schemaMap = (Map<String, Object>) schema;
            if (schemaMap.containsKey("required") && schemaMap.get("required") instanceof List) {
                required = (List<String>) schemaMap.get("required");
            }
        }
        
        // Check for required properties
        for (String requiredProp : required) {
            if (!parameters.containsKey(requiredProp)) {
                return false; // Missing required property
            }
        }
        
        // Validate each parameter against schema
        for (Map.Entry<String, Object> entry : parameters.entrySet()) {
            String key = entry.getKey();
            Object value = entry.getValue();
            
            if (!validateSingleParameter(key, value, schema)) {
                return false;
            }
            
            // Handle nested objects recursively
            if (value instanceof Map && getPropertySchema(key, schema) instanceof Map) {
                Map<String, Object> nestedParams = (Map<String, Object>) value;
                Object nestedSchema = getPropertySchema(key, schema);
                
                if (!validateParameters(nestedParams, nestedSchema)) {
                    return false;
                }
            }
        }
        
        return true;
    }
    
    // Helper method to get schema for a specific property
    private Object getPropertySchema(String propertyName, Object schema) {
        // Implementation details
        return null; // Placeholder
    }
    
    // Other methods...
}
```

#### Python उदाहरण: मानक पुस्तकालयमा नयाँ उपकरण योगदान गर्ने

```python
# Example contribution: A CSV data processing tool for the MCP standard library

from mcp_tools import Tool, ToolRequest, ToolResponse, ToolExecutionException
import pandas as pd
import io
import json
from typing import Dict, Any, List, Optional

class CsvProcessingTool(Tool):
    """
    Tool for processing and analyzing CSV data.
    
    This tool allows models to extract information from CSV files,
    run basic analysis, and convert data between formats.
    """
    
    def get_name(self):
        return "csvProcessor"
        
    def get_description(self):
        return "Processes and analyzes CSV data"
    
    def get_schema(self):
        return {
            "type": "object",
            "properties": {
                "csvData": {
                    "type": "string", 
                    "description": "CSV data as a string"
                },
                "csvUrl": {
                    "type": "string",
                    "description": "URL to a CSV file (alternative to csvData)"
                },
                "operation": {
                    "type": "string",
                    "enum": ["summary", "filter", "transform", "convert"],
                    "description": "Operation to perform on the CSV data"
                },
                "filterColumn": {
                    "type": "string",
                    "description": "Column to filter by (for filter operation)"
                },
                "filterValue": {
                    "type": "string",
                    "description": "Value to filter for (for filter operation)"
                },
                "outputFormat": {
                    "type": "string",
                    "enum": ["json", "csv", "markdown"],
                    "default": "json",
                    "description": "Output format for the processed data"
                }
            },
            "oneOf": [
                {"required": ["csvData", "operation"]},
                {"required": ["csvUrl", "operation"]}
            ]
        }
    
    async def execute_async(self, request: ToolRequest) -> ToolResponse:
        try:
            # Extract parameters
            operation = request.parameters.get("operation")
            output_format = request.parameters.get("outputFormat", "json")
            
            # Get CSV data from either direct data or URL
            df = await self._get_dataframe(request)
            
            # Process based on requested operation
            result = {}
            
            if operation == "summary":
                result = self._generate_summary(df)
            elif operation == "filter":
                column = request.parameters.get("filterColumn")
                value = request.parameters.get("filterValue")
                if not column:
                    raise ToolExecutionException("filterColumn is required for filter operation")
                result = self._filter_data(df, column, value)
            elif operation == "transform":
                result = self._transform_data(df, request.parameters)
            elif operation == "convert":
                result = self._convert_format(df, output_format)
            else:
                raise ToolExecutionException(f"Unknown operation: {operation}")
            
            return ToolResponse(result=result)
        
        except Exception as e:
            raise ToolExecutionException(f"CSV processing failed: {str(e)}")
    
    async def _get_dataframe(self, request: ToolRequest) -> pd.DataFrame:
        """Gets a pandas DataFrame from either CSV data or URL"""
        if "csvData" in request.parameters:
            csv_data = request.parameters.get("csvData")
            return pd.read_csv(io.StringIO(csv_data))
        elif "csvUrl" in request.parameters:
            csv_url = request.parameters.get("csvUrl")
            return pd.read_csv(csv_url)
        else:
            raise ToolExecutionException("Either csvData or csvUrl must be provided")
    
    def _generate_summary(self, df: pd.DataFrame) -> Dict[str, Any]:
        """Generates a summary of the CSV data"""
        return {
            "columns": df.columns.tolist(),
            "rowCount": len(df),
            "columnCount": len(df.columns),
            "numericColumns": df.select_dtypes(include=['number']).columns.tolist(),
            "categoricalColumns": df.select_dtypes(include=['object']).columns.tolist(),
            "sampleRows": json.loads(df.head(5).to_json(orient="records")),
            "statistics": json.loads(df.describe().to_json())
        }
    
    def _filter_data(self, df: pd.DataFrame, column: str, value: str) -> Dict[str, Any]:
        """Filters the DataFrame by a column value"""
        if column not in df.columns:
            raise ToolExecutionException(f"Column '{column}' not found")
            
        filtered_df = df[df[column].astype(str).str.contains(value)]
        
        return {
            "originalRowCount": len(df),
            "filteredRowCount": len(filtered_df),
            "data": json.loads(filtered_df.to_json(orient="records"))
        }
    
    def _transform_data(self, df: pd.DataFrame, params: Dict[str, Any]) -> Dict[str, Any]:
        """Transforms the data based on parameters"""
        # Implementation would include various transformations
        return {
            "status": "success",
            "message": "Transformation applied"
        }
    
    def _convert_format(self, df: pd.DataFrame, format: str) -> Dict[str, Any]:
        """Converts the DataFrame to different formats"""
        if format == "json":
            return {
                "data": json.loads(df.to_json(orient="records")),
                "format": "json"
            }
        elif format == "csv":
            return {
                "data": df.to_csv(index=False),
                "format": "csv"
            }
        elif format == "markdown":
            return {
                "data": df.to_markdown(),
                "format": "markdown"
            }
        else:
            raise ToolExecutionException(f"Unsupported output format: {format}")
```

### योगदान दिशानिर्देशहरू

MCP परियोजनाहरूमा सफलतापूर्वक योगदान गर्न:

1. **सानोबाट सुरु गर्नुहोस्**: दस्तावेज, बग फिक्सहरू, वा साना सुधारहरूबाट सुरु गर्नुहोस्
2. **शैली मार्गदर्शिका पालना गर्नुहोस्**: परियोजनाको कोडिङ शैली र परम्पराहरू पालना गर्नुहोस्
3. **परीक्षण लेख्नुहोस्**: तपाईंको कोड योगदानहरूको लागि एकाइ परीक्षणहरू समावेश गर्नुहोस्
4. **तपाईंको कामको दस्तावेज गर्नुहोस्**: नयाँ सुविधाहरू वा परिवर्तनहरूको लागि स्पष्ट दस्तावेज थप्नुहोस्
5. **लक्षित PRs पेश गर्नुहोस्**: पुल अनुरोधहरूलाई एकल मुद्दा वा सुविधामा केन्द्रित राख्नुहोस्
6. **प्रतिक्रियासँग संलग्न हुनुहोस्**: तपाईंको योगदानहरूको प्रतिक्रियामा उत्तरदायी हुनुहोस्

### उदाहरण योगदान कार्यप्रवाह

```bash
# Clone the repository
git clone https://github.com/microsoft/mcp-for-beginners.git
cd mcp

# Create a new branch for your contribution
git checkout -b feature/my-contribution

# Make your changes
# ...

# Run tests to ensure your changes don't break existing functionality
dotnet test  # For .NET
mvn test     # For Java
pytest       # For Python

# Commit your changes with a descriptive message
git commit -am "Add support for binary data streams in the protocol"

# Push your branch to your fork
git push origin feature/my-contribution

# Create a pull request from your branch to the main repository
# Then engage with feedback and iterate on your PR as needed
```

## अनुकूलित MCP उपकरणहरू सिर्जना र साझेदारी

MCP पारिस्थितिकी तन्त्रमा योगदान गर्ने सबैभन्दा मूल्यवान तरिकाहरू मध्ये एक अनुकूलित उपकरणहरू सिर्जना र साझेदारी गर्नु हो।

### साझेदारी योग्य उपकरणहरू विकास गर्दै

#### .NET उदाहरण: साझेदारी योग्य उपकरण प्याकेज सिर्जना गर्दै

```csharp
// Create a new .NET library project
// dotnet new classlib -n McpFinanceTools

using Microsoft.Mcp.Tools;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace McpFinanceTools
{
    // Stock quote tool
    public class StockQuoteTool : IMcpTool
    {
        private readonly HttpClient _httpClient;
        
        public StockQuoteTool(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
        }
        
        public string Name => "stockQuote";
        public string Description => "Gets current stock quotes for specified symbols";
        
        public object GetSchema()
        {
            return new {
                type = "object",
                properties = new {
                    symbol = new { 
                        type = "string",
                        description = "Stock symbol (e.g., MSFT, AAPL)" 
                    },
                    includeHistory = new { 
                        type = "boolean",
                        description = "Whether to include historical data",
                        default = false
                    }
                },
                required = new[] { "symbol" }
            };
        }
        
        public async Task<ToolResponse> ExecuteAsync(ToolRequest request)
        {
            // Extract parameters
            string symbol = request.Parameters.GetProperty("symbol").GetString();
            bool includeHistory = false;
            
            if (request.Parameters.TryGetProperty("includeHistory", out var historyProp))
            {
                includeHistory = historyProp.GetBoolean();
            }
            
            // Call external API (example)
            var quoteResult = await GetStockQuoteAsync(symbol);
            
            // Add historical data if requested
            if (includeHistory)
            {
                var historyData = await GetStockHistoryAsync(symbol);
                quoteResult.Add("history", historyData);
            }
            
            // Return formatted result
            return new ToolResponse {
                Result = JsonSerializer.SerializeToElement(quoteResult)
            };
        }
        
        private async Task<Dictionary<string, object>> GetStockQuoteAsync(string symbol)
        {
            // Implementation would call a real stock API
            // This is a simplified example
            return new Dictionary<string, object>
            {
                ["symbol"] = symbol,
                ["price"] = 123.45,
                ["change"] = 2.5,
                ["percentChange"] = 1.2,
                ["lastUpdated"] = DateTime.UtcNow
            };
        }
        
        private async Task<object> GetStockHistoryAsync(string symbol)
        {
            // Implementation would get historical data
            // Simplified example
            return new[]
            {
                new { date = DateTime.Now.AddDays(-7).Date, price = 120.25 },
                new { date = DateTime.Now.AddDays(-6).Date, price = 122.50 },
                new { date = DateTime.Now.AddDays(-5).Date, price = 121.75 }
                // More historical data...
            };
        }
    }
}

// Create package and publish to NuGet
// dotnet pack -c Release
// dotnet nuget push bin/Release/McpFinanceTools.1.0.0.nupkg -s https://api.nuget.org/v3/index.json -k YOUR_API_KEY
```

#### Java उदाहरण: उपकरणहरूको लागि Maven प्याकेज सिर्जना गर्दै

```java
// pom.xml configuration for a shareable MCP tool package
<!-- 
<project>
    <groupId>com.example</groupId>
    <artifactId>mcp-weather-tools</artifactId>
    <version>1.0.0</version>
    
    <dependencies>
        <dependency>
            <groupId>com.mcp</groupId>
            <artifactId>mcp-server</artifactId>
            <version>1.0.0</version>
        </dependency>
    </dependencies>
    
    <distributionManagement>
        <repository>
            <id>github</id>
            <name>GitHub Packages</name>
            <url>https://maven.pkg.github.com/username/mcp-weather-tools</url>
        </repository>
    </distributionManagement>
</project>
-->

package com.example.mcp.weather;

import com.mcp.tools.Tool;
import com.mcp.tools.ToolRequest;
import com.mcp.tools.ToolResponse;
import com.mcp.tools.ToolExecutionException;

import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.net.URI;
import java.util.HashMap;
import java.util.Map;

public class WeatherForecastTool implements Tool {
    private final HttpClient httpClient;
    private final String apiKey;
    
    public WeatherForecastTool(String apiKey) {
        this.httpClient = HttpClient.newHttpClient();
        this.apiKey = apiKey;
    }
    
    @Override
    public String getName() {
        return "weatherForecast";
    }
    
    @Override
    public String getDescription() {
        return "Gets weather forecast for a specified location";
    }
    
    @Override
    public Object getSchema() {
        Map<String, Object> schema = new HashMap<>();
        // Schema definition...
        return schema;
    }
    
    @Override
    public ToolResponse execute(ToolRequest request) {
        try {
            String location = request.getParameters().get("location").asText();
            int days = request.getParameters().has("days") ? 
                request.getParameters().get("days").asInt() : 3;
            
            // Call weather API
            Map<String, Object> forecast = getForecast(location, days);
            
            // Build response
            return new ToolResponse.Builder()
                .setResult(forecast)
                .build();
        } catch (Exception ex) {
            throw new ToolExecutionException("Weather forecast failed: " + ex.getMessage(), ex);
        }
    }
    
    private Map<String, Object> getForecast(String location, int days) {
        // Implementation would call weather API
        // Simplified example
        Map<String, Object> result = new HashMap<>();
        // Add forecast data...
        return result;
    }
}

// Build and publish using Maven
// mvn clean package
// mvn deploy
```

#### Python उदाहरण: PyPI प्याकेज प्रकाशित गर्दै

```python
# Directory structure for a PyPI package:
# mcp_nlp_tools/
# ├── LICENSE
# ├── README.md
# ├── setup.py
# ├── mcp_nlp_tools/
# │   ├── __init__.py
# │   ├── sentiment_tool.py
# │   └── translation_tool.py

# Example setup.py
"""
from setuptools import setup, find_packages

setup(
    name="mcp_nlp_tools",
    version="0.1.0",
    packages=find_packages(),
    install_requires=[
        "mcp_server>=1.0.0",
        "transformers>=4.0.0",
        "torch>=1.8.0"
    ],
    author="Your Name",
    author_email="your.email@example.com",
    description="MCP tools for natural language processing tasks",
    long_description=open("README.md").read(),
    long_description_content_type="text/markdown",
    url="https://github.com/username/mcp_nlp_tools",
    classifiers=[
        "Programming Language :: Python :: 3",
        "License :: OSI Approved :: MIT License",
        "Operating System :: OS Independent",
    ],
    python_requires=">=3.8",
)
"""

# Example NLP tool implementation (sentiment_tool.py)
from mcp_tools import Tool, ToolRequest, ToolResponse, ToolExecutionException
from transformers import pipeline
import torch

class SentimentAnalysisTool(Tool):
    """MCP tool for sentiment analysis of text"""
    
    def __init__(self, model_name="distilbert-base-uncased-finetuned-sst-2-english"):
        # Load the sentiment analysis model
        self.sentiment_analyzer = pipeline("sentiment-analysis", model=model_name)
    
    def get_name(self):
        return "sentimentAnalysis"
        
    def get_description(self):
        return "Analyzes the sentiment of text, classifying it as positive or negative"
    
    def get_schema(self):
        return {
            "type": "object",
            "properties": {
                "text": {
                    "type": "string", 
                    "description": "The text to analyze for sentiment"
                },
                "includeScore": {
                    "type": "boolean",
                    "description": "Whether to include confidence scores",
                    "default": True
                }
            },
            "required": ["text"]
        }
    
    async def execute_async(self, request: ToolRequest) -> ToolResponse:
        try:
            # Extract parameters
            text = request.parameters.get("text")
            include_score = request.parameters.get("includeScore", True)
            
            # Analyze sentiment
            sentiment_result = self.sentiment_analyzer(text)[0]
            
            # Format result
            result = {
                "sentiment": sentiment_result["label"],
                "text": text
            }
            
            if include_score:
                result["score"] = sentiment_result["score"]
            
            # Return result
            return ToolResponse(result=result)
            
        except Exception as e:
            raise ToolExecutionException(f"Sentiment analysis failed: {str(e)}")

# To publish:
# python setup.py sdist bdist_wheel
# python -m twine upload dist/*
```

### उत्तम अभ्यासहरू साझेदारी गर्दै

समुदायसँग MCP उपकरणहरू साझेदारी गर्दा:

1. **पूर्ण दस्तावेज**:
   - उद्देश्य, प्रयोग, र उदाहरणहरूको दस्तावेज गर्नुहोस्
   - प्यारामिटरहरू र फर्किने मानहरूको व्याख्या गर्नुहोस्
   - कुनै पनि बाह्य निर्भरताहरूको दस्तावेज गर्नुहोस्

2. **त्रुटि ह्यान्डलिङ**:
   - मजबुत त्रुटि ह्यान्डलिङ कार्यान्वयन गर्नुहोस्
   - उपयोगी त्रुटि सन्देशहरू प्रदान गर्नुहोस्
   - किनाराका मामिलाहरूलाई सुगम रूपमा ह्यान्डल गर्नुहोस्

3. **प्रदर्शन विचारहरू**:
   - गति र स्रोत प्रयोग दुवैको लागि अनुकूलित गर्नुहोस्
   - आवश्यक पर्दा क्यासिङ कार्यान्वयन गर्नुहोस्
   - स्केलेबिलिटी विचार गर्नुहोस्

4. **सुरक्षा**:
   - सुरक्षित API कुञ्जीहरू र प्रमाणीकरण प्रयोग गर्नुहोस्
   - इनपुटहरू प्रमाणित र सफा गर्नुहोस्
   - बाह्य API कलहरूको लागि दर सीमितता कार्यान्वयन गर्नुहोस्

5. **परीक्षण**:
   - व्यापक परीक्षण कवरेज समावेश गर्नुहोस्
   - विभिन्न इनपुट प्रकारहरू र किनाराका मामिलाहरूको साथ परीक्षण गर्नुहोस्
   - परीक्षण प्रक्रियाहरूको दस्तावेज गर्नुहोस्

## सामुदायिक सहकार्य र उत्तम अभ्यासहरू

प्रभावकारी सहकार्य एक समृद्ध MCP पारिस्थितिकी तन्त्रको लागि कुञ्जी हो।

### सञ्चार च्यानलहरू

- GitHub मुद्दाहरू र छलफलहरू
- Microsoft टेक समुदाय
- Discord र Slack च्यानलहरू
- Stack Overflow (ट्याग: `model-context-protocol` or `mcp`)

### कोड समीक्षाहरू

MCP योगदानहरूको समीक्षा गर्दा:

1. **स्पष्टता**: के कोड स्पष्ट र राम्रोसँग दस्तावेज गरिएको छ?
2. **सहीता**: के यो अपेक्षित रूपमा काम गर्छ?
3. **संगति**: के यसले परियोजनाका परम्पराहरू पालना गर्छ?
4. **सम्पूर्णता**: के परीक्षणहरू र दस्तावेजहरू समावेश छन्?
5. **सुरक्षा**: के कुनै सुरक्षा चिन्ताहरू छन्?

### संस्करण अनुकूलता

MCP को लागि विकास गर्दा:

1. **प्रोटोकल संस्करणीकरण**: तपाईंको उपकरणले समर्थन गर्ने MCP प्रोटोकल संस्करणको पालना गर्नुहोस्
2. **क्लाइन्ट अनुकूलता**: पछाडि अनुकूलताको विचार गर्नुहोस्
3. **सर्भर अनुकूलता**: सर्भर कार्यान्वयन दिशानिर्देशहरू पालना गर्नुहोस्
4. **ब्रेकिङ परिवर्तनहरू**: कुनै पनि ब्रेकिङ परिवर्तनहरूको स्पष्ट दस्तावेज गर्नुहोस्

## उदाहरण सामुदायिक परियोजना: MCP उपकरण रजिस्ट्री

महत्त्वपूर्ण सामुदायिक योगदान MCP उपकरणहरूको लागि सार्वजनिक रजिस्ट्री विकास गर्न सक्दछ।

```python
# Example schema for a community tool registry API

from fastapi import FastAPI, HTTPException, Depends
from pydantic import BaseModel, Field, HttpUrl
from typing import List, Optional
import datetime
import uuid

# Models for the tool registry
class ToolSchema(BaseModel):
    """JSON Schema for a tool"""
    type: str
    properties: dict
    required: List[str] = []

class ToolRegistration(BaseModel):
    """Information for registering a tool"""
    name: str = Field(..., description="Unique name for the tool")
    description: str = Field(..., description="Description of what the tool does")
    version: str = Field(..., description="Semantic version of the tool")
    schema: ToolSchema = Field(..., description="JSON Schema for tool parameters")
    author: str = Field(..., description="Author of the tool")
    repository: Optional[HttpUrl] = Field(None, description="Repository URL")
    documentation: Optional[HttpUrl] = Field(None, description="Documentation URL")
    package: Optional[HttpUrl] = Field(None, description="Package URL")
    tags: List[str] = Field(default_factory=list, description="Tags for categorization")
    examples: List[dict] = Field(default_factory=list, description="Example usage")

class Tool(ToolRegistration):
    """Tool with registry metadata"""
    id: uuid.UUID = Field(default_factory=uuid.uuid4)
    created_at: datetime.datetime = Field(default_factory=datetime.datetime.now)
    updated_at: datetime.datetime = Field(default_factory=datetime.datetime.now)
    downloads: int = Field(default=0)
    rating: float = Field(default=0.0)
    ratings_count: int = Field(default=0)

# FastAPI application for the registry
app = FastAPI(title="MCP Tool Registry")

# In-memory database for this example
tools_db = {}

@app.post("/tools", response_model=Tool)
async def register_tool(tool: ToolRegistration):
    """Register a new tool in the registry"""
    if tool.name in tools_db:
        raise HTTPException(status_code=400, detail=f"Tool '{tool.name}' already exists")
    
    new_tool = Tool(**tool.dict())
    tools_db[tool.name] = new_tool
    return new_tool

@app.get("/tools", response_model=List[Tool])
async def list_tools(tag: Optional[str] = None):
    """List all registered tools, optionally filtered by tag"""
    if tag:
        return [tool for tool in tools_db.values() if tag in tool.tags]
    return list(tools_db.values())

@app.get("/tools/{tool_name}", response_model=Tool)
async def get_tool(tool_name: str):
    """Get information about a specific tool"""
    if tool_name not in tools_db:
        raise HTTPException(status_code=404, detail=f"Tool '{tool_name}' not found")
    return tools_db[tool_name]

@app.delete("/tools/{tool_name}")
async def delete_tool(tool_name: str):
    """Delete a tool from the registry"""
    if tool_name not in tools_db:
        raise HTTPException(status_code=404, detail=f"Tool '{tool_name}' not found")
    del tools_db[tool_name]
    return {"message": f"Tool '{tool_name}' deleted"}
```

## मुख्य निष्कर्षहरू

- MCP समुदाय विविध छ र विभिन्न प्रकारका योगदानहरूलाई स्वागत गर्दछ
- MCP मा योगदान कोर प्रोटोकल सुधारहरूदेखि अनुकूलित उपकरणहरू सम्म हुन सक्छ
- योगदान दिशानिर्देशहरू पालना गर्दा तपाईंको PR स्वीकृत हुने सम्भावना बढ्छ
- MCP उपकरणहरू सिर्जना र साझेदारी गर्नु पारिस्थितिकी तन्त्रलाई सुधार गर्ने मूल्यवान तरिका हो
- सामुदायिक सहकार्य MCP को वृद्धि र सुधारको लागि आवश्यक छ

## व्यायाम

1. तपाईंको सीप र चासोको आधारमा MCP पारिस्थितिकी तन्त्रमा तपाईं योगदान गर्न सक्ने क्षेत्र पहिचान गर्नुहोस्
2. MCP रिपोजिटोरीलाई फोर्क गर्नुहोस् र स्थानीय विकास वातावरण सेट गर्नुहोस्
3. समुदायलाई फाइदा पुग्ने सानो सुधार, बग फिक्स, वा उपकरण सिर्जना गर्नुहोस्
4. उचित परीक्षण र दस्तावेजको साथ तपाईंको योगदानको दस्तावेज गर्नुहोस्
5. उपयुक्त रिपोजिटोरीमा पुल अनुरोध पेश गर्नुहोस्

## अतिरिक्त स्रोतहरू

- [MCP सामुदायिक परियोजनाहरू](https://github.com/topics/model-context-protocol)

---

अर्को: [प्रारम्भिक अपनाउनेबाट पाठहरू](../07-LessonsfromEarlyAdoption/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको हो। हामी यथार्थताको लागि प्रयास गर्छौं, तर कृपया जानकार हुनुहोस् कि स्वचालित अनुवादहरूमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छन्। यसको मूल भाषामा रहेको मूल दस्तावेजलाई आधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीको लागि, पेशेवर मानव अनुवाद सिफारिस गरिन्छ। यो अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी उत्तरदायी हुनेछैनौं।