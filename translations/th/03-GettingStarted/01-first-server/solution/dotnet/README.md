<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T06:00:08+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "th"
}
-->
# การรันตัวอย่างนี้

## -1- ติดตั้ง dependencies

```bash
dotnet restore
```

## -3- รันตัวอย่าง


```bash
dotnet run
```

## -4- ทดสอบตัวอย่าง

ขณะที่เซิร์ฟเวอร์กำลังทำงานในเทอร์มินัลหนึ่ง ให้เปิดเทอร์มินัลอีกอันและรันคำสั่งต่อไปนี้:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

คำสั่งนี้จะเริ่มเว็บเซิร์ฟเวอร์พร้อมอินเทอร์เฟซแบบภาพที่ช่วยให้คุณทดสอบตัวอย่างได้

เมื่อเซิร์ฟเวอร์เชื่อมต่อแล้ว:

- ลองเรียกดูรายการเครื่องมือและรันคำสั่ง `add` โดยใส่อาร์กิวเมนต์ 2 และ 4 คุณจะเห็นผลลัพธ์เป็น 6
- ไปที่ resources และ resource template แล้วเรียกใช้ "greeting" พิมพ์ชื่อเข้าไปและคุณจะเห็นข้อความทักทายพร้อมชื่อที่คุณป้อน

### การทดสอบในโหมด CLI

คุณสามารถเปิดใช้งานโดยตรงในโหมด CLI โดยรันคำสั่งนี้:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

คำสั่งนี้จะแสดงรายการเครื่องมือทั้งหมดที่มีในเซิร์ฟเวอร์ คุณจะเห็นผลลัพธ์ดังนี้:

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

คุณจะเห็นผลลัพธ์ดังนี้:

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
> ปกติแล้วการรัน inspector ในโหมด CLI จะเร็วกว่าการรันผ่านเบราว์เซอร์มาก
> อ่านข้อมูลเพิ่มเติมเกี่ยวกับ inspector ได้ที่ [นี่](https://github.com/modelcontextprotocol/inspector)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลโดยอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลสำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญด้านมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดขึ้นจากการใช้การแปลนี้