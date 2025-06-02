<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:15:52+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "th"
}
-->
# Lesson: การสร้าง Web Search MCP Server

บทนี้จะแสดงวิธีการสร้างเอเจนต์ AI ในโลกจริงที่ผสานรวมกับ API ภายนอก จัดการกับข้อมูลหลากหลายประเภท จัดการข้อผิดพลาด และประสานงานเครื่องมือต่าง ๆ หลายตัว — ทั้งหมดในรูปแบบที่พร้อมใช้งานในระบบจริง คุณจะได้เห็น:

- **การผสานรวมกับ API ภายนอกที่ต้องมีการยืนยันตัวตน**
- **การจัดการข้อมูลหลายประเภทจากหลายจุดเชื่อมต่อ**
- **กลยุทธ์การจัดการข้อผิดพลาดและบันทึกข้อมูลที่มั่นคง**
- **การประสานงานเครื่องมือหลายตัวในเซิร์ฟเวอร์เดียว**

เมื่อจบบทนี้ คุณจะมีประสบการณ์ใช้งานจริงกับรูปแบบและแนวปฏิบัติที่จำเป็นสำหรับแอปพลิเคชัน AI และ LLM ขั้นสูง

## บทนำ

ในบทเรียนนี้ คุณจะได้เรียนรู้วิธีสร้าง MCP server และ client ขั้นสูงที่ขยายความสามารถของ LLM ด้วยข้อมูลเว็บแบบเรียลไทม์โดยใช้ SerpAPI นี่คือทักษะสำคัญสำหรับการพัฒนาเอเจนต์ AI ที่สามารถเข้าถึงข้อมูลอัปเดตล่าสุดจากเว็บได้

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- ผสานรวม API ภายนอก (เช่น SerpAPI) อย่างปลอดภัยเข้าสู่ MCP server
- ใช้งานเครื่องมือหลายตัวสำหรับการค้นหาเว็บ ข่าว สินค้า และ Q&A
- แยกวิเคราะห์และจัดรูปแบบข้อมูลเชิงโครงสร้างสำหรับการใช้งานกับ LLM
- จัดการข้อผิดพลาดและควบคุมอัตราการเรียก API ได้อย่างมีประสิทธิภาพ
- สร้างและทดสอบทั้ง MCP client แบบอัตโนมัติและแบบโต้ตอบ

## Web Search MCP Server

ส่วนนี้แนะนำสถาปัตยกรรมและฟีเจอร์ของ Web Search MCP Server คุณจะเห็นว่า FastMCP และ SerpAPI ถูกใช้ร่วมกันอย่างไรเพื่อขยายความสามารถของ LLM ด้วยข้อมูลเว็บแบบเรียลไทม์

### ภาพรวม

การใช้งานนี้มีเครื่องมือสี่ตัวที่แสดงความสามารถของ MCP ในการจัดการงานที่ขับเคลื่อนด้วย API ภายนอกที่หลากหลายอย่างปลอดภัยและมีประสิทธิภาพ:

- **general_search**: สำหรับผลลัพธ์เว็บทั่วไป
- **news_search**: สำหรับข่าวล่าสุด
- **product_search**: สำหรับข้อมูลอีคอมเมิร์ซ
- **qna**: สำหรับคำถามและคำตอบสั้น ๆ

### ฟีเจอร์
- **ตัวอย่างโค้ด**: มีบล็อกโค้ดเฉพาะภาษาสำหรับ Python (และขยายไปยังภาษาอื่นได้ง่าย) โดยใช้ส่วนที่พับได้เพื่อความชัดเจน

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

ก่อนรัน client การเข้าใจว่า server ทำอะไรจะช่วยได้ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)

ตัวอย่างสั้น ๆ ของการนิยามและลงทะเบียนเครื่องมือใน server:

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

