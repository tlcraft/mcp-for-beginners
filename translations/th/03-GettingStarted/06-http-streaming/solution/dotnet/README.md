<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-07-13T21:04:38+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "th"
}
-->
# การรันตัวอย่างนี้

## -1- ติดตั้ง dependencies

```bash
dotnet restore
```

## -2- รันตัวอย่าง

```bash
dotnet run
```

## -3- ทดสอบตัวอย่าง

เปิดเทอร์มินัลแยกต่างหากก่อนรันคำสั่งด้านล่าง (ตรวจสอบให้แน่ใจว่าเซิร์ฟเวอร์ยังทำงานอยู่)

เมื่อเซิร์ฟเวอร์ทำงานในเทอร์มินัลหนึ่ง ให้เปิดเทอร์มินัลอีกอันและรันคำสั่งต่อไปนี้:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

คำสั่งนี้จะเริ่มเว็บเซิร์ฟเวอร์พร้อมอินเทอร์เฟซแบบภาพที่ช่วยให้คุณทดสอบตัวอย่างได้

> ตรวจสอบให้แน่ใจว่าเลือก **Streamable HTTP** เป็นประเภทการส่งข้อมูล และ URL คือ `http://localhost:3001/mcp`

เมื่อเซิร์ฟเวอร์เชื่อมต่อแล้ว:

- ลองแสดงรายการเครื่องมือและรันคำสั่ง `add` พร้อมอาร์กิวเมนต์ 2 และ 4 คุณจะเห็นผลลัพธ์เป็น 6
- ไปที่ resources และ resource template แล้วเรียกใช้ "greeting" พิมพ์ชื่อเข้าไป คุณจะเห็นข้อความทักทายพร้อมชื่อที่คุณใส่

### การทดสอบในโหมด CLI

คุณสามารถเปิดใช้งานโดยตรงในโหมด CLI โดยรันคำสั่งต่อไปนี้:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

คำสั่งนี้จะแสดงรายการเครื่องมือทั้งหมดที่มีในเซิร์ฟเวอร์ คุณจะเห็นผลลัพธ์ดังนี้:

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
> โดยปกติจะเร็วกว่ามากถ้าใช้ ispector ในโหมด CLI แทนการใช้ในเบราว์เซอร์
> อ่านข้อมูลเพิ่มเติมเกี่ยวกับ inspector ได้ที่ [นี่](https://github.com/modelcontextprotocol/inspector)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้