<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3c6e23d98c958565f6adee083b173ba0",
  "translation_date": "2025-05-20T20:55:28+00:00",
  "source_file": "06-CommunityContributions/README.md",
  "language_code": "hi"
}
-->
# Community and Contributions

## अवलोकन

यह पाठ MCP समुदाय के साथ जुड़ने, MCP इकोसिस्टम में योगदान देने, और सहयोगात्मक विकास के लिए सर्वोत्तम प्रथाओं का पालन करने पर केंद्रित है। खुले स्रोत MCP परियोजनाओं में भाग लेना समझना उन लोगों के लिए आवश्यक है जो इस तकनीक के भविष्य को आकार देना चाहते हैं।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:
- MCP समुदाय और इकोसिस्टम की संरचना को समझना
- MCP समुदाय के फोरम और चर्चाओं में प्रभावी रूप से भाग लेना
- MCP ओपन-सोर्स रिपॉजिटरी में योगदान देना
- कस्टम MCP टूल बनाना और साझा करना
- MCP विकास और सहयोग के लिए सर्वोत्तम प्रथाओं का पालन करना

## MCP समुदाय इकोसिस्टम

MCP इकोसिस्टम विभिन्न घटकों और प्रतिभागियों से मिलकर बनता है जो प्रोटोकॉल को आगे बढ़ाने के लिए मिलकर काम करते हैं।

### प्रमुख सामुदायिक घटक

1. **कोर प्रोटोकॉल मेंटेनर्स**: Microsoft और अन्य संगठन जो कोर MCP विनिर्देशों और संदर्भ कार्यान्वयन का रखरखाव करते हैं
2. **टूल डेवलपर्स**: वे व्यक्ति और टीमें जो MCP टूल बनाते हैं
3. **इंटीग्रेशन प्रोवाइडर्स**: कंपनियां जो MCP को अपने उत्पादों और सेवाओं में एकीकृत करती हैं
4. **अंत उपयोगकर्ता**: डेवलपर्स और संगठन जो अपने एप्लिकेशन में MCP का उपयोग करते हैं
5. **योगदानकर्ता**: समुदाय के सदस्य जो कोड, दस्तावेज़ या अन्य संसाधन प्रदान करते हैं

### सामुदायिक संसाधन

#### आधिकारिक चैनल

