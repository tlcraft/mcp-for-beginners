<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7b4b9bfacd2926725e6f1cda82bc8ff5",
  "translation_date": "2025-07-16T21:30:17+00:00",
  "source_file": "06-CommunityContributions/README.md",
  "language_code": "ja"
}
-->
# Community and Contributions

## Overview

このレッスンでは、MCPコミュニティへの参加方法、MCPエコシステムへの貢献方法、そして共同開発のベストプラクティスについて学びます。オープンソースのMCPプロジェクトに参加する方法を理解することは、この技術の未来を形作りたい方にとって重要です。

## Learning Objectives

このレッスンの終了時には、以下ができるようになります：
- MCPコミュニティとエコシステムの構造を理解する
- MCPコミュニティのフォーラムやディスカッションに効果的に参加する
- MCPのオープンソースリポジトリに貢献する
- カスタムMCPツールやサーバーを作成し共有する
- MCP開発とコラボレーションのベストプラクティスに従う
- MCP開発のためのコミュニティリソースやフレームワークを見つける

## The MCP Community Ecosystem

MCPエコシステムは、プロトコルの発展に向けて協力するさまざまな要素と参加者で構成されています。

### Key Community Components

1. **Core Protocol Maintainers**: 公式の[Model Context Protocol GitHub組織](https://github.com/modelcontextprotocol)がコアMCP仕様とリファレンス実装を管理しています
2. **Tool Developers**: MCPツールやサーバーを作成する個人やチーム
3. **Integration Providers**: MCPを自社製品やサービスに統合する企業
4. **End Users**: MCPをアプリケーションで利用する開発者や組織
5. **Contributors**: コード、ドキュメント、その他のリソースを提供するコミュニティメンバー

### Community Resources

#### Official Channels

- [MCP GitHub Organization](https://github.com/modelcontextprotocol)
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://modelcontextprotocol.io/docs/specification)
- [GitHub Discussions](https://github.com/orgs/modelcontextprotocol/discussions)
- [MCP Examples & Servers Repository](https://github.com/modelcontextprotocol/servers)

#### Community-Driven Resources

- [MCP Clients](https://modelcontextprotocol.io/clients) - MCP統合をサポートするクライアントの一覧
- [Community MCP Servers](https://github.com/modelcontextprotocol/servers?tab=readme-ov-file#-community-servers) - コミュニティが開発したMCPサーバーの増え続けるリスト
- [Awesome MCP Servers](https://github.com/wong2/awesome-mcp-servers) - 厳選されたMCPサーバーのリスト
- [PulseMCP](https://www.pulsemcp.com/) - MCPリソースを見つけるためのコミュニティハブ＆ニュースレター
- [Discord Server](https://discord.gg/jHEGxQu2a5) - MCP開発者とつながる場所
- 言語別SDK実装
- ブログ記事やチュートリアル

## Contributing to MCP

### Types of Contributions

MCPエコシステムはさまざまな種類の貢献を歓迎しています：

1. **Code Contributions**:
   - コアプロトコルの改善
   - バグ修正
   - ツールやサーバーの実装
   - 多言語のクライアント/サーバーライブラリ

2. **Documentation**:
   - 既存ドキュメントの改善
   - チュートリアルやガイドの作成
   - ドキュメントの翻訳
   - サンプルや例の作成

3. **Community Support**:
   - フォーラムやディスカッションでの質問対応
   - テストや問題報告
   - コミュニティイベントの企画
   - 新しい貢献者のメンタリング

### Contribution Process: Core Protocol

コアMCPプロトコルや公式実装に貢献するには、[公式の貢献ガイドライン](https://github.com/modelcontextprotocol/modelcontextprotocol/blob/main/CONTRIBUTING.md)にある以下の原則に従ってください：

1. **Simplicity and Minimalism**: MCP仕様は新しい概念の追加に対して高い基準を持っています。仕様に追加するのは簡単ですが、削除は難しいです。

2. **Concrete Approach**: 仕様変更は具体的な実装上の課題に基づくべきで、推測的なアイデアではありません。

3. **Stages of a Proposal**:
   - Define: 問題領域を探り、他のMCPユーザーも同様の問題を抱えていることを確認する
   - Prototype: 例となる解決策を作成し、その実用性を示す
   - Write: プロトタイプに基づいて仕様提案を書く

### Development Environment Setup

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

### Example: Contributing a Bug Fix

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

### Example: Contributing a New Tool to the Standard Library

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

MCPプロジェクトに成功裏に貢献するためのポイント：

1. **Start Small**: ドキュメント、バグ修正、小さな改善から始める
2. **Follow the Style Guide**: プロジェクトのコーディングスタイルと規約に従う
3. **Write Tests**: コードにはユニットテストを含める
4. **Document Your Work**: 新機能や変更点は明確にドキュメント化する
5. **Submit Targeted PRs**: プルリクエストは単一の問題や機能に絞る
6. **Engage with Feedback**: フィードバックには積極的に対応する

### Example Contribution Workflow

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

## Creating and Sharing MCP Servers

MCPエコシステムに貢献する最も価値のある方法の一つは、カスタムMCPサーバーを作成し共有することです。コミュニティはすでに多様なサービスやユースケース向けに数百のサーバーを開発しています。

### MCP Server Development Frameworks

MCPサーバー開発を簡単にするフレームワークがいくつかあります：

1. **Official SDKs**:
   - [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
   - [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
   - [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
   - [Go SDK](https://github.com/modelcontextprotocol/go-sdk)
   - [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
   - [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

2. **Community Frameworks**:
   - [MCP-Framework](https://mcp-framework.com/) - TypeScriptでエレガントかつ高速にMCPサーバーを構築
   - [MCP Declarative Java SDK](https://github.com/codeboyzhou/mcp-declarative-java-sdk) - Javaで注釈駆動のMCPサーバー
   - [Quarkus MCP Server SDK](https://github.com/quarkiverse/quarkus-mcp-server) - MCPサーバー向けJavaフレームワーク
   - [Next.js MCP Server Template](https://github.com/vercel-labs/mcp-for-next.js) - MCPサーバー用のNext.jsスタータープロジェクト

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

MCPツールをコミュニティと共有する際のポイント：

1. **Complete Documentation**:
   - 目的、使い方、例をドキュメント化する
   - パラメーターや戻り値を説明する
   - 外部依存関係があれば記載する

2. **Error Handling**:
   - 堅牢なエラーハンドリングを実装する
   - 有用なエラーメッセージを提供する
   - エッジケースも適切に処理する

3. **Performance Considerations**:
   - 速度とリソース使用の両面で最適化する
   - 適切な場合はキャッシュを利用する
   - スケーラビリティを考慮する

4. **Security**:
   - 安全なAPIキーや認証を使用する
   - 入力値の検証とサニタイズを行う
   - 外部API呼び出しに対してレート制限を実装する

5. **Testing**:
   - 十分なテストカバレッジを含める
   - さまざまな入力タイプやエッジケースでテストする
   - テスト手順をドキュメント化する

## Community Collaboration and Best Practices

効果的なコラボレーションは、活気あるMCPエコシステムの鍵です。

### Communication Channels

- GitHub IssuesとDiscussions
- Microsoft Tech Community
- DiscordやSlackチャンネル
- Stack Overflow（タグ：`model-context-protocol` または `mcp`）

### Code Reviews

MCPへの貢献をレビューする際のポイント：

1. **Clarity**: コードは明確で十分にドキュメント化されているか？
2. **Correctness**: 期待通りに動作するか？
3. **Consistency**: プロジェクトの規約に従っているか？
4. **Completeness**: テストやドキュメントが含まれているか？
5. **Security**: セキュリティ上の懸念はないか？

### Version Compatibility

MCP向けに開発する際の注意点：

1. **Protocol Versioning**: ツールが対応するMCPプロトコルバージョンに従う
2. **Client Compatibility**: 後方互換性を考慮する
3. **Server Compatibility**: サーバー実装のガイドラインに従う
4. **Breaking Changes**: 破壊的変更は明確にドキュメント化する

## Example Community Project: MCP Tool Registry

重要なコミュニティ貢献の一例として、MCPツールの公開レジストリを開発することが挙げられます。

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

- MCPコミュニティは多様で、さまざまな種類の貢献を歓迎している
- MCPへの貢献はコアプロトコルの改善からカスタムツールの作成まで幅広い
- 貢献ガイドラインに従うことでPRの承認率が上がる
- MCPツールの作成と共有はエコシステムを強化する貴重な方法
- コミュニティの協力はMCPの成長と改善に不可欠

## Exercise

1. 自分のスキルや興味に基づいて、MCPエコシステムのどの分野に貢献できるかを見つける
2. MCPリポジトリをフォークし、ローカル開発環境をセットアップする
3. コミュニティに役立つ小さな改善、バグ修正、またはツールを作成する
4. 適切なテストとドキュメントを添えて貢献内容を記録する
5. 対応するリポジトリにプルリクエストを提出する

## Additional Resources

- [MCP Community Projects](https://github.com/topics/model-context-protocol)


---

Next: [Lessons from Early Adoption](../07-LessonsfromEarlyAdoption/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性の向上に努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。