<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:23:51+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "ja"
}
-->
# MCPサーバーとstdioトランスポート

> **⚠️ 重要な更新情報**: MCP仕様2025-06-18より、スタンドアロンのSSE（Server-Sent Events）トランスポートは**非推奨**となり、「Streamable HTTP」トランスポートに置き換えられました。現在のMCP仕様では、以下の2つの主要なトランスポートメカニズムが定義されています：
> 1. **stdio** - 標準入力/出力（ローカルサーバーに推奨）
> 2. **Streamable HTTP** - 内部でSSEを使用する可能性のあるリモートサーバー向け
>
> このレッスンでは、ほとんどのMCPサーバー実装に推奨される**stdioトランスポート**に焦点を当てて更新されています。

stdioトランスポートを使用すると、MCPサーバーは標準入力および出力ストリームを介してクライアントと通信できます。これは現在のMCP仕様で最も一般的かつ推奨されるトランスポートメカニズムであり、さまざまなクライアントアプリケーションと簡単に統合できるシンプルで効率的な方法を提供します。

## 概要

このレッスンでは、stdioトランスポートを使用してMCPサーバーを構築および利用する方法を学びます。

## 学習目標

このレッスンの終わりまでに、以下ができるようになります：

- stdioトランスポートを使用してMCPサーバーを構築する
- MCPサーバーをインスペクターでデバッグする
- Visual Studio Codeを使用してMCPサーバーを利用する
- 現在のMCPトランスポートメカニズムを理解し、stdioが推奨される理由を把握する

## stdioトランスポート - 動作の仕組み

stdioトランスポートは、現在のMCP仕様（2025-06-18）でサポートされている2つのトランスポートタイプの1つです。その仕組みは以下の通りです：

- **シンプルな通信**: サーバーは標準入力（`stdin`）からJSON-RPCメッセージを読み取り、標準出力（`stdout`）にメッセージを送信します。
- **プロセスベース**: クライアントはMCPサーバーをサブプロセスとして起動します。
- **メッセージ形式**: メッセージは、改行で区切られた個々のJSON-RPCリクエスト、通知、またはレスポンスです。
- **ログ記録**: サーバーはログ記録のために標準エラー（`stderr`）にUTF-8文字列を書き込むことができます。

### 主な要件：
- メッセージは改行で区切られ、埋め込み改行を含んではいけません。
- サーバーは、`stdout`に有効なMCPメッセージ以外を書き込んではいけません。
- クライアントは、サーバーの`stdin`に有効なMCPメッセージ以外を書き込んではいけません。

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

上記のコードでは：

- MCP SDKから`Server`クラスと`StdioServerTransport`をインポートしています。
- 基本的な設定と機能を持つサーバーインスタンスを作成しています。

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

上記のコードでは：

- MCP SDKを使用してサーバーインスタンスを作成しています。
- デコレータを使用してツールを定義しています。
- stdio_serverコンテキストマネージャを使用してトランスポートを処理しています。

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

SSEとの主な違いは、stdioサーバーが以下を必要としない点です：

- WebサーバーのセットアップやHTTPエンドポイント
- クライアントによるサーバーのサブプロセスとしての起動
- stdin/stdoutストリームを介した通信
- 実装とデバッグがより簡単

## 演習: stdioサーバーの作成

サーバーを作成するには、以下の2点を念頭に置く必要があります：

- 接続とメッセージ用のエンドポイントを公開するためにWebサーバーを使用する必要があります。

## 実習: シンプルなMCP stdioサーバーの作成

この実習では、推奨されるstdioトランスポートを使用してシンプルなMCPサーバーを作成します。このサーバーは、クライアントが標準のModel Context Protocolを使用して呼び出せるツールを公開します。

### 前提条件

- Python 3.8以上
- MCP Python SDK: `pip install mcp`
- 非同期プログラミングの基本的な理解

最初のMCP stdioサーバーを作成してみましょう：

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## 非推奨となったSSEアプローチとの主な違い

**Stdioトランスポート（現在の標準）:**
- シンプルなサブプロセスモデル - クライアントがサーバーを子プロセスとして起動
- stdin/stdoutを介したJSON-RPCメッセージによる通信
- HTTPサーバーのセットアップ不要
- パフォーマンスとセキュリティの向上
- デバッグと開発が容易