- [MCP GitHub Repository](https://github.com/modelcontextprotocol)
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Discussions](https://github.com/orgs/modelcontextprotocol/discussions)

#### समुदाय संचालित संसाधन

- भाषा-विशिष्ट SDK कार्यान्वयन
- सर्वर कार्यान्वयन और टूल लाइब्रेरी
- ब्लॉग पोस्ट और ट्यूटोरियल
- सामुदायिक फोरम और सोशल मीडिया चर्चाएं

## MCP में योगदान देना

### योगदान के प्रकार

MCP इकोसिस्टम विभिन्न प्रकार के योगदानों का स्वागत करता है:

1. **कोड योगदान**:
   - कोर प्रोटोकॉल में सुधार
   - बग फिक्स
   - टूल कार्यान्वयन
   - विभिन्न भाषाओं में क्लाइंट/सर्वर लाइब्रेरी

2. **दस्तावेज़ीकरण**:
   - मौजूदा दस्तावेज़ों में सुधार
   - ट्यूटोरियल और गाइड बनाना
   - दस्तावेज़ों का अनुवाद करना
   - उदाहरण और नमूना एप्लिकेशन बनाना

3. **सामुदायिक समर्थन**:
   - फोरम पर सवालों का जवाब देना
   - परीक्षण और मुद्दों की रिपोर्टिंग
   - सामुदायिक कार्यक्रमों का आयोजन
   - नए योगदानकर्ताओं को मार्गदर्शन देना

### योगदान प्रक्रिया: कोर प्रोटोकॉल

कोर MCP प्रोटोकॉल या आधिकारिक कार्यान्वयन में योगदान करने के लिए:

#### .NET उदाहरण: प्रोटोकॉल सुधार में योगदान

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

#### Java उदाहरण: बग फिक्स में योगदान

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

#### Python उदाहरण: स्टैंडर्ड लाइब्रेरी में नया टूल जोड़ना

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

### योगदान दिशानिर्देश

MCP परियोजनाओं में सफल योगदान करने के लिए:

1. **छोटे से शुरू करें**: दस्तावेज़ीकरण, बग फिक्स या छोटे सुधारों से शुरुआत करें
2. **स्टाइल गाइड का पालन करें**: परियोजना की कोडिंग शैली और मानकों का पालन करें
3. **टेस्ट लिखें**: अपने कोड योगदान के लिए यूनिट टेस्ट शामिल करें
4. **अपने काम का दस्तावेज़ीकरण करें**: नई विशेषताओं या परिवर्तनों के लिए स्पष्ट दस्तावेज़ जोड़ें
5. **लक्षित PR सबमिट करें**: पुल रिक्वेस्ट को एक मुद्दे या फीचर तक सीमित रखें
6. **प्रतिक्रिया के साथ जुड़ें**: अपने योगदान पर मिली प्रतिक्रिया के प्रति उत्तरदायी रहें

### योगदान कार्यप्रवाह का उदाहरण

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

## कस्टम MCP टूल बनाना और साझा करना

MCP इकोसिस्टम में योगदान करने का सबसे मूल्यवान तरीका कस्टम टूल बनाना और साझा करना है।

### साझा करने योग्य टूल विकसित करना

#### .NET उदाहरण: साझा करने योग्य टूल पैकेज बनाना

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

#### Java उदाहरण: टूल्स के लिए Maven पैकेज बनाना

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

#### Python उदाहरण: PyPI पैकेज प्रकाशित करना

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

### सर्वोत्तम प्रथाओं को साझा करना

जब MCP टूल समुदाय के साथ साझा करें:

1. **पूर्ण दस्तावेज़ीकरण**:
   - उद्देश्य, उपयोग और उदाहरणों का दस्तावेज़ीकरण करें
   - पैरामीटर और रिटर्न वैल्यू समझाएं
   - किसी भी बाहरी निर्भरता का उल्लेख करें

2. **त्रुटि प्रबंधन**:
   - मजबूत त्रुटि प्रबंधन लागू करें
   - उपयोगी त्रुटि संदेश प्रदान करें
   - विशेष मामलों को सावधानी से संभालें

3. **प्रदर्शन विचार**:
   - गति और संसाधन उपयोग दोनों के लिए अनुकूलित करें
   - आवश्यकतानुसार कैशिंग लागू करें
   - स्केलेबिलिटी पर ध्यान दें

4. **सुरक्षा**:
   - सुरक्षित API कुंजी और प्रमाणीकरण का उपयोग करें
   - इनपुट की जांच और सफाई करें
   - बाहरी API कॉल के लिए रेट लिमिटिंग लागू करें

5. **परीक्षण**:
   - व्यापक परीक्षण कवरेज शामिल करें
   - विभिन्न इनपुट प्रकार और विशेष मामलों के साथ परीक्षण करें
   - परीक्षण प्रक्रियाओं का दस्तावेज़ीकरण करें

## सामुदायिक सहयोग और सर्वोत्तम प्रथाएं

प्रभावी सहयोग एक समृद्ध MCP इकोसिस्टम की कुंजी है।

### संचार चैनल

- GitHub Issues और Discussions
- Microsoft Tech Community
- Discord और Slack चैनल
- Stack Overflow (टैग: `model-context-protocol` or `mcp`)

### कोड समीक्षा

जब MCP योगदान की समीक्षा करें:

1. **स्पष्टता**: क्या कोड स्पष्ट और अच्छी तरह दस्तावेजीकृत है?
2. **सहीपन**: क्या यह अपेक्षित रूप से काम करता है?
3. **संगति**: क्या यह परियोजना की मानकों का पालन करता है?
4. **पूर्णता**: क्या टेस्ट और दस्तावेज़ शामिल हैं?
5. **सुरक्षा**: क्या कोई सुरक्षा चिंता है?

### संस्करण संगतता

MCP के लिए विकास करते समय:

1. **प्रोटोकॉल संस्करणिंग**: उस MCP प्रोटोकॉल संस्करण का पालन करें जिसे आपका टूल सपोर्ट करता है
2. **क्लाइंट संगतता**: पिछली संगतता पर विचार करें
3. **सर्वर संगतता**: सर्वर कार्यान्वयन दिशानिर्देशों का पालन करें
4. **ब्रेकिंग परिवर्तन**: किसी भी ब्रेकिंग परिवर्तन को स्पष्ट रूप से दस्तावेज़ करें

## उदाहरण सामुदायिक परियोजना: MCP टूल रजिस्ट्री

एक महत्वपूर्ण सामुदायिक योगदान MCP टूल्स के लिए एक सार्वजनिक रजिस्ट्री विकसित करना हो सकता है।

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

## मुख्य बातें

- MCP समुदाय विविध है और विभिन्न प्रकार के योगदानों का स्वागत करता है
- MCP में योगदान कोर प्रोटोकॉल सुधार से लेकर कस्टम टूल तक हो सकता है
- योगदान दिशानिर्देशों का पालन करने से आपके PR को स्वीकार किए जाने की संभावना बढ़ती है
- MCP टूल बनाना और साझा करना इकोसिस्टम को बेहतर बनाने का एक मूल्यवान तरीका है
- समुदाय सहयोग MCP के विकास और सुधार के लिए आवश्यक है

## अभ्यास

1. MCP इकोसिस्टम में अपने कौशल और रुचियों के आधार पर योगदान करने के लिए एक क्षेत्र पहचानें
2. MCP रिपॉजिटरी को फोर्क करें और स्थानीय विकास पर्यावरण सेटअप करें
3. एक छोटा सुधार, बग फिक्स, या ऐसा टूल बनाएं जो समुदाय के लिए उपयोगी हो
4. अपने योगदान को उचित टेस्ट और दस्तावेज़ के साथ दस्तावेजीकृत करें
5. उपयुक्त रिपॉजिटरी में पुल रिक्वेस्ट सबमिट करें

## अतिरिक्त संसाधन

- [MCP Community Projects](https://github.com/topics/model-context-protocol)


---

Next: [Lessons from Early Adoption](../07-LessonsfromEarlyAdoption/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान रखें कि स्वचालित अनुवादों में त्रुटियाँ या गलतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।