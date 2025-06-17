<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-17T16:47:26+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "my"
}
-->
## စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေရေး

MCP ဆာဗာကို စမ်းသပ်မတိုင်မီ၊ ရရှိနိုင်သောကိရိယာများနှင့် အမှားရှာဖွေရေးအတွက် အကောင်းဆုံးနည်းလမ်းများကို နားလည်ထားခြင်းမှာ အရေးကြီးသည်။ ထိရောက်စွာ စမ်းသပ်ခြင်းဖြင့် သင့်ဆာဗာသည် မျှော်မှန်းထားသလို အလုပ်လုပ်နေကြောင်း သေချာစေပြီး ပြဿနာများကို အလျင်အမြန် ဖော်ထုတ်ကာ ဖြေရှင်းနိုင်စေသည်။ အောက်တွင် MCP အကောင်အထည်ဖော်မှုကို စစ်ဆေးရန် အကြံပြုထားသော နည်းလမ်းများကို ဖော်ပြထားသည်။

## အကျဉ်းချုပ်

ဤသင်ခန်းစာတွင် သင့်အတွက် သင့်တော်သော စမ်းသပ်နည်းလမ်းနှင့် ထိရောက်သော စမ်းသပ်ကိရိယာကို ရွေးချယ်နည်းကို ဖော်ပြထားသည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာအဆုံးသတ်ချိန်တွင် သင်သည် -

- စမ်းသပ်မှုအတွက် မတူညီသောနည်းလမ်းများကို ဖော်ပြနိုင်မည်။
- သင့်ကုဒ်ကို ထိရောက်စွာ စမ်းသပ်ရန် ကိရိယာများကို အသုံးပြုနိုင်မည်။

## MCP ဆာဗာများ စမ်းသပ်ခြင်း

MCP သည် သင့်ဆာဗာများကို စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေရေးအတွက် ကိရိယာများကို ပံ့ပိုးပေးသည် -

- **MCP Inspector**: CLI ကိရိယာတစ်ခုဖြစ်ပြီး CLI အဖြစ်နှင့် မျက်နှာပြင်အဖြစ် နှစ်မျိုးလုံး အသုံးပြုနိုင်သည်။
- **လက်ဖြင့် စမ်းသပ်ခြင်း**: curl ကဲ့သို့သော ကိရိယာတစ်ခုကို အသုံးပြု၍ ဝဘ်တောင်းဆိုမှုများကို လည်ပတ်နိုင်ပြီး HTTP လုပ်ဆောင်နိုင်သည့် ကိရိယာ များအားလုံးအသုံးပြုနိုင်သည်။
- **ယူနစ်စမ်းသပ်ခြင်း**: သင့်ကြိုက်နှစ်သက်သော စမ်းသပ်မှုဖွဲ့စည်းပုံကို အသုံးပြု၍ ဆာဗာနှင့် ကလိုင်ယင့်၏ လုပ်ဆောင်ချက်များကို စမ်းသပ်နိုင်သည်။

### MCP Inspector အသုံးပြုခြင်း

ဤကိရိယာ၏ အသုံးပြုနည်းကို ယခင်သင်ခန်းစာများတွင် ရှင်းပြထားပြီး ဖြစ်သော်လည်း အထက်လွှာအနည်းငယ် ပြောပြလိုသည်။ Node.js ဖြင့် တည်ဆောက်ထားသော ကိရိယာတစ်ခုဖြစ်ပြီး `npx` ကို ခေါ်ယူ၍ အသုံးပြုနိုင်သည်။ ၎င်းကိရိယာကို ယာယီဒေါင်းလုဒ်လုပ်၍ ထည့်သွင်းကာ သင့်တောင်းဆိုမှု ပြီးဆုံးသည့်အခါ မိမိကိုယ်ကို သန့်ရှင်းပေးသည်။

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) သည် -

- **ဆာဗာ၏ စွမ်းရည်များ ရှာဖွေရန်**: ရရှိနိုင်သော အရင်းအမြစ်များ၊ ကိရိယာများနှင့် prompt များကို အလိုအလျောက် ဖော်ထုတ်ပေးသည်။
- **ကိရိယာ အကောင်အထည်ဖော်မှု စမ်းသပ်ခြင်း**: parameter များကို လေ့လာပြီး တုံ့ပြန်မှုများကို အချိန်နဲ့တပြေးညီ ကြည့်ရှုနိုင်သည်။
- **ဆာဗာ Metadata ကြည့်ရှုခြင်း**: ဆာဗာအချက်အလက်၊ schema များနှင့် ဖွဲ့စည်းမှုများကို စစ်ဆေးနိုင်သည်။

ပုံမှန်အသုံးပြုမှုမှာ -

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

