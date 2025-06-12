<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-12T22:23:24+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "ja"
}
-->
## テストとデバッグ

MCPサーバーのテストを始める前に、利用可能なツールやデバッグのベストプラクティスを理解することが重要です。効果的なテストはサーバーが期待通りに動作することを保証し、問題の迅速な特定と解決を助けます。以下のセクションでは、MCPの実装を検証するための推奨される方法を紹介します。

## 概要

このレッスンでは、適切なテスト方法の選び方と最も効果的なテストツールについて説明します。

## 学習目標

このレッスンの終了時には、以下ができるようになります：

- さまざまなテスト手法を説明できる。
- 複数のツールを使って効果的にコードをテストできる。

## MCPサーバーのテスト

MCPはサーバーのテストとデバッグを支援するツールを提供しています：

- **MCP Inspector**：CLIツールとしてもビジュアルツールとしても使用できるコマンドラインツール。
- **手動テスト**：curlのようなツールを使ってWebリクエストを実行できますが、HTTPを実行できるツールなら何でも構いません。
- **ユニットテスト**：お好みのテストフレームワークを使ってサーバーとクライアントの機能をテストすることが可能です。

### MCP Inspectorの使い方

このツールの使い方は以前のレッスンで説明しましたが、ここでは概要を簡単に説明します。Node.jsで作られており、`npx`実行ファイルを呼び出すことで使用できます。この実行によりツールが一時的にダウンロード・インストールされ、リクエスト処理後は自動的にクリーンアップされます。

[MCP Inspector](https://github.com/modelcontextprotocol/inspector)でできること：

- **サーバー機能の発見**：利用可能なリソース、ツール、プロンプトを自動検出
- **ツール実行のテスト**：さまざまなパラメータを試し、リアルタイムでレスポンスを確認
- **サーバーメタデータの閲覧**：サーバー情報、スキーマ、設定の確認

ツールの典型的な実行例は以下の通りです：

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

上記コマンドはMCPとそのビジュアルインターフェースを起動し、ブラウザでローカルのWebインターフェースを開きます。登録されたMCPサーバー、利用可能なツール、リソース、プロンプトがダッシュボードに表示されます。インターフェースを使ってツール実行のインタラクティブなテストやサーバーメタデータの検査、リアルタイムレスポンスの確認ができ、MCPサーバーの実装検証とデバッグが容易になります。

画面は以下のようになります： ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ja.png)

CLIモードで実行する場合は`--cli`オプションを付けます。以下はCLIモードでサーバー上のすべてのツールを一覧表示する例です：

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### 手動テスト

インスペクターツールでサーバー機能をテストする以外に、curlのようなHTTPクライアントを使って直接テストする方法もあります。

curlを使うと、HTTPリクエストでMCPサーバーを直接テストできます：

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

上記のcurl使用例からわかるように、ツール名とパラメータを含むペイロードでPOSTリクエストを送りツールを呼び出します。自分に合った方法を選んでください。CLIツールは一般的に操作が速く、スクリプト化しやすいためCI/CD環境で便利です。

### ユニットテスト

ツールやリソースの機能が期待通りに動作することを保証するためにユニットテストを作成しましょう。以下はテストコードの例です。

```python
import pytest

from mcp.server.fastmcp import FastMCP
from mcp.shared.memory import (
    create_connected_server_and_client_session as create_session,
)

# Mark the whole module for async tests
pytestmark = pytest.mark.anyio


async def test_list_tools_cursor_parameter():
    """Test that the cursor parameter is accepted for list_tools.

    Note: FastMCP doesn't currently implement pagination, so this test
    only verifies that the cursor parameter is accepted by the client.
    """

 server = FastMCP("test")

    # Create a couple of test tools
    @server.tool(name="test_tool_1")
    async def test_tool_1() -> str:
        """First test tool"""
        return "Result 1"

    @server.tool(name="test_tool_2")
    async def test_tool_2() -> str:
        """Second test tool"""
        return "Result 2"

    async with create_session(server._mcp_server) as client_session:
        # Test without cursor parameter (omitted)
        result1 = await client_session.list_tools()
        assert len(result1.tools) == 2

        # Test with cursor=None
        result2 = await client_session.list_tools(cursor=None)
        assert len(result2.tools) == 2

        # Test with cursor as string
        result3 = await client_session.list_tools(cursor="some_cursor_value")
        assert len(result3.tools) == 2

        # Test with empty string cursor
        result4 = await client_session.list_tools(cursor="")
        assert len(result4.tools) == 2
    
```

上記コードは以下のことを行っています：

- 関数としてテストを作成し、assert文を使えるpytestフレームワークを利用。
- 2つの異なるツールを持つMCPサーバーを作成。
- `assert`文で特定の条件が満たされているか確認。

[こちらのファイル全文](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)も参考にしてください。

このファイルを参考に、自分のサーバーが正しく機能しているかテストできます。

主要なSDKには同様のテストセクションがあるので、使用するランタイムに合わせて調整可能です。

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 追加リソース

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## 次に進む

- 次へ：[Deployment](/03-GettingStarted/09-deployment/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間翻訳を推奨します。本翻訳の使用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。