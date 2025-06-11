<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T15:44:01+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "th"
}
-->
# บทเรียน: การสร้าง Web Search MCP Server

บทนี้สาธิตวิธีการสร้าง AI agent ที่ใช้งานจริง ซึ่งรวมการทำงานกับ API ภายนอก จัดการข้อมูลหลายประเภท รับมือกับข้อผิดพลาด และประสานงานเครื่องมือต่างๆ หลายตัว — ทั้งหมดในรูปแบบที่พร้อมใช้งานจริง คุณจะได้เห็น:

- **การเชื่อมต่อกับ API ภายนอกที่ต้องมีการยืนยันตัวตน**
- **การจัดการข้อมูลหลายประเภทจากหลาย endpoints**
- **กลยุทธ์การจัดการข้อผิดพลาดและการบันทึกข้อมูลอย่างมั่นคง**
- **การประสานงานเครื่องมือหลายตัวในเซิร์ฟเวอร์เดียว**

เมื่อจบบทนี้ คุณจะมีประสบการณ์ใช้งานจริงกับรูปแบบและแนวปฏิบัติที่จำเป็นสำหรับแอปพลิเคชัน AI และ LLM ขั้นสูง

## บทนำ

ในบทเรียนนี้ คุณจะได้เรียนรู้วิธีสร้าง MCP server และ client ขั้นสูง ที่ขยายความสามารถของ LLM ด้วยข้อมูลเว็บแบบเรียลไทม์ผ่าน SerpAPI ทักษะนี้สำคัญมากสำหรับการพัฒนา AI agent ที่สามารถเข้าถึงข้อมูลล่าสุดจากเว็บได้

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- เชื่อมต่อ API ภายนอก (เช่น SerpAPI) อย่างปลอดภัยกับ MCP server
- ใช้เครื่องมือหลายตัวสำหรับค้นหาเว็บ ข่าว สินค้า และถามตอบ
- แปลงและจัดรูปแบบข้อมูลที่มีโครงสร้างเพื่อให้ LLM ใช้งานได้
- จัดการข้อผิดพลาดและควบคุมอัตราการเรียก API อย่างมีประสิทธิภาพ
- สร้างและทดสอบทั้ง MCP client แบบอัตโนมัติและแบบโต้ตอบ

## Web Search MCP Server

ส่วนนี้แนะนำโครงสร้างและฟีเจอร์ของ Web Search MCP Server คุณจะเห็นการใช้งาน FastMCP และ SerpAPI ร่วมกันเพื่อขยายความสามารถของ LLM ด้วยข้อมูลเว็บแบบเรียลไทม์

### ภาพรวม

การใช้งานนี้มีเครื่องมือสี่ตัวที่แสดงความสามารถของ MCP ในการจัดการงานที่ขับเคลื่อนด้วย API ภายนอกที่หลากหลายอย่างปลอดภัยและมีประสิทธิภาพ:

- **general_search**: สำหรับผลการค้นหาทั่วไปบนเว็บ
- **news_search**: สำหรับข่าวล่าสุด
- **product_search**: สำหรับข้อมูลอีคอมเมิร์ซ
- **qna**: สำหรับคำถามและคำตอบสั้นๆ

### ฟีเจอร์
- **ตัวอย่างโค้ด**: มีบล็อกโค้ดเฉพาะภาษาสำหรับ Python (และขยายไปยังภาษาอื่นได้ง่าย) โดยใช้ส่วนที่พับเก็บได้เพื่อความชัดเจน

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

ก่อนรัน client ควรทำความเข้าใจว่าเซิร์ฟเวอร์ทำอะไรบ้าง [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)

นี่คือตัวอย่างสั้นๆ ของวิธีที่เซิร์ฟเวอร์กำหนดและลงทะเบียนเครื่องมือ:

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

- **การเชื่อมต่อ API ภายนอก**: แสดงการจัดการคีย์ API และคำขอภายนอกอย่างปลอดภัย
- **การแปลงข้อมูลที่มีโครงสร้าง**: แสดงวิธีเปลี่ยนผลตอบกลับ API ให้เหมาะกับ LLM
- **การจัดการข้อผิดพลาด**: การจัดการข้อผิดพลาดที่มั่นคงพร้อมบันทึกที่เหมาะสม
- **Client แบบโต้ตอบ**: รวมทั้งการทดสอบอัตโนมัติและโหมดโต้ตอบสำหรับการทดสอบ
- **การจัดการบริบท**: ใช้ MCP Context สำหรับบันทึกและติดตามคำขอ

