<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:06:27+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "bn"
}
-->
## Testing and Debugging

আপনার MCP সার্ভার পরীক্ষা শুরু করার আগে, উপলব্ধ টুল এবং ডিবাগিংয়ের সেরা পদ্ধতিগুলো বোঝা গুরুত্বপূর্ণ। কার্যকর পরীক্ষণ নিশ্চিত করে যে আপনার সার্ভার প্রত্যাশিতভাবে কাজ করছে এবং দ্রুত সমস্যা সনাক্ত ও সমাধান করতে সাহায্য করে। নিম্নলিখিত অংশে MCP বাস্তবায়ন যাচাই করার জন্য প্রস্তাবিত পদ্ধতিগুলো আলোচনা করা হয়েছে।

## Overview

এই লেসনে সঠিক পরীক্ষার পদ্ধতি নির্বাচন এবং সবচেয়ে কার্যকর পরীক্ষার টুল কীভাবে ব্যবহার করবেন তা কভার করা হয়েছে।

## Learning Objectives

এই লেসনের শেষে আপনি সক্ষম হবেন:

- বিভিন্ন পরীক্ষার পদ্ধতি বর্ণনা করতে।
- বিভিন্ন টুল ব্যবহার করে আপনার কোড কার্যকরভাবে পরীক্ষা করতে।

## Testing MCP Servers

MCP আপনাকে আপনার সার্ভারগুলো পরীক্ষা এবং ডিবাগ করার জন্য টুল সরবরাহ করে:

- **MCP Inspector**: একটি কমান্ড লাইন টুল যা CLI টুল হিসেবে এবং ভিজ্যুয়াল টুল হিসেবে চালানো যায়।
- **Manual testing**: আপনি curl এর মতো টুল ব্যবহার করে ওয়েব রিকোয়েস্ট চালাতে পারেন, তবে যেকোনো HTTP চালানোর সক্ষম টুল ব্যবহার করা যাবে।
- **Unit testing**: আপনার পছন্দের টেস্টিং ফ্রেমওয়ার্ক ব্যবহার করে সার্ভার এবং ক্লায়েন্ট উভয়ের ফিচারগুলো পরীক্ষা করা সম্ভব।

### Using MCP Inspector

আমরা পূর্বের লেসনে এই টুলের ব্যবহার বর্ণনা করেছি, তবে এখানে এর একটি সংক্ষিপ্ত পরিচিতি দিচ্ছি। এটি Node.js এ নির্মিত একটি টুল এবং আপনি `npx` এক্সিকিউটেবল কল করে এটি ব্যবহার করতে পারেন, যা অস্থায়ীভাবে টুলটি ডাউনলোড ও ইনস্টল করবে এবং আপনার রিকোয়েস্ট সম্পন্ন হলে নিজেই পরিষ্কার হয়ে যাবে।

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) আপনাকে সাহায্য করে:

- **Discover Server Capabilities**: স্বয়ংক্রিয়ভাবে উপলব্ধ রিসোর্স, টুল এবং প্রম্পট শনাক্ত করা
- **Test Tool Execution**: বিভিন্ন প্যারামিটার পরীক্ষা করা এবং রিয়েল-টাইমে প্রতিক্রিয়া দেখা
- **View Server Metadata**: সার্ভারের তথ্য, স্কিমা এবং কনফিগারেশন পর্যালোচনা করা

একটি সাধারণ টুল চালানোর উদাহরণ নিচে দেওয়া হলো:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

উপরের কমান্ডটি একটি MCP এবং এর ভিজ্যুয়াল ইন্টারফেস চালু করে এবং ব্রাউজারে একটি লোকাল ওয়েব ইন্টারফেস লঞ্চ করে। আপনি একটি ড্যাশবোর্ড দেখতে পাবেন যেখানে আপনার রেজিস্টার্ড MCP সার্ভার, তাদের উপলব্ধ টুল, রিসোর্স এবং প্রম্পট প্রদর্শিত হবে। ইন্টারফেসটি ইন্টারেক্টিভলি টুল এক্সিকিউশন পরীক্ষা, সার্ভার মেটাডেটা পরিদর্শন এবং রিয়েল-টাইম প্রতিক্রিয়া দেখার সুযোগ দেয়, যা MCP সার্ভার বাস্তবায়ন যাচাই ও ডিবাগ করা সহজ করে।

এটি দেখতে এমন হতে পারে: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.bn.png)

আপনি CLI মোডেও এই টুল চালাতে পারেন, তখন `--cli` অ্যাট্রিবিউট যোগ করতে হবে। নিচে CLI মোডে টুল চালানোর একটি উদাহরণ দেওয়া হলো, যা সার্ভারের সব টুলের তালিকা দেখায়:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manual Testing

ইনস্পেক্টর টুল ব্যবহার করে সার্ভারের ক্ষমতা পরীক্ষা করার পাশাপাশি, আরেকটি সমজাতীয় পদ্ধতি হল HTTP চালাতে সক্ষম ক্লায়েন্ট ব্যবহার করা, যেমন curl।

curl দিয়ে আপনি সরাসরি HTTP রিকোয়েস্ট ব্যবহার করে MCP সার্ভার পরীক্ষা করতে পারেন:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

উপরের curl ব্যবহারে দেখা যাচ্ছে, আপনি একটি POST রিকোয়েস্ট ব্যবহার করে টুল কল করছেন যার পে-লোডে টুলের নাম এবং প্যারামিটার রয়েছে। আপনার সুবিধা অনুযায়ী পদ্ধতি ব্যবহার করুন। CLI টুল সাধারণত দ্রুত এবং স্ক্রিপ্টের মাধ্যমে চালানো সহজ, যা CI/CD পরিবেশে উপযোগী।

### Unit Testing

আপনার টুল এবং রিসোর্সের জন্য ইউনিট টেস্ট তৈরি করুন যাতে তারা প্রত্যাশিতভাবে কাজ করে। নিচে কিছু উদাহরণ টেস্টিং কোড দেওয়া হলো।

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

উপরের কোডটি নিম্নলিখিত কাজগুলো করে:

- pytest ফ্রেমওয়ার্ক ব্যবহার করে, যা আপনাকে ফাংশন হিসেবে টেস্ট তৈরি করতে এবং assert স্টেটমেন্ট ব্যবহার করতে দেয়।
- দুইটি ভিন্ন টুল সহ একটি MCP সার্ভার তৈরি করে।
- নির্দিষ্ট শর্ত পূরণ হচ্ছে কিনা তা যাচাই করতে `assert` স্টেটমেন্ট ব্যবহার করে।

[পুরো ফাইলটি এখানে দেখুন](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

উপরের ফাইলটি দেখে, আপনি নিজের সার্ভার পরীক্ষা করতে পারবেন এবং নিশ্চিত করতে পারবেন যে ক্ষমতাগুলো সঠিকভাবে তৈরি হয়েছে।

সব প্রধান SDK তে একই রকম টেস্টিং অংশ থাকে, তাই আপনি আপনার পছন্দের রানটাইম অনুযায়ী সামঞ্জস্য করতে পারবেন।

## Samples 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Additional Resources

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## What's Next

- Next: [Deployment](/03-GettingStarted/09-deployment/README.md)

**অস্বীকারোক্তি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে বলে অনুগ্রহ করে সচেতন থাকুন। মূল নথিটি তার নিজস্ব ভাষায় কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ প্রয়োজন। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুলবোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।