<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:43:43+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "th"
}
-->
## การทดสอบและการดีบัก

ก่อนที่คุณจะเริ่มทดสอบเซิร์ฟเวอร์ MCP ของคุณ สิ่งสำคัญคือต้องเข้าใจเครื่องมือที่มีอยู่และแนวปฏิบัติที่ดีที่สุดสำหรับการดีบัก การทดสอบที่มีประสิทธิภาพจะช่วยให้เซิร์ฟเวอร์ของคุณทำงานตามที่คาดหวังและช่วยให้คุณระบุและแก้ไขปัญหาได้อย่างรวดเร็ว ส่วนต่อไปนี้จะกล่าวถึงวิธีการที่แนะนำสำหรับการตรวจสอบการใช้งาน MCP ของคุณ

## ภาพรวม

บทเรียนนี้ครอบคลุมถึงวิธีการเลือกวิธีการทดสอบที่เหมาะสมและเครื่องมือทดสอบที่มีประสิทธิภาพที่สุด

## วัตถุประสงค์การเรียนรู้

เมื่อสิ้นสุดบทเรียนนี้ คุณจะสามารถ:

- อธิบายวิธีการต่างๆ สำหรับการทดสอบ
- ใช้เครื่องมือที่หลากหลายเพื่อทดสอบโค้ดของคุณได้อย่างมีประสิทธิภาพ

## การทดสอบเซิร์ฟเวอร์ MCP

MCP มีเครื่องมือช่วยในการทดสอบและดีบักเซิร์ฟเวอร์ของคุณ:

- **MCP Inspector**: เครื่องมือบรรทัดคำสั่งที่สามารถใช้งานได้ทั้งแบบ CLI และแบบเครื่องมือภาพ
- **การทดสอบด้วยตนเอง**: คุณสามารถใช้เครื่องมือเช่น curl เพื่อส่งคำขอเว็บ แต่เครื่องมือใดๆ ที่สามารถส่ง HTTP ก็ใช้ได้
- **การทดสอบหน่วย**: สามารถใช้เฟรมเวิร์กการทดสอบที่คุณชื่นชอบเพื่อทดสอบคุณสมบัติของทั้งเซิร์ฟเวอร์และลูกค้า

### การใช้ MCP Inspector

เราได้อธิบายการใช้งานเครื่องมือนี้ในบทเรียนก่อนหน้านี้ แต่เรามาพูดถึงมันในระดับสูงกัน เครื่องมือนี้สร้างขึ้นใน Node.js และคุณสามารถใช้มันได้โดยการเรียก `npx` ซึ่งจะดาวน์โหลดและติดตั้งเครื่องมือชั่วคราวและจะล้างตัวเองเมื่อเสร็จสิ้นการดำเนินการคำขอของคุณ

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) ช่วยคุณ:

- **ค้นพบความสามารถของเซิร์ฟเวอร์**: ตรวจจับทรัพยากร เครื่องมือ และพรอมต์ที่มีอยู่โดยอัตโนมัติ
- **ทดสอบการดำเนินการของเครื่องมือ**: ลองใช้พารามิเตอร์ต่างๆ และดูการตอบสนองแบบเรียลไทม์
- **ดูข้อมูลเมตาของเซิร์ฟเวอร์**: ตรวจสอบข้อมูลเซิร์ฟเวอร์ สคีมา และการกำหนดค่า

การทำงานทั่วไปของเครื่องมือมีลักษณะดังนี้:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

คำสั่งข้างต้นเริ่มต้น MCP และอินเทอร์เฟซภาพของมันและเปิดอินเทอร์เฟซเว็บท้องถิ่นในเบราว์เซอร์ของคุณ คุณสามารถคาดหวังว่าจะเห็นแดชบอร์ดที่แสดงเซิร์ฟเวอร์ MCP ที่ลงทะเบียนของคุณ เครื่องมือ ทรัพยากร และพรอมต์ที่มีอยู่ อินเทอร์เฟซนี้ช่วยให้คุณทดสอบการดำเนินการของเครื่องมือแบบโต้ตอบ ตรวจสอบข้อมูลเมตาของเซิร์ฟเวอร์ และดูการตอบสนองแบบเรียลไทม์ ทำให้ง่ายขึ้นในการตรวจสอบและดีบักการใช้งานเซิร์ฟเวอร์ MCP ของคุณ

นี่คือสิ่งที่มันอาจดูเหมือน: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.th.png)

คุณยังสามารถเรียกใช้เครื่องมือนี้ในโหมด CLI ซึ่งในกรณีนี้คุณเพิ่ม attribute `--cli` นี่คือตัวอย่างการเรียกใช้เครื่องมือในโหมด "CLI" ซึ่งแสดงรายการเครื่องมือทั้งหมดบนเซิร์ฟเวอร์:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### การทดสอบด้วยตนเอง

นอกเหนือจากการเรียกใช้เครื่องมือ inspector เพื่อทดสอบความสามารถของเซิร์ฟเวอร์ อีกวิธีหนึ่งที่คล้ายกันคือการเรียกใช้ไคลเอนต์ที่สามารถใช้ HTTP เช่น curl

ด้วย curl คุณสามารถทดสอบเซิร์ฟเวอร์ MCP ได้โดยตรงโดยใช้คำขอ HTTP:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

จากการใช้งาน curl ข้างต้น คุณใช้คำขอ POST เพื่อเรียกใช้เครื่องมือโดยใช้ข้อมูลที่ประกอบด้วยชื่อเครื่องมือและพารามิเตอร์ ใช้วิธีการที่เหมาะสมกับคุณที่สุด เครื่องมือ CLI โดยทั่วไปมักจะใช้งานได้เร็วกว่าและสามารถสคริปต์ได้ ซึ่งสามารถเป็นประโยชน์ในสภาพแวดล้อม CI/CD

### การทดสอบหน่วย

สร้างการทดสอบหน่วยสำหรับเครื่องมือและทรัพยากรของคุณเพื่อให้แน่ใจว่ามันทำงานตามที่คาดหวัง นี่คือตัวอย่างโค้ดการทดสอบ

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

โค้ดก่อนหน้านี้ทำสิ่งต่อไปนี้:

- ใช้เฟรมเวิร์ก pytest ซึ่งช่วยให้คุณสร้างการทดสอบเป็นฟังก์ชันและใช้ assert statements
- สร้างเซิร์ฟเวอร์ MCP พร้อมด้วยเครื่องมือสองชนิด
- ใช้ `assert` statement เพื่อตรวจสอบว่ามีการตอบสนองเงื่อนไขที่กำหนด

ดูไฟล์เต็มได้ที่ [ที่นี่](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

จากไฟล์ข้างต้น คุณสามารถทดสอบเซิร์ฟเวอร์ของคุณเองเพื่อให้แน่ใจว่าความสามารถถูกสร้างขึ้นตามที่ควร

SDK หลักทั้งหมดมีส่วนการทดสอบที่คล้ายกัน ดังนั้นคุณสามารถปรับให้เข้ากับรันไทม์ที่คุณเลือกได้

## ตัวอย่าง

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## แหล่งข้อมูลเพิ่มเติม

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## ขั้นตอนต่อไป

- ต่อไป: [การปรับใช้](/03-GettingStarted/08-deployment/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปล AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามอย่างเต็มที่เพื่อความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาดั้งเดิมควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลสำคัญ แนะนำให้ใช้บริการแปลโดยมนุษย์ที่มีความเชี่ยวชาญ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดจากการใช้การแปลนี้