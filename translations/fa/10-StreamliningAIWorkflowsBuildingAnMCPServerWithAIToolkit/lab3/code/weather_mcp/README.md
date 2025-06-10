<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:23:06+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "fa"
}
-->
# Weather MCP Server

این یک نمونه سرور MCP در پایتون است که ابزارهای هواشناسی را با پاسخ‌های شبیه‌سازی شده پیاده‌سازی می‌کند. می‌توان از آن به عنوان چارچوبی برای سرور MCP خودتان استفاده کرد. این نمونه شامل ویژگی‌های زیر است:

- **ابزار هواشناسی**: ابزاری که اطلاعات هواشناسی شبیه‌سازی شده را بر اساس مکان داده شده ارائه می‌دهد.
- **اتصال به Agent Builder**: ویژگی‌ای که امکان اتصال سرور MCP به Agent Builder را برای تست و اشکال‌زدایی فراهم می‌کند.
- **اشکال‌زدایی در [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: ویژگی‌ای که اجازه می‌دهد با استفاده از MCP Inspector سرور MCP را اشکال‌زدایی کنید.

## شروع به کار با قالب Weather MCP Server

> **پیش‌نیازها**
>
> برای اجرای سرور MCP در ماشین توسعه محلی خود به موارد زیر نیاز دارید:
>
> - [Python](https://www.python.org/)
> - (*اختیاری - اگر ترجیح می‌دهید uv*) [uv](https://github.com/astral-sh/uv)
> - [افزونه دیباگر پایتون](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## آماده‌سازی محیط

دو روش برای راه‌اندازی محیط این پروژه وجود دارد. می‌توانید بر اساس ترجیح خود یکی را انتخاب کنید.

> توجه: پس از ساخت محیط مجازی، VSCode یا ترمینال را مجدداً بارگذاری کنید تا از استفاده پایتون محیط مجازی اطمینان حاصل شود.

| روش | مراحل |
| -------- | ----- |
| استفاده از `uv` | 1. ایجاد محیط مجازی: `uv venv` <br>2. اجرای دستور VSCode "***Python: Select Interpreter***" و انتخاب پایتون از محیط مجازی ساخته شده <br>3. نصب وابستگی‌ها (شامل وابستگی‌های توسعه): `uv pip install -r pyproject.toml --extra dev` |
| استفاده از `pip` | 1. ایجاد محیط مجازی: `python -m venv .venv` <br>2. اجرای دستور VSCode "***Python: Select Interpreter***" و انتخاب پایتون از محیط مجازی ساخته شده<br>3. نصب وابستگی‌ها (شامل وابستگی‌های توسعه): `pip install -e .[dev]` |

پس از راه‌اندازی محیط، می‌توانید سرور را در ماشین توسعه محلی خود از طریق Agent Builder به عنوان کلاینت MCP اجرا کنید تا شروع کنید:
1. پنل دیباگ VS Code را باز کنید. `Debug in Agent Builder` را انتخاب کرده یا `F5` را فشار دهید تا اشکال‌زدایی سرور MCP آغاز شود.
2. از AI Toolkit Agent Builder برای تست سرور با [این درخواست](../../../../../../../../../../../open_prompt_builder) استفاده کنید. سرور به طور خودکار به Agent Builder متصل خواهد شد.
3. برای تست سرور با درخواست، روی `Run` کلیک کنید.

**تبریک می‌گوییم**! شما با موفقیت Weather MCP Server را در ماشین توسعه محلی خود از طریق Agent Builder به عنوان کلاینت MCP اجرا کردید.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## موارد موجود در قالب

| پوشه / فایل | محتویات |
| ------------ | -------------------------------------------- |
| `.vscode`    | فایل‌های VSCode برای اشکال‌زدایی                   |
| `.aitk`      | پیکربندی‌های AI Toolkit                |
| `src`        | کد منبع سرور weather mcp   |

## چگونه Weather MCP Server را اشکال‌زدایی کنیم

> نکات:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) یک ابزار توسعه‌دهنده بصری برای تست و اشکال‌زدایی سرورهای MCP است.
> - همه حالت‌های اشکال‌زدایی از نقاط توقف پشتیبانی می‌کنند، بنابراین می‌توانید نقاط توقف را به کد پیاده‌سازی ابزار اضافه کنید.

| حالت اشکال‌زدایی | توضیحات | مراحل اشکال‌زدایی |
| ---------- | ----------- | --------------- |
| Agent Builder | اشکال‌زدایی سرور MCP در Agent Builder از طریق AI Toolkit. | 1. پنل دیباگ VS Code را باز کنید. `Debug in Agent Builder` را انتخاب کرده و `F5` را فشار دهید تا اشکال‌زدایی سرور MCP آغاز شود.<br>2. از AI Toolkit Agent Builder برای تست سرور با [این درخواست](../../../../../../../../../../../open_prompt_builder) استفاده کنید. سرور به طور خودکار به Agent Builder متصل خواهد شد.<br>3. برای تست سرور با درخواست، روی `Run` کلیک کنید. |
| MCP Inspector | اشکال‌زدایی سرور MCP با استفاده از MCP Inspector. | 1. نصب [Node.js](https://nodejs.org/)<br> 2. راه‌اندازی Inspector: `cd inspector` && `npm install` <br> 3. پنل دیباگ VS Code را باز کنید. `Debug SSE in Inspector (Edge)` یا `Debug SSE in Inspector (Chrome)` را انتخاب کنید. F5 را فشار دهید تا اشکال‌زدایی آغاز شود.<br> 4. وقتی MCP Inspector در مرورگر باز شد، روی دکمه `Connect` کلیک کنید تا این سرور MCP متصل شود.<br> 5. سپس می‌توانید `List Tools`، ابزاری را انتخاب کنید، پارامترها را وارد کنید و `Run Tool` تا کد سرور خود را اشکال‌زدایی کنید.<br> |

## پورت‌های پیش‌فرض و سفارشی‌سازی‌ها

| حالت اشکال‌زدایی | پورت‌ها | تعاریف | سفارشی‌سازی‌ها | توضیح |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | برای تغییر پورت‌های بالا، فایل‌های [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json)، [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json)، [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py)، [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) را ویرایش کنید. | ندارد |
| MCP Inspector | 3001 (سرور); 5173 و 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | برای تغییر پورت‌های بالا، فایل‌های [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json)، [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json)، [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py)، [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) را ویرایش کنید. | ندارد |

## بازخورد

اگر بازخورد یا پیشنهادی برای این قالب دارید، لطفاً یک Issue در [مخزن GitHub AI Toolkit](https://github.com/microsoft/vscode-ai-toolkit/issues) باز کنید.

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان مادری آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما در قبال هرگونه سوءتفاهم یا تفسیر نادرست ناشی از استفاده از این ترجمه مسئولیتی نداریم.