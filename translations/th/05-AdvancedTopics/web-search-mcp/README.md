<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T19:06:09+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "th"
}
-->
# Lesson: การสร้าง Web Search MCP Server

บทนี้จะแสดงให้เห็นวิธีการสร้าง AI agent ในโลกจริงที่เชื่อมต่อกับ API ภายนอก จัดการกับข้อมูลหลายประเภท จัดการข้อผิดพลาด และควบคุมเครื่องมือต่างๆ หลายตัว—all ในรูปแบบที่พร้อมใช้งานจริง คุณจะได้เห็น:

- **การเชื่อมต่อกับ API ภายนอกที่ต้องมีการยืนยันตัวตน**
- **การจัดการข้อมูลหลายประเภทจากหลาย endpoint**
- **การจัดการข้อผิดพลาดและการบันทึกอย่างเข้มแข็ง**
- **การควบคุมเครื่องมือหลายตัวในเซิร์ฟเวอร์เดียว**

เมื่อจบบทนี้ คุณจะมีประสบการณ์จริงกับรูปแบบและแนวทางปฏิบัติที่จำเป็นสำหรับแอปพลิเคชัน AI และ LLM ขั้นสูง

## บทนำ

ในบทนี้ คุณจะได้เรียนรู้วิธีสร้าง MCP server และ client ขั้นสูงที่ขยายความสามารถของ LLM ด้วยข้อมูลเว็บเรียลไทม์ผ่าน SerpAPI ทักษะนี้สำคัญสำหรับการพัฒนา AI agent ที่เข้าถึงข้อมูลล่าสุดจากเว็บได้

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทนี้ คุณจะสามารถ:

- เชื่อมต่อ API ภายนอก (เช่น SerpAPI) เข้ากับ MCP server อย่างปลอดภัย
- ใช้เครื่องมือหลายตัวสำหรับการค้นหาเว็บ ข่าว สินค้า และถามตอบ
- แยกวิเคราะห์และจัดรูปแบบข้อมูลเชิงโครงสร้างให้ LLM ใช้งานได้
- จัดการข้อผิดพลาดและควบคุมอัตราการเรียก API อย่างมีประสิทธิภาพ
- สร้างและทดสอบ MCP client ทั้งแบบอัตโนมัติและแบบโต้ตอบ

## Web Search MCP Server

ส่วนนี้แนะนำสถาปัตยกรรมและฟีเจอร์ของ Web Search MCP Server คุณจะเห็นการใช้ FastMCP และ SerpAPI ร่วมกันเพื่อขยายความสามารถของ LLM ด้วยข้อมูลเว็บเรียลไทม์

### ภาพรวม

การใช้งานนี้มีเครื่องมือสี่ตัวที่แสดงให้เห็นความสามารถของ MCP ในการจัดการงานที่ขับเคลื่อนด้วย API ภายนอกอย่างปลอดภัยและมีประสิทธิภาพ:

- **general_search**: สำหรับผลการค้นหาทั่วไปบนเว็บ
- **news_search**: สำหรับหัวข้อข่าวล่าสุด
- **product_search**: สำหรับข้อมูลอีคอมเมิร์ซ
- **qna**: สำหรับข้อความถาม-ตอบ

### ฟีเจอร์
- **ตัวอย่างโค้ด**: มีบล็อกโค้ดเฉพาะภาษาสำหรับ Python (และขยายไปยังภาษาอื่นได้ง่าย) ใช้ส่วนที่พับเก็บได้เพื่อความชัดเจน

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

ก่อนรัน client ควรเข้าใจว่า server ทำงานอย่างไร [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)

นี่คือตัวอย่างสั้นๆ ของการกำหนดและลงทะเบียนเครื่องมือใน server:

<details>  
<summary>Python Server</summary> 

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

- **การเชื่อมต่อ API ภายนอก**: แสดงการจัดการคีย์ API และการร้องขอภายนอกอย่างปลอดภัย
- **การแยกวิเคราะห์ข้อมูลเชิงโครงสร้าง**: แปลงผลลัพธ์ API เป็นรูปแบบที่ LLM เข้าใจได้
- **การจัดการข้อผิดพลาด**: มีการจัดการข้อผิดพลาดอย่างเข้มแข็งพร้อมการบันทึกที่เหมาะสม
- **Client โต้ตอบได้**: รวมทั้งการทดสอบอัตโนมัติและโหมดโต้ตอบสำหรับการทดสอบ
- **การจัดการบริบท**: ใช้ MCP Context ในการบันทึกและติดตามคำขอ