အထက်ပါ command သည် MCP နှင့် ၎င်း၏ မျက်နှာပြင်ကို စတင်ဖွင့်ပြီး သင့် browser တွင် ဒေသဆိုင်ရာ ဝဘ်မျက်နှာပြင်ကို ဖွင့်ပေးသည်။ သင့်မှတ်ပုံတင်ထားသော MCP ဆာဗာများ၊ ၎င်းတို့ရရှိနိုင်သော ကိရိယာများ၊ အရင်းအမြစ်များနှင့် prompt များကို dashboard တွင် မြင်တွေ့နိုင်မည်ဖြစ်သည်။ ၎င်းမျက်နှာပြင်မှ ကိရိယာများကို အပြန်အလှန် စမ်းသပ်နိုင်ခြင်း၊ ဆာဗာ metadata ကို စစ်ဆေးနိုင်ခြင်းနှင့် တုံ့ပြန်မှုများကို အချိန်နဲ့တပြေးညီ ကြည့်ရှုနိုင်ခြင်းတို့က MCP ဆာဗာ အကောင်အထည်ဖော်မှုများကို အလွယ်တကူ သေချာစစ်ဆေးရန် အထောက်အကူဖြစ်စေသည်။

ဒီလိုမျိုးမြင်ရနိုင်ပါတယ်။ ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.my.png)

CLI အဖြစ်လည်း ဒီကိရိယာကို အသုံးပြုနိုင်ပြီး၊ CLI mode တွင် `--cli` attribute ကို ထည့်သွင်းရမည်။ CLI mode ဖြင့် ကိရိယာများအားလုံးကို စာရင်းပြုစုပုံမှာ -

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### လက်ဖြင့် စမ်းသပ်ခြင်း

ဆာဗာ၏ စွမ်းရည်များကို စမ်းသပ်ရန် inspector tool ကို အသုံးပြုခြင်းအပြင်၊ HTTP အသုံးပြုနိုင်သော client တစ်ခုဖြစ်သော curl ကဲ့သို့သော ကိရိယာကိုလည်း အသုံးပြုနိုင်သည်။

curl ဖြင့် MCP ဆာဗာများကို တိုက်ရိုက် HTTP တောင်းဆိုမှုများဖြင့် စမ်းသပ်နိုင်သည်။

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

အထက်ပါ curl အသုံးပြုမှုအရ POST တောင်းဆိုမှုဖြင့် ကိရိယာတစ်ခုကို ၎င်း၏ နာမည်နှင့် parameter များပါဝင်သည့် payload ဖြင့် ခေါ်ယူသည်။ သင့်အတွက် အဆင်ပြေသည့် နည်းလမ်းကို အသုံးပြုပါ။ CLI ကိရိယာများသည် အထူးသဖြင့် လျင်မြန်ပြီး စာရိုက်သတ်မှတ်ချက်များဖြင့် စာရွက်လုပ်နိုင်သဖြင့် CI/CD ပတ်ဝန်းကျင်တွင် အထောက်အကူဖြစ်စေသည်။

### ယူနစ် စမ်းသပ်ခြင်း

သင့်ကိရိယာများနှင့် အရင်းအမြစ်များအတွက် ယူနစ်စမ်းသပ်မှုများ ဖန်တီး၍ မျှော်မှန်းထားသည့်အတိုင်း လုပ်ဆောင်နိုင်ကြောင်း သေချာစေပါ။ ဥပမာ စမ်းသပ်ရေးကုဒ်အချို့မှာ -

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

အထက်ပါကုဒ်သည် -

- pytest framework ကို အသုံးပြု၍ function အဖြစ် စမ်းသပ်မှုများ ဖန်တီးကာ assert ပြုလုပ်သည်။
- ကိရိယာ နှစ်ခုပါဝင်သည့် MCP ဆာဗာတစ်ခု ဖန်တီးသည်။
- အချို့အခြေအနေများ ပြည့်မီကြောင်း `assert` ဖြင့် စစ်ဆေးသည်။

[ပြည့်စုံသော ဖိုင်ကို ဒီမှာ ကြည့်ရှုနိုင်သည်](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

အထက်ဖော်ပြပါဖိုင်အတိုင်း သင့်ကိုယ်ပိုင် ဆာဗာကို စမ်းသပ်၍ စွမ်းရည်များ သင့်တော်စွာ ဖန်တီးထားကြောင်း သေချာစေပါ။

အဓိက SDK များအားလုံးတွင် ဒီလို စမ်းသပ်မှုပိုင်းများ ရှိပြီး သင့်ရွေးချယ်ထားသော runtime အလိုက် ချိန်ညှိနိုင်ပါသည်။

## နမူနာများ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## ထပ်ဆောင်း အရင်းအမြစ်များ

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## နောက်တစ်ဆင့်

- နောက်တစ်ဆင့်: [Deployment](/03-GettingStarted/09-deployment/README.md)

**အတည်မပြုချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်မှု ဝန်ဆောင်မှုဖြစ်သော [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေသော်လည်း အလိုအလျောက် ဘာသာပြန်ချက်များတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်သည်ကို သတိပြုပါရန် အကြောင်းကြားအပ်ပါသည်။ မူလစာတမ်းကို မူရင်းဘာသာဖြင့်သာ အတည်ပြုရမည့် အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် အလုပ်သမားလက်တွေ့ ဘာသာပြန်သူမှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။