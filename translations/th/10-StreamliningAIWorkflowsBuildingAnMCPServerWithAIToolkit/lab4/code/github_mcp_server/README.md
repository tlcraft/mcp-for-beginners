<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:11:09+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "th"
}
-->
# Weather MCP Server

นี่คือตัวอย่าง MCP Server ที่เขียนด้วย Python ซึ่งมีเครื่องมือเกี่ยวกับสภาพอากาศพร้อมคำตอบจำลอง สามารถใช้เป็นโครงสร้างสำหรับสร้าง MCP Server ของคุณเองได้ โดยมีฟีเจอร์ดังนี้:

- **Weather Tool**: เครื่องมือที่ให้ข้อมูลสภาพอากาศจำลองตามตำแหน่งที่ระบุ
- **Git Clone Tool**: เครื่องมือสำหรับโคลนรีโพสิตอรี git ไปยังโฟลเดอร์ที่กำหนด
- **VS Code Open Tool**: เครื่องมือสำหรับเปิดโฟลเดอร์ใน VS Code หรือ VS Code Insiders
- **Connect to Agent Builder**: ฟีเจอร์ที่ช่วยให้คุณเชื่อมต่อ MCP server กับ Agent Builder เพื่อทดสอบและดีบัก
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: ฟีเจอร์สำหรับดีบัก MCP Server ด้วย MCP Inspector

## เริ่มต้นกับ Weather MCP Server template