## ข้อกำหนดเบื้องต้น

ก่อนเริ่ม ให้ตรวจสอบว่าสภาพแวดล้อมของคุณพร้อมใช้งานตามขั้นตอนเหล่านี้ เพื่อให้แน่ใจว่าติดตั้ง dependencies ครบถ้วนและตั้งค่าคีย์ API ถูกต้องสำหรับการพัฒนาและทดสอบอย่างราบรื่น

- Python 3.8 ขึ้นไป
- SerpAPI API Key (สมัครได้ที่ [SerpAPI](https://serpapi.com/) — มีบริการฟรี)

## การติดตั้ง

เริ่มต้นโดยทำตามขั้นตอนเหล่านี้เพื่อตั้งค่าสภาพแวดล้อมของคุณ:

1. ติดตั้ง dependencies โดยใช้ uv (แนะนำ) หรือ pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. สร้างไฟล์ `.env` ที่โฟลเดอร์โปรเจกต์โดยใส่คีย์ SerpAPI ของคุณ:

```
SERPAPI_KEY=your_serpapi_key_here
```

## การใช้งาน

Web Search MCP Server คือส่วนหลักที่เปิดใช้งานเครื่องมือต่างๆ สำหรับค้นหาเว็บ ข่าว สินค้า และถามตอบ โดยเชื่อมต่อกับ SerpAPI มันจัดการคำขอที่เข้ามา เรียก API วิเคราะห์ผลลัพธ์ และส่งผลลัพธ์ที่มีโครงสร้างกลับไปยัง client

คุณสามารถดูโค้ดทั้งหมดได้ที่ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)

### การรันเซิร์ฟเวอร์

ใช้คำสั่งนี้เพื่อเริ่ม MCP server:

```bash
python server.py
```

เซิร์ฟเวอร์จะรันในรูปแบบ stdio-based MCP server ที่ client สามารถเชื่อมต่อได้โดยตรง

### โหมดของ Client

client (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)

### การรัน Client

เพื่อรันทดสอบอัตโนมัติ (ซึ่งจะเริ่มเซิร์ฟเวอร์ให้อัตโนมัติ):

```bash
python client.py
```

หรือรันในโหมดโต้ตอบ:

```bash
python client.py --interactive
```

### การทดสอบด้วยวิธีต่างๆ

มีหลายวิธีในการทดสอบและโต้ตอบกับเครื่องมือที่เซิร์ฟเวอร์ให้มา ขึ้นอยู่กับความต้องการและวิธีการทำงานของคุณ

#### การเขียนสคริปต์ทดสอบเองด้วย MCP Python SDK
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

ในบริบทนี้ "สคริปต์ทดสอบ" หมายถึงโปรแกรม Python ที่คุณเขียนขึ้นมาเองเพื่อทำหน้าที่เป็น client สำหรับ MCP server แทนที่จะเป็น unit test อย่างเป็นทางการ สคริปต์นี้ช่วยให้คุณเชื่อมต่อกับเซิร์ฟเวอร์ เรียกใช้เครื่องมือใดก็ได้พร้อมพารามิเตอร์ที่คุณเลือก และตรวจสอบผลลัพธ์ วิธีนี้เหมาะสำหรับ:
- ทดลองและพัฒนาเรียกใช้เครื่องมือ
- ตรวจสอบการตอบสนองของเซิร์ฟเวอร์ต่อข้อมูลนำเข้าต่างๆ
- อัตโนมัติการเรียกเครื่องมือซ้ำๆ
- สร้าง workflow หรือการเชื่อมต่อบน MCP server ของคุณเอง

คุณสามารถใช้สคริปต์ทดสอบเพื่อทดลองคำค้นหาใหม่ๆ แก้ไขข้อผิดพลาดของเครื่องมือ หรือใช้เป็นจุดเริ่มต้นสำหรับการทำ automation ขั้นสูง ด้านล่างคือตัวอย่างการใช้ MCP Python SDK เพื่อสร้างสคริปต์แบบนี้

## คำอธิบายเครื่องมือ

คุณสามารถใช้เครื่องมือต่อไปนี้ที่เซิร์ฟเวอร์ให้มา เพื่อทำการค้นหาและสอบถามในรูปแบบต่างๆ แต่ละเครื่องมือจะอธิบายพร้อมพารามิเตอร์และตัวอย่างการใช้งาน

ส่วนนี้ให้รายละเอียดเกี่ยวกับเครื่องมือแต่ละตัวและพารามิเตอร์ของมัน

### general_search

ทำการค้นหาเว็บทั่วไปและส่งคืนผลลัพธ์ในรูปแบบที่จัดเรียงแล้ว

**วิธีเรียกใช้เครื่องมือนี้:**

คุณสามารถเรียกใช้ `general_search` จากสคริปต์ของคุณเองโดยใช้ MCP Python SDK หรือโต้ตอบผ่าน Inspector หรือโหมด client แบบโต้ตอบ นี่คือตัวอย่างโค้ดโดยใช้ SDK:

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

อีกทางเลือกหนึ่ง ในโหมดโต้ตอบ เลือก `general_search` from the menu and enter your query when prompted.

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

คุณสามารถเรียกใช้ `news_search` จากสคริปต์ของคุณเองโดยใช้ MCP Python SDK หรือโต้ตอบผ่าน Inspector หรือโหมด client แบบโต้ตอบ นี่คือตัวอย่างโค้ดโดยใช้ SDK:

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

อีกทางเลือกหนึ่ง ในโหมดโต้ตอบ เลือก `news_search` from the menu and enter your query when prompted.

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

คุณสามารถเรียกใช้ `product_search` จากสคริปต์ของคุณเองโดยใช้ MCP Python SDK หรือโต้ตอบผ่าน Inspector หรือโหมด client แบบโต้ตอบ นี่คือตัวอย่างโค้ดโดยใช้ SDK:

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

อีกทางเลือกหนึ่ง ในโหมดโต้ตอบ เลือก `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): คำค้นหาสินค้า

**ตัวอย่างคำขอ:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

ดึงคำตอบโดยตรงสำหรับคำถามจากเครื่องมือค้นหา

**วิธีเรียกใช้เครื่องมือนี้:**

คุณสามารถเรียกใช้ `qna` จากสคริปต์ของคุณเองโดยใช้ MCP Python SDK หรือโต้ตอบผ่าน Inspector หรือโหมด client แบบโต้ตอบ นี่คือตัวอย่างโค้ดโดยใช้ SDK:

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

อีกทางเลือกหนึ่ง ในโหมดโต้ตอบ เลือก `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): คำถามที่ต้องการคำตอบ

