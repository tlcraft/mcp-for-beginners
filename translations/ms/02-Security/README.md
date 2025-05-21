<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:18:45+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "ms"
}
-->
# Security Best Practices

اعتماد بروتوكول Model Context Protocol (MCP) يضيف قدرات قوية لتطبيقات الذكاء الاصطناعي، لكنه يجلب معه تحديات أمنية فريدة تتجاوز المخاطر البرمجية التقليدية. بالإضافة إلى المخاوف المعروفة مثل الترميز الآمن، مبدأ أقل الامتيازات، وأمن سلسلة التوريد، يواجه MCP وأعباء العمل الخاصة بالذكاء الاصطناعي تهديدات جديدة مثل حقن التعليمات (prompt injection)، تسميم الأدوات، والتعديل الديناميكي للأدوات. هذه المخاطر قد تؤدي إلى تسرب البيانات، انتهاكات الخصوصية، وسلوك غير مقصود للنظام إذا لم تُدار بشكل صحيح.

تتناول هذه الدرس أهم المخاطر الأمنية المرتبطة بـ MCP — بما في ذلك التوثيق، التفويض، الصلاحيات الزائدة، حقن التعليمات غير المباشر، وثغرات سلسلة التوريد — وتقدم ضوابط عملية وممارسات مثلى للتخفيف منها. ستتعلم أيضًا كيفية الاستفادة من حلول Microsoft مثل Prompt Shields، Azure Content Safety، وGitHub Advanced Security لتعزيز تنفيذ MCP الخاص بك. بفهم وتطبيق هذه الضوابط، يمكنك تقليل احتمال حدوث اختراق أمني وضمان بقاء أنظمة الذكاء الاصطناعي قوية وموثوقة.

# Learning Objectives

بحلول نهاية هذا الدرس، ستكون قادرًا على:

- تحديد وشرح المخاطر الأمنية الفريدة التي يطرحها بروتوكول Model Context Protocol (MCP)، بما في ذلك حقن التعليمات، تسميم الأدوات، الصلاحيات الزائدة، وثغرات سلسلة التوريد.
- وصف وتطبيق ضوابط تخفيف فعالة لمخاطر أمان MCP، مثل التوثيق القوي، مبدأ أقل الامتيازات، إدارة الرموز الآمنة، والتحقق من سلسلة التوريد.
- فهم والاستفادة من حلول Microsoft مثل Prompt Shields، Azure Content Safety، وGitHub Advanced Security لحماية MCP وأعباء العمل الخاصة بالذكاء الاصطناعي.
- إدراك أهمية التحقق من بيانات تعريف الأدوات، مراقبة التغييرات الديناميكية، والدفاع ضد هجمات حقن التعليمات غير المباشر.
- دمج ممارسات الأمان المعروفة — مثل الترميز الآمن، تقوية الخوادم، وهندسة الثقة الصفرية — في تنفيذ MCP الخاص بك لتقليل احتمالية وتأثير الاختراقات الأمنية.

# MCP security controls

أي نظام لديه وصول إلى موارد مهمة يواجه تحديات أمنية ضمنية. يمكن التعامل مع هذه التحديات عادةً من خلال التطبيق الصحيح لمفاهيم وضوابط الأمان الأساسية. بما أن MCP جديد التعريف نسبيًا، فإن المواصفات تتغير بسرعة مع تطور البروتوكول. مع مرور الوقت، ستنضج ضوابط الأمان داخله، مما يمكّن من تكامل أفضل مع البنى الأمنية المؤسسية والممارسات المثلى المعروفة.

