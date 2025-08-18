<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "69ba3bd502bd743233137bac5539c08b",
  "translation_date": "2025-08-18T14:34:14+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "th"
}
-->
# การใช้งานตัวอย่างนี้

แนะนำให้ติดตั้ง `uv` แต่ไม่จำเป็นต้องติดตั้ง ดู [คำแนะนำ](https://docs.astral.sh/uv/#highlights)

## -0- สร้าง virtual environment

```bash
python -m venv venv
```

## -1- เปิดใช้งาน virtual environment

```bash
venv\Scrips\activate
```

## -2- ติดตั้ง dependencies

```bash
pip install "mcp[cli]"
```

## -3- รันตัวอย่าง

```bash
uvicorn server:app
```

## -4- ทดสอบตัวอย่าง

เมื่อเซิร์ฟเวอร์กำลังทำงานในหนึ่ง terminal ให้เปิดอีก terminal และรันคำสั่งต่อไปนี้:

```bash
mcp dev server.py
```

สิ่งนี้จะเริ่มต้นเว็บเซิร์ฟเวอร์พร้อมอินเทอร์เฟซแบบภาพที่ช่วยให้คุณทดสอบตัวอย่างได้

เมื่อเซิร์ฟเวอร์เชื่อมต่อแล้ว:

- ลองแสดงรายการเครื่องมือและรัน `add` โดยใช้ args 2 และ 4 คุณควรเห็นผลลัพธ์เป็น 6
- ไปที่ resources และ resource template แล้วเรียก get_greeting พิมพ์ชื่อเข้าไป คุณควรเห็นข้อความต้อนรับพร้อมชื่อที่คุณให้มา

### การทดสอบในโหมด CLI

Inspector ที่คุณรันนั้นจริง ๆ แล้วเป็นแอป Node.js และ `mcp dev` เป็น wrapper ที่ครอบคลุมมัน

คุณสามารถเปิดใช้งานโดยตรงในโหมด CLI โดยรันคำสั่งต่อไปนี้:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

สิ่งนี้จะแสดงรายการเครื่องมือทั้งหมดที่มีในเซิร์ฟเวอร์ คุณควรเห็นผลลัพธ์ดังนี้:

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

เพื่อเรียกใช้งานเครื่องมือ ให้พิมพ์:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

คุณควรเห็นผลลัพธ์ดังนี้:

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

> [!TIP]
> โดยปกติการรัน inspector ในโหมด CLI จะเร็วกว่าในเบราว์เซอร์มาก
> อ่านเพิ่มเติมเกี่ยวกับ inspector [ที่นี่](https://github.com/modelcontextprotocol/inspector)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้การแปลมีความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่แม่นยำ เอกสารต้นฉบับในภาษาดั้งเดิมควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลภาษาจากผู้เชี่ยวชาญ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดซึ่งเกิดจากการใช้การแปลนี้