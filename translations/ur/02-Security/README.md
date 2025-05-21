<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T22:53:12+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "ur"
}
-->
# بہترین حفاظتی طریقے

Model Context Protocol (MCP) کو اپنانا AI سے چلنے والی ایپلیکیشنز میں طاقتور نئی صلاحیتیں لاتا ہے، لیکن یہ روایتی سافٹ ویئر کے خطرات سے آگے بڑھ کر منفرد حفاظتی چیلنجز بھی پیش کرتا ہے۔ محفوظ کوڈنگ، کم از کم مراعات، اور سپلائی چین سیکیورٹی جیسے قائم شدہ تحفظات کے علاوہ، MCP اور AI کے کاموں کو نئے خطرات کا سامنا ہے جیسے prompt injection، tool poisoning، اور dynamic tool modification۔ اگر ان خطرات کو صحیح طریقے سے منظم نہ کیا جائے تو یہ ڈیٹا کی چوری، پرائیویسی کی خلاف ورزی، اور غیر متوقع نظامی رویے کا باعث بن سکتے ہیں۔

یہ سبق MCP سے متعلق سب سے اہم حفاظتی خطرات کو بیان کرتا ہے — بشمول authentication، authorization، ضرورت سے زیادہ permissions، بالواسطہ prompt injection، اور سپلائی چین کی کمزوریوں — اور انہیں کم کرنے کے لیے قابل عمل کنٹرولز اور بہترین طریقے فراہم کرتا ہے۔ آپ سیکھیں گے کہ Microsoft کے حل جیسے Prompt Shields، Azure Content Safety، اور GitHub Advanced Security کو کیسے استعمال کیا جائے تاکہ آپ کی MCP کی عملدرآمد مضبوط ہو۔ ان کنٹرولز کو سمجھ کر اور اپنانے سے آپ حفاظتی خلاف ورزی کے امکانات کو نمایاں طور پر کم کر سکتے ہیں اور اپنے AI نظاموں کو قابل اعتماد اور مضبوط بنا سکتے ہیں۔

# سیکھنے کے مقاصد

اس سبق کے آخر تک، آپ کر سکیں گے:

- Model Context Protocol (MCP) کی وجہ سے پیدا ہونے والے منفرد حفاظتی خطرات کی شناخت اور وضاحت کرنا، جن میں prompt injection، tool poisoning، ضرورت سے زیادہ permissions، اور سپلائی چین کی کمزوریاں شامل ہیں۔
- MCP کے حفاظتی خطرات کے لیے موثر کنٹرولز کو بیان اور لاگو کرنا، جیسے مضبوط authentication، کم از کم مراعات، محفوظ token مینجمنٹ، اور سپلائی چین کی تصدیق۔
- Microsoft کے حل جیسے Prompt Shields، Azure Content Safety، اور GitHub Advanced Security کو سمجھنا اور استعمال کرنا تاکہ MCP اور AI کے کاموں کی حفاظت کی جا سکے۔
- ٹول میٹا ڈیٹا کی تصدیق، dynamic تبدیلیوں کی نگرانی، اور بالواسطہ prompt injection حملوں کے خلاف دفاع کی اہمیت کو پہچاننا۔
- محفوظ کوڈنگ، سرور کی سختی، اور zero trust architecture جیسے قائم شدہ حفاظتی بہترین طریقوں کو MCP کی عملدرآمد میں شامل کرنا تاکہ حفاظتی خلاف ورزیوں کے امکانات اور اثرات کو کم کیا جا سکے۔

# MCP حفاظتی کنٹرولز

کوئی بھی نظام جسے اہم وسائل تک رسائی حاصل ہو، اس کے ساتھ حفاظتی چیلنجز بھی ہوتے ہیں۔ عام طور پر حفاظتی چیلنجز کو بنیادی حفاظتی کنٹرولز اور تصورات کے درست اطلاق سے حل کیا جا سکتا ہے۔ چونکہ MCP ابھی نیا متعین کیا گیا ہے، اس لیے اس کی وضاحت تیزی سے بدل رہی ہے اور پروٹوکول کے ارتقاء کے ساتھ۔ بالآخر اس میں شامل حفاظتی کنٹرولز پختہ ہو جائیں گے، جو ادارہ جاتی اور قائم شدہ حفاظتی معماروں اور بہترین طریقوں کے ساتھ بہتر انضمام کی اجازت دیں گے۔

