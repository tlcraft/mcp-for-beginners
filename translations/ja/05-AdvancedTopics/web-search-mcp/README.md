<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T15:04:02+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ja"
}
-->
# レッスン: Web検索MCPサーバーの構築

この章では、外部APIと連携し、多様なデータタイプを扱い、エラー管理を行い、複数のツールを統合する、実践的なAIエージェントの作り方を示します。以下の内容を学べます：

- **認証が必要な外部APIとの連携**
- **複数のエンドポイントからの多様なデータタイプの処理**
- **堅牢なエラー処理とログ戦略**
- **単一サーバー内でのマルチツールのオーケストレーション**

これらを通じて、先進的なAIやLLM搭載アプリケーションに不可欠なパターンやベストプラクティスを実践的に習得できます。

## はじめに

このレッスンでは、SerpAPIを使ってリアルタイムのウェブデータを取り込み、LLMの能力を拡張する高度なMCPサーバーとクライアントの構築方法を学びます。これは、最新情報にアクセスできる動的なAIエージェント開発において重要なスキルです。

## 学習目標

このレッスンの終了時には、以下ができるようになります：

- SerpAPIなどの外部APIを安全にMCPサーバーに統合する
- ウェブ検索、ニュース検索、商品検索、Q&Aの複数ツールを実装する
- LLMが扱いやすい形式に構造化データを解析・整形する
- エラー処理とAPIのレート制限管理を効果的に行う
- 自動テストおよびインタラクティブなMCPクライアントの構築とテスト

## Web検索MCPサーバー

このセクションでは、Web検索MCPサーバーのアーキテクチャと特徴を紹介します。FastMCPとSerpAPIを組み合わせて、リアルタイムのウェブデータでLLMの能力を拡張する方法を示します。

### 概要

この実装では、MCPが多様な外部API駆動のタスクを安全かつ効率的に扱う能力を示す4つのツールを提供します：

- **general_search**：広範囲なウェブ検索用
- **news_search**：最新ニュースの取得用
- **product_search**：Eコマースデータ検索用
- **qna**：質問応答スニペット取得用

### 特徴
- **コード例**：Python用の言語別コードブロックを折りたたみ可能なセクションで掲載（他言語への拡張も容易）

<details>  
<summary>Python</summary>  

```python
# Example usage of the general_search tool
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "open source LLMs"})
            print(result)
```
</details>

クライアントを実行する前に、サーバーが何をしているか理解すると良いでしょう。[`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)を参照してください。

以下はサーバーがツールを定義し登録する簡単な例です：

<details>  
<summary>Pythonサーバー</summary> 

```python
# server.py (excerpt)
from mcp.server import MCPServer, Tool

async def general_search(query: str):
    # ...implementation...

server = MCPServer()
server.add_tool(Tool("general_search", general_search))

if __name__ == "__main__":
    server.run()
```
</details>

- **外部API連携**：APIキーと外部リクエストの安全な取り扱いを実演
- **構造化データ解析**：APIレスポンスをLLMに適した形式に変換する方法を示す
- **エラー処理**：適切なログ記録を伴う堅牢なエラー処理
- **インタラクティブクライアント**：自動テストとインタラクティブモードの両方を提供
- **コンテキスト管理**：MCP Contextを利用したログ記録とリクエスト追跡

## 事前準備

開始前に、以下の手順で環境を整えてください。これにより、依存関係がインストールされ、APIキーが正しく設定され、開発とテストがスムーズに進みます。

- Python 3.8以上
- SerpAPI APIキー（[SerpAPI](https://serpapi.com/)で登録 - 無料プランあり）

## インストール

環境設定のため、以下の手順に従ってください：

1. uv（推奨）またはpipで依存関係をインストール：

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. プロジェクトルートに`.env`ファイルを作成し、SerpAPIキーを設定：

```
SERPAPI_KEY=your_serpapi_key_here
```

## 使い方

Web検索MCPサーバーは、SerpAPIと連携してウェブ、ニュース、商品検索、Q&Aのツールを提供するコアコンポーネントです。リクエストを受け、API呼び出しを管理し、レスポンスを解析してクライアントに構造化された結果を返します。

完全な実装は[`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)で確認できます。

### サーバーの起動

MCPサーバーを起動するには、以下のコマンドを使用します：

```bash
python server.py
```

このサーバーはstdioベースのMCPサーバーとして動作し、クライアントが直接接続可能です。

### クライアントモード

クライアントは[`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)です。

### クライアントの実行

自動テストを実行する（サーバーも自動で起動）：

```bash
python client.py
```

またはインタラクティブモードで起動：

```bash
python client.py --interactive
```

### 様々な方法でのテスト

用途やワークフローに応じて、サーバーのツールをテスト・操作する方法は複数あります。

#### MCP Python SDKを使ったカスタムテストスクリプトの作成
MCP Python SDKを使って独自のテストスクリプトを作成可能です：

<details>
<summary>Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def test_custom_query():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            # Call tools with your custom parameters
            result = await session.call_tool("general_search", 
                                           arguments={"query": "your custom query"})
            # Process the result
```
</details>

ここでいう「テストスクリプト」とは、MCPサーバーのクライアントとして機能するカスタムPythonプログラムのことです。正式なユニットテストではなく、プログラムからサーバーに接続し、任意のツールをパラメータ付きで呼び出し、結果を確認できます。この方法は以下に役立ちます：

- ツール呼び出しのプロトタイピングや実験
- サーバーの応答の検証
- 繰り返しツールを自動で呼び出す
- MCPサーバー上で独自のワークフローや統合を構築

新しいクエリの素早い試行やツール動作のデバッグ、より高度な自動化の出発点としても有用です。以下にMCP Python SDKを使った例を示します。

## ツールの説明

サーバーが提供する以下のツールを使って、様々な検索やクエリを実行できます。各ツールのパラメータと使用例を説明します。

このセクションでは、利用可能なツールとそのパラメータの詳細を提供します。

### general_search

一般的なウェブ検索を行い、整形された結果を返します。

**このツールの呼び出し方：**

MCP Python SDKを使ってスクリプトから呼び出すか、Inspectorやインタラクティブクライアントモードで利用できます。SDKを使ったコード例：

<details>
<summary>Python例</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_general_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "latest AI trends"})
            print(result)
