<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:01:57+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "ar"
}
-->
# خادم MCP للطقس

هذا نموذج لخادم MCP مكتوب بلغة Python ينفذ أدوات الطقس مع استجابات وهمية. يمكن استخدامه كأساس لإنشاء خادم MCP خاص بك. يتضمن الميزات التالية:

- **أداة الطقس**: أداة توفر معلومات طقس وهمية بناءً على الموقع المحدد.
- **أداة استنساخ Git**: أداة تستنسخ مستودع git إلى مجلد معين.
- **أداة فتح VS Code**: أداة تفتح مجلداً في VS Code أو VS Code Insiders.
- **الاتصال بمنشئ الوكيل**: ميزة تتيح لك ربط خادم MCP بمنشئ الوكيل للاختبار وتصحيح الأخطاء.
- **التصحيح في [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: ميزة تسمح لك بتصحيح خادم MCP باستخدام MCP Inspector.

## ابدأ باستخدام قالب خادم MCP للطقس

> **المتطلبات الأساسية**
>
> لتشغيل خادم MCP على جهاز التطوير المحلي لديك، ستحتاج إلى:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (مطلوب لأداة git_clone_repo)
> - [VS Code](https://code.visualstudio.com/) أو [VS Code Insiders](https://code.visualstudio.com/insiders/) (مطلوب لأداة open_in_vscode)
> - (*اختياري - إذا كنت تفضل uv*) [uv](https://github.com/astral-sh/uv)
> - [امتداد مصحح أخطاء Python](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## إعداد البيئة

هناك طريقتان لإعداد البيئة لهذا المشروع. يمكنك اختيار أي منهما بناءً على تفضيلك.

> ملاحظة: أعد تحميل VSCode أو الطرفية لضمان استخدام بايثون من البيئة الافتراضية بعد إنشائها.

| الطريقة | الخطوات |
| -------- | ----- |
| باستخدام `uv` | 1. أنشئ البيئة الافتراضية: `uv venv` <br>2. نفذ أمر VSCode "***Python: Select Interpreter***" واختر بايثون من البيئة الافتراضية التي أنشأتها <br>3. ثبت التبعيات (بما في ذلك تبعيات التطوير): `uv pip install -r pyproject.toml --extra dev` |
| باستخدام `pip` | 1. أنشئ البيئة الافتراضية: `python -m venv .venv` <br>2. نفذ أمر VSCode "***Python: Select Interpreter***" واختر بايثون من البيئة الافتراضية التي أنشأتها<br>3. ثبت التبعيات (بما في ذلك تبعيات التطوير): `pip install -e .[dev]` |

بعد إعداد البيئة، يمكنك تشغيل الخادم على جهاز التطوير المحلي باستخدام منشئ الوكيل كعميل MCP للبدء:
1. افتح لوحة تصحيح الأخطاء في VS Code. اختر `Debug in Agent Builder` أو اضغط `F5` لبدء تصحيح خادم MCP.
2. استخدم منشئ الوكيل AI Toolkit لاختبار الخادم مع [هذا الطلب](../../../../../../../../../../../open_prompt_builder). سيتم توصيل الخادم تلقائياً بمنشئ الوكيل.
3. انقر `Run` لاختبار الخادم باستخدام الطلب.

**تهانينا**! لقد نجحت في تشغيل خادم MCP للطقس على جهاز التطوير المحلي باستخدام منشئ الوكيل كعميل MCP.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## ما يتضمنه القالب

| المجلد / الملف | المحتويات                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | ملفات VSCode لتصحيح الأخطاء                   |
| `.aitk`      | إعدادات AI Toolkit                |
| `src`        | الشيفرة المصدرية لخادم MCP للطقس   |

## كيفية تصحيح خادم MCP للطقس

> ملاحظات:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) هو أداة تطوير بصرية لاختبار وتصحيح خوادم MCP.
> - جميع أوضاع التصحيح تدعم نقاط التوقف، لذا يمكنك إضافة نقاط توقف في كود تنفيذ الأداة.

## الأدوات المتاحة

### أداة الطقس
توفر أداة `get_weather` معلومات طقس وهمية لموقع محدد.

| المعامل | النوع | الوصف |
| --------- | ---- | ----------- |
| `location` | نص | الموقع المطلوب الحصول على الطقس له (مثلاً اسم المدينة، الولاية، أو الإحداثيات) |

### أداة استنساخ Git
تستنسخ أداة `git_clone_repo` مستودع git إلى مجلد محدد.

| المعامل | النوع | الوصف |
| --------- | ---- | ----------- |
| `repo_url` | نص | رابط مستودع git المراد استنساخه |
| `target_folder` | نص | مسار المجلد الذي سيتم استنساخ المستودع فيه |

تعيد الأداة كائن JSON يحتوي على:
- `success`: قيمة منطقية تدل على نجاح العملية
- `target_folder` أو `error`: مسار المستودع المستنسخ أو رسالة خطأ

### أداة فتح VS Code
تفتح أداة `open_in_vscode` مجلداً في تطبيق VS Code أو VS Code Insiders.

| المعامل | النوع | الوصف |
| --------- | ---- | ----------- |
| `folder_path` | نص | مسار المجلد الذي سيتم فتحه |
| `use_insiders` | قيمة منطقية (اختياري) | هل تستخدم VS Code Insiders بدلاً من VS Code العادي |

تعيد الأداة كائن JSON يحتوي على:
- `success`: قيمة منطقية تدل على نجاح العملية
- `message` أو `error`: رسالة تأكيد أو رسالة خطأ

## وضع التصحيح | الوصف | خطوات التصحيح |
| ---------- | ----------- | --------------- |
| منشئ الوكيل | تصحيح خادم MCP في منشئ الوكيل عبر AI Toolkit. | 1. افتح لوحة تصحيح الأخطاء في VS Code. اختر `Debug in Agent Builder` واضغط `F5` لبدء تصحيح خادم MCP.<br>2. استخدم منشئ الوكيل AI Toolkit لاختبار الخادم مع [هذا الطلب](../../../../../../../../../../../open_prompt_builder). سيتم توصيل الخادم تلقائياً بمنشئ الوكيل.<br>3. انقر `Run` لاختبار الخادم باستخدام الطلب. |
| MCP Inspector | تصحيح خادم MCP باستخدام MCP Inspector. | 1. ثبت [Node.js](https://nodejs.org/)<br> 2. أعد إعداد Inspector: `cd inspector` && `npm install` <br> 3. افتح لوحة تصحيح الأخطاء في VS Code. اختر `Debug SSE in Inspector (Edge)` أو `Debug SSE in Inspector (Chrome)`. اضغط F5 لبدء التصحيح.<br> 4. عند إطلاق MCP Inspector في المتصفح، انقر زر `Connect` لربط هذا الخادم.<br> 5. بعدها يمكنك `List Tools`، اختر أداة، أدخل المعاملات، و`Run Tool` لتصحيح كود الخادم.<br> |

## المنافذ الافتراضية والتخصيصات

| وضع التصحيح | المنافذ | التعريفات | التخصيصات | ملاحظة |
| ---------- | ----- | ------------ | -------------- |-------------- |
| منشئ الوكيل | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | عدل [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json)، [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json)، [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py)، [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) لتغيير المنافذ أعلاه. | لا شيء |
| MCP Inspector | 3001 (الخادم); 5173 و 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | عدل [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json)، [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json)، [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py)، [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) لتغيير المنافذ أعلاه.| لا شيء |

## الملاحظات

إذا كان لديك أي ملاحظات أو اقتراحات حول هذا القالب، يرجى فتح مشكلة في [مستودع AI Toolkit على GitHub](https://github.com/microsoft/vscode-ai-toolkit/issues)

**إخلاء مسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. بالنسبة للمعلومات الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسيرات خاطئة ناتجة عن استخدام هذه الترجمة.