<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3c6e23d98c958565f6adee083b173ba0",
  "translation_date": "2025-05-20T21:07:20+00:00",
  "source_file": "06-CommunityContributions/README.md",
  "language_code": "ne"
}
-->
# Community and Contributions

## Overview

यस पाठले MCP समुदायसँग कसरी संलग्न हुने, MCP इकोसिस्टममा कसरी योगदान गर्ने, र सहकार्य विकासका लागि उत्तम अभ्यासहरू के हुन् भन्नेमा केन्द्रित छ। खुला स्रोत MCP परियोजनाहरूमा कसरी सहभागी हुने भन्ने बुझाइ यस प्रविधिको भविष्य आकार दिन चाहनेहरूका लागि अत्यावश्यक छ।

## Learning Objectives

यस पाठको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:
- MCP समुदाय र इकोसिस्टमको संरचना बुझ्न
- MCP समुदायका फोरम र छलफलहरूमा प्रभावकारी रूपमा सहभागी हुन
- MCP खुला स्रोत रिपोजिटोरीहरूमा योगदान गर्न
- आफ्नै कस्टम MCP उपकरणहरू सिर्जना र साझेदारी गर्न
- MCP विकास र सहकार्यका लागि उत्तम अभ्यासहरू पालन गर्न

## The MCP Community Ecosystem

MCP इकोसिस्टम विभिन्न घटक र सहभागीहरू मिलेर प्रोटोकललाई अघि बढाउँछन्।

### Key Community Components

1. **Core Protocol Maintainers**: Microsoft र अन्य संस्थाहरू जसले मुख्य MCP विशिष्टता र सन्दर्भ कार्यान्वयनहरू व्यवस्थापन गर्छन्
2. **Tool Developers**: MCP उपकरणहरू बनाउने व्यक्ति र टोलीहरू
3. **Integration Providers**: कम्पनीहरू जसले MCP लाई आफ्ना उत्पादन र सेवाहरूमा एकीकृत गर्छन्
4. **End Users**: विकासकर्ता र संगठनहरू जसले MCP लाई आफ्ना अनुप्रयोगहरूमा प्रयोग गर्छन्
5. **Contributors**: समुदायका सदस्यहरू जसले कोड, दस्तावेज, वा अन्य स्रोतहरू योगदान गर्छन्

### Community Resources

#### Official Channels

