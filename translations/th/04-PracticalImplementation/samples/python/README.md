<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:30:51+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "th"
}
-->
# Model Context Protocol (MCP) Python Implementation

ที่เก็บนี้ประกอบด้วยการใช้งาน Model Context Protocol (MCP) ด้วยภาษา Python โดยแสดงตัวอย่างการสร้างทั้งแอปเซิร์ฟเวอร์และไคลเอนต์ที่สื่อสารกันตามมาตรฐาน MCP

## ภาพรวม

การใช้งาน MCP นี้ประกอบด้วยส่วนหลักสองส่วน:

1. **MCP Server (`server.py`)** - เซิร์ฟเวอร์ที่เปิดเผย:
   - **Tools**: ฟังก์ชันที่เรียกใช้งานจากระยะไกลได้
   - **Resources**: ข้อมูลที่สามารถดึงมาใช้งานได้
   - **Prompts**: แบบฟอร์มสำหรับสร้าง prompt สำหรับโมเดลภาษา

2. **MCP Client (`client.py`)** - แอปไคลเอนต์ที่เชื่อมต่อกับเซิร์ฟเวอร์และใช้งานฟีเจอร์ต่าง ๆ

## ฟีเจอร์

การใช้งานนี้แสดงฟีเจอร์สำคัญของ MCP หลายอย่าง:

### Tools
- `completion` - สร้างข้อความตอบกลับจากโมเดล AI (จำลอง)
- `add` - เครื่องคิดเลขง่าย ๆ ที่บวกเลขสองจำนวน

### Resources
- `models://` - คืนข้อมูลเกี่ยวกับโมเดล AI ที่มีอยู่
- `greeting://{name}` - คืนคำทักทายส่วนตัวตามชื่อที่กำหนด

### Prompts
- `review_code` - สร้าง prompt สำหรับการรีวิวโค้ด

## การติดตั้ง

เพื่อใช้งาน MCP นี้ ให้ติดตั้งแพ็กเกจที่จำเป็น:

```powershell
pip install mcp-server mcp-client
```

## การรันเซิร์ฟเวอร์และไคลเอนต์

### การเริ่มเซิร์ฟเวอร์

รันเซิร์ฟเวอร์ในหน้าต่างเทอร์มินัลหนึ่ง:

```powershell
python server.py
```

เซิร์ฟเวอร์ยังสามารถรันในโหมดพัฒนาโดยใช้ MCP CLI:

```powershell
mcp dev server.py
```

หรือจะติดตั้งใน Claude Desktop (ถ้ามี):

```powershell
mcp install server.py
```

### การรันไคลเอนต์

รันไคลเอนต์ในหน้าต่างเทอร์มินัลอีกอัน:

```powershell
python client.py
```

ซึ่งจะเชื่อมต่อกับเซิร์ฟเวอร์และสาธิตฟีเจอร์ทั้งหมดที่มี

### การใช้งานไคลเอนต์

ไคลเอนต์ (`client.py`) แสดงความสามารถทั้งหมดของ MCP:

```powershell
python client.py
```

ซึ่งจะเชื่อมต่อกับเซิร์ฟเวอร์และใช้งานฟีเจอร์ทุกอย่าง รวมถึง tools, resources และ prompts ผลลัพธ์จะแสดง:

1. ผลลัพธ์เครื่องคิดเลข (5 + 7 = 12)
2. การตอบกลับจากเครื่องมือ completion กับคำถาม "What is the meaning of life?"
3. รายชื่อโมเดล AI ที่มีอยู่
4. คำทักทายส่วนตัวสำหรับ "MCP Explorer"
5. แบบฟอร์ม prompt สำหรับรีวิวโค้ด

## รายละเอียดการใช้งาน

เซิร์ฟเวอร์ถูกพัฒนาด้วย `FastMCP` API ซึ่งให้การสร้าง MCP services แบบง่าย นี่คือตัวอย่างการกำหนด tools:

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

ไคลเอนต์ใช้ไลบรารี MCP client เพื่อเชื่อมต่อและเรียกใช้งานเซิร์ฟเวอร์:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## เรียนรู้เพิ่มเติม

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับ MCP เยี่ยมชม: https://modelcontextprotocol.io/

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารฉบับนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่แม่นยำ เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่ถูกต้องที่สุด สำหรับข้อมูลสำคัญแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญด้านภาษา เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดใด ๆ ที่เกิดจากการใช้การแปลนี้