**ตัวอย่างคำขอ:**

```json
{
  "question": "what is artificial intelligence"
}
```

## รายละเอียดโค้ด

ส่วนนี้มีโค้ดตัวอย่างและการอ้างอิงสำหรับการใช้งานเซิร์ฟเวอร์และไคลเอนต์

<details>
<summary>Python</summary>

ดูรายละเอียดโค้ดทั้งหมดได้ที่ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## แนวคิดขั้นสูงในบทเรียนนี้

ก่อนเริ่มสร้าง นี่คือแนวคิดขั้นสูงที่สำคัญซึ่งจะปรากฏในบทนี้ การเข้าใจสิ่งเหล่านี้จะช่วยให้คุณติดตามได้ง่ายขึ้น แม้จะเป็นมือใหม่:

- **การประสานงานเครื่องมือหลายตัว**: หมายถึงการรันเครื่องมือหลายตัว (เช่น ค้นหาเว็บ ข่าว สินค้า และถามตอบ) ใน MCP server เดียว ช่วยให้เซิร์ฟเวอร์ของคุณจัดการงานหลากหลาย ไม่ใช่แค่หนึ่งงาน
- **การจัดการอัตราการเรียก API**: API ภายนอกหลายตัว (เช่น SerpAPI) จำกัดจำนวนคำขอที่ส่งได้ในช่วงเวลาหนึ่ง โค้ดที่ดีจะตรวจสอบขีดจำกัดเหล่านี้และจัดการอย่างเหมาะสม เพื่อแอปไม่ล่มเมื่อเกินขีดจำกัด
- **การแปลงข้อมูลที่มีโครงสร้าง**: ผลลัพธ์ API มักซับซ้อนและซ้อนกัน แนวคิดนี้คือการแปลงผลลัพธ์ให้เป็นรูปแบบที่สะอาดและง่ายต่อการใช้งานสำหรับ LLM หรือโปรแกรมอื่นๆ
- **การกู้คืนจากข้อผิดพลาด**: บางครั้งเกิดปัญหา เช่น เครือข่ายล่ม หรือ API ไม่ส่งข้อมูลตามที่คาด การกู้คืนจากข้อผิดพลาดคือการที่โค้ดของคุณสามารถจัดการปัญหาเหล่านี้และยังให้ข้อมูลตอบกลับที่เป็นประโยชน์ แทนที่จะล่มไปเลย
- **การตรวจสอบพารามิเตอร์**: คือการตรวจสอบให้แน่ใจว่าข้อมูลนำเข้าทั้งหมดถูกต้องและปลอดภัย รวมถึงการตั้งค่าค่าดีฟอลต์และตรวจสอบชนิดข้อมูล เพื่อป้องกันข้อผิดพลาดและความสับสน

