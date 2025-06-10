<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:22:48+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "ar"
}
-->
# خادم Weather MCP

هذا نموذج لخادم MCP مكتوب بلغة Python ينفذ أدوات الطقس مع ردود وهمية. يمكن استخدامه كأساس لإنشاء خادم MCP خاص بك. يتضمن الميزات التالية:

- **أداة الطقس**: أداة توفر معلومات طقس وهمية بناءً على الموقع المعطى.
- **الاتصال بـ Agent Builder**: ميزة تتيح لك ربط خادم MCP بـ Agent Builder للاختبار وتصحيح الأخطاء.
- **التصحيح في [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: ميزة تتيح لك تصحيح خادم MCP باستخدام MCP Inspector.

## البدء باستخدام قالب Weather MCP Server

> **المتطلبات الأساسية**
>
> لتشغيل خادم MCP على جهاز التطوير المحلي الخاص بك، ستحتاج إلى:
>
> - [Python](https://www.python.org/)
> - (*اختياري - إذا كنت تفضل uv*) [uv](https://github.com/astral-sh/uv)
> - [امتداد مصحح أخطاء Python](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## إعداد البيئة

هناك طريقتان لإعداد البيئة لهذا المشروع. يمكنك اختيار أي منهما حسب تفضيلك.

> ملاحظة: أعد تحميل VSCode أو الطرفية للتأكد من استخدام Python الخاص بالبيئة الافتراضية بعد إنشائها.

| الطريقة | الخطوات |
| -------- | ----- |
| باستخدام `uv` | 1. إنشاء البيئة الافتراضية: `uv venv` <br>2. تشغيل أمر VSCode "***Python: Select Interpreter***" واختيار Python من البيئة الافتراضية المنشأة <br>3. تثبيت الاعتمادات (بما في ذلك اعتمادات التطوير): `uv pip install -r pyproject.toml --extra dev` |
| باستخدام `pip` | 1. إنشاء البيئة الافتراضية: `python -m venv .venv` <br>2. تشغيل أمر VSCode "***Python: Select Interpreter***" واختيار Python من البيئة الافتراضية المنشأة<br>3. تثبيت الاعتمادات (بما في ذلك اعتمادات التطوير): `pip install -e .[dev]` |

بعد إعداد البيئة، يمكنك تشغيل الخادم على جهاز التطوير المحلي عبر Agent Builder كعميل MCP للبدء:
1. افتح لوحة التصحيح في VS Code. اختر `Debug in Agent Builder` أو اضغط `F5` لبدء تصحيح خادم MCP.
2. استخدم AI Toolkit Agent Builder لاختبار الخادم باستخدام [هذا الموجه](../../../../../../../../../../../open_prompt_builder). سيتم الاتصال تلقائياً بالخادم عبر Agent Builder.
3. اضغط `Run` لاختبار الخادم باستخدام الموجه.

**تهانينا**! لقد نجحت في تشغيل خادم Weather MCP على جهاز التطوير المحلي الخاص بك عبر Agent Builder كعميل MCP.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## ما الذي يتضمنه القالب

| المجلد / الملف| المحتويات                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | ملفات VSCode لتصحيح الأخطاء                   |
| `.aitk`      | إعدادات AI Toolkit                |
| `src`        | الشيفرة المصدرية لخادم weather mcp   |

## كيفية تصحيح خادم Weather MCP

> ملاحظات:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) هو أداة تطوير بصرية لاختبار وتصحيح خوادم MCP.
> - جميع أوضاع التصحيح تدعم نقاط التوقف، لذا يمكنك إضافة نقاط توقف إلى كود تنفيذ الأداة.

| وضع التصحيح | الوصف | خطوات التصحيح |
| ---------- | ----------- | --------------- |
| Agent Builder | تصحيح خادم MCP في Agent Builder عبر AI Toolkit. | 1. افتح لوحة التصحيح في VS Code. اختر `Debug in Agent Builder` واضغط `F5` لبدء تصحيح خادم MCP.<br>2. استخدم AI Toolkit Agent Builder لاختبار الخادم باستخدام [هذا الموجه](../../../../../../../../../../../open_prompt_builder). سيتم الاتصال تلقائياً بالخادم عبر Agent Builder.<br>3. اضغط `Run` لاختبار الخادم باستخدام الموجه. |
| MCP Inspector | تصحيح خادم MCP باستخدام MCP Inspector. | 1. قم بتثبيت [Node.js](https://nodejs.org/)<br> 2. إعداد Inspector: `cd inspector` && `npm install` <br> 3. افتح لوحة التصحيح في VS Code. اختر `Debug SSE in Inspector (Edge)` أو `Debug SSE in Inspector (Chrome)`. اضغط F5 لبدء التصحيح.<br> 4. عند إطلاق MCP Inspector في المتصفح، اضغط زر `Connect` لربط هذا الخادم.<br> 5. بعدها يمكنك `List Tools`، اختيار أداة، إدخال المعطيات، و `Run Tool` لتصحيح كود الخادم الخاص بك.<br> |

## المنافذ الافتراضية والتخصيصات

| وضع التصحيح | المنافذ | التعريفات | التخصيصات | ملاحظة |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | حرر [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json)، [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json)، [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py)، [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) لتغيير المنافذ أعلاه. | غير متوفر |
| MCP Inspector | 3001 (الخادم); 5173 و 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | حرر [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json)، [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json)، [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py)، [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) لتغيير المنافذ أعلاه.| غير متوفر |

## الملاحظات

إذا كان لديك أي ملاحظات أو اقتراحات لهذا القالب، يرجى فتح تذكرة على [مستودع AI Toolkit على GitHub](https://github.com/microsoft/vscode-ai-toolkit/issues)

**تنويه**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. بالنسبة للمعلومات الحساسة، يُنصح بالترجمة الاحترافية بواسطة مترجم بشري. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.