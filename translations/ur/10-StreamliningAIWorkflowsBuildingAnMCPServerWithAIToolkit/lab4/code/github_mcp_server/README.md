<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:02:39+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "ur"
}
-->
# Weather MCP Server

یہ Python میں ایک نمونہ MCP Server ہے جو موسمی آلات کو جعلی جوابات کے ساتھ نافذ کرتا ہے۔ اسے آپ کے اپنے MCP Server کے لیے ایک بنیاد کے طور پر استعمال کیا جا سکتا ہے۔ اس میں درج ذیل خصوصیات شامل ہیں:

- **Weather Tool**: ایک آلہ جو دی گئی جگہ کی بنیاد پر موسمی معلومات فراہم کرتا ہے۔
- **Git Clone Tool**: ایک آلہ جو git repository کو مخصوص فولڈر میں کلون کرتا ہے۔
- **VS Code Open Tool**: ایک آلہ جو فولڈر کو VS Code یا VS Code Insiders میں کھولتا ہے۔
- **Connect to Agent Builder**: ایک خصوصیت جو MCP سرور کو Agent Builder سے منسلک کرنے کی اجازت دیتی ہے تاکہ ٹیسٹنگ اور ڈیبگنگ کی جا سکے۔
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: ایک خصوصیت جو MCP Inspector کا استعمال کرتے ہوئے MCP Server کو ڈیبگ کرنے کی اجازت دیتی ہے۔

## Weather MCP Server ٹیمپلیٹ کے ساتھ شروع کریں

