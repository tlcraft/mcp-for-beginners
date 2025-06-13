<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:50:02+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "ms"
}
-->
في الكود السابق قمنا بـ:

- استيراد المكتبات
- إنشاء نسخة من العميل والاتصال باستخدام stdio كوسيلة للنقل.
- سرد المطالبات، الموارد، والأدوات وتشغيلها جميعًا.

ها هو لديك، عميل يمكنه التحدث إلى خادم MCP.

دعونا نأخذ وقتنا في القسم التالي من التمرين ونفصل كل جزء من الكود ونشرح ما يحدث.

## تمرين: كتابة عميل

كما ذكرنا أعلاه، دعونا نأخذ وقتنا في شرح الكود، وبالطبع يمكنك البرمجة معنا إذا أردت.

### -1- استيراد المكتبات

دعونا نستورد المكتبات التي نحتاجها، سنحتاج إلى مراجع للعميل وللبروتوكول الذي اخترناه للنقل، stdio. stdio هو بروتوكول مخصص للأشياء التي تعمل على جهازك المحلي. SSE هو بروتوكول نقل آخر سنعرضه في الفصول القادمة لكنه خيارك الآخر. ولكن الآن، دعونا نتابع مع stdio.

دعونا ننتقل إلى التهيئة.

### -2- تهيئة العميل ووسيلة النقل

سنحتاج إلى إنشاء نسخة من وسيلة النقل ونسخة من العميل:

### -3- سرد ميزات الخادم

الآن، لدينا عميل يمكنه الاتصال إذا تم تشغيل البرنامج. ومع ذلك، فهو لا يعرض ميزاته فعليًا لذا دعونا نفعل ذلك الآن:

رائع، الآن لقد حصلنا على جميع الميزات. السؤال هو متى نستخدمها؟ حسنًا، هذا العميل بسيط جدًا، بمعنى أننا سنحتاج إلى استدعاء الميزات صراحةً عندما نريدها. في الفصل التالي، سننشئ عميلًا أكثر تقدمًا لديه وصول إلى نموذج لغوي كبير خاص به، LLM. ولكن الآن، دعونا نرى كيف يمكننا استدعاء الميزات على الخادم:

### -4- استدعاء الميزات

لاستدعاء الميزات، يجب التأكد من تحديد الوسائط الصحيحة وفي بعض الحالات اسم ما نحاول استدعاءه.

### -5- تشغيل العميل

لتشغيل العميل، اكتب الأمر التالي في الطرفية:

## الواجب

في هذا الواجب، ستستخدم ما تعلمته في إنشاء عميل ولكن عليك إنشاء عميل خاص بك.

إليك خادم يمكنك استخدامه تحتاج إلى الاتصال به عبر كود العميل الخاص بك، حاول إضافة ميزات أكثر إلى الخادم لجعله أكثر إثارة.

## الحل

[الحل](./solution/README.md)

## النقاط الرئيسية

النقاط الرئيسية لهذا الفصل حول العملاء هي:

- يمكن استخدامها لاكتشاف الميزات على الخادم واستدعائها.
- يمكنها بدء خادم أثناء بدء تشغيلها (كما في هذا الفصل) ولكن يمكن للعملاء الاتصال بالخوادم العاملة أيضًا.
- هي طريقة رائعة لاختبار قدرات الخادم إلى جانب البدائل مثل Inspector كما وُصف في الفصل السابق.

## موارد إضافية

- [بناء العملاء في MCP](https://modelcontextprotocol.io/quickstart/client)

## عينات

- [آلة حاسبة جافا](../samples/java/calculator/README.md)
- [آلة حاسبة .Net](../../../../03-GettingStarted/samples/csharp)
- [آلة حاسبة جافا سكريبت](../samples/javascript/README.md)
- [آلة حاسبة تايب سكريبت](../samples/typescript/README.md)
- [آلة حاسبة بايثون](../../../../03-GettingStarted/samples/python)

## ماذا بعد

- التالي: [إنشاء عميل مع LLM](/03-GettingStarted/03-llm-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat yang penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.