<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3c6e23d98c958565f6adee083b173ba0",
  "translation_date": "2025-05-20T20:31:42+00:00",
  "source_file": "06-CommunityContributions/README.md",
  "language_code": "ur"
}
-->
# کمیونٹی اور شراکتیں

## جائزہ

یہ سبق MCP کمیونٹی کے ساتھ کس طرح مشغول ہونا، MCP ماحولیاتی نظام میں حصہ ڈالنا، اور مشترکہ ترقی کے بہترین طریقوں پر عمل کرنا سکھاتا ہے۔ اوپن سورس MCP پروجیکٹس میں حصہ لینے کا طریقہ سمجھنا ان لوگوں کے لیے ضروری ہے جو اس ٹیکنالوجی کے مستقبل کو تشکیل دینا چاہتے ہیں۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ قابل ہوں گے:
- MCP کمیونٹی اور ماحولیاتی نظام کی ساخت کو سمجھنا
- MCP کمیونٹی فورمز اور مباحثوں میں مؤثر طریقے سے حصہ لینا
- MCP اوپن سورس ریپوزٹریز میں تعاون کرنا
- کسٹم MCP ٹولز بنانا اور شیئر کرنا
- MCP ترقی اور تعاون کے بہترین طریقوں پر عمل کرنا

## MCP کمیونٹی ماحولیاتی نظام

MCP ماحولیاتی نظام مختلف اجزاء اور شرکاء پر مشتمل ہے جو پروٹوکول کو آگے بڑھانے کے لیے مل کر کام کرتے ہیں۔

### اہم کمیونٹی اجزاء

1. **Core Protocol Maintainers**: Microsoft اور دیگر تنظیمیں جو بنیادی MCP وضاحتوں اور ریفرنس امپلیمنٹیشنز کو برقرار رکھتی ہیں  
2. **Tool Developers**: افراد اور ٹیمیں جو MCP ٹولز بناتی ہیں  
3. **Integration Providers**: کمپنیاں جو MCP کو اپنے مصنوعات اور خدمات میں شامل کرتی ہیں  
4. **End Users**: ڈویلپرز اور تنظیمیں جو MCP کو اپنی ایپلیکیشنز میں استعمال کرتی ہیں  
5. **Contributors**: کمیونٹی کے ممبران جو کوڈ، دستاویزات، یا دیگر وسائل فراہم کرتے ہیں  

### کمیونٹی وسائل

#### Official Channels

