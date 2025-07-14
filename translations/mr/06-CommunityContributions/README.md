<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3c6e23d98c958565f6adee083b173ba0",
  "translation_date": "2025-07-14T03:56:55+00:00",
  "source_file": "06-CommunityContributions/README.md",
  "language_code": "mr"
}
-->
# समुदाय आणि योगदान

## आढावा

हा धडा MCP समुदायाशी कसे संवाद साधायचे, MCP परिसंस्थेत कसे योगदान द्यायचे, आणि सहकार्यात्मक विकासासाठी सर्वोत्तम पद्धती कशा पाळायच्या यावर लक्ष केंद्रित करतो. ओपन-सोर्स MCP प्रकल्पांमध्ये सहभागी होण्याची समज असणे या तंत्रज्ञानाच्या भविष्यात प्रभाव टाकण्यासाठी अत्यावश्यक आहे.

## शिकण्याचे उद्दिष्टे

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:
- MCP समुदाय आणि परिसंस्थेची रचना समजून घेणे
- MCP समुदाय फोरम आणि चर्चांमध्ये प्रभावीपणे सहभागी होणे
- MCP ओपन-सोर्स रेपॉझिटरीजमध्ये योगदान देणे
- सानुकूल MCP साधने तयार करणे आणि शेअर करणे
- MCP विकास आणि सहकार्यासाठी सर्वोत्तम पद्धती पाळणे

## MCP समुदाय परिसंस्था

MCP परिसंस्था विविध घटक आणि सहभागींचा समावेश करते जे प्रोटोकॉलच्या प्रगतीसाठी एकत्र काम करतात.

### मुख्य समुदाय घटक

1. **कोर प्रोटोकॉल मेंटेनर्स**: Microsoft आणि इतर संस्था ज्या कोर MCP स्पेसिफिकेशन्स आणि संदर्भ अंमलबजावणी सांभाळतात
2. **साधन विकासक**: व्यक्ती आणि संघ जे MCP साधने तयार करतात
3. **इंटीग्रेशन प्रदाते**: कंपन्या ज्या MCP त्यांच्या उत्पादनांमध्ये आणि सेवा मध्ये समाकलित करतात
4. **अंतिम वापरकर्ते**: विकासक आणि संस्था ज्या त्यांच्या अनुप्रयोगांमध्ये MCP वापरतात
5. **योगदानकर्ते**: समुदाय सदस्य जे कोड, दस्तऐवज किंवा इतर संसाधने योगदान देतात

### समुदाय संसाधने

#### अधिकृत चॅनेल्स