> **ضروریات**
>
> اپنے مقامی ڈویلپمنٹ مشین پر MCP Server چلانے کے لیے آپ کو درج ذیل کی ضرورت ہوگی:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (git_clone_repo آلہ کے لیے ضروری)
> - [VS Code](https://code.visualstudio.com/) یا [VS Code Insiders](https://code.visualstudio.com/insiders/) (open_in_vscode آلہ کے لیے ضروری)
> - (*اختیاری - اگر آپ uv کو ترجیح دیتے ہیں*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## ماحول تیار کریں

اس پروجیکٹ کے ماحول کو ترتیب دینے کے لیے دو طریقے ہیں۔ آپ اپنی پسند کے مطابق کوئی بھی طریقہ منتخب کر سکتے ہیں۔

> نوٹ: ورچوئل ماحول بنانے کے بعد VSCode یا ٹرمینل کو ری لوڈ کریں تاکہ ورچوئل ماحول کا Python استعمال ہو۔

| طریقہ | مراحل |
| -------- | ----- |
| Using `uv` | 1. ورچوئل ماحول بنائیں: `uv venv` <br>2. VSCode کمانڈ "***Python: Select Interpreter***" چلائیں اور بنائے گئے ورچوئل ماحول سے Python منتخب کریں <br>3. dependencies انسٹال کریں (dev dependencies سمیت): `uv pip install -r pyproject.toml --extra dev` |
| Using `pip` | 1. ورچوئل ماحول بنائیں: `python -m venv .venv` <br>2. VSCode کمانڈ "***Python: Select Interpreter***" چلائیں اور بنائے گئے ورچوئل ماحول سے Python منتخب کریں<br>3. dependencies انسٹال کریں (dev dependencies سمیت): `pip install -e .[dev]` |

ماحول سیٹ اپ کرنے کے بعد، آپ Agent Builder کے ذریعے اپنے مقامی ڈویلپمنٹ مشین پر MCP Client کے طور پر سرور چلا سکتے ہیں تاکہ شروع کریں:
1. VS Code Debug پینل کھولیں۔ `Debug in Agent Builder` منتخب کریں یا `F5` دبائیں تاکہ MCP سرور کی ڈیبگنگ شروع ہو۔
2. AI Toolkit Agent Builder استعمال کریں تاکہ سرور کو [اس پرامپٹ](../../../../../../../../../../../open_prompt_builder) کے ساتھ ٹیسٹ کریں۔ سرور خود بخود Agent Builder سے منسلک ہو جائے گا۔
3. سرور کو پرامپٹ کے ساتھ ٹیسٹ کرنے کے لیے `Run` پر کلک کریں۔

**مبارک ہو**! آپ نے کامیابی سے Agent Builder کے ذریعے MCP Client کے طور پر اپنے مقامی ڈویلپمنٹ مشین پر Weather MCP Server چلایا ہے۔
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## ٹیمپلیٹ میں شامل کیا گیا ہے

| فولڈر / فائل| مواد                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | VSCode فائلز برائے ڈیبگنگ                   |
| `.aitk`      | AI Toolkit کے لیے کنفیگریشنز                |
| `src`        | weather mcp server کا سورس کوڈ   |

## Weather MCP Server کو کیسے ڈیبگ کریں

> نوٹس:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) ایک بصری ڈویلپر ٹول ہے جو MCP سرورز کی ٹیسٹنگ اور ڈیبگنگ کے لیے ہے۔
> - تمام ڈیبگنگ موڈز بریک پوائنٹس کی حمایت کرتے ہیں، لہٰذا آپ ٹول کی امپلیمنٹیشن کوڈ میں بریک پوائنٹس شامل کر سکتے ہیں۔

## دستیاب آلات

### Weather Tool
`get_weather` آلہ مخصوص جگہ کے لیے جعلی موسمی معلومات فراہم کرتا ہے۔

| پیرامیٹر | قسم | وضاحت |
| --------- | ---- | ----------- |
| `location` | string | وہ جگہ جہاں موسمی معلومات حاصل کرنی ہیں (مثلاً شہر کا نام، ریاست، یا کوآرڈینیٹس) |

### Git Clone Tool
`git_clone_repo` آلہ git repository کو مخصوص فولڈر میں کلون کرتا ہے۔

| پیرامیٹر | قسم | وضاحت |
| --------- | ---- | ----------- |
| `repo_url` | string | کلون کرنے کے لیے git repository کا URL |
| `target_folder` | string | وہ فولڈر جہاں repository کلون کرنی ہے |

آلہ ایک JSON آبجیکٹ واپس کرتا ہے جس میں شامل ہے:
- `success`: Boolean جو آپریشن کی کامیابی ظاہر کرتا ہے
- `target_folder` یا `error`: کلون کی گئی repository کا راستہ یا ایک ایرر پیغام

### VS Code Open Tool
`open_in_vscode` آلہ فولڈر کو VS Code یا VS Code Insiders ایپلیکیشن میں کھولتا ہے۔

| پیرامیٹر | قسم | وضاحت |
| --------- | ---- | ----------- |
| `folder_path` | string | کھولنے کے لیے فولڈر کا راستہ |
| `use_insiders` | boolean (اختیاری) | کیا عام VS Code کے بجائے VS Code Insiders استعمال کرنا ہے |

آلہ ایک JSON آبجیکٹ واپس کرتا ہے جس میں شامل ہے:
- `success`: Boolean جو آپریشن کی کامیابی ظاہر کرتا ہے
- `message` یا `error`: تصدیقی پیغام یا ایرر پیغام

## Debug Mode | وضاحت | ڈیبگ کرنے کے مراحل |
| ---------- | ----------- | --------------- |
| Agent Builder | AI Toolkit کے ذریعے Agent Builder میں MCP سرور کی ڈیبگنگ۔ | 1. VS Code Debug پینل کھولیں۔ `Debug in Agent Builder` منتخب کریں اور MCP سرور کی ڈیبگنگ شروع کرنے کے لیے `F5` دبائیں۔<br>2. AI Toolkit Agent Builder استعمال کریں تاکہ سرور کو [اس پرامپٹ](../../../../../../../../../../../open_prompt_builder) کے ساتھ ٹیسٹ کریں۔ سرور خود بخود Agent Builder سے منسلک ہو جائے گا۔<br>3. پرامپٹ کے ساتھ سرور کو ٹیسٹ کرنے کے لیے `Run` پر کلک کریں۔ |
| MCP Inspector | MCP Inspector کا استعمال کرتے ہوئے MCP سرور کی ڈیبگنگ۔ | 1. [Node.js](https://nodejs.org/) انسٹال کریں۔<br> 2. Inspector سیٹ اپ کریں: `cd inspector` && `npm install` <br> 3. VS Code Debug پینل کھولیں۔ `Debug SSE in Inspector (Edge)` یا `Debug SSE in Inspector (Chrome)` منتخب کریں۔ F5 دبائیں تاکہ ڈیبگنگ شروع ہو۔<br> 4. جب MCP Inspector براؤزر میں لانچ ہو، تو اس MCP سرور کو منسلک کرنے کے لیے `Connect` بٹن پر کلک کریں۔<br> 5. پھر آپ `List Tools` کر سکتے ہیں، کوئی آلہ منتخب کریں، پیرامیٹرز داخل کریں، اور `Run Tool` کر کے اپنے سرور کوڈ کی ڈیبگنگ کریں۔<br> |

## ڈیفالٹ پورٹس اور تخصیصات

| Debug Mode | پورٹس | تعریفات | تخصیصات | نوٹ |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | پورٹس تبدیل کرنے کے لیے [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json)، [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json)، [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py)، [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) میں ترمیم کریں۔ | N/A |
| MCP Inspector | 3001 (سرور); 5173 اور 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | پورٹس تبدیل کرنے کے لیے [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json)، [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json)، [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py)، [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) میں ترمیم کریں۔ | N/A |

## فیڈبیک

اگر آپ کے پاس اس ٹیمپلیٹ کے لیے کوئی فیڈبیک یا تجاویز ہیں، تو براہ کرم [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues) پر ایک مسئلہ کھولیں۔

**دسclaimer**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار تراجم میں غلطیاں یا کمی بیشی ہو سکتی ہے۔ اصل دستاویز اپنی مادری زبان میں معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ تجویز کیا جاتا ہے۔ اس ترجمہ کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے لیے ہم ذمہ دار نہیں ہیں۔