[Microsoft Digital Defense Report](https://aka.ms/mddr) میں شائع شدہ تحقیق کے مطابق، رپورٹ شدہ خلاف ورزیوں میں سے 98% کو مضبوط حفاظتی عادات سے روکا جا سکتا ہے، اور کسی بھی قسم کی خلاف ورزی کے خلاف بہترین حفاظت یہ ہے کہ آپ اپنی بنیادی حفاظتی عادات، محفوظ کوڈنگ کے بہترین طریقے، اور سپلائی چین سیکیورٹی کو درست رکھیں — وہ آزمائے ہوئے طریقے جو ہم پہلے سے جانتے ہیں، حفاظتی خطرے کو کم کرنے میں سب سے زیادہ مؤثر ہیں۔

آئیے دیکھتے ہیں کہ MCP اپنانے کے دوران حفاظتی خطرات کو حل کرنے کے لیے آپ کن طریقوں سے آغاز کر سکتے ہیں۔

# MCP سرور کی تصدیق (اگر آپ کی MCP عملدرآمد 26 اپریل 2025 سے پہلے تھی)

> **Note:** درج ذیل معلومات 26 اپریل 2025 تک درست ہیں۔ MCP پروٹوکول مسلسل ترقی کر رہا ہے، اور مستقبل کی عملدرآمد میں نئے authentication پیٹرنز اور کنٹرولز متعارف ہو سکتے ہیں۔ تازہ ترین اپ ڈیٹس اور رہنمائی کے لیے ہمیشہ [MCP Specification](https://spec.modelcontextprotocol.io/) اور سرکاری [MCP GitHub repository](https://github.com/modelcontextprotocol) کو دیکھیں۔

### مسئلے کا بیان  
اصل MCP وضاحت میں یہ فرض کیا گیا تھا کہ ڈویلپرز اپنی authentication سرور خود لکھیں گے۔ اس کے لیے OAuth اور متعلقہ حفاظتی پابندیوں کا علم ضروری تھا۔ MCP سرورز OAuth 2.0 Authorization Servers کے طور پر کام کرتے تھے، جو صارف کی authentication کو براہ راست سنبھالتے تھے بجائے اس کے کہ اسے Microsoft Entra ID جیسے بیرونی سروس کو سپرد کیا جائے۔ 26 اپریل 2025 کے بعد MCP وضاحت میں اپ ڈیٹ آئی ہے جس کے تحت MCP سرورز صارف کی authentication کو بیرونی سروس کو سپرد کر سکتے ہیں۔

### خطرات  
- MCP سرور میں authorization لاجک کی غلط ترتیب حساس ڈیٹا کے انکشاف اور غلط طریقے سے نافذ کردہ رسائی کنٹرولز کا باعث بن سکتی ہے۔  
- مقامی MCP سرور پر OAuth ٹوکن کی چوری۔ اگر ٹوکن چوری ہو جائے تو اسے MCP سرور کی نقل کرنے اور متعلقہ سروس کے وسائل اور ڈیٹا تک رسائی کے لیے استعمال کیا جا سکتا ہے۔

### حفاظتی کنٹرولز  
- **Authorization Logic کا جائزہ اور سختی:** اپنے MCP سرور کی authorization عملدرآمد کا بغور آڈٹ کریں تاکہ صرف مطلوبہ صارفین اور کلائنٹس حساس وسائل تک رسائی حاصل کر سکیں۔ عملی رہنمائی کے لیے دیکھیں [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) اور [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).  
- **محفوظ ٹوکن کے طریقے نافذ کریں:** [Microsoft کی ٹوکن کی تصدیق اور لائف ٹائم کے بہترین طریقے](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) پر عمل کریں تاکہ رسائی ٹوکن کے غلط استعمال اور ٹوکن کی دوبارہ چوری کا خطرہ کم کیا جا سکے۔  
- **ٹوکن اسٹوریج کی حفاظت کریں:** ہمیشہ ٹوکنز کو محفوظ طریقے سے ذخیرہ کریں اور انہیں سیکیورٹی کے لیے انکرپشن کا استعمال کریں، چاہے وہ ذخیرہ میں ہوں یا منتقلی کے دوران۔ عملدرآمد کے نکات کے لیے دیکھیں [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# MCP سرورز کے لیے ضرورت سے زیادہ permissions

### مسئلے کا بیان  
MCP سرورز کو جس سروس یا وسائل تک رسائی حاصل ہے، ان کے لیے ضرورت سے زیادہ permissions دی گئی ہو سکتی ہیں۔ مثال کے طور پر، ایک AI سیلز ایپلیکیشن کا MCP سرور جو ادارہ جاتی ڈیٹا اسٹور سے جڑتا ہے، اسے صرف سیلز ڈیٹا تک رسائی ہونی چاہیے، نہ کہ اسٹور کی تمام فائلوں تک۔ کم از کم مراعات کے اصول کی طرف رجوع کریں (جو سب سے پرانا حفاظتی اصول ہے)، کوئی بھی وسیلہ ایسی permissions نہیں رکھنی چاہیے جو اس کے کام انجام دینے کے لیے ضروری سے زیادہ ہوں۔ AI میں یہ چیلنج زیادہ ہوتا ہے کیونکہ اسے لچکدار بنانے کے لیے ضروری permissions کی صحیح تعریف مشکل ہو سکتی ہے۔

### خطرات  
- ضرورت سے زیادہ permissions دینے سے MCP سرور غیر مجاز ڈیٹا نکال سکتا ہے یا ترمیم کر سکتا ہے۔ اگر ڈیٹا ذاتی شناختی معلومات (PII) ہو تو یہ پرائیویسی کا مسئلہ بھی بن سکتا ہے۔

### حفاظتی کنٹرولز  
- **کم از کم مراعات کا اصول اپنائیں:** MCP سرور کو صرف وہی permissions دیں جو اس کے کام کے لیے بالکل ضروری ہوں۔ ان permissions کا باقاعدہ جائزہ لیں اور اپ ڈیٹ کریں تاکہ وہ ضرورت سے زیادہ نہ ہوں۔ تفصیلی رہنمائی کے لیے دیکھیں [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).  
- **Role-Based Access Control (RBAC) استعمال کریں:** MCP سرور کو مخصوص وسائل اور کارروائیوں کے لیے محدود کردہ رولز تفویض کریں، وسیع یا غیر ضروری permissions سے گریز کریں۔  
- **Permissions کی نگرانی اور آڈٹ کریں:** permissions کے استعمال کی مسلسل نگرانی کریں اور رسائی کے لاگز کا آڈٹ کریں تاکہ ضرورت سے زیادہ یا غیر استعمال شدہ مراعات کو فوری طور پر دور کیا جا سکے۔

# بالواسطہ prompt injection حملے

### مسئلے کا بیان

خراب یا متاثرہ MCP سرورز اہم خطرات پیدا کر سکتے ہیں، جیسے صارف کے ڈیٹا کا انکشاف یا غیر متوقع کارروائیوں کا امکان۔ یہ خطرات خاص طور پر AI اور MCP پر مبنی کاموں میں اہم ہیں، جہاں:

- **Prompt Injection Attacks:** حملہ آور prompts یا بیرونی مواد میں خراب ہدایات شامل کرتے ہیں، جس سے AI نظام غیر مطلوبہ کارروائیاں کرتا ہے یا حساس ڈیٹا لیک کر دیتا ہے۔ مزید جانیں: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)  
- **Tool Poisoning:** حملہ آور ٹول کے میٹا ڈیٹا (جیسے وضاحتیں یا پیرامیٹرز) کو تبدیل کرتے ہیں تاکہ AI کے رویے کو متاثر کیا جا سکے، ممکنہ طور پر حفاظتی کنٹرولز کو بائی پاس کر کے یا ڈیٹا چوری کر کے۔ تفصیلات: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)  
- **Cross-Domain Prompt Injection:** خراب ہدایات دستاویزات، ویب صفحات، یا ای میلز میں چھپی ہوتی ہیں، جو AI کے ذریعے پروسیس کی جاتی ہیں، جس سے ڈیٹا لیک یا چالاکی ہوتی ہے۔  
- **Dynamic Tool Modification (Rug Pulls):** ٹول کی تعریفیں صارف کی منظوری کے بعد تبدیل کی جا سکتی ہیں، نئی خراب حرکات متعارف کراتے ہوئے، صارف کی اطلاع کے بغیر۔

یہ کمزوریاں MCP سرورز اور ٹولز کو آپ کے ماحول میں شامل کرتے وقت مضبوط تصدیق، نگرانی، اور حفاظتی کنٹرولز کی ضرورت کو اجاگر کرتی ہیں۔ مزید تفصیل کے لیے اوپر دی گئی لنکس دیکھیں۔

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.ur.png)