- **การผสานรวม API ภายนอก**: แสดงการจัดการคีย์ API และคำขอภายนอกอย่างปลอดภัย
- **การแยกวิเคราะห์ข้อมูลเชิงโครงสร้าง**: แสดงวิธีแปลงผลลัพธ์ API ให้เหมาะกับ LLM
- **การจัดการข้อผิดพลาด**: การจัดการข้อผิดพลาดอย่างมั่นคงพร้อมบันทึกที่เหมาะสม
- **Client แบบโต้ตอบ**: มีทั้งการทดสอบอัตโนมัติและโหมดโต้ตอบสำหรับการทดสอบ
- **การจัดการบริบท**: ใช้ MCP Context สำหรับการบันทึกและติดตามคำขอ

## สิ่งที่ต้องเตรียมก่อนเริ่ม

ก่อนเริ่มต้น ให้ตรวจสอบว่าสภาพแวดล้อมของคุณถูกตั้งค่าอย่างถูกต้องตามขั้นตอนเหล่านี้ เพื่อให้แน่ใจว่าติดตั้ง dependencies ครบถ้วนและตั้งค่าคีย์ API อย่างถูกต้องสำหรับการพัฒนาและทดสอบที่ราบรื่น

- Python 3.8 หรือสูงกว่า
- คีย์ SerpAPI (สมัครได้ที่ [SerpAPI](https://serpapi.com/) - มีแผนฟรี)

## การติดตั้ง

เริ่มต้นโดยทำตามขั้นตอนเหล่านี้เพื่อตั้งค่าสภาพแวดล้อมของคุณ:

1. ติดตั้ง dependencies โดยใช้ uv (แนะนำ) หรือ pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. สร้างไฟล์ `.env` ในโฟลเดอร์โปรเจกต์หลักพร้อมคีย์ SerpAPI ของคุณ:

```
SERPAPI_KEY=your_serpapi_key_here
```

## การใช้งาน

Web Search MCP Server คือส่วนหลักที่เปิดเผยเครื่องมือสำหรับการค้นหาเว็บ ข่าว สินค้า และ Q&A โดยผสานรวมกับ SerpAPI มันจัดการคำขอที่เข้ามา ควบคุมการเรียก API แยกวิเคราะห์ผลลัพธ์ และส่งคืนข้อมูลที่จัดรูปแบบให้กับ client

คุณสามารถดูการใช้งานเต็มรูปแบบได้ใน [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)

### การรัน Server

ใช้คำสั่งนี้เพื่อเริ่ม MCP server:

```bash
python server.py
```

server จะทำงานในรูปแบบ stdio-based MCP server ที่ client สามารถเชื่อมต่อได้โดยตรง

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

### การทดสอบด้วยวิธีต่าง ๆ

มีหลายวิธีในการทดสอบและโต้ตอบกับเครื่องมือที่ server ให้มา ขึ้นอยู่กับความต้องการและรูปแบบการทำงานของคุณ

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

ในบริบทนี้ "สคริปต์ทดสอบ" หมายถึงโปรแกรม Python ที่คุณเขียนเองเพื่อทำหน้าที่เป็น client สำหรับ MCP server แทนที่จะเป็น unit test อย่างเป็นทางการ สคริปต์นี้ช่วยให้คุณเชื่อมต่อกับ server เรียกใช้เครื่องมือใดก็ได้พร้อมพารามิเตอร์ที่เลือก และตรวจสอบผลลัพธ์ วิธีนี้เหมาะสำหรับ:
- การสร้างต้นแบบและทดลองเรียกเครื่องมือ
- ตรวจสอบว่าการตอบสนองของ server กับข้อมูลเข้าแตกต่างกันอย่างไร
- อัตโนมัติการเรียกเครื่องมือซ้ำ ๆ
- สร้างเวิร์กโฟลว์หรือการผสานงานของคุณเองบน MCP server

คุณสามารถใช้สคริปต์ทดสอบเพื่อทดลองคำค้นใหม่ ๆ แก้ไขบั๊กพฤติกรรมของเครื่องมือ หรือเป็นจุดเริ่มต้นสำหรับการทำงานอัตโนมัติขั้นสูง ตัวอย่างการใช้ MCP Python SDK เพื่อสร้างสคริปต์แบบนี้มีด้านล่าง

## คำอธิบายเครื่องมือ

คุณสามารถใช้เครื่องมือต่อไปนี้ที่ server มีให้เพื่อทำการค้นหาและสอบถามข้อมูลประเภทต่าง ๆ แต่ละเครื่องมืออธิบายพร้อมพารามิเตอร์และตัวอย่างการใช้งานไว้ด้านล่าง

ส่วนนี้ให้รายละเอียดเกี่ยวกับแต่ละเครื่องมือที่มีและพารามิเตอร์ของพวกมัน

### general_search

ทำการค้นหาเว็บทั่วไปและส่งคืนผลลัพธ์ที่จัดรูปแบบแล้ว

**วิธีเรียกใช้งานเครื่องมือนี้:**

คุณสามารถเรียกใช้ `general_search` จากสคริปต์ของคุณเองโดยใช้ MCP Python SDK หรือแบบโต้ตอบผ่าน Inspector หรือโหมด client แบบโต้ตอบ นี่คือตัวอย่างโค้ดโดยใช้ SDK:

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

ค้นหาบทความข่าวล่าสุดที่เกี่ยวข้องกับคำค้น

**วิธีเรียกใช้งานเครื่องมือนี้:**

คุณสามารถเรียกใช้ `news_search` จากสคริปต์ของคุณเองโดยใช้ MCP Python SDK หรือแบบโต้ตอบผ่าน Inspector หรือโหมด client แบบโต้ตอบ นี่คือตัวอย่างโค้ดโดยใช้ SDK:

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

ค้นหาสินค้าที่ตรงกับคำค้น

**วิธีเรียกใช้งานเครื่องมือนี้:**

คุณสามารถเรียกใช้ `product_search` จากสคริปต์ของคุณเองโดยใช้ MCP Python SDK หรือแบบโต้ตอบผ่าน Inspector หรือโหมด client แบบโต้ตอบ นี่คือตัวอย่างโค้ดโดยใช้ SDK:

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

**วิธีเรียกใช้งานเครื่องมือนี้:**

คุณสามารถเรียกใช้ `qna` จากสคริปต์ของคุณเองโดยใช้ MCP Python SDK หรือแบบโต้ตอบผ่าน Inspector หรือโหมด client แบบโต้ตอบ นี่คือตัวอย่างโค้ดโดยใช้ SDK:

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

ส่วนนี้ให้ตัวอย่างโค้ดและข้อมูลอ้างอิงสำหรับการใช้งาน server และ client

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

ก่อนเริ่มสร้าง มีแนวคิดขั้นสูงที่สำคัญซึ่งจะพบตลอดบทนี้ การเข้าใจจะช่วยให้คุณตามได้ง่ายขึ้น แม้จะเป็นมือใหม่ก็ตาม:

- **การประสานงานเครื่องมือหลายตัว**: หมายถึงการรันเครื่องมือต่าง ๆ หลายตัว (เช่น การค้นหาเว็บ ข่าว สินค้า และ Q&A) ใน MCP server เดียว ซึ่งช่วยให้ server ของคุณจัดการงานหลากหลาย ไม่ใช่แค่หนึ่งงาน
- **การจัดการอัตราการเรียก API**: API ภายนอกหลายตัว (เช่น SerpAPI) จำกัดจำนวนคำขอที่สามารถส่งได้ในช่วงเวลาหนึ่ง โค้ดที่ดีจะตรวจสอบขีดจำกัดเหล่านี้และจัดการอย่างเหมาะสม เพื่อไม่ให้แอปของคุณล่มเมื่อถึงขีดจำกัด
- **การแยกวิเคราะห์ข้อมูลเชิงโครงสร้าง**: ผลลัพธ์จาก API มักซับซ้อนและซ้อนกัน แนวคิดนี้คือการแปลงผลลัพธ์เหล่านั้นให้อยู่ในรูปแบบที่สะอาด ใช้งานง่าย และเหมาะสำหรับ LLM หรือโปรแกรมอื่น ๆ
- **การกู้คืนจากข้อผิดพลาด**: บางครั้งเกิดปัญหา เช่น เครือข่ายล้มเหลว หรือ API ไม่ตอบตามที่คาดไว้ การกู้คืนจากข้อผิดพลาดหมายถึงโค้ดของคุณสามารถจัดการปัญหาเหล่านี้และยังคงให้ข้อมูลที่เป็นประโยชน์ แทนที่จะล่ม
- **การตรวจสอบพารามิเตอร์**: คือการตรวจสอบว่าอินพุตทั้งหมดของเครื่องมือถูกต้องและปลอดภัย รวมถึงการตั้งค่าค่าดีฟอลต์และตรวจสอบชนิดข้อมูล ซึ่งช่วยป้องกันบั๊กและความสับสน

ส่วนนี้จะช่วยคุณวินิจฉัยและแก้ไขปัญหาทั่วไปที่อาจเจอขณะใช้งาน Web Search MCP Server หากคุณเจอข้อผิดพลาดหรือพฤติกรรมที่ไม่คาดคิด ส่วนแก้ไขปัญหานี้มีคำแนะนำสำหรับปัญหาที่พบบ่อยที่สุด ควรตรวจสอบก่อนขอความช่วยเหลือเพิ่มเติม เพราะมักจะแก้ปัญหาได้เร็ว

## การแก้ไขปัญหา

เมื่อทำงานกับ Web Search MCP Server คุณอาจเจอปัญหาบ้างเป็นเรื่องปกติเมื่อพัฒนาโดยใช้ API ภายนอกและเครื่องมือใหม่ ๆ ส่วนนี้ให้คำแนะนำแก้ไขปัญหาที่ใช้งานได้จริงสำหรับปัญหาที่พบบ่อย เพื่อให้คุณกลับมาทำงานได้อย่างรวดเร็ว หากเจอข้อผิดพลาด ให้เริ่มที่นี่: คำแนะนำด้านล่างแก้ไขปัญหาที่ผู้ใช้ส่วนใหญ่เจอและมักจะแก้ได้โดยไม่ต้องขอความช่วยเหลือเพิ่ม

### ปัญหาที่พบบ่อย

ด้านล่างคือปัญหาที่พบบ่อยที่สุด พร้อมคำอธิบายชัดเจนและขั้นตอนแก้ไข:

1. **ไม่มี SERPAPI_KEY ในไฟล์ .env**
   - หากเห็นข้อผิดพลาด `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `` ให้สร้างไฟล์ `.env` หากยังไม่มี และเพิ่ม SERPAPI_KEY ลงไป ถ้าคีย์ถูกต้องแต่ยังเจอปัญหา ให้ตรวจสอบว่าแผนฟรีของคุณยังมีโควต้าเหลืออยู่หรือไม่

### โหมดดีบัก

โดยปกติแอปจะบันทึกเฉพาะข้อมูลสำคัญ หากต้องการดูรายละเอียดเพิ่มเติมเกี่ยวกับสิ่งที่เกิดขึ้น (เช่น เพื่อวินิจฉัยปัญหายาก) คุณสามารถเปิดโหมด DEBUG ได้ ซึ่งจะแสดงข้อมูลเพิ่มเติมเกี่ยวกับแต่ละขั้นตอนที่แอปทำ

**ตัวอย่าง: ผลลัพธ์ปกติ**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**ตัวอย่าง: ผลลัพธ์โหมด DEBUG**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

สังเกตว่าโหมด DEBUG จะแสดงบรรทัดเพิ่มเติมเกี่ยวกับคำขอ HTTP การตอบกลับ และรายละเอียดภายในอื่น ๆ ซึ่งช่วยได้มากในการแก้ปัญหา

เพื่อเปิดโหมด DEBUG ให้ตั้งค่าระดับ logging เป็น DEBUG ที่ด้านบนของ `client.py` or `server.py`:

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
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยมืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดขึ้นจากการใช้การแปลนี้