- [MCP GitHub Repository](https://github.com/modelcontextprotocol)
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Discussions](https://github.com/orgs/modelcontextprotocol/discussions)

#### समुदाय-चालित संसाधने

- भाषा-विशिष्ट SDK अंमलबजावणी
- सर्व्हर अंमलबजावणी आणि साधन लायब्ररी
- ब्लॉग पोस्ट आणि ट्युटोरियल्स
- समुदाय फोरम आणि सोशल मीडिया चर्चा

## MCP मध्ये योगदान देणे

### योगदानाचे प्रकार

MCP परिसंस्थेत विविध प्रकारच्या योगदानांचे स्वागत आहे:

1. **कोड योगदान**:
   - कोर प्रोटोकॉल सुधारणा
   - बग दुरुस्ती
   - साधन अंमलबजावणी
   - वेगवेगळ्या भाषांमध्ये क्लायंट/सर्व्हर लायब्ररी

2. **दस्तऐवजीकरण**:
   - विद्यमान दस्तऐवज सुधारणा
   - ट्युटोरियल्स आणि मार्गदर्शक तयार करणे
   - दस्तऐवजांचे भाषांतर करणे
   - उदाहरणे आणि नमुना अनुप्रयोग तयार करणे

3. **समुदाय समर्थन**:
   - फोरमवर प्रश्नांची उत्तरे देणे
   - चाचणी करणे आणि समस्या नोंदवणे
   - समुदाय कार्यक्रमांचे आयोजन करणे
   - नवीन योगदानकर्त्यांचे मार्गदर्शन करणे

### योगदान प्रक्रिया: कोर प्रोटोकॉल

कोर MCP प्रोटोकॉल किंवा अधिकृत अंमलबजावणींमध्ये योगदान देण्यासाठी:

#### .NET उदाहरण: प्रोटोकॉल सुधारणा योगदान देणे

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

#### Java उदाहरण: बग दुरुस्ती योगदान देणे

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

#### Python उदाहरण: स्टँडर्ड लायब्ररीसाठी नवीन साधन योगदान देणे

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

### योगदान मार्गदर्शक तत्त्वे

MCP प्रकल्पांमध्ये यशस्वी योगदान देण्यासाठी:

1. **लहानपासून सुरुवात करा**: दस्तऐवज, बग दुरुस्ती किंवा लहान सुधारणा पासून सुरुवात करा
2. **स्टाइल गाइडचे पालन करा**: प्रकल्पाच्या कोडिंग शैली आणि नियमांचे पालन करा
3. **चाचण्या लिहा**: तुमच्या कोड योगदानासाठी युनिट चाचण्या समाविष्ट करा
4. **तुमचे काम दस्तऐवज करा**: नवीन वैशिष्ट्ये किंवा बदलांसाठी स्पष्ट दस्तऐवज जोडा
5. **लक्ष केंद्रित PR सबमिट करा**: पुल विनंत्या एका मुद्दा किंवा वैशिष्ट्यावर केंद्रित ठेवा
6. **अभिप्रायाशी संवाद साधा**: तुमच्या योगदानावर अभिप्रायाला प्रतिसाद द्या

### उदाहरण योगदान कार्यप्रवाह

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

## सानुकूल MCP साधने तयार करणे आणि शेअर करणे

MCP परिसंस्थेत योगदान देण्याचा एक अत्यंत मौल्यवान मार्ग म्हणजे सानुकूल साधने तयार करणे आणि शेअर करणे.

### शेअर करण्यायोग्य साधने विकसित करणे

#### .NET उदाहरण: शेअर करण्यायोग्य साधन पॅकेज तयार करणे

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

#### Java उदाहरण: साधनांसाठी Maven पॅकेज तयार करणे

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

#### Python उदाहरण: PyPI पॅकेज प्रकाशित करणे

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

### सर्वोत्तम पद्धती शेअर करणे

समुदायासोबत MCP साधने शेअर करताना:

1. **पूर्ण दस्तऐवजीकरण**:
   - उद्दिष्ट, वापर आणि उदाहरणे दस्तऐवज करा
   - पॅरामीटर्स आणि परतावा मूल्ये स्पष्ट करा
   - कोणत्याही बाह्य अवलंबित्वांचे दस्तऐवज करा

2. **त्रुटी हाताळणी**:
   - मजबूत त्रुटी हाताळणी अंमलात आणा
   - उपयुक्त त्रुटी संदेश द्या
   - कोपऱ्याच्या प्रकरणांना नीट हाताळा

3. **कार्यक्षमता विचार**:
   - गती आणि संसाधन वापरासाठी ऑप्टिमायझेशन करा
   - योग्य तेव्हा कॅशिंग अंमलात आणा
   - स्केलेबिलिटीचा विचार करा

4. **सुरक्षा**:
   - सुरक्षित API की आणि प्रमाणीकरण वापरा
   - इनपुट्सची पडताळणी आणि स्वच्छता करा
   - बाह्य API कॉलसाठी दर मर्यादा अंमलात आणा

5. **चाचणी**:
   - सर्वसमावेशक चाचणी कव्हरेज समाविष्ट करा
   - वेगवेगळ्या इनपुट प्रकारांसह आणि कोपऱ्याच्या प्रकरणांसह चाचणी करा
   - चाचणी प्रक्रियेचे दस्तऐवज करा

## समुदाय सहकार्य आणि सर्वोत्तम पद्धती

प्रभावी सहकार्य हे एक समृद्ध MCP परिसंस्थेसाठी महत्त्वाचे आहे.

### संवाद चॅनेल्स

- GitHub Issues आणि Discussions
- Microsoft Tech Community
- Discord आणि Slack चॅनेल्स
- Stack Overflow (टॅग: `model-context-protocol` किंवा `mcp`)

### कोड पुनरावलोकने

MCP योगदानांचे पुनरावलोकन करताना:

1. **स्पष्टता**: कोड स्पष्ट आणि चांगल्या प्रकारे दस्तऐवज केलेला आहे का?
2. **योग्यता**: तो अपेक्षेनुसार कार्य करतो का?
3. **सुसंगतता**: प्रकल्पाच्या नियमांचे पालन करतो का?
4. **पूर्णता**: चाचण्या आणि दस्तऐवज समाविष्ट आहेत का?
5. **सुरक्षा**: कोणतीही सुरक्षा समस्या आहेत का?

### आवृत्ती सुसंगतता

MCP साठी विकास करताना:

1. **प्रोटोकॉल आवृत्ती**: तुमच्या साधनाने समर्थित MCP प्रोटोकॉल आवृत्तीचे पालन करा
2. **क्लायंट सुसंगतता**: मागील आवृत्त्यांसाठी सुसंगतता विचारात घ्या
3. **सर्व्हर सुसंगतता**: सर्व्हर अंमलबजावणी मार्गदर्शक तत्त्वांचे पालन करा
4. **ब्रेकिंग बदल**: कोणतेही ब्रेकिंग बदल स्पष्टपणे दस्तऐवज करा

## उदाहरण समुदाय प्रकल्प: MCP टूल रजिस्ट्री

एक महत्त्वाचे समुदाय योगदान म्हणजे MCP साधनांसाठी सार्वजनिक रजिस्ट्री विकसित करणे.

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

## मुख्य मुद्दे

- MCP समुदाय विविध आहे आणि विविध प्रकारच्या योगदानांचे स्वागत करतो
- MCP मध्ये योगदान कोर प्रोटोकॉल सुधारणा पासून सानुकूल साधनांपर्यंत असू शकते
- योगदान मार्गदर्शक तत्त्वांचे पालन केल्याने तुमच्या PR च्या स्वीकारण्याची शक्यता वाढते
- MCP साधने तयार करणे आणि शेअर करणे परिसंस्थेचा विकास करण्याचा मौल्यवान मार्ग आहे
- समुदाय सहकार्य MCP च्या वाढीसाठी आणि सुधारण्यासाठी अत्यावश्यक आहे

## सराव

1. तुमच्या कौशल्ये आणि आवडींनुसार MCP परिसंस्थेत तुम्ही कोणत्या क्षेत्रात योगदान देऊ शकता ते ओळखा
2. MCP रेपॉझिटरी फोर्क करा आणि स्थानिक विकास वातावरण सेट करा
3. समुदायासाठी फायदेशीर अशी लहान सुधारणा, बग दुरुस्ती किंवा साधन तयार करा
4. तुमचे योगदान योग्य चाचण्या आणि दस्तऐवजांसह नोंदवा
5. संबंधित रेपॉझिटरीमध्ये पुल विनंती सबमिट करा

## अतिरिक्त संसाधने

- [MCP Community Projects](https://github.com/topics/model-context-protocol)


---

पुढे: [प्रारंभिक स्वीकारापासून शिकवण्या](../07-LessonsfromEarlyAdoption/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.