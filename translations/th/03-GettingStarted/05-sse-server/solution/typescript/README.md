<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:10:12+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "th"
}
-->
# การใช้งานตัวอย่างนี้

## -1- ติดตั้งการพึ่งพา

```bash
npm install
```

## -3- รันตัวอย่าง

```bash
npm run build
```

## -4- ทดสอบตัวอย่าง

เมื่อเซิร์ฟเวอร์กำลังทำงานในเทอร์มินัลหนึ่ง ให้เปิดเทอร์มินัลอีกอันแล้วรันคำสั่งต่อไปนี้:

```bash
npm run inspector
```

นี่จะเริ่มต้นเว็บเซิร์ฟเวอร์ที่มีอินเทอร์เฟซภาพให้คุณทดสอบตัวอย่าง

เมื่อเซิร์ฟเวอร์เชื่อมต่อแล้ว:

- ลองรายการเครื่องมือและรัน `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build`

- ในเทอร์มินัลแยกกัน รันคำสั่งต่อไปนี้:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
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

- เรียกใช้ประเภทเครื่องมือโดยการพิมพ์คำสั่งต่อไปนี้:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

คุณควรเห็นผลลัพธ์ดังนี้:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> ปกติจะเร็วมากในการรัน inspector ในโหมด CLI มากกว่าในเบราว์เซอร์
> อ่านเพิ่มเติมเกี่ยวกับ inspector [ที่นี่](https://github.com/modelcontextprotocol/inspector)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้การแปลมีความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาของตนเองควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลภาษามนุษย์ที่มีความเชี่ยวชาญ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดจากการใช้การแปลนี้