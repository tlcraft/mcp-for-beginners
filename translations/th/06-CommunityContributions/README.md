<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6e190a963029f156b7ecffad7093b8ce",
  "translation_date": "2025-05-17T15:52:59+00:00",
  "source_file": "06-CommunityContributions/README.md",
  "language_code": "th"
}
-->
# ชุมชนและการมีส่วนร่วม

## ภาพรวม

บทเรียนนี้มุ่งเน้นวิธีการมีส่วนร่วมกับชุมชน MCP, มีส่วนร่วมในระบบนิเวศ MCP, และปฏิบัติตามแนวทางที่ดีที่สุดสำหรับการพัฒนาร่วมกัน การเข้าใจวิธีการมีส่วนร่วมในโครงการ MCP แบบโอเพนซอร์สเป็นสิ่งสำคัญสำหรับผู้ที่ต้องการมีบทบาทในอนาคตของเทคโนโลยีนี้

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:
- เข้าใจโครงสร้างของชุมชนและระบบนิเวศ MCP
- มีส่วนร่วมอย่างมีประสิทธิภาพในฟอรัมและการอภิปรายของชุมชน MCP
- มีส่วนร่วมในที่เก็บโอเพนซอร์ส MCP
- สร้างและแชร์เครื่องมือ MCP ที่ปรับแต่งเอง
- ปฏิบัติตามแนวทางที่ดีที่สุดสำหรับการพัฒนาและการร่วมมือใน MCP

## ระบบนิเวศของชุมชน MCP

ระบบนิเวศ MCP ประกอบด้วยส่วนประกอบและผู้เข้าร่วมต่างๆ ที่ทำงานร่วมกันเพื่อพัฒนามาตรฐาน

### ส่วนประกอบสำคัญของชุมชน

1. **ผู้ดูแลมาตรฐานหลัก**: Microsoft และองค์กรอื่นๆ ที่ดูแลข้อกำหนดและการใช้งานอ้างอิงของ MCP
2. **ผู้พัฒนาเครื่องมือ**: บุคคลและทีมที่สร้างเครื่องมือ MCP
3. **ผู้ให้บริการการรวมระบบ**: บริษัทที่รวม MCP เข้ากับผลิตภัณฑ์และบริการของพวกเขา
4. **ผู้ใช้ปลายทาง**: นักพัฒนาและองค์กรที่ใช้ MCP ในแอปพลิเคชันของพวกเขา
5. **ผู้มีส่วนร่วม**: สมาชิกชุมชนที่มีส่วนร่วมในโค้ด, เอกสาร, หรือทรัพยากรอื่นๆ

### ทรัพยากรของชุมชน

#### ช่องทางอย่างเป็นทางการ

