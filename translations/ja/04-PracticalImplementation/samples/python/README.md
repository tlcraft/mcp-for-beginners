<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:28:37+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "ja"
}
-->
# Model Context Protocol (MCP) Python 実装

このリポジトリは、Model Context Protocol (MCP) のPython実装を含んでおり、MCP標準を使って通信するサーバーとクライアントアプリケーションの作り方を示しています。

## 概要

MCP実装は主に2つのコンポーネントで構成されています：

1. **MCP Server (`server.py`)** - 以下を公開するサーバー：
   - **Tools**：リモートで呼び出せる関数
   - **Resources**：取得可能なデータ
   - **Prompts**：言語モデル向けのプロンプトテンプレート

2. **MCP Client (`client.py`)** - サーバーに接続し、その機能を利用するクライアントアプリケーション

## 機能

この実装では、いくつかの主要なMCP機能を示しています：

### Tools
- `completion` - AIモデルからテキスト補完を生成（シミュレーション）
- `add` - 2つの数値を足し算するシンプルな電卓

### Resources
- `models://` - 利用可能なAIモデルの情報を返す
- `greeting://{name}` - 指定した名前に対するパーソナライズされた挨拶を返す

### Prompts
- `review_code` - コードレビュー用のプロンプトを生成

## インストール

このMCP実装を使うには、必要なパッケージをインストールしてください：

```powershell
pip install mcp-server mcp-client
```

## サーバーとクライアントの起動

### サーバーの起動

1つのターミナルでサーバーを起動します：

```powershell
python server.py
```

サーバーはMCP CLIを使って開発モードで起動することもできます：

```powershell
mcp dev server.py
```

または、Claude Desktopにインストールして起動することも可能です（利用可能な場合）：

```powershell
mcp install server.py
```

### クライアントの起動

別のターミナルでクライアントを起動します：

```powershell
python client.py
```

これによりサーバーに接続し、利用可能な全機能をデモします。

### クライアントの使い方

クライアント（`client.py`）はMCPの全機能を実演します：

```powershell
python client.py
```

これによりサーバーに接続し、tools、resources、promptsを含む全機能を試します。出力には以下が表示されます：

1. 電卓ツールの結果（5 + 7 = 12）
2. "What is the meaning of life?" に対する補完ツールの応答
3. 利用可能なAIモデルの一覧
4. "MCP Explorer" に対するパーソナライズされた挨拶
5. コードレビュー用のプロンプトテンプレート

## 実装の詳細

サーバーは `FastMCP` API を使って実装されており、MCPサービスを定義するための高レベル抽象を提供します。以下はツール定義の簡単な例です：

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers together
    
    Args:
        a: First number
        b: Second number
    
    Returns:
        The sum of the two numbers
    """
    logger.info(f"Adding {a} and {b}")
    return a + b
```

クライアントはMCPクライアントライブラリを使ってサーバーに接続し、呼び出します：

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## 詳しく知るには

MCPについての詳細は以下を参照してください：https://modelcontextprotocol.io/

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されました。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の母国語版が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や解釈の相違について、当方は一切責任を負いません。