**بالواسطہ Prompt Injection** (جسے cross-domain prompt injection یا XPIA بھی کہا جاتا ہے) جنریٹیو AI نظاموں میں ایک سنگین کمزوری ہے، خاص طور پر وہ جو Model Context Protocol (MCP) استعمال کرتے ہیں۔ اس حملے میں، خراب ہدایات بیرونی مواد میں چھپی ہوتی ہیں — جیسے دستاویزات، ویب صفحات، یا ای میلز۔ جب AI نظام اس مواد کو پروسیس کرتا ہے، تو یہ چھپی ہوئی ہدایات کو جائز صارف کی کمانڈز سمجھ سکتا ہے، جس کے نتیجے میں غیر متوقع کارروائیاں جیسے ڈیٹا لیک، نقصان دہ مواد کی تخلیق، یا صارف کے تعاملات میں چالاکی ہو سکتی ہے۔ تفصیلی وضاحت اور حقیقی دنیا کی مثالوں کے لیے دیکھیں [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)۔

اس حملے کی ایک خاص طور پر خطرناک شکل **Tool Poisoning** ہے۔ اس میں حملہ آور MCP ٹولز کے میٹا ڈیٹا (جیسے ٹول کی وضاحتیں یا پیرامیٹرز) میں خراب ہدایات شامل کرتے ہیں۔ چونکہ بڑے زبان ماڈلز (LLMs) اس میٹا ڈیٹا پر انحصار کرتے ہیں کہ وہ کون سے ٹولز کو کال کریں، اس لیے متاثرہ وضاحتیں ماڈل کو غیر مجاز ٹول کالز کرنے یا حفاظتی کنٹرولز کو بائی پاس کرنے پر مجبور کر سکتی ہیں۔ یہ چالاکیاں اکثر صارفین سے پوشیدہ رہتی ہیں لیکن AI نظام انہیں سمجھ کر عمل کر لیتا ہے۔ یہ خطرہ خاص طور پر ہوسٹ کیے گئے MCP سرور ماحول میں بڑھ جاتا ہے، جہاں صارف کی منظوری کے بعد ٹول کی تعریفیں تبدیل کی جا سکتی ہیں — جسے بعض اوقات "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" کہا جاتا ہے۔ ایسے حالات میں، ایک پہلے محفوظ ٹول بعد میں خراب حرکات کے لیے تبدیل ہو سکتا ہے، جیسے ڈیٹا چوری یا نظامی رویے میں تبدیلی، بغیر صارف کی اطلاع کے۔ اس حملے کے بارے میں مزید جاننے کے لیے دیکھیں [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)۔

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.ur.png)