- [ที่เก็บ GitHub ของ MCP](https://github.com/modelcontextprotocol)
- [เอกสาร MCP](https://modelcontextprotocol.io/)
- [ข้อกำหนด MCP](https://spec.modelcontextprotocol.io/)
- [การอภิปรายบน GitHub](https://github.com/orgs/modelcontextprotocol/discussions)

#### ทรัพยากรที่ขับเคลื่อนโดยชุมชน

- การใช้งาน SDK เฉพาะภาษา
- การใช้งานเซิร์ฟเวอร์และห้องสมุดเครื่องมือ
- บล็อกโพสต์และบทเรียน
- ฟอรัมชุมชนและการอภิปรายบนสื่อสังคม

## การมีส่วนร่วมใน MCP

### ประเภทของการมีส่วนร่วม

ระบบนิเวศ MCP ยินดีต้อนรับการมีส่วนร่วมหลากหลายประเภท:

1. **การมีส่วนร่วมในโค้ด**:
   - การปรับปรุงมาตรฐานหลัก
   - การแก้ไขข้อบกพร่อง
   - การใช้งานเครื่องมือ
   - ห้องสมุดไคลเอนต์/เซิร์ฟเวอร์ในภาษาต่างๆ

2. **เอกสาร**:
   - การปรับปรุงเอกสารที่มีอยู่
   - การสร้างบทเรียนและคู่มือ
   - การแปลเอกสาร
   - การสร้างตัวอย่างและแอปพลิเคชันตัวอย่าง

3. **การสนับสนุนชุมชน**:
   - การตอบคำถามในฟอรัม
   - การทดสอบและรายงานปัญหา
   - การจัดกิจกรรมชุมชน
   - การให้คำปรึกษาแก่ผู้มีส่วนร่วมใหม่

### กระบวนการมีส่วนร่วม: มาตรฐานหลัก

เพื่อมีส่วนร่วมในมาตรฐาน MCP หลักหรือการใช้งานอย่างเป็นทางการ:

#### ตัวอย่าง .NET: การมีส่วนร่วมในการปรับปรุงมาตรฐาน

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

#### ตัวอย่าง Java: การมีส่วนร่วมในการแก้ไขข้อบกพร่อง

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

#### ตัวอย่าง Python: การมีส่วนร่วมในการสร้างเครื่องมือใหม่ให้กับห้องสมุดมาตรฐาน

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

### แนวทางการมีส่วนร่วม

เพื่อให้การมีส่วนร่วมในโครงการ MCP ประสบความสำเร็จ:

1. **เริ่มต้นเล็กๆ**: เริ่มต้นด้วยเอกสาร, การแก้ไขข้อบกพร่อง, หรือการปรับปรุงเล็กๆ
2. **ปฏิบัติตามคู่มือสไตล์**: ปฏิบัติตามสไตล์การเขียนโค้ดและธรรมเนียมของโครงการ
3. **เขียนการทดสอบ**: รวมการทดสอบหน่วยสำหรับการมีส่วนร่วมของคุณ
4. **เอกสารงานของคุณ**: เพิ่มเอกสารที่ชัดเจนสำหรับคุณลักษณะใหม่หรือการเปลี่ยนแปลง
5. **ส่ง PR ที่มุ่งเน้น**: รักษาการดึงคำร้องให้มุ่งเน้นไปที่ปัญหาหรือคุณลักษณะเดียว
6. **มีส่วนร่วมกับความคิดเห็น**: ตอบสนองต่อความคิดเห็นเกี่ยวกับการมีส่วนร่วมของคุณ

### ขั้นตอนการมีส่วนร่วมตัวอย่าง

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

## การสร้างและแชร์เครื่องมือ MCP ที่ปรับแต่งเอง

หนึ่งในวิธีที่มีค่าที่สุดในการมีส่วนร่วมในระบบนิเวศ MCP คือการสร้างและแชร์เครื่องมือที่ปรับแต่งเอง

### การพัฒนาเครื่องมือที่สามารถแชร์ได้

#### ตัวอย่าง .NET: การสร้างแพ็คเกจเครื่องมือที่สามารถแชร์ได้

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

#### ตัวอย่าง Java: การสร้างแพ็คเกจ Maven สำหรับเครื่องมือ

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

#### ตัวอย่าง Python: การเผยแพร่แพ็คเกจ PyPI

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

### การแชร์แนวทางที่ดีที่สุด

เมื่อแชร์เครื่องมือ MCP กับชุมชน:

1. **เอกสารที่สมบูรณ์**:
   - เอกสารจุดประสงค์, การใช้งาน, และตัวอย่าง
   - อธิบายพารามิเตอร์และค่าที่ส่งกลับ
   - เอกสารการพึ่งพาภายนอกใดๆ

2. **การจัดการข้อผิดพลาด**:
   - ใช้การจัดการข้อผิดพลาดที่แข็งแกร่ง
   - ให้ข้อความข้อผิดพลาดที่มีประโยชน์
   - จัดการกรณีขอบอย่างดี

3. **ข้อพิจารณาด้านประสิทธิภาพ**:
   - ปรับให้เหมาะสมสำหรับความเร็วและการใช้งานทรัพยากร
   - ใช้การแคชเมื่อเหมาะสม
   - พิจารณาการขยายตัว

4. **ความปลอดภัย**:
   - ใช้คีย์ API และการตรวจสอบที่ปลอดภัย
   - ตรวจสอบและทำความสะอาดข้อมูลที่ป้อน
   - ใช้การจำกัดอัตราสำหรับการเรียก API ภายนอก

5. **การทดสอบ**:
   - รวมการครอบคลุมการทดสอบที่ครอบคลุม
   - ทดสอบกับประเภทข้อมูลและกรณีขอบที่ต่างกัน
   - เอกสารขั้นตอนการทดสอบ

## การร่วมมือในชุมชนและแนวทางที่ดีที่สุด

การร่วมมืออย่างมีประสิทธิภาพเป็นกุญแจสำคัญต่อระบบนิเวศ MCP ที่เจริญรุ่งเรือง

### ช่องทางการสื่อสาร

- ปัญหาและการอภิปรายบน GitHub
- Microsoft Tech Community
- ช่องทาง Discord และ Slack
- Stack Overflow (แท็ก: `model-context-protocol` or `mcp`)

### การตรวจสอบโค้ด

เมื่อตรวจสอบการมีส่วนร่วมใน MCP:

1. **ความชัดเจน**: โค้ดชัดเจนและมีเอกสารดีหรือไม่?
2. **ความถูกต้อง**: ทำงานตามที่คาดไว้หรือไม่?
3. **ความสม่ำเสมอ**: ปฏิบัติตามธรรมเนียมของโครงการหรือไม่?
4. **ความครบถ้วน**: รวมการทดสอบและเอกสารหรือไม่?
5. **ความปลอดภัย**: มีข้อกังวลด้านความปลอดภัยหรือไม่?

### ความเข้ากันได้ของเวอร์ชัน

เมื่อพัฒนาสำหรับ MCP:

1. **การจัดการเวอร์ชันมาตรฐาน**: ปฏิบัติตามเวอร์ชันมาตรฐาน MCP ที่เครื่องมือของคุณรองรับ
2. **ความเข้ากันได้ของไคลเอนต์**: พิจารณาความเข้ากันได้ย้อนหลัง
3. **ความเข้ากันได้ของเซิร์ฟเวอร์**: ปฏิบัติตามแนวทางการใช้งานเซิร์ฟเวอร์
4. **การเปลี่ยนแปลงที่มีผลกระทบ**: เอกสารการเปลี่ยนแปลงที่มีผลกระทบอย่างชัดเจน

## โครงการชุมชนตัวอย่าง: การลงทะเบียนเครื่องมือ MCP

การมีส่วนร่วมของชุมชนที่สำคัญอาจเป็นการพัฒนาการลงทะเบียนสาธารณะสำหรับเครื่องมือ MCP

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

## ข้อคิดสำคัญ

- ชุมชน MCP มีความหลากหลายและยินดีต้อนรับการมีส่วนร่วมหลากหลายประเภท
- การมีส่วนร่วมใน MCP สามารถตั้งแต่การปรับปรุงมาตรฐานหลักไปจนถึงเครื่องมือที่ปรับแต่งเอง
- การปฏิบัติตามแนวทางการมีส่วนร่วมช่วยเพิ่มโอกาสที่ PR ของคุณจะได้รับการยอมรับ
- การสร้างและแชร์เครื่องมือ MCP เป็นวิธีที่มีค่าในการเสริมสร้างระบบนิเวศ
- การร่วมมือในชุมชนเป็นสิ่งสำคัญสำหรับการเติบโตและการปรับปรุงของ MCP

## แบบฝึกหัด

1. ระบุพื้นที่ในระบบนิเวศ MCP ที่คุณสามารถมีส่วนร่วมตามทักษะและความสนใจของคุณ
2. Fork ที่เก็บ MCP และตั้งค่าสภาพแวดล้อมการพัฒนาในท้องถิ่น
3. สร้างการปรับปรุงเล็กๆ, การแก้ไขข้อบกพร่อง, หรือเครื่องมือที่เป็นประโยชน์ต่อชุมชน
4. เอกสารการมีส่วนร่วมของคุณด้วยการทดสอบและเอกสารที่เหมาะสม
5. ส่งคำร้องขอดึงไปยังที่เก็บที่เหมาะสม

## ทรัพยากรเพิ่มเติม

- [โครงการชุมชน MCP](https://github.com/topics/model-context-protocol)


---

ถัดไป: [บทเรียนจากการยอมรับในช่วงแรก](../07-LessonsfromEarlyAdoption/README.md)

**คำปฏิเสธความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามเพื่อความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาของตนเองควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลสำคัญ แนะนำให้ใช้บริการแปลภาษามนุษย์ที่เป็นมืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดจากการใช้การแปลนี้