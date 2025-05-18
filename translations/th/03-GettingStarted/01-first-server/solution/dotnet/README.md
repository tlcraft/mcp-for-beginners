<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:09:44+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "th"
}
-->
# การใช้งานตัวอย่างนี้

## -1- ติดตั้ง dependencies

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- รันตัวอย่าง

```bash
dotnet run
```

## -4- ทดสอบตัวอย่าง

เมื่อเซิร์ฟเวอร์กำลังทำงานในเทอร์มินัลหนึ่ง ให้เปิดเทอร์มินัลอีกอันแล้วรันคำสั่งต่อไปนี้:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

นี่จะเริ่มต้นเว็บเซิร์ฟเวอร์พร้อมอินเทอร์เฟซแบบภาพที่ช่วยให้คุณทดสอบตัวอย่างได้

เมื่อเซิร์ฟเวอร์เชื่อมต่อแล้ว:

- ลองแสดงรายการเครื่องมือและรัน `add` ด้วยอาร์กิวเมนต์ 2 และ 4 คุณควรเห็น 6 ในผลลัพธ์
- ไปที่ resources และ resource template และเรียก "greeting" พิมพ์ชื่อเข้าไปแล้วคุณควรเห็นคำทักทายพร้อมชื่อที่คุณให้

### การทดสอบในโหมด CLI

คุณสามารถเปิดใช้งานโดยตรงในโหมด CLI ด้วยการรันคำสั่งต่อไปนี้:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

นี่จะแสดงรายการเครื่องมือทั้งหมดที่มีในเซิร์ฟเวอร์ คุณควรเห็นผลลัพธ์ต่อไปนี้:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

ในการเรียกใช้เครื่องมือ ให้พิมพ์:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

คุณควรเห็นผลลัพธ์ต่อไปนี้:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> โดยปกติแล้วการรัน inspector ในโหมด CLI จะเร็วกว่ารันในเบราว์เซอร์มาก
> อ่านเพิ่มเติมเกี่ยวกับ inspector [ที่นี่](https://github.com/modelcontextprotocol/inspector)

**คำปฏิเสธความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ถูกต้องที่สุด โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลสำคัญ แนะนำให้ใช้บริการแปลภาษามนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดซึ่งเกิดจากการใช้การแปลนี้