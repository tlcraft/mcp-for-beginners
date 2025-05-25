<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:16:49+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "th"
}
-->
# การใช้งานตัวอย่างนี้

แนะนำให้ติดตั้ง `uv` แต่ไม่จำเป็นต้องทำตามคำแนะนำ [ที่นี่](https://docs.astral.sh/uv/#highlights)

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

เมื่อเซิร์ฟเวอร์ทำงานในเทอร์มินัลหนึ่ง ให้เปิดอีกเทอร์มินัลหนึ่งและรันคำสั่งต่อไปนี้:

```bash
mcp dev server.py
```

นี่จะเริ่มเซิร์ฟเวอร์เว็บพร้อมอินเทอร์เฟซที่ช่วยให้คุณทดสอบตัวอย่างได้

เมื่อเซิร์ฟเวอร์เชื่อมต่อแล้ว:

- ลองแสดงรายการเครื่องมือและรัน `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` เป็นตัวห่อหุ้มมัน

คุณสามารถเปิดใช้งานในโหมด CLI ได้โดยรันคำสั่งต่อไปนี้:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

นี่จะแสดงรายการเครื่องมือทั้งหมดที่มีในเซิร์ฟเวอร์ คุณควรเห็นผลลัพธ์ดังนี้:

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

ในการเรียกใช้งานเครื่องมือ ให้พิมพ์:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> โดยปกติจะรัน inspector ในโหมด CLI ได้เร็วกว่าในเบราว์เซอร์
> อ่านเพิ่มเติมเกี่ยวกับ inspector [ที่นี่](https://github.com/modelcontextprotocol/inspector)

**คำปฏิเสธความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามอย่างดีที่สุดเพื่อให้ได้ความถูกต้อง แต่อย่างไรก็ตามการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่แม่นยำเกิดขึ้นได้ เอกสารต้นฉบับในภาษาต้นฉบับควรถูกพิจารณาเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลภาษามนุษย์มืออาชีพ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดจากการใช้การแปลนี้