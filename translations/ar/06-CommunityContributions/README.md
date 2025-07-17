<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7b4b9bfacd2926725e6f1cda82bc8ff5",
  "translation_date": "2025-07-16T23:31:34+00:00",
  "source_file": "06-CommunityContributions/README.md",
  "language_code": "ar"
}
-->
# المجتمع والمساهمات

## نظرة عامة

تركز هذه الدرسة على كيفية التفاعل مع مجتمع MCP، والمساهمة في نظام MCP البيئي، واتباع أفضل الممارسات للتطوير التعاوني. فهم كيفية المشاركة في مشاريع MCP مفتوحة المصدر أمر ضروري لمن يرغب في تشكيل مستقبل هذه التقنية.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:
- فهم هيكل مجتمع MCP ونظامه البيئي
- المشاركة بفعالية في منتديات ومناقشات مجتمع MCP
- المساهمة في مستودعات MCP مفتوحة المصدر
- إنشاء ومشاركة أدوات وخوادم MCP مخصصة
- اتباع أفضل الممارسات لتطوير MCP والتعاون فيه
- اكتشاف موارد وأُطُر المجتمع لتطوير MCP

## نظام مجتمع MCP البيئي

يتكون نظام MCP البيئي من مكونات ومشاركين متنوعين يعملون معًا لتطوير البروتوكول.

### المكونات الرئيسية للمجتمع

