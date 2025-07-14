<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:20:03+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "th"
}
-->
# การรันตัวอย่างนี้

นี่คือวิธีการรันเซิร์ฟเวอร์และไคลเอนต์ HTTP streaming แบบคลาสสิก รวมถึงเซิร์ฟเวอร์และไคลเอนต์ MCP streaming โดยใช้ Python

### ภาพรวม

- คุณจะตั้งค่าเซิร์ฟเวอร์ MCP ที่สตรีมการแจ้งเตือนความคืบหน้าไปยังไคลเอนต์ในขณะที่ประมวลผลรายการ
- ไคลเอนต์จะแสดงการแจ้งเตือนแต่ละรายการแบบเรียลไทม์
- คู่มือนี้ครอบคลุมถึงข้อกำหนดเบื้องต้น การตั้งค่า การรัน และการแก้ไขปัญหา

### ข้อกำหนดเบื้องต้น

- Python 3.9 หรือใหม่กว่า
- แพ็กเกจ Python `mcp` (ติดตั้งด้วยคำสั่ง `pip install mcp`)

### การติดตั้งและการตั้งค่า

1. โคลนรีโพซิทอรีหรือดาวน์โหลดไฟล์โซลูชัน

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **สร้างและเปิดใช้งาน virtual environment (แนะนำ):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **ติดตั้ง dependencies ที่จำเป็น:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### ไฟล์

- **เซิร์ฟเวอร์:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **ไคลเอนต์:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### การรัน Classic HTTP Streaming Server

1. ไปที่ไดเรกทอรีโซลูชัน:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. เริ่มต้นเซิร์ฟเวอร์ HTTP streaming แบบคลาสสิก:

   ```pwsh
   python server.py
   ```

3. เซิร์ฟเวอร์จะเริ่มทำงานและแสดงผลดังนี้:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### การรัน Classic HTTP Streaming Client

1. เปิดเทอร์มินัลใหม่ (เปิดใช้งาน virtual environment และไดเรกทอรีเดียวกัน):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. คุณจะเห็นข้อความที่ถูกสตรีมแสดงผลตามลำดับ:

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### การรัน MCP Streaming Server

1. ไปที่ไดเรกทอรีโซลูชัน:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. เริ่มเซิร์ฟเวอร์ MCP ด้วย transport แบบ streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. เซิร์ฟเวอร์จะเริ่มทำงานและแสดงผลดังนี้:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### การรัน MCP Streaming Client

1. เปิดเทอร์มินัลใหม่ (เปิดใช้งาน virtual environment และไดเรกทอรีเดียวกัน):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. คุณจะเห็นการแจ้งเตือนแสดงผลแบบเรียลไทม์ในขณะที่เซิร์ฟเวอร์ประมวลผลแต่ละรายการ:
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### ขั้นตอนสำคัญในการพัฒนา

1. **สร้างเซิร์ฟเวอร์ MCP โดยใช้ FastMCP**
2. **กำหนดเครื่องมือที่ประมวลผลรายการและส่งการแจ้งเตือนโดยใช้ `ctx.info()` หรือ `ctx.log()`**
3. **รันเซิร์ฟเวอร์ด้วย `transport="streamable-http"`**
4. **พัฒนาไคลเอนต์ที่มี message handler เพื่อแสดงการแจ้งเตือนเมื่อได้รับ**

### การอธิบายโค้ด
- เซิร์ฟเวอร์ใช้ฟังก์ชันแบบ async และบริบท MCP เพื่อส่งอัปเดตความคืบหน้า
- ไคลเอนต์พัฒนาด้วย async message handler เพื่อพิมพ์การแจ้งเตือนและผลลัพธ์สุดท้าย

### เคล็ดลับและการแก้ไขปัญหา

- ใช้ `async/await` เพื่อให้การทำงานไม่บล็อก
- จัดการข้อผิดพลาดในทั้งเซิร์ฟเวอร์และไคลเอนต์เพื่อความเสถียร
- ทดสอบกับไคลเอนต์หลายตัวเพื่อดูการอัปเดตแบบเรียลไทม์
- หากพบข้อผิดพลาด ให้ตรวจสอบเวอร์ชัน Python และตรวจสอบว่าติดตั้ง dependencies ครบถ้วนแล้ว

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดขึ้นจากการใช้การแปลนี้