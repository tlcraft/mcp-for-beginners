<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:55:47+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "th"
}
-->
# การใช้งานตัวอย่างนี้

ตัวอย่างนี้เกี่ยวข้องกับการมี LLM บนไคลเอนต์ ซึ่งคุณจำเป็นต้องรันใน Codespaces หรือจัดการตั้งค่า personal access token ใน GitHub เพื่อให้ทำงานได้

## -1- ติดตั้ง dependencies

```bash
npm install
```

## -3- รันเซิร์ฟเวอร์

```bash
npm run build
```

## -4- รันไคลเอนต์

```sh
npm run client
```

คุณควรเห็นผลลัพธ์ที่คล้ายกันดังนี้:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**คำปฏิเสธความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้การแปลมีความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นฉบับควรถือว่าเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้การแปลโดยมนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดจากการใช้การแปลนี้