1. **صيانة البروتوكول الأساسي**: منظمة [Model Context Protocol GitHub الرسمية](https://github.com/modelcontextprotocol) تدير المواصفات الأساسية لـ MCP والتنفيذات المرجعية
2. **مطوروا الأدوات**: الأفراد والفرق التي تنشئ أدوات وخوادم MCP
3. **مزودو التكامل**: الشركات التي تدمج MCP في منتجاتها وخدماتها
4. **المستخدمون النهائيون**: المطورون والمنظمات التي تستخدم MCP في تطبيقاتهم
5. **المساهمون**: أعضاء المجتمع الذين يساهمون بالكود، التوثيق، أو موارد أخرى

### موارد المجتمع

#### القنوات الرسمية

- [منظمة MCP على GitHub](https://github.com/modelcontextprotocol)
- [توثيق MCP](https://modelcontextprotocol.io/)
- [مواصفات MCP](https://modelcontextprotocol.io/docs/specification)
- [مناقشات GitHub](https://github.com/orgs/modelcontextprotocol/discussions)
- [مستودع أمثلة وخوادم MCP](https://github.com/modelcontextprotocol/servers)

#### الموارد التي يقودها المجتمع

- [عملاء MCP](https://modelcontextprotocol.io/clients) - قائمة بالعملاء الذين يدعمون تكامل MCP
- [خوادم MCP المجتمعية](https://github.com/modelcontextprotocol/servers?tab=readme-ov-file#-community-servers) - قائمة متزايدة من خوادم MCP التي طورها المجتمع
- [Awesome MCP Servers](https://github.com/wong2/awesome-mcp-servers) - قائمة مختارة من خوادم MCP
- [PulseMCP](https://www.pulsemcp.com/) - مركز المجتمع والنشرة الإخبارية لاكتشاف موارد MCP
- [خادم Discord](https://discord.gg/jHEGxQu2a5) - تواصل مع مطوري MCP
- تنفيذات SDK حسب اللغة
- منشورات المدونات والدروس التعليمية

## المساهمة في MCP

### أنواع المساهمات

يرحب نظام MCP البيئي بأنواع مختلفة من المساهمات:

1. **مساهمات الكود**:
   - تحسينات البروتوكول الأساسي
   - إصلاحات الأخطاء
   - تنفيذات الأدوات والخوادم
   - مكتبات العميل/الخادم بلغات مختلفة

2. **التوثيق**:
   - تحسين التوثيق الحالي
   - إنشاء دروس وأدلة
   - ترجمة التوثيق
   - إنشاء أمثلة وتطبيقات نموذجية

3. **دعم المجتمع**:
   - الإجابة على الأسئلة في المنتديات والمناقشات
   - اختبار والإبلاغ عن المشاكل
   - تنظيم فعاليات المجتمع
   - توجيه المساهمين الجدد

### عملية المساهمة: البروتوكول الأساسي

للمساهمة في بروتوكول MCP الأساسي أو التنفيذات الرسمية، اتبع المبادئ التالية من [إرشادات المساهمة الرسمية](https://github.com/modelcontextprotocol/modelcontextprotocol/blob/main/CONTRIBUTING.md):

1. **البساطة والحد الأدنى**: تحافظ مواصفات MCP على معايير عالية لإضافة مفاهيم جديدة. من الأسهل إضافة أشياء إلى المواصفة من إزالتها.

2. **النهج الملموس**: يجب أن تستند تغييرات المواصفة إلى تحديات تنفيذ محددة، وليس أفكارًا تخمينية.

3. **مراحل الاقتراح**:
   - التعريف: استكشاف مساحة المشكلة، والتحقق من أن مستخدمي MCP الآخرين يواجهون مشكلة مماثلة
   - النموذج الأولي: بناء حل نموذجي وعرض تطبيقه العملي
   - الكتابة: بناءً على النموذج الأولي، كتابة اقتراح المواصفة

### إعداد بيئة التطوير

```bash
# Fork the repository
git clone https://github.com/YOUR-USERNAME/modelcontextprotocol.git
cd modelcontextprotocol

# Install dependencies
npm install

# For schema changes, validate and generate schema.json:
npm run check:schema:ts
npm run generate:schema

# For documentation changes
npm run check:docs
npm run format

# Preview documentation locally (optional):
npm run serve:docs
```

### مثال: المساهمة بإصلاح خطأ

```javascript
// Original code with bug in the typescript-sdk
export function validateResource(resource: unknown): resource is MCPResource {
  if (!resource || typeof resource !== 'object') {
    return false;
  }
  
  // Bug: Missing property validation
  // Current implementation:
  const hasName = 'name' in resource;
  const hasSchema = 'schema' in resource;
  
  return hasName && hasSchema;
}

// Fixed implementation in a contribution
export function validateResource(resource: unknown): resource is MCPResource {
  if (!resource || typeof resource !== 'object') {
    return false;
  }
  
  // Improved validation
  const hasName = 'name' in resource && typeof (resource as MCPResource).name === 'string';
  const hasSchema = 'schema' in resource && typeof (resource as MCPResource).schema === 'object';
  const hasDescription = !('description' in resource) || typeof (resource as MCPResource).description === 'string';
  
  return hasName && hasSchema && hasDescription;
}
```

### مثال: المساهمة بأداة جديدة لمكتبة المعايير

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

### إرشادات المساهمة

لتحقيق مساهمة ناجحة في مشاريع MCP:

1. **ابدأ صغيرًا**: ابدأ بالتوثيق، إصلاح الأخطاء، أو تحسينات صغيرة
2. **اتبع دليل الأسلوب**: التزم بأسلوب الترميز واتفاقيات المشروع
3. **اكتب اختبارات**: أدرج اختبارات وحدات لمساهماتك البرمجية
4. **وثق عملك**: أضف توثيقًا واضحًا للميزات أو التغييرات الجديدة
5. **قدّم طلبات سحب مركزة**: اجعل طلبات السحب تركز على مشكلة أو ميزة واحدة
6. **تفاعل مع الملاحظات**: كن متجاوبًا مع الملاحظات على مساهماتك

### مثال على سير عمل المساهمة

```bash
# Clone the repository
git clone https://github.com/modelcontextprotocol/typescript-sdk.git
cd typescript-sdk

# Create a new branch for your contribution
git checkout -b feature/my-contribution

# Make your changes
# ...

# Run tests to ensure your changes don't break existing functionality
npm test

# Commit your changes with a descriptive message
git commit -am "Fix validation in resource handler"

# Push your branch to your fork
git push origin feature/my-contribution

# Create a pull request from your branch to the main repository
# Then engage with feedback and iterate on your PR as needed
```

## إنشاء ومشاركة خوادم MCP

واحدة من أكثر الطرق قيمة للمساهمة في نظام MCP البيئي هي إنشاء ومشاركة خوادم MCP مخصصة. لقد طور المجتمع بالفعل مئات الخوادم لخدمات وحالات استخدام مختلفة.

### أُطُر تطوير خوادم MCP

تتوفر عدة أُطُر لتبسيط تطوير خوادم MCP:

1. **SDKs الرسمية**:
   - [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
   - [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
   - [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
   - [Go SDK](https://github.com/modelcontextprotocol/go-sdk)
   - [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
   - [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

2. **أُطُر المجتمع**:
   - [MCP-Framework](https://mcp-framework.com/) - بناء خوادم MCP بأناقة وسرعة باستخدام TypeScript
   - [MCP Declarative Java SDK](https://github.com/codeboyzhou/mcp-declarative-java-sdk) - خوادم MCP مدفوعة بالتعليقات التوضيحية باستخدام Java
   - [Quarkus MCP Server SDK](https://github.com/quarkiverse/quarkus-mcp-server) - إطار عمل Java لخوادم MCP
   - [Next.js MCP Server Template](https://github.com/vercel-labs/mcp-for-next.js) - مشروع بداية Next.js لخوادم MCP

### تطوير أدوات قابلة للمشاركة

#### مثال .NET: إنشاء حزمة أداة قابلة للمشاركة

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

#### مثال Java: إنشاء حزمة Maven للأدوات

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

#### مثال Python: نشر حزمة PyPI

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

### مشاركة أفضل الممارسات

عند مشاركة أدوات MCP مع المجتمع:

1. **توثيق كامل**:
   - وثق الغرض، الاستخدام، والأمثلة
   - شرح المعاملات وقيم الإرجاع
   - توثيق أي تبعيات خارجية

2. **معالجة الأخطاء**:
   - تنفيذ معالجة أخطاء قوية
   - توفير رسائل خطأ مفيدة
   - التعامل مع الحالات الحدية بسلاسة

3. **اعتبارات الأداء**:
   - تحسين السرعة واستهلاك الموارد
   - تنفيذ التخزين المؤقت عند الحاجة
   - مراعاة قابلية التوسع

4. **الأمان**:
   - استخدام مفاتيح API ومصادقة آمنة
   - التحقق من صحة المدخلات وتنقيتها
   - تنفيذ تحديد المعدل للطلبات الخارجية

5. **الاختبار**:
   - تضمين تغطية اختبار شاملة
   - اختبار مع أنواع مدخلات مختلفة وحالات حدية
   - توثيق إجراءات الاختبار

## التعاون المجتمعي وأفضل الممارسات

التعاون الفعال هو مفتاح ازدهار نظام MCP البيئي.

### قنوات الاتصال

- قضايا ومناقشات GitHub
- مجتمع Microsoft Tech
- قنوات Discord وSlack
- Stack Overflow (الوسم: `model-context-protocol` أو `mcp`)

### مراجعات الكود

عند مراجعة مساهمات MCP:

1. **الوضوح**: هل الكود واضح وموثق جيدًا؟
2. **الصحة**: هل يعمل كما هو متوقع؟
3. **الاتساق**: هل يتبع اتفاقيات المشروع؟
4. **الشمولية**: هل تتضمن الاختبارات والتوثيق؟
5. **الأمان**: هل هناك أي مخاوف أمنية؟

### توافق الإصدارات

عند التطوير لـ MCP:

1. **إصدار البروتوكول**: التزم بإصدار بروتوكول MCP الذي يدعمه أداتك
2. **توافق العميل**: ضع في اعتبارك التوافق مع الإصدارات السابقة
3. **توافق الخادم**: اتبع إرشادات تنفيذ الخادم
4. **التغييرات الجذرية**: وثق بوضوح أي تغييرات جذرية

## مشروع مجتمعي نموذجي: سجل أدوات MCP

يمكن أن تكون مساهمة مجتمعية مهمة هي تطوير سجل عام لأدوات MCP.

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

## النقاط الرئيسية

- مجتمع MCP متنوع ويرحب بأنواع مختلفة من المساهمات
- يمكن أن تتراوح المساهمة في MCP من تحسينات البروتوكول الأساسي إلى الأدوات المخصصة
- اتباع إرشادات المساهمة يزيد من فرص قبول طلب السحب الخاص بك
- إنشاء ومشاركة أدوات MCP طريقة قيمة لتعزيز النظام البيئي
- التعاون المجتمعي ضروري لنمو وتحسين MCP

## التمرين

1. حدد مجالًا في نظام MCP البيئي يمكنك المساهمة فيه بناءً على مهاراتك واهتماماتك
2. قم بعمل Fork لمستودع MCP وأعد إعداد بيئة تطوير محلية
3. أنشئ تحسينًا صغيرًا، إصلاح خطأ، أو أداة تفيد المجتمع
4. وثق مساهمتك مع اختبارات وتوثيق مناسب
5. قدم طلب سحب إلى المستودع المناسب

## موارد إضافية

- [مشاريع مجتمع MCP](https://github.com/topics/model-context-protocol)


---

التالي: [دروس من التبني المبكر](../07-LessonsfromEarlyAdoption/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.