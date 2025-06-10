<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:20:34+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "sl"
}
-->
# Weather MCP Server

Ini je contoh MCP Server di Python yang ngimplementasiin alat cuaca dengan respons palsu. Bisa dipakai sebagai kerangka buat MCP Server kamu sendiri. Fitur-fiturnya meliputi:

- **Weather Tool**: Alat yang nyediain info cuaca palsu berdasarkan lokasi yang diberikan.
- **Git Clone Tool**: Alat yang nge-clone repositori git ke folder yang ditentukan.
- **VS Code Open Tool**: Alat yang buka folder di VS Code atau VS Code Insiders.
- **Connect to Agent Builder**: Fitur yang memungkinkan kamu nyambungin MCP server ke Agent Builder buat testing dan debugging.
- **Debug di [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Fitur buat debug MCP Server pake MCP Inspector.

## Mulai dengan template Weather MCP Server

> **Prasyarat**
>
> Buat ngejalanin MCP Server di mesin dev lokal kamu, kamu butuh:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (dibutuhin buat git_clone_repo tool)
> - [VS Code](https://code.visualstudio.com/) atau [VS Code Insiders](https://code.visualstudio.com/insiders/) (dibutuhin buat open_in_vscode tool)
> - (*Opsional - kalau kamu suka uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Siapkan lingkungan

Ada dua cara buat nyiapin lingkungan proyek ini. Kamu bisa pilih salah satu sesuai preferensi.

> Catatan: Reload VSCode atau terminal supaya python dari virtual environment yang dipakai setelah bikin virtual environment.

| Cara | Langkah |
| -------- | ----- |
| Pakai `uv` | 1. Buat virtual environment: `uv venv` <br>2. Jalankan perintah VSCode "***Python: Select Interpreter***" dan pilih python dari virtual environment yang dibuat <br>3. Install dependensi (termasuk dev dependencies): `uv pip install -r pyproject.toml --extra dev` |
| Pakai `pip` | 1. Buat virtual environment: `python -m venv .venv` <br>2. Jalankan perintah VSCode "***Python: Select Interpreter***" dan pilih python dari virtual environment yang dibuat<br>3. Install dependensi (termasuk dev dependencies): `pip install -e .[dev]` | 

Setelah nyiapin lingkungan, kamu bisa jalankan server di mesin dev lokal lewat Agent Builder sebagai MCP Client buat mulai:
1. Buka panel Debug di VS Code. Pilih `Debug in Agent Builder` atau tekan `F5` buat mulai debugging MCP server.
2. Pakai AI Toolkit Agent Builder buat tes server dengan [prompt ini](../../../../../../../../../../../open_prompt_builder). Server bakal otomatis tersambung ke Agent Builder.
3. Klik `Run` buat tes server dengan prompt tersebut.

**Selamat**! Kamu berhasil menjalankan Weather MCP Server di mesin dev lokal lewat Agent Builder sebagai MCP Client.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Isi template ini

| Folder / File| Isi                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | File VSCode buat debugging                   |
| `.aitk`      | Konfigurasi untuk AI Toolkit                |
| `src`        | Kode sumber untuk weather mcp server   |

## Cara debug Weather MCP Server

> Catatan:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) adalah alat visual buat developer untuk testing dan debugging MCP server.
> - Semua mode debugging mendukung breakpoint, jadi kamu bisa pasang breakpoint di kode implementasi alat.

## Alat yang tersedia

### Weather Tool  
Alat `get_weather` nyediain info cuaca palsu untuk lokasi yang ditentukan.

| Parameter | Tipe | Deskripsi |
| --------- | ---- | ----------- |
| `location` | string | Lokasi yang mau diambil info cuacanya (misal: nama kota, provinsi, atau koordinat) |

### Git Clone Tool  
Alat `git_clone_repo` nge-clone repositori git ke folder yang ditentukan.

| Parameter | Tipe | Deskripsi |
| --------- | ---- | ----------- |
| `repo_url` | string | URL repositori git yang mau di-clone |
| `target_folder` | string | Path folder tempat repositori akan di-clone |

Alat ini mengembalikan objek JSON dengan:
- `success`: Boolean yang nunjukin apakah operasi berhasil
- `target_folder` atau `error`: Path repositori yang di-clone atau pesan error

### VS Code Open Tool  
Alat `open_in_vscode` buka folder di aplikasi VS Code atau VS Code Insiders.

| Parameter | Tipe | Deskripsi |
| --------- | ---- | ----------- |
| `folder_path` | string | Path folder yang mau dibuka |
| `use_insiders` | boolean (opsional) | Apakah mau pakai VS Code Insiders daripada VS Code biasa |

Alat ini mengembalikan objek JSON dengan:
- `success`: Boolean yang nunjukin apakah operasi berhasil
- `message` atau `error`: Pesan konfirmasi atau pesan error

## Mode Debug | Deskripsi | Langkah debug |
| ---------- | ----------- | --------------- |
| Agent Builder | Debug MCP server di Agent Builder lewat AI Toolkit. | 1. Buka panel Debug di VS Code. Pilih `Debug in Agent Builder` dan tekan `F5` buat mulai debugging MCP server.<br>2. Pakai AI Toolkit Agent Builder buat tes server dengan [prompt ini](../../../../../../../../../../../open_prompt_builder). Server bakal otomatis tersambung ke Agent Builder.<br>3. Klik `Run` buat tes server dengan prompt tersebut. |
| MCP Inspector | Debug MCP server pake MCP Inspector. | 1. Install [Node.js](https://nodejs.org/)<br> 2. Siapkan Inspector: `cd inspector` && `npm install` <br> 3. Buka panel Debug di VS Code. Pilih `Debug SSE in Inspector (Edge)` atau `Debug SSE in Inspector (Chrome)`. Tekan F5 buat mulai debugging.<br> 4. Saat MCP Inspector terbuka di browser, klik tombol `Connect` buat nyambungin MCP server ini.<br> 5. Lalu kamu bisa `List Tools`, pilih alat, input parameter, dan `Run Tool` buat debug kode server kamu.<br> |

## Port default dan kustomisasi

| Mode Debug | Port | Definisi | Kustomisasi | Catatan |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Edit [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) buat ubah port di atas. | N/A |
| MCP Inspector | 3001 (Server); 5173 dan 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Edit [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) buat ubah port di atas.| N/A |

## Feedback

Kalau kamu punya masukan atau saran untuk template ini, silakan buka issue di [repository AI Toolkit GitHub](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za prevajanje z umetno inteligenco [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za kritične informacije priporočamo strokovni človeški prevod. Za kakršnekoli nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.