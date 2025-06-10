<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:23:27+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "ur"
}
-->
# Weather MCP Server

یہ Python میں ایک نمونہ MCP Server ہے جو موسمی آلات کو جعلی جوابات کے ساتھ نافذ کرتا ہے۔ اسے آپ کے اپنے MCP Server کے لیے ایک سانچہ کے طور پر استعمال کیا جا سکتا ہے۔ اس میں درج ذیل خصوصیات شامل ہیں:

- **Weather Tool**: ایک آلہ جو دی گئی جگہ کی بنیاد پر موسمی معلومات فراہم کرتا ہے۔
- **Connect to Agent Builder**: ایک خصوصیت جو آپ کو MCP سرور کو Agent Builder سے جوڑنے کی اجازت دیتی ہے تاکہ ٹیسٹنگ اور ڈیبگنگ کی جا سکے۔
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: ایک خصوصیت جو MCP Inspector کا استعمال کرتے ہوئے MCP Server کو ڈیبگ کرنے کی سہولت دیتی ہے۔

## Get started with the Weather MCP Server template

> **Prerequisites**
>
> MCP Server کو اپنی لوکل ڈویلپمنٹ مشین پر چلانے کے لیے آپ کو درج ذیل کی ضرورت ہوگی:
>
> - [Python](https://www.python.org/)
> - (*اختیاری - اگر آپ uv کو ترجیح دیتے ہیں*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Prepare environment

اس پروجیکٹ کے لیے ماحول ترتیب دینے کے دو طریقے ہیں۔ آپ اپنی پسند کے مطابق کوئی بھی طریقہ منتخب کر سکتے ہیں۔

> Note: ورچوئل ماحول بنانے کے بعد VSCode یا ٹرمینل کو ری لوڈ کریں تاکہ ورچوئل ماحول کا python استعمال ہو۔

| Approach | Steps |
| -------- | ----- |
| Using `uv` | 1. ورچوئل ماحول بنائیں: `uv venv` <br>2. VSCode کمانڈ "***Python: Select Interpreter***" چلائیں اور بنائے گئے ورچوئل ماحول سے python منتخب کریں <br>3. dependencies انسٹال کریں (dev dependencies سمیت): `uv pip install -r pyproject.toml --extra dev` |
| Using `pip` | 1. ورچوئل ماحول بنائیں: `python -m venv .venv` <br>2. VSCode کمانڈ "***Python: Select Interpreter***" چلائیں اور بنائے گئے ورچوئل ماحول سے python منتخب کریں<br>3. dependencies انسٹال کریں (dev dependencies سمیت): `pip install -e .[dev]` |

ماحول ترتیب دینے کے بعد، آپ Agent Builder کو MCP Client کے طور پر استعمال کرتے ہوئے اپنی لوکل ڈویلپمنٹ مشین پر سرور چلا سکتے ہیں:
1. VS Code Debug پینل کھولیں۔ MCP سرور کو ڈیبگ کرنے کے لیے `Debug in Agent Builder` منتخب کریں یا `F5` دبائیں۔
2. AI Toolkit Agent Builder کا استعمال کرتے ہوئے [اس پرامپٹ](../../../../../../../../../../../open_prompt_builder) کے ساتھ سرور کی جانچ کریں۔ سرور خود بخود Agent Builder سے جڑ جائے گا۔
3. سرور کی جانچ کے لیے `Run` پر کلک کریں۔

**مبارک ہو**! آپ نے کامیابی سے Agent Builder کو MCP Client کے طور پر استعمال کرتے ہوئے اپنی لوکل مشین پر Weather MCP Server چلایا ہے۔
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## What's included in the template

| Folder / File| مواد                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | ڈیبگنگ کے لیے VSCode فائلز                   |
| `.aitk`      | AI Toolkit کے لیے کنفیگریشنز                |
| `src`        | weather mcp server کا سورس کوڈ   |

## How to debug the Weather MCP Server

> Notes:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) ایک بصری ڈویلپر ٹول ہے جو MCP servers کی ٹیسٹنگ اور ڈیبگنگ کے لیے استعمال ہوتا ہے۔
> - تمام ڈیبگنگ موڈز بریک پوائنٹس کو سپورٹ کرتے ہیں، لہٰذا آپ ٹول کے امپلیمینٹیشن کوڈ میں بریک پوائنٹس شامل کر سکتے ہیں۔

| Debug Mode | Description | Steps to debug |
| ---------- | ----------- | --------------- |
| Agent Builder | AI Toolkit کے ذریعے Agent Builder میں MCP سرور کو ڈیبگ کریں۔ | 1. VS Code Debug پینل کھولیں۔ MCP سرور کو ڈیبگ کرنے کے لیے `Debug in Agent Builder` منتخب کریں اور `F5` دبائیں۔<br>2. AI Toolkit Agent Builder کا استعمال کرتے ہوئے [اس پرامپٹ](../../../../../../../../../../../open_prompt_builder) کے ساتھ سرور کی جانچ کریں۔ سرور خود بخود Agent Builder سے جڑ جائے گا۔<br>3. سرور کی جانچ کے لیے `Run` پر کلک کریں۔ |
| MCP Inspector | MCP Inspector کا استعمال کرتے ہوئے MCP سرور کو ڈیبگ کریں۔ | 1. [Node.js](https://nodejs.org/) انسٹال کریں۔<br> 2. Inspector سیٹ اپ کریں: `cd inspector` && `npm install` <br> 3. VS Code Debug پینل کھولیں۔ `Debug SSE in Inspector (Edge)` یا `Debug SSE in Inspector (Chrome)` منتخب کریں۔ ڈیبگنگ شروع کرنے کے لیے F5 دبائیں۔<br> 4. جب MCP Inspector براؤزر میں لانچ ہو جائے، تو اس MCP سرور کو کنیکٹ کرنے کے لیے `Connect` بٹن پر کلک کریں۔<br> 5. پھر آپ `List Tools` کر سکتے ہیں، ایک ٹول منتخب کریں، پیرامیٹرز ان پٹ کریں، اور اپنے سرور کوڈ کو ڈیبگ کرنے کے لیے `Run Tool` کریں۔<br> |

## Default Ports and customizations

| Debug Mode | Ports | Definitions | Customizations | Note |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | اوپر دیے گئے پورٹس کو تبدیل کرنے کے لیے [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) میں ترمیم کریں۔ | N/A |
| MCP Inspector | 3001 (Server); 5173 اور 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | اوپر دیے گئے پورٹس کو تبدیل کرنے کے لیے [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) میں ترمیم کریں۔| N/A |

## Feedback

اگر آپ کے پاس اس ٹیمپلیٹ کے لیے کوئی رائے یا تجاویز ہیں، تو براہ کرم [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues) پر ایک مسئلہ کھولیں۔

**دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار تراجم میں غلطیاں یا نقائص ہو سکتے ہیں۔ اصل دستاویز اپنی مادری زبان میں معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ تجویز کیا جاتا ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے لیے ہم ذمہ دار نہیں ہیں۔