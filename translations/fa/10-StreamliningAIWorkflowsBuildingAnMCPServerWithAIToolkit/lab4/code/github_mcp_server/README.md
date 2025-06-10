<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:02:17+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "fa"
}
-->
# Weather MCP Server

این یک نمونه سرور MCP در پایتون است که ابزارهای هواشناسی را با پاسخ‌های شبیه‌سازی شده پیاده‌سازی می‌کند. می‌توان از آن به عنوان چارچوبی برای سرور MCP خودتان استفاده کرد. این نمونه شامل ویژگی‌های زیر است:

- **ابزار هواشناسی**: ابزاری که اطلاعات هواشناسی شبیه‌سازی شده را بر اساس مکان داده شده ارائه می‌دهد.
- **ابزار کلون گیت**: ابزاری که یک مخزن گیت را به پوشه مشخصی کلون می‌کند.
- **ابزار باز کردن در VS Code**: ابزاری که یک پوشه را در VS Code یا VS Code Insiders باز می‌کند.
- **اتصال به Agent Builder**: ویژگی‌ای که اجازه می‌دهد سرور MCP را برای تست و اشکال‌زدایی به Agent Builder متصل کنید.
- **اشکال‌زدایی در [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: ویژگی‌ای که امکان اشکال‌زدایی سرور MCP را با استفاده از MCP Inspector فراهم می‌کند.

## شروع کار با قالب Weather MCP Server

> **پیش‌نیازها**
>
> برای اجرای سرور MCP در ماشین توسعه محلی خود، به موارد زیر نیاز دارید:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (برای ابزار git_clone_repo لازم است)
> - [VS Code](https://code.visualstudio.com/) یا [VS Code Insiders](https://code.visualstudio.com/insiders/) (برای ابزار open_in_vscode لازم است)
> - (اختیاری - اگر uv را ترجیح می‌دهید) [uv](https://github.com/astral-sh/uv)
> - [افزونه اشکال‌زدای پایتون](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## آماده‌سازی محیط

دو روش برای راه‌اندازی محیط این پروژه وجود دارد. می‌توانید بر اساس ترجیح خود یکی را انتخاب کنید.

> توجه: پس از ایجاد محیط مجازی، VSCode یا ترمینال را مجدداً بارگذاری کنید تا اطمینان حاصل شود که پایتون محیط مجازی استفاده می‌شود.

| روش | مراحل |
| -------- | ----- |
| استفاده از `uv` | 1. ایجاد محیط مجازی: `uv venv` <br>2. اجرای فرمان VSCode "***Python: Select Interpreter***" و انتخاب پایتون از محیط مجازی ایجاد شده <br>3. نصب وابستگی‌ها (شامل وابستگی‌های توسعه): `uv pip install -r pyproject.toml --extra dev` |
| استفاده از `pip` | 1. ایجاد محیط مجازی: `python -m venv .venv` <br>2. اجرای فرمان VSCode "***Python: Select Interpreter***" و انتخاب پایتون از محیط مجازی ایجاد شده<br>3. نصب وابستگی‌ها (شامل وابستگی‌های توسعه): `pip install -e .[dev]` | 

پس از راه‌اندازی محیط، می‌توانید سرور را در ماشین توسعه محلی خود از طریق Agent Builder به عنوان MCP Client اجرا کنید تا شروع به کار کنید:
1. پنل اشکال‌زدایی VS Code را باز کنید. `Debug in Agent Builder` را انتخاب کنید یا کلید `F5` را فشار دهید تا اشکال‌زدایی سرور MCP آغاز شود.
2. از AI Toolkit Agent Builder برای تست سرور با [این درخواست](../../../../../../../../../../../open_prompt_builder) استفاده کنید. سرور به طور خودکار به Agent Builder متصل خواهد شد.
3. برای تست سرور با درخواست، روی `Run` کلیک کنید.

**تبریک می‌گوییم**! شما با موفقیت سرور Weather MCP را در ماشین توسعه محلی خود از طریق Agent Builder به عنوان MCP Client اجرا کردید.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## موارد موجود در قالب

| پوشه / فایل | محتویات                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | فایل‌های VSCode برای اشکال‌زدایی                   |
| `.aitk`      | پیکربندی‌های AI Toolkit                |
| `src`        | کد منبع سرور weather mcp   |

## چگونه سرور Weather MCP را اشکال‌زدایی کنیم

> نکات:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) یک ابزار توسعه‌دهنده بصری برای تست و اشکال‌زدایی سرورهای MCP است.
> - همه حالت‌های اشکال‌زدایی از نقاط توقف پشتیبانی می‌کنند، بنابراین می‌توانید نقاط توقف را به کد پیاده‌سازی ابزار اضافه کنید.

## ابزارهای موجود

### ابزار هواشناسی
ابزار `get_weather` اطلاعات هواشناسی شبیه‌سازی شده برای مکان مشخص شده را ارائه می‌دهد.

| پارامتر | نوع | توضیحات |
| --------- | ---- | ----------- |
| `location` | رشته | مکانی که می‌خواهید هواشناسی آن را دریافت کنید (مثلاً نام شهر، ایالت یا مختصات) |

### ابزار کلون گیت
ابزار `git_clone_repo` یک مخزن گیت را به پوشه مشخص شده کلون می‌کند.

| پارامتر | نوع | توضیحات |
| --------- | ---- | ----------- |
| `repo_url` | رشته | آدرس URL مخزن گیت برای کلون کردن |
| `target_folder` | رشته | مسیر پوشه‌ای که مخزن باید در آن کلون شود |

این ابزار یک شیء JSON برمی‌گرداند که شامل:
- `success`: مقدار بولی که نشان می‌دهد عملیات موفقیت‌آمیز بوده است
- `target_folder` یا `error`: مسیر مخزن کلون شده یا پیام خطا

### ابزار باز کردن در VS Code
ابزار `open_in_vscode` یک پوشه را در برنامه VS Code یا VS Code Insiders باز می‌کند.

| پارامتر | نوع | توضیحات |
| --------- | ---- | ----------- |
| `folder_path` | رشته | مسیر پوشه‌ای که باید باز شود |
| `use_insiders` | بولی (اختیاری) | آیا به جای VS Code معمولی از VS Code Insiders استفاده شود |

این ابزار یک شیء JSON برمی‌گرداند که شامل:
- `success`: مقدار بولی که نشان می‌دهد عملیات موفقیت‌آمیز بوده است
- `message` یا `error`: پیام تایید یا پیام خطا

## حالت اشکال‌زدایی | توضیح | مراحل اشکال‌زدایی |
| ---------- | ----------- | --------------- |
| Agent Builder | اشکال‌زدایی سرور MCP در Agent Builder از طریق AI Toolkit. | 1. پنل اشکال‌زدایی VS Code را باز کنید. `Debug in Agent Builder` را انتخاب کرده و کلید `F5` را فشار دهید تا اشکال‌زدایی سرور MCP شروع شود.<br>2. از AI Toolkit Agent Builder برای تست سرور با [این درخواست](../../../../../../../../../../../open_prompt_builder) استفاده کنید. سرور به طور خودکار به Agent Builder متصل خواهد شد.<br>3. برای تست سرور با درخواست، روی `Run` کلیک کنید. |
| MCP Inspector | اشکال‌زدایی سرور MCP با استفاده از MCP Inspector. | 1. نصب [Node.js](https://nodejs.org/)<br> 2. راه‌اندازی Inspector: `cd inspector` && `npm install` <br> 3. پنل اشکال‌زدایی VS Code را باز کنید. `Debug SSE in Inspector (Edge)` یا `Debug SSE in Inspector (Chrome)` را انتخاب کنید. کلید F5 را برای شروع اشکال‌زدایی فشار دهید.<br> 4. وقتی MCP Inspector در مرورگر باز شد، دکمه `Connect` را برای اتصال این سرور MCP کلیک کنید.<br> 5. سپس می‌توانید `List Tools`، یک ابزار را انتخاب کنید، پارامترها را وارد کنید و `Run Tool` تا کد سرور خود را اشکال‌زدایی کنید.<br> |

## پورت‌های پیش‌فرض و سفارشی‌سازی‌ها

| حالت اشکال‌زدایی | پورت‌ها | تعاریف | سفارشی‌سازی‌ها | توضیح |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | برای تغییر پورت‌های فوق، [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json)، [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json)، [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py)، [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) را ویرایش کنید. | ندارد |
| MCP Inspector | 3001 (سرور)؛ 5173 و 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | برای تغییر پورت‌های فوق، [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json)، [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json)، [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py)، [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) را ویرایش کنید.| ندارد |

## بازخورد

اگر بازخورد یا پیشنهادی برای این قالب دارید، لطفاً یک issue در [مخزن GitHub AI Toolkit](https://github.com/microsoft/vscode-ai-toolkit/issues) باز کنید.

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است شامل خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان مادری خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که ناشی از استفاده از این ترجمه باشد، نیستیم.