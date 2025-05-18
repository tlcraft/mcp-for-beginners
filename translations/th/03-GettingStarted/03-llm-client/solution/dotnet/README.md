<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:41:29+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "th"
}
-->
# รันตัวอย่างนี้

> [!NOTE]
> ตัวอย่างนี้สมมติว่าคุณกำลังใช้ GitHub Codespaces หากคุณต้องการรันในเครื่องของคุณเอง คุณจำเป็นต้องตั้งค่า personal access token บน GitHub

## ติดตั้งไลบรารี

```sh
dotnet restore
```

ควรติดตั้งไลบรารีดังต่อไปนี้: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

## รัน

```sh 
dotnet run
```

คุณควรเห็นผลลัพธ์ที่คล้ายกับ:

```text
Setting up stdio transport
Listing tools
Connected to server with tools: Add
Tool description: Adds two numbers
Tool parameters: {"title":"Add","description":"Adds two numbers","type":"object","properties":{"a":{"type":"integer"},"b":{"type":"integer"}},"required":["a","b"]}
Tool definition: Azure.AI.Inference.ChatCompletionsToolDefinition
Properties: {"a":{"type":"integer"},"b":{"type":"integer"}}
MCP Tools def: 0: Azure.AI.Inference.ChatCompletionsToolDefinition
Tool call 0: Add with arguments {"a":2,"b":4}
Sum 6
```

ผลลัพธ์ส่วนใหญ่จะเป็นการดีบัก แต่สิ่งที่สำคัญคือคุณกำลังแสดงรายการเครื่องมือจาก MCP Server แปลงพวกนั้นเป็นเครื่องมือ LLM และคุณจะได้คำตอบจาก MCP client เป็น "Sum 6"

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ได้ความถูกต้องที่สุด โปรดทราบว่าการแปลโดยอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาดั้งเดิมควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลภาษามนุษย์มืออาชีพ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดจากการใช้การแปลนี้