**SSEトランスポート（MCP 2025-06-18以降非推奨）:**
- SSEエンドポイントを持つHTTPサーバーが必要
- Webサーバーインフラのセットアップが複雑
- HTTPエンドポイントの追加のセキュリティ考慮事項
- WebベースのシナリオではStreamable HTTPに置き換え

### stdioトランスポートを使用したサーバーの作成

stdioサーバーを作成するには、以下を行う必要があります：

1. **必要なライブラリをインポート** - MCPサーバーコンポーネントとstdioトランスポートをインポート
2. **サーバーインスタンスを作成** - サーバーをその機能とともに定義
3. **ツールを定義** - 公開したい機能を追加
4. **トランスポートを設定** - stdio通信を構成
5. **サーバーを実行** - サーバーを起動し、メッセージを処理

ステップごとに構築してみましょう：

### ステップ1: 基本的なstdioサーバーを作成

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### ステップ2: ツールを追加

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### ステップ3: サーバーの実行

コードを`server.py`として保存し、コマンドラインから実行します：

```bash
python server.py
```

サーバーは起動し、stdinからの入力を待機します。stdioトランスポートを介してJSON-RPCメッセージで通信します。

### ステップ4: インスペクターを使用したテスト

インスペクターを使用してサーバーをテストできます：

1. インスペクターをインストール: `npx @modelcontextprotocol/inspector`
2. インスペクターを実行し、サーバーを指定
3. 作成したツールをテスト

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

## Debugging your stdio server

### Using the MCP Inspector

The MCP Inspector is a valuable tool for debugging and testing MCP servers. Here's how to use it with your stdio server:

1. **Install the Inspector**:
   ```

### 期待される結果

サーバーが正しく起動すると、以下が確認できます：
- インスペクターにサーバーの機能が表示される
- テスト可能なツールが利用可能
- 成功したJSON-RPCメッセージのやり取り
- インターフェースに表示されるツールのレスポンス

### よくある問題と解決策

**サーバーが起動しない:**
- すべての依存関係がインストールされているか確認: `pip install mcp`
- Pythonの構文とインデントを確認
- コンソールのエラーメッセージを確認

**ツールが表示されない:**
- `@server.tool()`デコレータが存在するか確認
- ツール関数が`main()`の前に定義されているか確認
- サーバーが正しく構成されているか確認

**接続の問題:**
- サーバーがstdioトランスポートを正しく使用しているか確認
- 他のプロセスが干渉していないか確認
- インスペクターコマンドの構文を確認

## 課題

サーバーにさらに多くの機能を追加してみてください。例えば、[このページ](https://api.chucknorris.io/)を参考にして、APIを呼び出すツールを追加してみましょう。サーバーの設計は自由です。楽しんでください :)

## 解答

[解答](./solution/README.md) 動作するコードの一例はこちらです。

## 重要なポイント

この章の重要なポイントは以下の通りです：

- stdioトランスポートはローカルMCPサーバーに推奨されるメカニズムです。
- stdioトランスポートは、標準入力および出力ストリームを使用してMCPサーバーとクライアント間のシームレスな通信を可能にします。
- インスペクターやVisual Studio Codeを使用して、stdioサーバーを直接利用でき、デバッグや統合が簡単です。

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## 追加リソース

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 次のステップ

### 次のステップ

MCPサーバーをstdioトランスポートで構築する方法を学んだので、次の高度なトピックを探求してみましょう：

- **次へ**: [MCPのHTTPストリーミング（Streamable HTTP）](../06-http-streaming/README.md) - リモートサーバー向けのもう1つのサポートされているトランスポートメカニズムを学ぶ
- **高度**: [MCPセキュリティのベストプラクティス](../../02-Security/README.md) - MCPサーバーにセキュリティを実装する
- **運用**: [デプロイ戦略](../09-deployment/README.md) - サーバーを運用環境にデプロイする

## 追加リソース

- [MCP仕様2025-06-18](https://spec.modelcontextprotocol.io/specification/) - 公式仕様
- [MCP SDKドキュメント](https://github.com/modelcontextprotocol/sdk) - すべての言語向けSDKリファレンス
- [コミュニティの例](../../06-CommunityContributions/README.md) - コミュニティによるサーバー例

---

**免責事項**:  
この文書は、AI翻訳サービス [Co-op Translator](https://github.com/Azure/co-op-translator) を使用して翻訳されています。正確性を追求しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知ください。元の言語で記載された文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。この翻訳の使用に起因する誤解や誤解釈について、当方は一切の責任を負いません。