ส่วนนี้จะช่วยคุณวินิจฉัยและแก้ไขปัญหาที่พบบ่อยเมื่อทำงานกับ Web Search MCP Server หากเจอข้อผิดพลาดหรือพฤติกรรมที่ไม่คาดคิดขณะใช้ Web Search MCP Server ส่วนแก้ไขปัญหานี้จะให้คำแนะนำสำหรับปัญหาที่พบมากที่สุด ควรอ่านก่อนขอความช่วยเหลือเพิ่มเติม เพราะมักแก้ปัญหาได้รวดเร็ว

## การแก้ไขปัญหา

เมื่อทำงานกับ Web Search MCP Server คุณอาจเจอปัญหาบ้างเป็นเรื่องปกติเมื่อพัฒนาโดยใช้ API ภายนอกและเครื่องมือใหม่ๆ ส่วนนี้ให้คำแนะนำที่ใช้งานได้จริงสำหรับปัญหาที่พบบ่อย เพื่อให้คุณกลับมาทำงานได้เร็ว หากเจอข้อผิดพลาด ให้เริ่มที่นี่: คำแนะนำด้านล่างแก้ปัญหาที่ผู้ใช้ส่วนใหญ่เจอและมักช่วยแก้ปัญหาได้โดยไม่ต้องขอความช่วยเหลือเพิ่มเติม

### ปัญหาที่พบบ่อย

ด้านล่างนี้คือปัญหาที่ผู้ใช้เจอบ่อย พร้อมคำอธิบายและวิธีแก้ไข:

1. **ไม่มี SERPAPI_KEY ในไฟล์ .env**
   - หากเห็นข้อผิดพลาด `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `` ให้สร้างไฟล์ `.env` ตามต้องการ หากคีย์ถูกต้องแต่ยังเจอปัญหา ให้ตรวจสอบว่าโควต้าฟรีของคุณยังเหลือหรือไม่

### โหมดดีบัก

โดยปกติแอปจะบันทึกเฉพาะข้อมูลสำคัญ หากต้องการดูรายละเอียดเพิ่มเติมเกี่ยวกับสิ่งที่เกิดขึ้น (เช่น เพื่อวินิจฉัยปัญหายากๆ) คุณสามารถเปิดโหมด DEBUG ได้ ซึ่งจะแสดงข้อมูลขั้นตอนต่างๆ มากขึ้น

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

สังเกตว่าโหมด DEBUG จะแสดงบรรทัดเพิ่มเติมเกี่ยวกับคำขอ HTTP การตอบกลับ และรายละเอียดภายในอื่นๆ ซึ่งช่วยได้มากในการแก้ปัญหา

เพื่อเปิดโหมด DEBUG ให้ตั้งค่าระดับ logging เป็น DEBUG ที่ส่วนบนของไฟล์ `client.py` or `server.py`:

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

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาดั้งเดิมถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยมนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดขึ้นจากการใช้การแปลนี้