<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "14a2dfbea55ef735660a06bd6bdfe5f3",
  "translation_date": "2025-06-13T21:31:07+00:00",
  "source_file": "09-CaseStudy/UpdateADOItemsFromYT.md",
  "language_code": "ar"
}
-->
# دراسة حالة: تحديث عناصر Azure DevOps باستخدام بيانات YouTube عبر MCP

> **تنويه:** توجد أدوات وتقارير عبر الإنترنت يمكنها أتمتة عملية تحديث عناصر Azure DevOps باستخدام بيانات من منصات مثل YouTube. السيناريو التالي مقدم كمثال توضيحي فقط لكيفية تطبيق أدوات MCP لأتمتة وتكامل المهام.

## نظرة عامة

تُظهر هذه الدراسة مثالًا على كيفية استخدام بروتوكول سياق النموذج (MCP) وأدواته لأتمتة تحديث عناصر العمل في Azure DevOps (ADO) بمعلومات مأخوذة من منصات الإنترنت مثل YouTube. السيناريو الموضح هو مجرد توضيح لقدرات هذه الأدوات الواسعة، التي يمكن تكييفها لتلبية العديد من احتياجات الأتمتة المماثلة.

في هذا المثال، يتابع Advocate الجلسات عبر الإنترنت باستخدام عناصر ADO، حيث يحتوي كل عنصر على رابط فيديو YouTube. من خلال الاستفادة من أدوات MCP، يمكن لـ Advocate تحديث عناصر ADO ببيانات الفيديو الحديثة مثل عدد المشاهدات بطريقة متكررة وآلية. يمكن تعميم هذا النهج على حالات أخرى تتطلب دمج معلومات من مصادر الإنترنت في ADO أو أنظمة أخرى.

## السيناريو

يتولى Advocate مسؤولية متابعة تأثير الجلسات عبر الإنترنت وتفاعل المجتمع. يتم تسجيل كل جلسة كعنصر عمل في مشروع 'DevRel' داخل ADO، ويحتوي عنصر العمل على حقل لرابط فيديو YouTube. لتقديم تقرير دقيق عن مدى وصول الجلسة، يحتاج Advocate إلى تحديث عنصر ADO بعدد المشاهدات الحالي للفيديو وتاريخ استرجاع هذه المعلومات.

## الأدوات المستخدمة

- [Azure DevOps MCP](https://github.com/microsoft/azure-devops-mcp): يتيح الوصول البرمجي وتحديث عناصر عمل ADO عبر MCP.
- [Playwright MCP](https://github.com/microsoft/playwright-mcp): يقوم بأتمتة إجراءات المتصفح لاستخلاص البيانات الحية من صفحات الويب، مثل إحصائيات فيديو YouTube.

## سير العمل خطوة بخطوة

1. **تحديد عنصر ADO**: بدءًا من معرف عنصر العمل في ADO (مثل 1234) في مشروع 'DevRel'.
2. **استرجاع رابط YouTube**: استخدام أداة Azure DevOps MCP للحصول على رابط YouTube من عنصر العمل.
3. **استخلاص عدد المشاهدات**: استخدام أداة Playwright MCP للانتقال إلى رابط YouTube واستخلاص عدد المشاهدات الحالي.
4. **تحديث عنصر ADO**: كتابة عدد المشاهدات الأخير وتاريخ الاسترجاع في قسم 'التأثير والتعلم' داخل عنصر العمل في ADO باستخدام أداة Azure DevOps MCP.

## مثال على الطلب

```bash
- Work with the ADO Item ID: 1234
- The project is '2025-Awesome'
- Get the YouTube URL for the ADO item
- Use Playwright to get the current views from the YouTube video
- Update the ADO item with the current video views and the updated date of the information
```

## مخطط تدفق Mermaid

```mermaid
flowchart TD
    A[Start: Advocate identifies ADO Item ID] --> B[Get YouTube URL from ADO Item using Azure DevOps MCP]
    B --> C[Extract current video views using Playwright MCP]
    C --> D[Update ADO Item's Impact and Learnings section with view count and date]
    D --> E[End]
```

## التنفيذ التقني

- **تنسيق MCP**: يتم تنسيق سير العمل بواسطة خادم MCP، الذي ينسق استخدام كل من أدوات Azure DevOps MCP و Playwright MCP.
- **الأتمتة**: يمكن تشغيل العملية يدويًا أو جدولتها لتعمل بشكل دوري للحفاظ على تحديث عناصر ADO.
- **القابلية للتوسع**: يمكن توسيع نفس النمط لتحديث عناصر ADO بمقاييس أخرى من الإنترنت (مثل الإعجابات، التعليقات) أو من منصات أخرى.

## النتائج والتأثير

- **الكفاءة**: يقلل الجهد اليدوي على Advocates عبر أتمتة استرجاع وتحديث بيانات الفيديو.
- **الدقة**: يضمن أن تعكس عناصر ADO أحدث البيانات المتوفرة من المصادر عبر الإنترنت.
- **القابلية لإعادة الاستخدام**: يوفر سير عمل قابل لإعادة الاستخدام لسيناريوهات مماثلة تشمل مصادر بيانات أو مقاييس أخرى.

## المراجع

- [Azure DevOps MCP](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP](https://github.com/microsoft/playwright-mcp)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**تنويه**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الرسمي والمعتمد. للمعلومات الحساسة، يُنصح بالترجمة الاحترافية البشرية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.