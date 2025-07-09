<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-09T23:07:20+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "th"
}
-->
# การรันตัวอย่างนี้

แนะนำให้ติดตั้ง `uv` แต่ไม่จำเป็น ดู [คำแนะนำ](https://docs.astral.sh/uv/#highlights)

## -0- สร้างสภาพแวดล้อมเสมือน

```bash
python -m venv venv
```

## -1- เปิดใช้งานสภาพแวดล้อมเสมือน

```bash
venv\Scrips\activate
```

## -2- ติดตั้ง dependencies

```bash
pip install "mcp[cli]"
```

## -3- รันตัวอย่าง


```bash
mcp run server.py
```

## -4- ทดสอบตัวอย่าง

เมื่อเซิร์ฟเวอร์กำลังทำงานในเทอร์มินัลหนึ่ง ให้เปิดเทอร์มินัลอีกอันและรันคำสั่งต่อไปนี้:

```bash
mcp dev server.py
```

คำสั่งนี้จะเริ่มเซิร์ฟเวอร์เว็บพร้อมอินเทอร์เฟซแบบกราฟิกที่ช่วยให้คุณทดสอบตัวอย่างได้

เมื่อเซิร์ฟเวอร์เชื่อมต่อแล้ว:

- ลองแสดงรายการเครื่องมือและรัน `add` โดยใส่อาร์กิวเมนต์ 2 และ 4 คุณจะเห็นผลลัพธ์เป็น 6

- ไปที่ resources และ resource template แล้วเรียกใช้ get_greeting พิมพ์ชื่อเข้าไปและคุณจะเห็นข้อความทักทายพร้อมชื่อที่คุณใส่

### การทดสอบในโหมด CLI

Inspector ที่คุณรันจริงๆ แล้วเป็นแอป Node.js และ `mcp dev` เป็นตัวห่อหุ้มมัน

คุณสามารถเปิดใช้งานโดยตรงในโหมด CLI โดยรันคำสั่งนี้:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

คำสั่งนี้จะแสดงรายการเครื่องมือทั้งหมดที่มีในเซิร์ฟเวอร์ คุณจะเห็นผลลัพธ์ดังนี้:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

เพื่อเรียกใช้เครื่องมือ ให้พิมพ์:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

คุณจะเห็นผลลัพธ์ดังนี้:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> โดยปกติจะเร็วกว่ามากถ้ารัน inspector ในโหมด CLI แทนการใช้เบราว์เซอร์
> อ่านข้อมูลเพิ่มเติมเกี่ยวกับ inspector ได้ที่ [นี่](https://github.com/modelcontextprotocol/inspector)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้