## ข้อกำหนดเบื้องต้น

ก่อนเริ่ม ให้แน่ใจว่าสภาพแวดล้อมของคุณถูกตั้งค่าอย่างถูกต้องตามขั้นตอนเหล่านี้ เพื่อให้แน่ใจว่าติดตั้ง dependencies ครบถ้วนและตั้งค่าคีย์ API อย่างถูกต้องเพื่อการพัฒนาและทดสอบที่ราบรื่น

- Python 3.8 ขึ้นไป
- SerpAPI API Key (สมัครได้ที่ [SerpAPI](https://serpapi.com/) - มีแบบฟรีให้ใช้)

## การติดตั้ง

เริ่มต้นโดยทำตามขั้นตอนนี้เพื่อเตรียมสภาพแวดล้อมของคุณ:

1. ติดตั้ง dependencies โดยใช้ uv (แนะนำ) หรือ pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. สร้างไฟล์ `.env` ที่โฟลเดอร์หลักของโปรเจกต์ พร้อมคีย์ SerpAPI ของคุณ:

```
SERPAPI_KEY=your_serpapi_key_here
```

## การใช้งาน

Web Search MCP Server คือส่วนหลักที่เปิดเผยเครื่องมือสำหรับค้นหาเว็บ ข่าว สินค้า และถามตอบ โดยเชื่อมต่อกับ SerpAPI รับคำขอ จัดการการเรียก API แยกวิเคราะห์ผลลัพธ์ และส่งผลลัพธ์เชิงโครงสร้างกลับไปยัง client

คุณสามารถดูการใช้งานทั้งหมดได้ที่ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)

### การรัน Server

เพื่อเริ่ม MCP server ใช้คำสั่งนี้:

```bash
python server.py
```

server จะทำงานเป็น stdio-based MCP server ที่ client สามารถเชื่อมต่อโดยตรง

### โหมดของ Client

client (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)

### การรัน Client

เพื่อรันการทดสอบอัตโนมัติ (ซึ่งจะเริ่ม server อัตโนมัติ):

```bash
python client.py
```

หรือรันในโหมดโต้ตอบ:

```bash
python client.py --interactive
```

### การทดสอบด้วยวิธีต่างๆ

มีหลายวิธีในการทดสอบและโต้ตอบกับเครื่องมือที่ server มีให้ ขึ้นอยู่กับความต้องการและกระบวนการทำงานของคุณ

#### เขียนสคริปต์ทดสอบเองด้วย MCP Python SDK
คุณยังสามารถสร้างสคริปต์ทดสอบของตัวเองโดยใช้ MCP Python SDK:

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

ในบริบทนี้ "สคริปต์ทดสอบ" หมายถึงโปรแกรม Python ที่คุณเขียนเองเพื่อทำหน้าที่เป็น client สำหรับ MCP server แทนที่จะเป็น unit test อย่างเป็นทางการ สคริปต์นี้ช่วยให้คุณเชื่อมต่อกับ server เรียกเครื่องมือด้วยพารามิเตอร์ที่เลือก และตรวจสอบผลลัพธ์ วิธีนี้เหมาะสำหรับ:
- การทดลองและทดสอบการเรียกเครื่องมือ
- ตรวจสอบว่าการตอบสนองของ server เป็นอย่างไรกับข้อมูลเข้าแต่ละแบบ
- อัตโนมัติการเรียกเครื่องมือซ้ำๆ
- สร้าง workflow หรือการผสานรวมของคุณเองบน MCP server

คุณสามารถใช้สคริปต์ทดสอบเพื่อทดลองคำค้นใหม่ๆ แก้บั๊กพฤติกรรมของเครื่องมือ หรือเป็นจุดเริ่มต้นของการอัตโนมัติขั้นสูง ด้านล่างคือตัวอย่างการใช้ MCP Python SDK เพื่อสร้างสคริปต์ดังกล่าว

## คำอธิบายเครื่องมือ

คุณสามารถใช้เครื่องมือเหล่านี้ที่ server มีให้เพื่อทำการค้นหาและสอบถามในรูปแบบต่างๆ เครื่องมือแต่ละตัวมีคำอธิบายพร้อมพารามิเตอร์และตัวอย่างการใช้งานดังนี้

ส่วนนี้ให้รายละเอียดของแต่ละเครื่องมือที่มีและพารามิเตอร์ของพวกมัน

### general_search

ทำการค้นหาเว็บทั่วไปและส่งผลลัพธ์ที่จัดรูปแบบแล้วกลับมา

**วิธีเรียกใช้เครื่องมือนี้:**

คุณสามารถเรียก `general_search` จากสคริปต์ของคุณโดยใช้ MCP Python SDK หรือโต้ตอบผ่าน Inspector หรือโหมด client แบบโต้ตอบ นี่คือตัวอย่างโค้ดที่ใช้ SDK:

<details>
<summary>ตัวอย่าง Python</summary>

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

หรือในโหมดโต้ตอบ เลือก `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): คำค้นหา

**ตัวอย่างคำขอ:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

ค้นหาข่าวล่าสุดที่เกี่ยวข้องกับคำค้นหา

**วิธีเรียกใช้เครื่องมือนี้:**

คุณสามารถเรียก `news_search` จากสคริปต์ของคุณโดยใช้ MCP Python SDK หรือโต้ตอบผ่าน Inspector หรือโหมด client แบบโต้ตอบ นี่คือตัวอย่างโค้ดที่ใช้ SDK:

<details>
<summary>ตัวอย่าง Python</summary>

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

หรือในโหมดโต้ตอบ เลือก `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): คำค้นหา