- [MCP GitHub Repository](https://github.com/modelcontextprotocol)  
- [MCP Documentation](https://modelcontextprotocol.io/)  
- [MCP Specification](https://spec.modelcontextprotocol.io/)  
- [GitHub Discussions](https://github.com/orgs/modelcontextprotocol/discussions)  

#### Community-Driven Resources

- مخصوص زبانوں کے SDK امپلیمنٹیشنز  
- سرور امپلیمنٹیشنز اور ٹول لائبریریز  
- بلاگ پوسٹس اور ٹیوٹوریلز  
- کمیونٹی فورمز اور سوشل میڈیا مباحثے  

## MCP میں تعاون کرنا

### تعاون کی اقسام

MCP ماحولیاتی نظام مختلف قسم کی شراکتوں کا خیرمقدم کرتا ہے:

1. **Code Contributions**:  
   - بنیادی پروٹوکول میں بہتری  
   - بگ فکسز  
   - ٹول امپلیمنٹیشنز  
   - مختلف زبانوں میں کلائنٹ/سرور لائبریریز  

2. **Documentation**:  
   - موجودہ دستاویزات کو بہتر بنانا  
   - ٹیوٹوریلز اور گائیڈز بنانا  
   - دستاویزات کا ترجمہ کرنا  
   - مثالیں اور سیمپل ایپلیکیشنز بنانا  

3. **Community Support**:  
   - فورمز پر سوالات کے جواب دینا  
   - ٹیسٹنگ اور مسائل رپورٹ کرنا  
   - کمیونٹی ایونٹس کا انعقاد  
   - نئے شراکت داروں کی رہنمائی  

### تعاون کا عمل: Core Protocol

بنیادی MCP پروٹوکول یا سرکاری امپلیمنٹیشنز میں تعاون کرنے کے لیے:

#### .NET مثال: پروٹوکول میں بہتری کے لیے تعاون

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

#### Java مثال: بگ فکس میں تعاون

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

#### Python مثال: معیاری لائبریری میں نیا ٹول شامل کرنا

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

### تعاون کے رہنما اصول

MCP پروجیکٹس میں کامیاب تعاون کے لیے:

1. **چھوٹے سے شروع کریں**: دستاویزات، بگ فکسز، یا چھوٹے بہتریوں سے آغاز کریں  
2. **Style Guide پر عمل کریں**: پروجیکٹ کے کوڈنگ اسٹائل اور روایات کی پیروی کریں  
3. **ٹیسٹ لکھیں**: اپنی کوڈ شراکتوں کے لیے یونٹ ٹیسٹ شامل کریں  
4. **اپنے کام کی دستاویزات بنائیں**: نئی خصوصیات یا تبدیلیوں کے لیے واضح دستاویزات شامل کریں  
5. **مخصوص PRs جمع کروائیں**: پل ریکویسٹ کو ایک مسئلہ یا فیچر تک محدود رکھیں  
6. **فیڈبیک پر توجہ دیں**: اپنی شراکتوں پر ملنے والے فیڈبیک کا جواب دیں  

### تعاون کی مثال ورک فلو

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

## کسٹم MCP ٹولز بنانا اور شیئر کرنا

MCP ماحولیاتی نظام میں تعاون کرنے کے سب سے قیمتی طریقوں میں سے ایک کسٹم ٹولز بنانا اور شیئر کرنا ہے۔

### شیئر کرنے والے ٹولز تیار کرنا

#### .NET مثال: شیئر کرنے والے ٹول پیکیج کی تخلیق

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

#### Java مثال: ٹولز کے لیے Maven پیکیج بنانا

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

#### Python مثال: PyPI پیکیج شائع کرنا

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

### بہترین طریقے شیئر کرنا

جب MCP ٹولز کمیونٹی کے ساتھ شیئر کریں:

1. **مکمل دستاویزات**:  
   - مقصد، استعمال، اور مثالیں دستاویز کریں  
   - پیرامیٹرز اور ریٹرن ویلیوز کی وضاحت کریں  
   - کسی بھی بیرونی انحصار کی دستاویزات شامل کریں  

2. **غلطی کا انتظام**:  
   - مضبوط ایرر ہینڈلنگ نافذ کریں  
   - مفید ایرر میسجز فراہم کریں  
   - کنارے کے کیسز کو بہتر طریقے سے ہینڈل کریں  

3. **کارکردگی کے پہلو**:  
   - رفتار اور وسائل کے استعمال کے لیے بہتر بنائیں  
   - مناسب جگہ پر کیشنگ نافذ کریں  
   - اسکیل ایبلیٹی کو مدنظر رکھیں  

4. **سیکیورٹی**:  
   - محفوظ API کیز اور تصدیق کا استعمال کریں  
   - ان پٹس کی ویلیڈیشن اور صفائی کریں  
   - بیرونی API کالز کے لیے ریٹ لمٹنگ نافذ کریں  

5. **ٹیسٹنگ**:  
   - جامع ٹیسٹ کور شامل کریں  
   - مختلف ان پٹ ٹائپس اور کنارے کے کیسز کے ساتھ ٹیسٹ کریں  
   - ٹیسٹ کے طریقہ کار کی دستاویزات بنائیں  

## کمیونٹی تعاون اور بہترین طریقے

موثر تعاون ایک کامیاب MCP ماحولیاتی نظام کی کلید ہے۔

### مواصلاتی چینلز

- GitHub Issues اور Discussions  
- Microsoft Tech Community  
- Discord اور Slack چینلز  
- Stack Overflow (ٹیگ: `model-context-protocol` or `mcp`)  

### کوڈ ریویوز

جب MCP تعاون کا جائزہ لیں:

1. **وضاحت**: کیا کوڈ واضح اور اچھی طرح دستاویزی ہے؟  
2. **درستی**: کیا یہ متوقع طریقے سے کام کرتا ہے؟  
3. **تسلسل**: کیا یہ پروجیکٹ کی روایات کی پیروی کرتا ہے؟  
4. **مکمل پن**: کیا ٹیسٹ اور دستاویزات شامل ہیں؟  
5. **سیکیورٹی**: کیا کوئی سیکیورٹی مسائل ہیں؟  

### ورژن مطابقت

جب MCP کے لیے ترقی کریں:

1. **Protocol Versioning**: اپنے ٹول کی حمایت شدہ MCP پروٹوکول ورژن کی پابندی کریں  
2. **Client Compatibility**: پچھلے ورژنز کے ساتھ مطابقت پر غور کریں  
3. **Server Compatibility**: سرور امپلیمنٹیشن کے رہنما اصولوں کی پیروی کریں  
4. **Breaking Changes**: کسی بھی اہم تبدیلیوں کی واضح دستاویزات بنائیں  

## کمیونٹی پروجیکٹ کی مثال: MCP Tool Registry

ایک اہم کمیونٹی تعاون MCP ٹولز کے لیے ایک عوامی رجسٹری تیار کرنا ہو سکتا ہے۔

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

## اہم نکات

- MCP کمیونٹی متنوع ہے اور مختلف قسم کی شراکتوں کا خیرمقدم کرتی ہے  
- MCP میں تعاون بنیادی پروٹوکول کی بہتری سے لے کر کسٹم ٹولز تک ہو سکتا ہے  
- تعاون کے رہنما اصولوں پر عمل کرنے سے آپ کے PR کے قبول ہونے کے امکانات بہتر ہوتے ہیں  
- MCP ٹولز بنانا اور شیئر کرنا ماحولیاتی نظام کو بہتر بنانے کا قیمتی طریقہ ہے  
- کمیونٹی تعاون MCP کی ترقی اور بہتری کے لیے ضروری ہے  

## مشق

1. MCP ماحولیاتی نظام میں اپنی مہارت اور دلچسپی کی بنیاد پر تعاون کا ایک شعبہ منتخب کریں  
2. MCP ریپوزٹری کو فورک کریں اور لوکل ڈیولپمنٹ ماحول ترتیب دیں  
3. ایک چھوٹا بہتری، بگ فکس، یا ٹول بنائیں جو کمیونٹی کے لیے فائدہ مند ہو  
4. اپنی شراکت کو مناسب ٹیسٹ اور دستاویزات کے ساتھ دستاویزی شکل دیں  
5. متعلقہ ریپوزٹری میں پل ریکویسٹ جمع کروائیں  

## اضافی وسائل

- [MCP Community Projects](https://github.com/topics/model-context-protocol)  


---

Next: [Lessons from Early Adoption](../07-LessonsfromEarlyAdoption/README.md)

**دستخطی**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا نواقص ہو سکتے ہیں۔ اصل دستاویز اپنی مادری زبان میں معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ تجویز کیا جاتا ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