<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7b4b9bfacd2926725e6f1cda82bc8ff5",
  "translation_date": "2025-07-17T08:13:00+00:00",
  "source_file": "06-CommunityContributions/README.md",
  "language_code": "tl"
}
-->
# Community at Mga Ambag

## Pangkalahatang-ideya

Tinututukan ng araling ito kung paano makilahok sa MCP community, mag-ambag sa MCP ecosystem, at sundin ang mga pinakamahusay na kasanayan para sa kolaboratibong pag-unlad. Mahalaga ang pag-unawa kung paano makibahagi sa mga open-source na proyekto ng MCP para sa mga nais hubugin ang hinaharap ng teknolohiyang ito.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:
- Maunawaan ang estruktura ng MCP community at ecosystem
- Epektibong makilahok sa mga forum at talakayan ng MCP community
- Mag-ambag sa mga open-source na repositoryo ng MCP
- Gumawa at magbahagi ng mga custom na MCP tools at servers
- Sundin ang mga pinakamahusay na kasanayan sa pag-develop at kolaborasyon sa MCP
- Tuklasin ang mga mapagkukunan at framework ng komunidad para sa pag-develop ng MCP

## Ang MCP Community Ecosystem

Binubuo ang MCP ecosystem ng iba't ibang bahagi at kalahok na nagtutulungan upang paunlarin ang protocol.

### Pangunahing Bahagi ng Komunidad