## خطرات  
غیر ارادی AI کارروائیاں مختلف حفاظتی خطرات پیش کرتی ہیں جن میں ڈیٹا چوری اور پرائیویسی کی خلاف ورزیاں شامل ہیں۔

### حفاظتی کنٹرولز  
### Indirect Prompt Injection حملوں سے بچاؤ کے لیے prompt shields کا استعمال  
-----------------------------------------------------------------------------

**AI Prompt Shields** Microsoft کی طرف سے تیار کردہ ایک حل ہے جو براہ راست اور بالواسطہ prompt injection حملوں کے خلاف دفاع فراہم کرتا ہے۔ یہ درج ذیل طریقوں سے مدد کرتے ہیں:

1.  **دیکھ بھال اور فلٹرنگ:** Prompt Shields جدید مشین لرننگ الگورتھمز اور قدرتی زبان کی پروسیسنگ استعمال کرتے ہیں تاکہ دستاویزات، ویب صفحات، یا ای میلز جیسے بیرونی مواد میں چھپی خراب ہدایات کو پہچان کر فلٹر کر سکیں۔  
2.  **Spotlighting:** یہ تکنیک AI نظام کو جائز نظام کی ہدایات اور ممکنہ غیر معتبر بیرونی ان پٹس کے درمیان فرق کرنے میں مدد دیتی ہے۔ ان پٹ متن کو اس طرح تبدیل کر کے جو ماڈل کے لیے زیادہ متعلقہ ہو، Spotlighting یقینی بناتی ہے کہ AI خراب ہدایات کو بہتر طریقے سے شناخت کر کے نظر انداز کر سکے۔  
3.  **Delimiters اور Datamarking:** سسٹم پیغام میں delimiters شامل کرنا واضح طور پر ان پٹ متن کی جگہ بتاتا ہے، جو AI نظام کو صارف کے ان پٹس اور ممکنہ نقصان دہ بیرونی مواد کو الگ کرنے میں مدد دیتا ہے۔ Datamarking اس تصور کو آگے بڑھاتا ہے خاص نشانیاں استعمال کر کے تاکہ معتبر اور غیر معتبر ڈیٹا کی حد بندی کو نمایاں کیا جا سکے۔  
4.  **مسلسل نگرانی اور اپ ڈیٹس:** Microsoft مسلسل Prompt Shields کی نگرانی اور اپ ڈیٹ کرتا ہے تاکہ نئے اور بدلتے ہوئے خطرات کا مقابلہ کیا جا سکے۔ یہ پیشگی حکمت عملی یقینی بناتی ہے کہ دفاع تازہ ترین حملوں کے طریقوں کے خلاف مؤثر رہیں۔  
5. **Azure Content Safety کے ساتھ انضمام:** Prompt Shields Azure AI Content Safety سوٹ کا حصہ ہیں، جو jailbreak کوششوں، نقصان دہ مواد، اور AI ایپلیکیشنز میں دیگر حفاظتی خطرات کی شناخت کے اضافی اوزار فراہم کرتا ہے۔

