<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:49:50+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "th"
}
-->
# การรันตัวอย่าง

ที่นี่เราสมมติว่าคุณมีโค้ดเซิร์ฟเวอร์ที่ทำงานได้แล้ว กรุณาหาเซิร์ฟเวอร์จากบทก่อนหน้านี้

## การตั้งค่า mcp.json

นี่คือไฟล์ที่คุณใช้เป็นข้อมูลอ้างอิง [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json)

แก้ไขส่วนเซิร์ฟเวอร์ตามความเหมาะสมเพื่อชี้ไปยังเส้นทางแบบสมบูรณ์ของเซิร์ฟเวอร์ของคุณ รวมถึงคำสั่งเต็มที่จำเป็นต้องใช้ในการรัน

ในไฟล์ตัวอย่างที่กล่าวถึงข้างต้น ส่วนเซิร์ฟเวอร์จะมีลักษณะดังนี้:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

ซึ่งสอดคล้องกับการรันคำสั่งแบบนี้: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` พิมพ์อะไรบางอย่างเช่น "add 3 to 20"

    คุณจะเห็นเครื่องมือแสดงขึ้นเหนือกล่องข้อความแชทเพื่อให้คุณเลือกใช้เครื่องมือนั้นเหมือนในภาพนี้:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.th.png)

    การเลือกเครื่องมือนี้ควรแสดงผลลัพธ์เป็นตัวเลขว่า "23" หากคำสั่งของคุณเหมือนที่เราได้กล่าวไว้ก่อนหน้านี้

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาด้วย AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้การแปลมีความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ แนะนำให้ใช้บริการแปลโดยมนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้