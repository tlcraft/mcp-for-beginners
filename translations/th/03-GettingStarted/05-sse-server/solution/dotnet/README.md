<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:56:09+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "th"
}
-->
# การรันตัวอย่างนี้

## -1- ติดตั้ง dependencies

```bash
dotnet run
```

## -2- รันตัวอย่าง

```bash
dotnet run
```

## -3- ทดสอบตัวอย่าง

เริ่มต้น terminal แยกก่อนที่คุณจะรันคำสั่งด้านล่าง (ตรวจสอบว่าเซิร์ฟเวอร์ยังคงทำงานอยู่)

เมื่อเซิร์ฟเวอร์ทำงานใน terminal หนึ่ง ให้เปิดอีก terminal และรันคำสั่งต่อไปนี้:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

นี่ควรจะเริ่มต้นเว็บเซิร์ฟเวอร์ที่มีอินเตอร์เฟซแบบภาพให้คุณทดสอบตัวอย่างได้

เมื่อเซิร์ฟเวอร์เชื่อมต่อแล้ว:

- ลองแสดงรายการเครื่องมือและรัน `add` โดยมี args 2 และ 4 คุณควรจะเห็น 6 ในผลลัพธ์
- ไปที่ resources และ resource template และเรียก "greeting" พิมพ์ชื่อและคุณควรจะเห็นการทักทายด้วยชื่อที่คุณให้

### การทดสอบในโหมด CLI

คุณสามารถเปิดมันในโหมด CLI โดยตรงโดยการรันคำสั่งต่อไปนี้:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

นี่จะเป็นการแสดงรายการเครื่องมือทั้งหมดที่มีในเซิร์ฟเวอร์ คุณควรจะเห็นผลลัพธ์ดังนี้:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

เพื่อเรียกใช้เครื่องมือ ให้พิมพ์:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

คุณควรจะเห็นผลลัพธ์ดังนี้:

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
> ปกติจะเร็วกว่าในการรัน inspector ในโหมด CLI มากกว่าในเบราว์เซอร์
> อ่านเพิ่มเติมเกี่ยวกับ inspector [ที่นี่](https://github.com/modelcontextprotocol/inspector).

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ได้ความถูกต้องมากที่สุด โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ แนะนำให้ใช้บริการแปลภาษามนุษย์มืออาชีพ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดอันเกิดจากการใช้การแปลนี้