آپ AI prompt shields کے بارے میں مزید [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) میں پڑھ سکتے ہیں۔

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.ur.png)

### سپلائی چین سیکیورٹی

AI دور میں سپلائی چین سیکیورٹی بنیادی حیثیت رکھتی ہے، لیکن آپ کی سپلائی چین کی تعریف وسیع ہو گئی ہے۔ روایتی کوڈ پیکجز کے علاوہ، اب آپ کو تمام AI سے متعلقہ اجزاء، بشمول foundation models، embeddings services، context providers، اور تیسری پارٹی کے APIs کو سختی سے تصدیق اور نگرانی کرنی ہوگی۔ اگر ان کا مناسب انتظام نہ کیا جائے تو یہ کمزوریاں یا خطرات پیدا کر سکتے ہیں۔

**AI اور MCP کے لیے کلیدی سپلائی چین سیکیورٹی کے طریقے:**  
- **انضمام سے پہلے تمام اجزاء کی تصدیق کریں:** اس میں صرف اوپن سورس لائبریریز ہی نہیں بلکہ AI ماڈلز، ڈیٹا ذرائع، اور بیرونی APIs بھی شامل ہیں۔ ہمیشہ provenance، لائسنسنگ، اور معلوم کمزوریوں کی جانچ کریں۔  
- **محفوظ تعیناتی پائپ لائنز کو برقرار رکھیں:** خودکار CI/CD پائپ لائنز استعمال کریں جن میں حفاظتی اسکیننگ شامل ہو تاکہ مسائل جلد پکڑے جا سکیں۔ یقینی بنائیں کہ صرف معتبر آرٹیفیکٹس پروڈکشن میں تعینات ہوں۔  
- **مسلسل نگرانی اور آڈٹ کریں:** تمام dependencies بشمول ماڈلز اور ڈیٹا سروسز کی مسلسل نگرانی کریں تاکہ نئی کمزوریاں یا سپلائی چین حملے جلد پتہ چل سکیں۔  
- **کم از کم مراعات اور رسائی کنٹرولز لاگو کریں:** ماڈلز، ڈیٹا، اور سروسز تک رسائی کو صرف MCP سرور کی ضروریات تک محدود رکھیں۔  
- **خطرات کا فوری جواب دیں:** متاثرہ اجزاء کو پیچ کرنے یا تبدیل کرنے کے لیے عمل تیار رکھیں، اور اگر خلاف ورزی ہو تو سیکریٹس یا اسناد کو تبدیل کریں۔

[GitHub Advanced Security](https://github.com/security/advanced-security) جیسے فیچرز فراہم کرتا ہے جن میں سیکریٹ اسکیننگ، dependency اسکیننگ، اور CodeQL تجزیہ شامل ہیں۔ یہ اوزار [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) اور [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) کے ساتھ انٹیگریٹ ہوتے ہیں تاکہ ٹیموں کو کوڈ اور AI سپلائی چین کے خطرات کی شناخت اور کمی میں مدد ملے۔

Microsoft اپنے تمام مصنوعات کے لیے اندرونی طور پر بھی وسیع سپلائی چین سیکیورٹی طریقے اپناتا ہے۔ مزید جاننے کے لیے دیکھیں [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-m
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

### اگلا

اگلا: [باب 3: شروعات](/03-GettingStarted/README.md)

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جائے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ تجویز کیا جاتا ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر نہیں ہوگی۔