1. **Core Protocol Maintainers**: Ang opisyal na [Model Context Protocol GitHub organization](https://github.com/modelcontextprotocol) ang nangangalaga sa mga pangunahing MCP specifications at reference implementations
2. **Tool Developers**: Mga indibidwal at koponan na lumilikha ng MCP tools at servers
3. **Integration Providers**: Mga kumpanya na nag-iintegrate ng MCP sa kanilang mga produkto at serbisyo
4. **End Users**: Mga developer at organisasyon na gumagamit ng MCP sa kanilang mga aplikasyon
5. **Contributors**: Mga miyembro ng komunidad na nag-aambag ng code, dokumentasyon, o iba pang mga mapagkukunan

### Mga Mapagkukunan ng Komunidad

#### Opisyal na Mga Channel

- [MCP GitHub Organization](https://github.com/modelcontextprotocol)
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://modelcontextprotocol.io/docs/specification)
- [GitHub Discussions](https://github.com/orgs/modelcontextprotocol/discussions)
- [MCP Examples & Servers Repository](https://github.com/modelcontextprotocol/servers)

#### Mga Mapagkukunang Pinapatakbo ng Komunidad

- [MCP Clients](https://modelcontextprotocol.io/clients) - Listahan ng mga client na sumusuporta sa MCP integrations
- [Community MCP Servers](https://github.com/modelcontextprotocol/servers?tab=readme-ov-file#-community-servers) - Lumalawak na listahan ng mga MCP server na ginawa ng komunidad
- [Awesome MCP Servers](https://github.com/wong2/awesome-mcp-servers) - Piniling listahan ng mga MCP server
- [PulseMCP](https://www.pulsemcp.com/) - Sentro ng komunidad at newsletter para sa pagtuklas ng mga MCP resources
- [Discord Server](https://discord.gg/jHEGxQu2a5) - Makipag-ugnayan sa mga MCP developer
- Mga language-specific SDK implementations
- Mga blog post at tutorial

## Pag-aambag sa MCP

### Mga Uri ng Ambag

Tinatanggap ng MCP ecosystem ang iba't ibang uri ng ambag:

1. **Code Contributions**:
   - Mga pagpapahusay sa core protocol
   - Pag-aayos ng mga bug
   - Implementasyon ng mga tool at server
   - Mga client/server libraries sa iba't ibang wika

2. **Dokumentasyon**:
   - Pagpapabuti ng kasalukuyang dokumentasyon
   - Paggawa ng mga tutorial at gabay
   - Pagsasalin ng dokumentasyon
   - Paggawa ng mga halimbawa at sample na aplikasyon

3. **Suporta sa Komunidad**:
   - Pagsagot sa mga tanong sa mga forum at talakayan
   - Pagsubok at pag-uulat ng mga isyu
   - Pag-oorganisa ng mga kaganapan ng komunidad
   - Pagtuturo sa mga bagong contributor

### Proseso ng Pag-aambag: Core Protocol

Para mag-ambag sa core MCP protocol o opisyal na implementasyon, sundin ang mga prinsipyo mula sa [opisyal na contributing guidelines](https://github.com/modelcontextprotocol/modelcontextprotocol/blob/main/CONTRIBUTING.md):

1. **Simplicity and Minimalism**: Mataas ang pamantayan ng MCP specification sa pagdagdag ng mga bagong konsepto. Mas madali ang magdagdag kaysa mag-alis.

2. **Concrete Approach**: Ang mga pagbabago sa specification ay dapat nakabase sa mga tiyak na hamon sa implementasyon, hindi sa mga haka-haka.

3. **Mga Yugto ng Proposal**:
   - Define: Suriin ang problema, tiyakin na may kaparehong isyu ang ibang MCP user
   - Prototype: Gumawa ng halimbawa ng solusyon at ipakita ang praktikal na aplikasyon nito
   - Write: Batay sa prototype, isulat ang proposal para sa specification

### Setup ng Development Environment

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

### Halimbawa: Pag-aambag ng Bug Fix

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

### Halimbawa: Pag-aambag ng Bagong Tool sa Standard Library

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

### Mga Patnubay sa Pag-aambag

Para maging matagumpay ang iyong ambag sa mga proyekto ng MCP:

1. **Magsimula sa Maliit**: Simulan sa dokumentasyon, pag-aayos ng bug, o maliliit na pagpapahusay
2. **Sundin ang Style Guide**: Sumunod sa coding style at mga convention ng proyekto
3. **Sumulat ng Tests**: Isama ang unit tests para sa iyong mga code contribution
4. **Idokumento ang Iyong Gawain**: Magdagdag ng malinaw na dokumentasyon para sa mga bagong tampok o pagbabago
5. **Mag-submit ng Targeted PRs**: Panatilihing nakatuon ang pull requests sa isang isyu o tampok lamang
6. **Makipag-ugnayan sa Feedback**: Maging bukas at tumugon sa mga puna sa iyong mga ambag

### Halimbawa ng Workflow sa Pag-aambag

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

## Paggawa at Pagbabahagi ng MCP Servers

Isa sa pinakamahalagang paraan ng pag-ambag sa MCP ecosystem ay ang paggawa at pagbabahagi ng mga custom MCP servers. Marami nang MCP server ang nagawa ng komunidad para sa iba't ibang serbisyo at gamit.

### Mga Framework para sa Pag-develop ng MCP Server

May ilang framework na makakatulong upang mapadali ang pag-develop ng MCP server:

1. **Opisyal na SDKs**:
   - [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
   - [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
   - [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
   - [Go SDK](https://github.com/modelcontextprotocol/go-sdk)
   - [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
   - [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

2. **Mga Framework ng Komunidad**:
   - [MCP-Framework](https://mcp-framework.com/) - Gumawa ng MCP servers nang mabilis at elegante gamit ang TypeScript
   - [MCP Declarative Java SDK](https://github.com/codeboyzhou/mcp-declarative-java-sdk) - Annotation-driven MCP servers gamit ang Java
   - [Quarkus MCP Server SDK](https://github.com/quarkiverse/quarkus-mcp-server) - Java framework para sa MCP servers
   - [Next.js MCP Server Template](https://github.com/vercel-labs/mcp-for-next.js) - Starter Next.js project para sa MCP servers

### Pag-develop ng Mga Tool na Maibabahagi

#### Halimbawa sa .NET: Paggawa ng Shareable Tool Package

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

#### Halimbawa sa Java: Paggawa ng Maven Package para sa Mga Tool

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

#### Halimbawa sa Python: Pag-publish ng PyPI Package

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

### Mga Pinakamahusay na Kasanayan sa Pagbabahagi

Kapag nagbabahagi ng MCP tools sa komunidad:

1. **Kumpletong Dokumentasyon**:
   - Idokumento ang layunin, paggamit, at mga halimbawa
   - Ipaliwanag ang mga parameter at mga return value
   - Idokumento ang anumang external dependencies

2. **Pag-handle ng Error**:
   - Magpatupad ng matibay na error handling
   - Magbigay ng kapaki-pakinabang na mga mensahe ng error
   - Maayos na hawakan ang mga edge case

3. **Mga Pagsasaalang-alang sa Performance**:
   - I-optimize para sa bilis at paggamit ng resources
   - Gumamit ng caching kung angkop
   - Isaalang-alang ang scalability

4. **Seguridad**:
   - Gumamit ng secure na API keys at authentication
   - I-validate at i-sanitize ang mga input
   - Magpatupad ng rate limiting para sa mga external API calls

5. **Pagsusuri**:
   - Isama ang komprehensibong test coverage
   - Subukan gamit ang iba't ibang uri ng input at edge cases
   - Idokumento ang mga pamamaraan ng pagsusuri

## Kolaborasyon ng Komunidad at Mga Pinakamahusay na Kasanayan

Mahalaga ang epektibong kolaborasyon para sa isang masiglang MCP ecosystem.

### Mga Channel ng Komunikasyon

- GitHub Issues at Discussions
- Microsoft Tech Community
- Discord at Slack channels
- Stack Overflow (tag: `model-context-protocol` o `mcp`)

### Pagsusuri ng Code

Kapag nire-review ang mga ambag sa MCP:

1. **Kalinawan**: Malinaw at maayos ba ang dokumentasyon ng code?
2. **Katatagan**: Gumagana ba ito ayon sa inaasahan?
3. **Pagkakapare-pareho**: Sumusunod ba ito sa mga convention ng proyekto?
4. **Kumpletong Saklaw**: Kasama ba ang mga tests at dokumentasyon?
5. **Seguridad**: Mayroon bang mga isyu sa seguridad?

### Compatibility ng Bersyon

Kapag nagde-develop para sa MCP:

1. **Protocol Versioning**: Sundin ang bersyon ng MCP protocol na sinusuportahan ng iyong tool
2. **Client Compatibility**: Isaalang-alang ang backward compatibility
3. **Server Compatibility**: Sundin ang mga patnubay sa implementasyon ng server
4. **Breaking Changes**: Idokumento nang malinaw ang anumang breaking changes

## Halimbawa ng Proyektong Pangkomunidad: MCP Tool Registry

Isang mahalagang ambag sa komunidad ay ang paggawa ng pampublikong registry para sa mga MCP tool.

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

## Mga Pangunahing Punto

- Iba-iba ang MCP community at tinatanggap ang iba't ibang uri ng ambag
- Ang pag-aambag sa MCP ay maaaring mula sa pagpapahusay ng core protocol hanggang sa paggawa ng custom tools
- Ang pagsunod sa mga patnubay sa pag-aambag ay nagpapataas ng tsansa na tanggapin ang iyong PR
- Ang paggawa at pagbabahagi ng MCP tools ay mahalagang paraan upang paunlarin ang ecosystem
- Mahalaga ang kolaborasyon ng komunidad para sa paglago at pagbuti ng MCP

## Ehersisyo

1. Tukuyin ang isang bahagi ng MCP ecosystem kung saan maaari kang mag-ambag base sa iyong kakayahan at interes
2. I-fork ang MCP repository at i-setup ang lokal na development environment
3. Gumawa ng maliit na pagpapahusay, pag-aayos ng bug, o tool na makakatulong sa komunidad
4. Idokumento ang iyong ambag kasama ang mga angkop na tests at dokumentasyon
5. Mag-submit ng pull request sa tamang repositoryo

## Karagdagang Mga Mapagkukunan

- [MCP Community Projects](https://github.com/topics/model-context-protocol)


---

Susunod: [Lessons from Early Adoption](../07-LessonsfromEarlyAdoption/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.