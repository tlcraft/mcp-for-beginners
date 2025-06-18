<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T06:00:14+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
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

เปิดเทอร์มินัลอีกหน้าต่างก่อนรันคำสั่งด้านล่าง (ตรวจสอบให้แน่ใจว่าเซิร์ฟเวอร์ยังทำงานอยู่)

ในขณะที่เซิร์ฟเวอร์กำลังรันในเทอร์มินัลหนึ่ง ให้เปิดเทอร์มินัลอีกหน้าต่างและรันคำสั่งนี้:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

คำสั่งนี้จะเริ่มเว็บเซิร์ฟเวอร์พร้อมอินเทอร์เฟซแบบกราฟิกที่ช่วยให้คุณทดสอบตัวอย่างได้

> ตรวจสอบให้แน่ใจว่าเลือก **SSE** เป็นประเภทการเชื่อมต่อ และ URL เป็น `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add` โดยมี args เป็น 2 และ 4 คุณจะเห็นผลลัพธ์เป็น 6  
> - ไปที่ resources และ resource template แล้วเรียกใช้ "greeting" พิมพ์ชื่อเข้าไป คุณจะเห็นข้อความทักทายพร้อมชื่อที่คุณใส่

### การทดสอบในโหมด CLI

คุณสามารถรันโดยตรงในโหมด CLI ได้โดยใช้คำสั่งนี้:

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
> โดยทั่วไปการรัน inspector ในโหมด CLI จะเร็วกว่าการรันในเบราว์เซอร์มาก  
> อ่านรายละเอียดเพิ่มเติมเกี่ยวกับ inspector ได้ที่ [นี่](https://github.com/modelcontextprotocol/inspector)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลสำคัญ แนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดที่เกิดขึ้นจากการใช้การแปลนี้