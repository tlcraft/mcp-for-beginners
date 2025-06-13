<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:01:59+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "th"
}
-->
# การรันตัวอย่างนี้

นี่คือวิธีการรันเซิร์ฟเวอร์และไคลเอนต์ HTTP streaming แบบคลาสสิก รวมถึง MCP streaming server และไคลเอนต์ โดยใช้ Python

### ภาพรวม

- คุณจะตั้งค่า MCP server ที่ส่งการแจ้งเตือนความคืบหน้าไปยังไคลเอนต์ขณะที่กำลังประมวลผลรายการ
- ไคลเอนต์จะแสดงการแจ้งเตือนแต่ละรายการแบบเรียลไทม์
- คู่มือนี้ครอบคลุมถึงข้อกำหนดเบื้องต้น การตั้งค่า การรัน และการแก้ไขปัญหา

### ข้อกำหนดเบื้องต้น

- Python 3.9 หรือใหม่กว่า
- แพ็กเกจ `mcp` ของ Python (ติดตั้งด้วย `pip install mcp`)

### การติดตั้งและตั้งค่า

1. โคลนรีโพสิทอรีหรือดาวน์โหลดไฟล์โซลูชัน

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

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Client:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### การรัน Classic HTTP Streaming Server

1. ไปที่ไดเรกทอรีของโซลูชัน:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. เริ่มต้น classic HTTP streaming server:

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

2. คุณจะเห็นข้อความที่ถูกสตรีมแสดงผลทีละข้อความ:

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

1. ไปที่ไดเรกทอรีของโซลูชัน:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. เริ่ม MCP server ด้วยการขนส่งแบบ streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. เซิร์ฟเวอร์จะเริ่มทำงานและแสดงผล:
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
2. คุณจะเห็นการแจ้งเตือนถูกพิมพ์แบบเรียลไทม์ขณะที่เซิร์ฟเวอร์กำลังประมวลผลแต่ละรายการ:
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

1. **สร้าง MCP server โดยใช้ FastMCP**
2. **กำหนดเครื่องมือที่ประมวลผลรายการและส่งการแจ้งเตือนโดยใช้ `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` สำหรับการทำงานแบบไม่บล็อก**
- ควรจัดการข้อยกเว้นทั้งในเซิร์ฟเวอร์และไคลเอนต์เพื่อความเสถียร
- ทดสอบกับไคลเอนต์หลายตัวเพื่อดูการอัปเดตแบบเรียลไทม์
- หากพบข้อผิดพลาด ให้ตรวจสอบเวอร์ชัน Python และยืนยันว่าติดตั้ง dependencies ครบถ้วนแล้ว

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารฉบับนี้ได้รับการแปลโดยใช้บริการแปลภาษาด้วย AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้องได้ เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยมนุษย์ผู้เชี่ยวชาญ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้