تشير الأبحاث المنشورة في [Microsoft Digital Defense Report](https://aka.ms/mddr) إلى أن 98% من الاختراقات المبلغ عنها يمكن منعها من خلال ممارسات أمان قوية، وأفضل حماية ضد أي نوع من الاختراق هي تحقيق أساس قوي لممارسات الأمان الأساسية، الترميز الآمن، وأمن سلسلة التوريد — هذه الممارسات المجربة والمختبرة لا تزال تحقق أكبر تأثير في تقليل المخاطر الأمنية.

لنلق نظرة على بعض الطرق التي يمكنك من خلالها البدء في معالجة المخاطر الأمنية عند تبني MCP.

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** المعلومات التالية صحيحة حتى 26 أبريل 2025. بروتوكول MCP في تطور مستمر، وقد تقدم الإصدارات المستقبلية أنماط وضوابط توثيق جديدة. للحصول على آخر التحديثات والإرشادات، راجع دائمًا [MCP Specification](https://spec.modelcontextprotocol.io/) ومستودع [MCP GitHub الرسمي](https://github.com/modelcontextprotocol).

### Problem statement  
كانت المواصفة الأصلية لـ MCP تفترض أن المطورين سيكتبون خادم التوثيق الخاص بهم. هذا يتطلب معرفة بـ OAuth والقيود الأمنية ذات الصلة. كانت خوادم MCP تعمل كخوادم تفويض OAuth 2.0، تدير توثيق المستخدم مباشرة بدلاً من تفويضه إلى خدمة خارجية مثل Microsoft Entra ID. اعتبارًا من 26 أبريل 2025، يسمح تحديث للمواصفة لخوادم MCP بتفويض توثيق المستخدم إلى خدمة خارجية.

### Risks  
- تكوين خاطئ لمنطق التفويض في خادم MCP قد يؤدي إلى كشف بيانات حساسة وتطبيق خاطئ لضوابط الوصول.
- سرقة رموز OAuth على خادم MCP المحلي. إذا تم سرقتها، يمكن استخدام الرمز لانتحال هوية خادم MCP والوصول إلى الموارد والبيانات الخاصة بالخدمة التي تخص رمز OAuth.

### Mitigating controls  
- **مراجعة وتقوية منطق التفويض:** قم بتدقيق تنفيذ التفويض في خادم MCP الخاص بك بدقة لضمان وصول المستخدمين والعملاء المقصودين فقط إلى الموارد الحساسة. للحصول على إرشادات عملية، راجع [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) و [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **فرض ممارسات آمنة لإدارة الرموز:** اتبع [أفضل ممارسات Microsoft للتحقق من صحة الرموز وفترة صلاحيتها](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) لمنع سوء استخدام رموز الوصول وتقليل مخاطر إعادة تشغيل أو سرقة الرموز.
- **حماية تخزين الرموز:** قم دائمًا بتخزين الرموز بأمان واستخدم التشفير لحمايتها أثناء التخزين والنقل. للحصول على نصائح تنفيذية، راجع [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
قد يكون لخوادم MCP صلاحيات زائدة على الخدمة أو المورد الذي تصل إليه. على سبيل المثال، يجب أن يكون لخادم MCP في تطبيق مبيعات يعتمد على الذكاء الاصطناعي وصول محدود إلى بيانات المبيعات فقط وليس جميع الملفات في المخزن. بالعودة إلى مبدأ أقل الامتيازات (أحد أقدم مبادئ الأمان)، لا ينبغي لأي مورد أن يمتلك صلاحيات تتجاوز ما هو ضروري لأداء المهام المخصصة له. يقدم الذكاء الاصطناعي تحديًا إضافيًا هنا لأنه من الصعب تحديد الصلاحيات الدقيقة المطلوبة لتمكين المرونة.

### Risks  
- منح صلاحيات زائدة قد يسمح بتسريب أو تعديل بيانات لم يكن من المفترض أن يصل إليها خادم MCP. قد يكون هذا أيضًا مشكلة خصوصية إذا كانت البيانات تحتوي على معلومات تعريف شخصية (PII).

### Mitigating controls  
- **تطبيق مبدأ أقل الامتيازات:** امنح خادم MCP الحد الأدنى فقط من الصلاحيات اللازمة لأداء مهامه المطلوبة. راجع وحدث هذه الصلاحيات بانتظام لضمان عدم تجاوزها لما هو ضروري. للمزيد من الإرشادات، راجع [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **استخدام التحكم في الوصول القائم على الأدوار (RBAC):** قم بتعيين أدوار لخادم MCP تكون محددة بدقة للموارد والإجراءات المطلوبة، مع تجنب الصلاحيات الواسعة أو غير الضرورية.
- **مراقبة وتدقيق الصلاحيات:** راقب استخدام الصلاحيات باستمرار وراجع سجلات الوصول لاكتشاف ومعالجة الصلاحيات الزائدة أو غير المستخدمة بسرعة.

# Indirect prompt injection attacks

### Problem statement

يمكن لخوادم MCP الخبيثة أو المخترقة أن تسبب مخاطر كبيرة من خلال كشف بيانات العملاء أو تمكين إجراءات غير مقصودة. هذه المخاطر ذات صلة خاصة في أعباء العمل المعتمدة على الذكاء الاصطناعي وMCP، حيث:

- **هجمات حقن التعليمات (Prompt Injection Attacks):** يقوم المهاجمون بإدخال تعليمات خبيثة ضمن التعليمات أو المحتوى الخارجي، مما يجعل نظام الذكاء الاصطناعي ينفذ إجراءات غير مقصودة أو يكشف بيانات حساسة. للمزيد: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **تسميم الأدوات (Tool Poisoning):** يقوم المهاجمون بالتلاعب ببيانات تعريف الأدوات (مثل الأوصاف أو المعلمات) للتأثير على سلوك الذكاء الاصطناعي، مما قد يتجاوز الضوابط الأمنية أو يؤدي إلى تسرب البيانات. التفاصيل: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **حقن التعليمات عبر المجالات (Cross-Domain Prompt Injection):** يتم تضمين تعليمات خبيثة في مستندات أو صفحات ويب أو رسائل بريد إلكتروني، ثم يتم معالجتها من قبل الذكاء الاصطناعي، مما يؤدي إلى تسرب أو تلاعب بالبيانات.
- **التعديل الديناميكي للأدوات (Rug Pulls):** يمكن تغيير تعريفات الأدوات بعد موافقة المستخدم، مما يضيف سلوكيات خبيثة جديدة دون علم المستخدم.

تسلط هذه الثغرات الضوء على الحاجة إلى تحقق صارم، مراقبة، وضوابط أمنية عند دمج خوادم وأدوات MCP في بيئتك. للمزيد من التفاصيل، راجع الروابط المشار إليها أعلاه.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.ms.png)

**حقن التعليمات غير المباشر** (المعروف أيضًا باسم حقن التعليمات عبر المجالات أو XPIA) هو ثغرة حرجة في أنظمة الذكاء الاصطناعي التوليدية، بما في ذلك تلك التي تستخدم Model Context Protocol (MCP). في هذا الهجوم، يتم إخفاء تعليمات خبيثة داخل محتوى خارجي — مثل مستندات، صفحات ويب، أو رسائل بريد إلكتروني. عندما يعالج نظام الذكاء الاصطناعي هذا المحتوى، قد يفسر التعليمات المضمنة كأوامر شرعية من المستخدم، مما يؤدي إلى إجراءات غير مقصودة مثل تسرب البيانات، إنشاء محتوى ضار، أو التلاعب بتفاعلات المستخدم. لمزيد من الشرح والأمثلة الواقعية، راجع [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

شكل خطير بشكل خاص من هذا الهجوم هو **تسميم الأدوات**. هنا، يقوم المهاجمون بحقن تعليمات خبيثة في بيانات تعريف أدوات MCP (مثل أوصاف الأدوات أو معلماتها). وبما أن نماذج اللغة الكبيرة (LLMs) تعتمد على هذه البيانات لتحديد الأدوات التي يجب استدعاؤها، فإن الأوصاف المخترقة قد تخدع النموذج لتنفيذ استدعاءات أدوات غير مصرح بها أو تجاوز الضوابط الأمنية. غالبًا ما تكون هذه التلاعبات غير مرئية للمستخدمين النهائيين لكنها يمكن تفسيرها والتنفيذ من قبل نظام الذكاء الاصطناعي. يزداد هذا الخطر في بيئات خوادم MCP المستضافة، حيث يمكن تحديث تعريفات الأدوات بعد موافقة المستخدم — وهو سيناريو يُعرف أحيانًا باسم "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". في هذه الحالات، قد يتم تعديل أداة كانت آمنة سابقًا لتنفيذ أفعال خبيثة مثل تسريب البيانات أو تغيير سلوك النظام دون علم المستخدم. للمزيد حول هذا النوع من الهجمات، راجع [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.ms.png)

## Risks  
الإجراءات غير المقصودة للذكاء الاصطناعي تطرح مجموعة من المخاطر الأمنية التي تشمل تسرب البيانات وانتهاكات الخصوصية.

### Mitigating controls  
### Using prompt shields to protect against Indirect Prompt Injection attacks  
-----------------------------------------------------------------------------

**AI Prompt Shields** هي حل طورته Microsoft للدفاع ضد هجمات حقن التعليمات المباشرة وغير المباشرة. تساعد من خلال:

1.  **الكشف والتصفية:** تستخدم Prompt Shields خوارزميات تعلم آلي متقدمة ومعالجة لغة طبيعية للكشف عن التعليمات الخبيثة المضمنة في المحتوى الخارجي مثل المستندات وصفحات الويب والبريد الإلكتروني وتصفيتها.
    
2.  **التسليط الضوئي (Spotlighting):** تساعد هذه التقنية نظام الذكاء الاصطناعي على التمييز بين التعليمات النظامية الصحيحة والمدخلات الخارجية التي قد لا تكون موثوقة. من خلال تحويل نص الإدخال بطريقة تجعله أكثر ملاءمة للنموذج، يضمن Spotlighting أن يتعرف الذكاء الاصطناعي على التعليمات الخبيثة ويتجاهلها.
    
3.  **الفواصل والتمييز بالبيانات (Delimiters and Datamarking):** تضمين فواصل في رسالة النظام يوضح صراحة موقع نص الإدخال، مما يساعد نظام الذكاء الاصطناعي على التعرف على مدخلات المستخدم وفصلها عن المحتوى الخارجي الضار المحتمل. يوسع التمييز بالبيانات هذا المفهوم باستخدام علامات خاصة لتحديد حدود البيانات الموثوقة وغير الموثوقة.
    
4.  **المراقبة والتحديث المستمر:** تراقب Microsoft Prompt Shields باستمرار وتحدثها لمواجهة التهديدات الجديدة والمتطورة. هذا النهج الاستباقي يضمن بقاء الدفاعات فعالة ضد أحدث تقنيات الهجوم.
    
5. **التكامل مع Azure Content Safety:** تعد Prompt Shields جزءًا من مجموعة Azure AI Content Safety الأوسع، التي توفر أدوات إضافية للكشف عن محاولات الاختراق، المحتوى الضار، ومخاطر الأمان الأخرى في تطبيقات الذكاء الاصطناعي.

يمكنك قراءة المزيد عن AI prompt shields في [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.ms.png)

### Supply chain security

يظل أمن سلسلة التوريد أمرًا أساسيًا في عصر الذكاء الاصطناعي، لكن نطاق ما يُعتبر سلسلة التوريد قد توسع. بالإضافة إلى حزم الكود التقليدية، يجب الآن التحقق بدقة ومراقبة جميع المكونات المتعلقة بالذكاء الاصطناعي، بما في ذلك النماذج الأساسية، خدمات التضمين (embeddings)، مزودي السياق، وواجهات برمجة التطبيقات الخارجية. كل منها قد يضيف نقاط ضعف أو مخاطر إذا لم يُدار بشكل صحيح.

**الممارسات الأساسية لأمن سلسلة التوريد في AI وMCP:**
- **التحقق من جميع المكونات قبل الدمج:** يشمل ذلك ليس فقط المكتبات مفتوحة المصدر، بل أيضًا نماذج الذكاء الاصطناعي، مصادر البيانات، وواجهات برمجة التطبيقات الخارجية. تحقق دائمًا من الأصل، الترخيص، والثغرات المعروفة.
- **الحفاظ على خطوط نشر آمنة:** استخدم خطوط CI/CD مؤتمتة مع فحص أمني مدمج لاكتشاف المشكلات مبكرًا. تأكد من نشر القطع الموثوقة فقط في بيئة الإنتاج.
- **المراقبة والتدقيق المستمر:** نفذ مراقبة مستمرة لجميع التبعيات، بما في ذلك النماذج وخدمات البيانات، لاكتشاف الثغرات أو هجمات سلسلة التوريد الجديدة.
- **تطبيق مبدأ أقل الامتيازات وضوابط الوصول:** قيد الوصول إلى النماذج، البيانات، والخدمات فقط لما هو ضروري لعمل خادم MCP.
- **الاستجابة السريعة للتهديدات:** ضع عملية لتصحيح أو استبدال المكونات المخترقة، ولتدوير الأسرار أو بيانات الاعتماد إذا تم اكتشاف اختراق.

يوفر [GitHub Advanced Security](https://github.com/security/advanced-security) ميزات مثل فحص الأسرار، فحص التبعيات، وتحليل CodeQL. تتكامل هذه الأدوات مع [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) و[Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) لمساعدة الفرق على تحديد وتخفيف الثغرات عبر كود المصدر ومكونات سلسلة التوريد الخاصة بالذكاء الاصطناعي.

تطبق Microsoft أيضًا ممارسات أمنية واسعة لسلسلة التوريد داخليًا لجميع منتجاتها. تعرف على المزيد في [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Established security best practices that will uplift your MCP implementation's security posture

أي تنفيذ لـ MCP يرث الوضع الأمني الحالي لبيئة مؤسستك التي بُني عليها، لذا عند النظر في أمان MCP كجزء من أنظمة الذكاء الاصطناعي الشاملة، يُنصح برفع مستوى الوضع الأمني الحالي. الضوابط الأمنية المعروفة التالية ذات صلة خاصة:

- ممارسات الترميز الآمن في تطبيق الذكاء الاصطناعي الخاص بك — الحماية من [OWASP Top 10](https://owasp.org/www-project-top-ten/)، و[OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)، استخدام خزائن آمنة للأسرار والرموز، تنفيذ اتصالات آمنة شاملة بين جميع مكونات التطبيق، إلخ.
- تقوية الخوادم — استخدام المصادقة متعددة العوامل حيثما أمكن، الحفاظ على تحديث التصحيحات، دمج الخادم مع مزود هوية خارجي للوصول، إلخ.
- تحديث الأجهزة، البنية التحتية، والتطبيقات باستمرار.
- مراقبة الأمان — تنفيذ تسجيل ومراقبة لتطبيق الذكاء الاصطناعي (بما في ذلك عملاء وخوادم MCP) وإرسال هذه السجلات إلى نظام SIEM مركزي لاكتشاف الأنشطة غير الاعتيادية.
- هندسة الثقة الصفرية — عزل المكونات عبر ضوابط الشبكة والهوية بطريقة منطقية لتقليل الحركة الجانبية في حال تم اختراق تطبيق الذكاء الاصطناعي.

# Key Takeaways

- أساسيات الأمان تظل حاسمة: الترميز الآمن، مبدأ أقل الامتيازات، التحقق من سلسلة التوريد، والمراق
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Next

Next: [Chapter 3: Getting Started](/03-GettingStarted/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.