```
</details>

またはインタラクティブモードで、`general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（文字列）：検索クエリを選択

**リクエスト例：**

```json
{
  "query": "latest AI trends"
}
```

### news_search

指定したクエリに関連する最新ニュース記事を検索します。

**このツールの呼び出し方：**

MCP Python SDKを使ってスクリプトから呼び出すか、Inspectorやインタラクティブクライアントモードで利用可能。SDK例：

<details>
<summary>Python例</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_news_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("news_search", arguments={"query": "AI policy updates"})
            print(result)
```
</details>

またはインタラクティブモードで、`news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（文字列）：検索クエリを選択

**リクエスト例：**

```json
{
  "query": "AI policy updates"
}
```

### product_search

クエリに合致する商品を検索します。

**このツールの呼び出し方：**

MCP Python SDKを使ってスクリプトから呼び出すか、Inspectorやインタラクティブクライアントモードで利用可能。SDK例：

<details>
<summary>Python例</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_product_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("product_search", arguments={"query": "best AI gadgets 2025"})
            print(result)
```
</details>

またはインタラクティブモードで、`product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（文字列）：商品検索クエリを選択

**リクエスト例：**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

検索エンジンから質問に対する直接的な回答を取得します。

**このツールの呼び出し方：**

MCP Python SDKを使ってスクリプトから呼び出すか、Inspectorやインタラクティブクライアントモードで利用可能。SDK例：

<details>
<summary>Python例</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_qna():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("qna", arguments={"question": "what is artificial intelligence"})
            print(result)
```
</details>

またはインタラクティブモードで、`qna` from the menu and enter your question when prompted.

**Parameters:**
- `question`（文字列）：回答を求める質問を選択

**リクエスト例：**

```json
{
  "question": "what is artificial intelligence"
}
```

## コードの詳細

このセクションでは、サーバーおよびクライアント実装のコードスニペットと参照を提供します。

<details>
<summary>Python</summary>

完全な実装は[`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)を参照してください。

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## このレッスンの高度な概念

構築を始める前に、この章で頻出する重要な高度概念を理解しておくとスムーズです。これらを押さえることで、初めての方でも内容を追いやすくなります：

- **マルチツールオーケストレーション**：単一のMCPサーバー内で複数の異なるツール（ウェブ検索、ニュース検索、商品検索、Q&A）を動かすこと。多様なタスクを処理可能にします。
- **APIレート制限管理**：SerpAPIなど多くの外部APIは一定時間内のリクエスト数に制限があります。良いコードはこれを検知し、制限に達してもアプリが壊れないように対処します。
- **構造化データ解析**：APIレスポンスは複雑かつ入れ子構造の場合が多いです。これをLLMや他のプログラムが扱いやすいクリーンな形式に変換する技術です。
- **エラー復旧**：ネットワーク障害やAPIの想定外レスポンスなど問題が起きた際に、クラッシュせずに適切なフィードバックを返す処理です。
- **パラメータ検証**：ツールへの入力が正しく安全かをチェックし、デフォルト値設定や型チェックを行うことでバグや混乱を防ぎます。

このセクションはWeb検索MCPサーバーで遭遇しやすい問題の診断・解決に役立ちます。エラーや予期しない挙動があったらまずここを確認してください。多くの場合、ここにあるヒントで問題が解決します。

## トラブルシューティング

Web検索MCPサーバーを使う際に、時折問題が発生することがあります。これは外部APIや新しいツールを使う際にはよくあることです。このセクションでは、よくある問題とその解決策を実践的に紹介します。エラーが起きたらまずここを確認しましょう。以下のヒントは多くのユーザーが直面する問題をカバーしており、追加のサポートなしに解決できることが多いです。

### よくある問題

以下はユーザーがよく遭遇する問題と、その説明および解決手順です：

1. **.envファイルにSERPAPI_KEYがない**
   - `SERPAPI_KEY環境変数が見つかりません`というエラーが出た場合は、`.env`ファイルを作成し、`SERPAPI_KEY=your_serpapi_key_here`の形式でキーを設定してください。キーが正しいのにエラーが続く場合は、無料プランのクォータが切れていないか確認してください。

### デバッグモード

デフォルトでは、アプリは重要な情報のみをログに出力します。より詳細な動作を確認したい場合（特にトラブルシューティング時）は、DEBUGモードを有効にすると、HTTPリクエストやレスポンスなどの内部情報も表示されます。

**例：通常出力**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**例：DEBUG出力**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

DEBUGモードではHTTP通信や内部処理の追加ログが表示されるため、問題の原因特定に非常に役立ちます。

DEBUGモードを有効にするには、`client.py` or `server.py`の冒頭でログレベルをDEBUGに設定してください：

<details>
<summary>Python</summary>

```python
# At the top of your client.py or server.py
import logging
logging.basicConfig(
    level=logging.DEBUG,  # Change from INFO to DEBUG
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
```
</details>

---

## 次のステップ

- [5.10 リアルタイムストリーミング](../mcp-realtimestreaming/README.md)

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご了承ください。原文の言語によるオリジナル文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。