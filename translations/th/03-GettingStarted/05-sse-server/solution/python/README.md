<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:03:11+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "th"
}
-->
# การใช้งานตัวอย่างนี้

แนะนำให้ติดตั้ง `uv` แต่ไม่จำเป็น สามารถดู [คำแนะนำ](https://docs.astral.sh/uv/#highlights)

## -0- สร้างสภาพแวดล้อมเสมือน

```bash
python -m venv venv
```

## -1- เปิดใช้งานสภาพแวดล้อมเสมือน

```bash
venv\Scrips\activate
```

## -2- ติดตั้งสิ่งที่จำเป็น

```bash
pip install "mcp[cli]"
```

## -3- รันตัวอย่าง

```bash
mcp run server.py
```

## -4- ทดสอบตัวอย่าง

เมื่อเซิร์ฟเวอร์ทำงานในเทอร์มินัลหนึ่ง ให้เปิดอีกเทอร์มินัลหนึ่งและรันคำสั่งต่อไปนี้:

```bash
mcp dev server.py
```

นี่จะเริ่มเซิร์ฟเวอร์เว็บที่มีส่วนต่อประสานแบบภาพให้คุณทดสอบตัวอย่างได้

เมื่อเซิร์ฟเวอร์เชื่อมต่อ:

- ลองแสดงรายการเครื่องมือและรัน `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` เป็นตัวห่อรอบๆ

คุณสามารถเปิดใช้งานในโหมด CLI ได้โดยรันคำสั่งต่อไปนี้:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

นี่จะทำการแสดงรายการเครื่องมือทั้งหมดที่มีอยู่ในเซิร์ฟเวอร์ คุณควรเห็นผลลัพธ์ดังนี้:

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

ในการเรียกใช้เครื่องมือ ให้พิมพ์:

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

> ![!TIP]
> โดยทั่วไปแล้วจะเร็วกว่าในการรัน inspector ในโหมด CLI มากกว่าบนเบราว์เซอร์
> อ่านเพิ่มเติมเกี่ยวกับ inspector [ที่นี่](https://github.com/modelcontextprotocol/inspector)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลด้วย AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้การแปลมีความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาที่ใช้ควรถือว่าเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้การแปลโดยมนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดจากการใช้การแปลนี้