**ตัวอย่างคำขอ:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

ค้นหาสินค้าที่ตรงกับคำค้นหา

**วิธีเรียกใช้เครื่องมือนี้:**

คุณสามารถเรียก `product_search` จากสคริปต์ของคุณโดยใช้ MCP Python SDK หรือโต้ตอบผ่าน Inspector หรือโหมด client แบบโต้ตอบ นี่คือตัวอย่างโค้ดที่ใช้ SDK:

<details>
<summary>ตัวอย่าง Python</summary>

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

หรือในโหมดโต้ตอบ เลือก `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): คำค้นหาสินค้า

**ตัวอย่างคำขอ:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

รับคำตอบตรงสำหรับคำถามจากเครื่องมือค้นหา

**วิธีเรียกใช้เครื่องมือนี้:**

คุณสามารถเรียก `qna` จากสคริปต์ของคุณโดยใช้ MCP Python SDK หรือโต้ตอบผ่าน Inspector หรือโหมด client แบบโต้ตอบ นี่คือตัวอย่างโค้ดที่ใช้ SDK:

<details>
<summary>ตัวอย่าง Python</summary>

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

หรือในโหมดโต้ตอบ เลือก `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): คำถามที่ต้องการหาคำตอบ

**ตัวอย่างคำขอ:**

```json
{
  "question": "what is artificial intelligence"
}
```

## รายละเอียดโค้ด

ส่วนนี้มีตัวอย่างโค้ดและการอ้างอิงสำหรับการใช้งาน server และ client

<details>
<summary>Python</summary>

ดู [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) สำหรับรายละเอียดการใช้งานทั้งหมด

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## แนวคิดขั้นสูงในบทนี้

ก่อนเริ่มสร้าง นี่คือแนวคิดขั้นสูงที่สำคัญซึ่งจะปรากฏตลอดบทนี้ การเข้าใจจะช่วยให้คุณตามทัน แม้จะยังไม่คุ้นเคยกับพวกมัน:

- **การควบคุมเครื่องมือหลายตัว**: หมายถึงการรันเครื่องมือหลายตัว (เช่น ค้นหาเว็บ ข่าว สินค้า และถามตอบ) ภายใน MCP server เดียว ทำให้ server ของคุณจัดการงานหลากหลาย ไม่ใช่แค่หนึ่งงาน
- **การจัดการอัตราการเรียก API**: API ภายนอกหลายตัว (เช่น SerpAPI) จำกัดจำนวนคำขอในเวลาหนึ่ง โค้ดที่ดีจะตรวจสอบขีดจำกัดนี้และจัดการอย่างเหมาะสม เพื่อไม่ให้แอปพังเมื่อเกินขีดจำกัด
- **การแยกวิเคราะห์ข้อมูลเชิงโครงสร้าง**: ผลลัพธ์ API มักซับซ้อนและซ้อนกัน แนวคิดนี้คือการแปลงผลลัพธ์เหล่านั้นให้อยู่ในรูปแบบสะอาด ใช้งานง่าย และเหมาะกับ LLM หรือโปรแกรมอื่น
- **การกู้คืนจากข้อผิดพลาด**: บางครั้งเกิดปัญหา เช่น เครือข่ายล่ม หรือ API ไม่ตอบตามคาด การกู้คืนจากข้อผิดพลาดคือการที่โค้ดสามารถจัดการกับปัญหาเหล่านี้และให้ข้อมูลที่มีประโยชน์แทนที่จะล่ม
- **การตรวจสอบพารามิเตอร์**: คือการตรวจสอบว่าข้อมูลเข้าเครื่องมือถูกต้องและปลอดภัย รวมถึงการตั้งค่าค่าปริยายและตรวจสอบชนิดข้อมูล เพื่อป้องกันบั๊กและความสับสน

ส่วนนี้จะช่วยคุณวินิจฉัยและแก้ไขปัญหาทั่วไปที่อาจเจอระหว่างทำงานกับ Web Search MCP Server หากเจอข้อผิดพลาดหรือพฤติกรรมที่ไม่คาดคิด ส่วนแก้ไขปัญหานี้มีวิธีแก้ไขปัญหาที่พบบ่อยที่สุด ทบทวนคำแนะนำก่อนขอความช่วยเหลือเพิ่มเติม—มักช่วยแก้ปัญหาได้รวดเร็ว

## การแก้ไขปัญหา

เมื่อทำงานกับ Web Search MCP Server คุณอาจเจอปัญหาบ้างเป็นธรรมดาเมื่อพัฒนาโดยใช้ API ภายนอกและเครื่องมือใหม่ ส่วนนี้มีวิธีแก้ปัญหาที่ใช้งานได้จริงสำหรับปัญหาที่พบบ่อยที่สุด เพื่อให้คุณกลับมาทำงานได้เร็ว หากเจอข้อผิดพลาด ให้เริ่มจากตรงนี้: คำแนะนำด้านล่างแก้ไขปัญหาที่ผู้ใช้ส่วนใหญ่เจอและมักช่วยแก้ได้โดยไม่ต้องขอความช่วยเหลือเพิ่ม

### ปัญหาที่พบบ่อย

ด้านล่างคือปัญหาที่ผู้ใช้เจอบ่อยพร้อมคำอธิบายชัดเจนและขั้นตอนแก้ไข:

1. **ไม่มี SERPAPI_KEY ในไฟล์ .env**
   - หากเห็นข้อผิดพลาด `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` ให้สร้างไฟล์ `.env` ถ้าจำเป็น และตรวจสอบว่าคีย์ของคุณถูกต้องหรือไม่ รวมถึงตรวจสอบว่าโควตาฟรีหมดหรือยัง

### โหมด Debug

โดยปกติแอปจะบันทึกเฉพาะข้อมูลสำคัญ หากต้องการดูรายละเอียดมากขึ้น (เช่น เพื่อตรวจสอบปัญหายากๆ) คุณสามารถเปิดโหมด DEBUG ซึ่งจะแสดงข้อมูลขั้นตอนต่างๆ ที่แอปทำ

**ตัวอย่าง: ข้อมูลปกติ**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**ตัวอย่าง: ข้อมูล DEBUG**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

สังเกตว่าโหมด DEBUG จะแสดงบรรทัดเพิ่มเติมเกี่ยวกับ HTTP requests, responses และรายละเอียดภายในอื่นๆ ซึ่งช่วยได้มากในการแก้ไขปัญหา

เพื่อเปิดโหมด DEBUG ให้ตั้งค่าระดับ logging เป็น DEBUG ด้านบนของ `client.py` or `server.py`:

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

## ต่อไปคืออะไร

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลโดยอัตโนมัติอาจมีข้อผิดพลาดหรือความคลาดเคลื่อน เอกสารต้นฉบับในภาษาต้นฉบับถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญด้านภาษา เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดใด ๆ ที่เกิดจากการใช้การแปลนี้