> **สิ่งที่ต้องมี**
>
> ในการรัน MCP Server บนเครื่องพัฒนาของคุณ จำเป็นต้องมี:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (จำเป็นสำหรับเครื่องมือ git_clone_repo)
> - [VS Code](https://code.visualstudio.com/) หรือ [VS Code Insiders](https://code.visualstudio.com/insiders/) (จำเป็นสำหรับเครื่องมือ open_in_vscode)
> - (*ถ้าต้องการ - ถ้าคุณชอบ uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## เตรียมสภาพแวดล้อม

มีสองวิธีในการตั้งค่าสภาพแวดล้อมสำหรับโปรเจกต์นี้ คุณสามารถเลือกวิธีใดวิธีหนึ่งตามที่คุณสะดวก

> หมายเหตุ: รีโหลด VSCode หรือเทอร์มินัลเพื่อให้แน่ใจว่า python ใน virtual environment ถูกใช้งานหลังจากสร้าง virtual environment แล้ว

| วิธี | ขั้นตอน |
| -------- | ----- |
| Using `uv` | 1. สร้าง virtual environment: `uv venv` <br>2. รันคำสั่งใน VSCode "***Python: Select Interpreter***" แล้วเลือก python จาก virtual environment ที่สร้างขึ้น <br>3. ติดตั้ง dependencies (รวม dev dependencies): `uv pip install -r pyproject.toml --extra dev` |
| Using `pip` | 1. สร้าง virtual environment: `python -m venv .venv` <br>2. รันคำสั่งใน VSCode "***Python: Select Interpreter***" แล้วเลือก python จาก virtual environment ที่สร้างขึ้น<br>3. ติดตั้ง dependencies (รวม dev dependencies): `pip install -e .[dev]` | 

หลังจากตั้งค่าสภาพแวดล้อมเสร็จแล้ว คุณสามารถรันเซิร์ฟเวอร์บนเครื่องพัฒนาของคุณผ่าน Agent Builder ในฐานะ MCP Client เพื่อเริ่มต้นได้:
1. เปิดแผง Debug ของ VS Code เลือก `Debug in Agent Builder` หรือกด `F5` เพื่อเริ่มดีบัก MCP server
2. ใช้ AI Toolkit Agent Builder เพื่อทดสอบเซิร์ฟเวอร์ด้วย [พรอมต์นี้](../../../../../../../../../../../open_prompt_builder) เซิร์ฟเวอร์จะเชื่อมต่อกับ Agent Builder โดยอัตโนมัติ
3. คลิก `Run` เพื่อทดสอบเซิร์ฟเวอร์ด้วยพรอมต์

**ยินดีด้วย**! คุณรัน Weather MCP Server บนเครื่องพัฒนาของคุณผ่าน Agent Builder ในฐานะ MCP Client สำเร็จแล้ว  
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## สิ่งที่รวมอยู่ในเทมเพลต

| โฟลเดอร์ / ไฟล์ | เนื้อหา                                    |
| ------------ | -------------------------------------------- |
| `.vscode`    | ไฟล์ VSCode สำหรับการดีบัก                   |
| `.aitk`      | การตั้งค่าสำหรับ AI Toolkit                |
| `src`        | ซอร์สโค้ดของ weather mcp server            |

## วิธีดีบัก Weather MCP Server

> หมายเหตุ:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) คือเครื่องมือสำหรับนักพัฒนาที่มีอินเทอร์เฟซกราฟิกสำหรับทดสอบและดีบัก MCP servers
> - โหมดดีบักทั้งหมดรองรับ breakpoint คุณจึงสามารถเพิ่ม breakpoint ในโค้ดของเครื่องมือได้

## เครื่องมือที่มีให้ใช้งาน

### Weather Tool
เครื่องมือ `get_weather` ให้ข้อมูลสภาพอากาศจำลองสำหรับตำแหน่งที่ระบุ

| พารามิเตอร์ | ชนิด | คำอธิบาย |
| --------- | ---- | ----------- |
| `location` | string | ตำแหน่งที่ต้องการข้อมูลสภาพอากาศ (เช่น ชื่อเมือง รัฐ หรือพิกัด) |

### Git Clone Tool
เครื่องมือ `git_clone_repo` สำหรับโคลนรีโพสิตอรี git ไปยังโฟลเดอร์ที่กำหนด

| พารามิเตอร์ | ชนิด | คำอธิบาย |
| --------- | ---- | ----------- |
| `repo_url` | string | URL ของรีโพสิตอรี git ที่จะโคลน |
| `target_folder` | string | เส้นทางไปยังโฟลเดอร์ที่ต้องการเก็บรีโพสิตอรี |

เครื่องมือจะคืนค่าเป็นอ็อบเจ็กต์ JSON ที่ประกอบด้วย:
- `success`: Boolean บอกว่างานสำเร็จหรือไม่
- `target_folder` หรือ `error`: เส้นทางของรีโพสิตอรีที่โคลนหรือข้อความแสดงข้อผิดพลาด

### VS Code Open Tool
เครื่องมือ `open_in_vscode` สำหรับเปิดโฟลเดอร์ในแอป VS Code หรือ VS Code Insiders

| พารามิเตอร์ | ชนิด | คำอธิบาย |
| --------- | ---- | ----------- |
| `folder_path` | string | เส้นทางไปยังโฟลเดอร์ที่จะเปิด |
| `use_insiders` | boolean (optional) | เลือกใช้ VS Code Insiders แทน VS Code ปกติหรือไม่ |

เครื่องมือจะคืนค่าเป็นอ็อบเจ็กต์ JSON ที่ประกอบด้วย:
- `success`: Boolean บอกว่างานสำเร็จหรือไม่
- `message` หรือ `error`: ข้อความยืนยันหรือข้อความแสดงข้อผิดพลาด

## Debug Mode | คำอธิบาย | ขั้นตอนการดีบัก |
| ---------- | ----------- | --------------- |
| Agent Builder | ดีบัก MCP server ใน Agent Builder ผ่าน AI Toolkit | 1. เปิดแผง Debug ของ VS Code เลือก `Debug in Agent Builder` และกด `F5` เพื่อเริ่มดีบัก MCP server<br>2. ใช้ AI Toolkit Agent Builder เพื่อทดสอบเซิร์ฟเวอร์ด้วย [พรอมต์นี้](../../../../../../../../../../../open_prompt_builder) เซิร์ฟเวอร์จะเชื่อมต่อกับ Agent Builder โดยอัตโนมัติ<br>3. คลิก `Run` เพื่อทดสอบเซิร์ฟเวอร์ด้วยพรอมต์ |
| MCP Inspector | ดีบัก MCP server ด้วย MCP Inspector | 1. ติดตั้ง [Node.js](https://nodejs.org/)<br> 2. ตั้งค่า Inspector: `cd inspector` && `npm install` <br> 3. เปิดแผง Debug ของ VS Code เลือก `Debug SSE in Inspector (Edge)` หรือ `Debug SSE in Inspector (Chrome)` กด F5 เพื่อเริ่มดีบัก<br> 4. เมื่อ MCP Inspector เปิดในเบราว์เซอร์ ให้คลิกปุ่ม `Connect` เพื่อเชื่อมต่อ MCP server นี้<br> 5. จากนั้นคุณสามารถ `List Tools`, เลือกเครื่องมือ, ป้อนพารามิเตอร์ และ `Run Tool` เพื่อดีบักโค้ดเซิร์ฟเวอร์ของคุณ<br> |

## พอร์ตเริ่มต้นและการปรับแต่ง

| Debug Mode | พอร์ต | คำอธิบาย | การปรับแต่ง | หมายเหตุ |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | แก้ไข [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) เพื่อเปลี่ยนพอร์ตเหล่านี้ | ไม่มี |
| MCP Inspector | 3001 (Server); 5173 และ 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | แก้ไข [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) เพื่อเปลี่ยนพอร์ตเหล่านี้ | ไม่มี |

## ข้อเสนอแนะ

หากคุณมีข้อเสนอแนะหรือติชมสำหรับเทมเพลตนี้ กรุณาเปิด issue ใน [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารฉบับนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้การแปลโดยมนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดจากการใช้การแปลนี้