- [MCP GitHub Repository](https://github.com/modelcontextprotocol)
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Discussions](https://github.com/orgs/modelcontextprotocol/discussions)

#### Community-Driven Resources

- भाषा-विशिष्ट SDK कार्यान्वयनहरू
- सर्भर कार्यान्वयन र उपकरण पुस्तकालयहरू
- ब्लग पोस्ट र ट्युटोरियलहरू
- समुदाय फोरम र सामाजिक मिडिया छलफलहरू

## Contributing to MCP

### Types of Contributions

MCP इकोसिस्टम विभिन्न प्रकारका योगदानहरूलाई स्वागत गर्छ:

1. **Code Contributions**:
   - मुख्य प्रोटोकल सुधारहरू
   - बग फिक्सहरू
   - उपकरण कार्यान्वयनहरू
   - विभिन्न भाषामा क्लाइन्ट/सर्भर पुस्तकालयहरू

2. **Documentation**:
   - अवस्थित दस्तावेज सुधार्नु
   - ट्युटोरियल र गाइडहरू सिर्जना गर्नु
   - दस्तावेजहरूको अनुवाद गर्नु
   - उदाहरण र नमूना अनुप्रयोगहरू बनाउनु

3. **Community Support**:
   - फोरममा प्रश्नहरूको जवाफ दिनु
   - परीक्षण र समस्या रिपोर्ट गर्नु
   - समुदाय कार्यक्रमहरू आयोजना गर्नु
   - नयाँ योगदानकर्ताहरूलाई मार्गदर्शन गर्नु

### Contribution Process: Core Protocol

मुख्य MCP प्रोटोकल वा आधिकारिक कार्यान्वयनहरूमा योगदान गर्न:

#### .NET Example: Contributing a Protocol Enhancement

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

#### Java Example: Contributing a Bug Fix

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

#### Python Example: Contributing a New Tool to the Standard Library

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

### Contribution Guidelines

MCP परियोजनाहरूमा सफल योगदान गर्न:

1. **Start Small**: दस्तावेज, बग फिक्स, वा साना सुधारहरूबाट सुरु गर्नुहोस्
2. **Follow the Style Guide**: परियोजनाको कोडिङ शैली र परम्पराहरू पालन गर्नुहोस्
3. **Write Tests**: आफ्नो कोड योगदानका लागि युनिट टेस्टहरू समावेश गर्नुहोस्
4. **Document Your Work**: नयाँ सुविधाहरू वा परिवर्तनहरूको स्पष्ट दस्तावेज थप्नुहोस्
5. **Submit Targeted PRs**: पुल रिक्वेस्टहरूलाई एकै मुद्दा वा सुविधामा केन्द्रित राख्नुहोस्
6. **Engage with Feedback**: आफ्नो योगदानमा प्राप्त प्रतिक्रियामा सक्रिय हुनुहोस्

### Example Contribution Workflow

```bash
# Clone the repository
git clone https://github.com/microsoft/mcp-for-beginners.git
cd mcp-for-beginners

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

## Creating and Sharing Custom MCP Tools

MCP इकोसिस्टममा योगदान गर्ने सबैभन्दा मूल्यवान तरिका मध्ये एक हो आफ्नै कस्टम उपकरणहरू सिर्जना र साझेदारी गर्नु।

### Developing Shareable Tools

#### .NET Example: Creating a Shareable Tool Package

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

#### Java Example: Creating a Maven Package for Tools

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

#### Python Example: Publishing a PyPI Package

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

### Sharing Best Practices

जब MCP उपकरणहरू समुदायसँग साझा गर्नुहुन्छ:

1. **Complete Documentation**:
   - उद्देश्य, प्रयोग, र उदाहरणहरू दस्तावेज गर्नुहोस्
   - प्यारामिटर र रिटर्न मानहरू स्पष्ट पार्नुहोस्
   - कुनै पनि बाह्य निर्भरता उल्लेख गर्नुहोस्

2. **Error Handling**:
   - बलियो त्रुटि व्यवस्थापन कार्यान्वयन गर्नुहोस्
   - उपयोगी त्रुटि सन्देशहरू प्रदान गर्नुहोस्
   - किनाराका केसहरू राम्रोसँग ह्यान्डल गर्नुहोस्

3. **Performance Considerations**:
   - गति र स्रोत उपयोग दुवैमा अनुकूलन गर्नुहोस्
   - आवश्यक परे क्यासिङ कार्यान्वयन गर्नुहोस्
   - स्केलेबिलिटीलाई ध्यानमा राख्नुहोस्

4. **Security**:
   - सुरक्षित API कुञ्जी र प्रमाणीकरण प्रयोग गर्नुहोस्
   - इनपुटहरू मान्य र सफा गर्नुहोस्
   - बाह्य API कलहरूको लागि दर सीमितीकरण लागू गर्नुहोस्

5. **Testing**:
   - व्यापक परीक्षण समावेश गर्नुहोस्
   - विभिन्न इनपुट प्रकार र किनाराका केसहरूसँग परीक्षण गर्नुहोस्
   - परीक्षण प्रक्रियाहरू दस्तावेज गर्नुहोस्

## Community Collaboration and Best Practices

प्रभावकारी सहकार्य MCP इकोसिस्टमको समृद्धिका लागि महत्त्वपूर्ण छ।

### Communication Channels

- GitHub Issues र Discussions
- Microsoft Tech Community
- Discord र Slack च्यानलहरू
- Stack Overflow (ट्याग: `model-context-protocol` or `mcp`)

### Code Reviews

MCP योगदानहरूको समीक्षा गर्दा:

1. **Clarity**: कोड स्पष्ट र राम्रोसँग दस्तावेजित छ?
2. **Correctness**: के यो अपेक्षाअनुसार काम गर्छ?
3. **Consistency**: परियोजनाका परम्पराहरू पालन गरिएको छ?
4. **Completeness**: परीक्षण र दस्तावेजीकरण समावेश गरिएको छ?
5. **Security**: कुनै सुरक्षा समस्या छ?

### Version Compatibility

MCP का लागि विकास गर्दा:

1. **Protocol Versioning**: तपाईंको उपकरणले समर्थन गर्ने MCP प्रोटोकल संस्करण पालन गर्नुहोस्
2. **Client Compatibility**: पछाडि अनुकूलता विचार गर्नुहोस्
3. **Server Compatibility**: सर्भर कार्यान्वयन निर्देशनहरू पालना गर्नुहोस्
4. **Breaking Changes**: कुनै पनि ब्रेकिङ परिवर्तनहरू स्पष्ट रूपमा दस्तावेज गर्नुहोस्

## Example Community Project: MCP Tool Registry

महत्त्वपूर्ण सामुदायिक योगदान हुन सक्छ MCP उपकरणहरूको सार्वजनिक रजिष्ट्रि विकास गर्नु।

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

## Key Takeaways

- MCP समुदाय विविध छ र विभिन्न प्रकारका योगदानहरूलाई स्वागत गर्छ
- MCP मा योगदान मुख्य प्रोटोकल सुधारदेखि कस्टम उपकरणसम्म फरक हुन सक्छ
- योगदान निर्देशनहरू पालन गर्दा तपाईंको PR स्वीकृत हुने सम्भावना बढ्छ
- MCP उपकरणहरू सिर्जना र साझा गर्नु इकोसिस्टमलाई समृद्ध पार्ने मूल्यवान तरिका हो
- समुदाय सहकार्य MCP को विकास र सुधारका लागि अनिवार्य छ

## Exercise

1. आफ्नो सीप र रुचि अनुसार MCP इकोसिस्टममा योगदान गर्न सकिने क्षेत्र पहिचान गर्नुहोस्
2. MCP रिपोजिटोरी फोर्क गरी स्थानीय विकास वातावरण सेटअप गर्नुहोस्
3. समुदायलाई लाभ पुग्ने सानो सुधार, बग फिक्स, वा उपकरण सिर्जना गर्नुहोस्
4. उचित परीक्षण र दस्तावेजीकरणसहित आफ्नो योगदानलाई दस्तावेज गर्नुहोस्
5. उपयुक्त रिपोजिटोरीमा पुल रिक्वेस्ट पेश गर्नुहोस्

## Additional Resources

- [MCP Community Projects](https://github.com/topics/model-context-protocol)


---

Next: [Lessons from Early Adoption](../07-LessonsfromEarlyAdoption/README.md)

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) को प्रयोग गरेर अनुवाद गरिएको हो। हामी शुद्धताको प्रयास गर्छौं, तर कृपया जानकार हुनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छन्। मूल दस्तावेज़ यसको मूल भाषामा नै अधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।