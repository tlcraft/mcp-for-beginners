<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5ef8f5821c1a04f7b1fc4f15098ecab8",
  "translation_date": "2025-06-18T06:00:04+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "th"
}
-->
ซึ่งหมายถึงการรันคำสั่งประมาณนี้: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` พิมพ์ข้อความเช่น "add 3 to 20"

    คุณจะเห็นเครื่องมือแสดงขึ้นเหนือกล่องข้อความแชทเพื่อให้คุณเลือกใช้งานเครื่องมือดังภาพนี้:

    ![VS Code แสดงว่าต้องการรันเครื่องมือ](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.th.png)

    การเลือกเครื่องมือจะให้ผลลัพธ์เป็นตัวเลข "23" หากข้อความที่คุณพิมพ์เหมือนที่เรากล่าวไว้ข้างต้น

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด โปรดทราบว่าการแปลโดยอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่แม่นยำ เอกสารต้นฉบับในภาษาต้นทางควรถูกพิจารณาเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ แนะนำให้ใช้บริการแปลโดยมนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใดๆ ที่เกิดจากการใช้การแปลนี้