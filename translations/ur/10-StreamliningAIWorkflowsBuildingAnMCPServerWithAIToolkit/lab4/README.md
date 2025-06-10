<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f83bc722dc758efffd68667d6a1db470",
  "translation_date": "2025-06-10T06:41:30+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/README.md",
  "language_code": "ur"
}
-->
# 🐙 ماڈیول 4: عملی MCP ترقی - کسٹم GitHub کلون سرور

![Duration](https://img.shields.io/badge/Duration-30_minutes-blue?style=flat-square)  
![Difficulty](https://img.shields.io/badge/Difficulty-Intermediate-orange?style=flat-square)  
![MCP](https://img.shields.io/badge/MCP-Custom%20Server-purple?style=flat-square&logo=github)  
![VS Code](https://img.shields.io/badge/VS%20Code-Integration-blue?style=flat-square&logo=visualstudiocode)  
![GitHub Copilot](https://img.shields.io/badge/GitHub%20Copilot-Agent%20Mode-green?style=flat-square&logo=github)  

> **⚡ فوری آغاز:** صرف 30 منٹ میں ایک پروڈکشن کے قابل MCP سرور بنائیں جو GitHub ریپوزٹری کلوننگ اور VS Code انٹیگریشن کو خودکار بنائے!

## 🎯 سیکھنے کے مقاصد

اس لیب کے آخر تک، آپ کر سکیں گے:

- ✅ حقیقی دنیا کی ترقیاتی ورک فلو کے لیے کسٹم MCP سرور بنائیں  
- ✅ MCP کے ذریعے GitHub ریپوزٹری کلوننگ کی فعالیت نافذ کریں  
- ✅ کسٹم MCP سرورز کو VS Code اور Agent Builder کے ساتھ مربوط کریں  
- ✅ GitHub Copilot Agent Mode کو کسٹم MCP ٹولز کے ساتھ استعمال کریں  
- ✅ پروڈکشن ماحول میں کسٹم MCP سرورز کا ٹیسٹ اور تعینات کریں  

## 📋 ضروریات

- لیب 1-3 مکمل کرنا (MCP بنیادیات اور اعلیٰ سطح کی ترقی)  
- GitHub Copilot کی رکنیت ([مفت سائن اپ دستیاب](https://github.com/github-copilot/signup))  
- AI Toolkit اور GitHub Copilot ایکسٹینشنز کے ساتھ VS Code  
- Git CLI انسٹال اور ترتیب دیا ہوا  

## 🏗️ پروجیکٹ کا جائزہ

### **حقیقی دنیا کا ترقیاتی چیلنج**  
بطور ڈویلپر، ہم اکثر GitHub استعمال کرتے ہیں ریپوزٹریز کلون کرنے اور انہیں VS Code یا VS Code Insiders میں کھولنے کے لیے۔ یہ دستی عمل شامل ہے:  
1. ٹرمینل/کمانڈ پرامپٹ کھولنا  
2. مطلوبہ ڈائریکٹری پر جانا  
3. `git clone` کمانڈ چلانا  
4. کلون کی گئی ڈائریکٹری میں VS Code کھولنا  

**ہمارا MCP حل اسے ایک ذہین کمانڈ میں تبدیل کر دیتا ہے!**

### **جو آپ بنائیں گے**  
ایک **GitHub Clone MCP Server** (`git_mcp_server`) جو فراہم کرتا ہے:

| خصوصیت | وضاحت | فائدہ |  
|---------|-------------|---------|  
| 🔄 **ذہین ریپوزٹری کلوننگ** | GitHub ریپوز کو ویلیڈیٹ کر کے کلون کریں | خودکار ایرر چیکنگ |  
| 📁 **ذہین ڈائریکٹری مینجمنٹ** | ڈائریکٹریز کی حفاظت سے جانچ اور تخلیق | اوور رائٹنگ سے بچاؤ |  
| 🚀 **کراس-پلیٹ فارم VS Code انٹیگریشن** | پروجیکٹس کو VS Code/Insiders میں کھولیں | ورک فلو کا آسان تبادلہ |  
| 🛡️ **مضبوط ایرر ہینڈلنگ** | نیٹ ورک، اجازت اور راستے کے مسائل سنبھالنا | پروڈکشن کے قابل اعتباریت |  

---

## 📖 مرحلہ وار نفاذ

### مرحلہ 1: Agent Builder میں GitHub Agent بنائیں

1. **AI Toolkit ایکسٹینشن سے Agent Builder لانچ کریں**  
2. **نیا ایجنٹ بنائیں** درج ذیل کنفیگریشن کے ساتھ:  
   ```
   Agent Name: GitHubAgent
   ```  

3. **کسٹم MCP سرور شروع کریں:**  
   - **Tools** → **Add Tool** → **MCP Server** پر جائیں  
   - **"Create A new MCP Server"** منتخب کریں  
   - زیادہ سے زیادہ لچک کے لیے **Python template** منتخب کریں  
   - **سرور کا نام:** `git_mcp_server`  

### مرحلہ 2: GitHub Copilot Agent Mode ترتیب دیں

1. VS Code میں **GitHub Copilot کھولیں** (Ctrl/Cmd + Shift + P → "GitHub Copilot: Open")  
2. Copilot انٹرفیس میں **Agent Model منتخب کریں**  
3. بہتر استدلال کے لیے **Claude 3.7 ماڈل منتخب کریں**  
4. ٹول تک رسائی کے لیے **MCP انٹیگریشن فعال کریں**  

> **💡 پرو ٹپ:** Claude 3.7 ترقیاتی ورک فلو اور ایرر ہینڈلنگ پیٹرنز کی بہتر سمجھ فراہم کرتا ہے۔

### مرحلہ 3: MCP سرور کی بنیادی فعالیت نافذ کریں

**GitHub Copilot Agent Mode کے ساتھ درج ذیل تفصیلی پرامپٹ استعمال کریں:**  

```
Create two MCP tools with the following comprehensive requirements:

🔧 TOOL A: clone_repository
Requirements:
- Clone any GitHub repository to a specified local folder
- Return the absolute path of the successfully cloned project
- Implement comprehensive validation:
  ✓ Check if target directory already exists (return error if exists)
  ✓ Validate GitHub URL format (https://github.com/user/repo)
  ✓ Verify git command availability (prompt installation if missing)
  ✓ Handle network connectivity issues
  ✓ Provide clear error messages for all failure scenarios

🚀 TOOL B: open_in_vscode
Requirements:
- Open specified folder in VS Code or VS Code Insiders
- Cross-platform compatibility (Windows/Linux/macOS)
- Use direct application launch (not terminal commands)
- Auto-detect available VS Code installations
- Handle cases where VS Code is not installed
- Provide user-friendly error messages

Additional Requirements:
- Follow MCP 1.9.3 best practices
- Include proper type hints and documentation
- Implement logging for debugging purposes
- Add input validation for all parameters
- Include comprehensive error handling
```  

### مرحلہ 4: اپنے MCP سرور کا ٹیسٹ کریں

#### 4a. Agent Builder میں ٹیسٹ کریں

1. Agent Builder کے لیے **ڈیبگ کنفیگریشن شروع کریں**  
2. اپنے ایجنٹ کو اس سسٹم پرامپٹ کے ساتھ ترتیب دیں:  

```
SYSTEM_PROMPT:
You are my intelligent coding repository assistant. You help developers efficiently clone GitHub repositories and set up their development environment. Always provide clear feedback about operations and handle errors gracefully.
```  

3. حقیقی صارف کے منظرناموں کے ساتھ ٹیسٹ کریں:  

```
USER_PROMPT EXAMPLES:

Scenario : Basic Clone and Open
"Clone {Your GitHub Repo link such as https://github.com/kinfey/GHCAgentWorkshop
 } and save to {The global path you specify}, then open it with VS Code Insiders"
```  

![Agent Builder Testing](../../../../translated_images/DebugAgent.81d152370c503241b3b39a251b8966f7f739286df19dd57f9147f6402214a012.ur.png)  

**متوقع نتائج:**  
- ✅ راستے کی تصدیق کے ساتھ کامیاب کلوننگ  
- ✅ خودکار VS Code لانچ  
- ✅ غلط حالات کے لیے واضح ایرر پیغامات  
- ✅ ایج کیسز کا مناسب انتظام  

#### 4b. MCP Inspector میں ٹیسٹ کریں

![MCP Inspector Testing](../../../../translated_images/DebugInspector.eb5c95f94c69a8ba36944941b9a3588309a3a2fae101ace470ee09bde41d1667.ur.png)  

---

**🎉 مبارک ہو!** آپ نے ایک عملی، پروڈکشن کے قابل MCP سرور کامیابی سے بنایا ہے جو حقیقی ترقیاتی ورک فلو کے چیلنجز حل کرتا ہے۔ آپ کا کسٹم GitHub کلون سرور MCP کی طاقت کو خودکار بنانے اور ڈویلپر کی پیداواریت بڑھانے کے لیے ظاہر کرتا ہے۔

### 🏆 حاصل کردہ کامیابیاں:  
- ✅ **MCP Developer** - کسٹم MCP سرور بنایا  
- ✅ **Workflow Automator** - ترقیاتی عمل کو آسان بنایا  
- ✅ **Integration Expert** - متعدد ترقیاتی ٹولز کو مربوط کیا  
- ✅ **Production Ready** - تعیناتی کے قابل حل تیار کیے  

---

## 🎓 ورکشاپ مکمل: Model Context Protocol کے ساتھ آپ کا سفر

**محترم ورکشاپ شریک،**

Model Context Protocol ورکشاپ کے چاروں ماڈیول مکمل کرنے پر مبارکباد! آپ نے AI Toolkit کے بنیادی تصورات سے لے کر پروڈکشن کے قابل MCP سرورز بنانے تک کا لمبا سفر طے کیا ہے جو حقیقی دنیا کے ترقیاتی چیلنجز حل کرتے ہیں۔

### 🚀 آپ کا سیکھنے کا خلاصہ:

**[Module 1](../lab1/README.md)**: آپ نے AI Toolkit کے بنیادی اصول، ماڈلز کی جانچ، اور اپنا پہلا AI ایجنٹ بنانے کا آغاز کیا۔

**[Module 2](../lab2/README.md)**: آپ نے MCP فن تعمیر سیکھی، Playwright MCP کو مربوط کیا، اور اپنا پہلا براؤزر آٹومیشن ایجنٹ بنایا۔

**[Module 3](../lab3/README.md)**: آپ نے کسٹم MCP سرور کی ترقی میں مہارت حاصل کی، Weather MCP سرور کے ساتھ، اور ڈیبگنگ ٹولز میں مہارت حاصل کی۔

**[Module 4](../lab4/README.md)**: اب آپ نے سب کچھ استعمال کرتے ہوئے ایک عملی GitHub ریپوزٹری ورک فلو آٹومیشن ٹول بنایا ہے۔

### 🌟 آپ نے کیا مہارت حاصل کی:

- ✅ **AI Toolkit ماحولیاتی نظام**: ماڈلز، ایجنٹس، اور انٹیگریشن پیٹرنز  
- ✅ **MCP فن تعمیر**: کلائنٹ-سرور ڈیزائن، ٹرانسپورٹ پروٹوکولز، اور سیکیورٹی  
- ✅ **ڈویلپر ٹولز**: Playground سے Inspector تک اور پروڈکشن تعیناتی تک  
- ✅ **کسٹم ترقی**: اپنے MCP سرورز کی تعمیر، جانچ، اور تعیناتی  
- ✅ **عملی اطلاقات**: AI کے ساتھ حقیقی دنیا کے ورک فلو چیلنجز حل کرنا  

### 🔮 آپ کے اگلے اقدامات:

1. **اپنا MCP سرور بنائیں**: اپنی منفرد ورک فلو کو خودکار بنانے کے لیے یہ مہارتیں استعمال کریں  
2. **MCP کمیونٹی میں شامل ہوں**: اپنی تخلیقات شیئر کریں اور دوسروں سے سیکھیں  
3. **اعلیٰ درجے کی انٹیگریشن دریافت کریں**: MCP سرورز کو انٹرپرائز سسٹمز سے جوڑیں  
4. **اوپن سورس میں تعاون کریں**: MCP ٹولنگ اور دستاویزات کو بہتر بنانے میں مدد کریں  

یاد رکھیں، یہ ورکشاپ صرف آغاز ہے۔ Model Context Protocol ماحولیاتی نظام تیزی سے ترقی کر رہا ہے، اور آپ اب AI سے چلنے والے ترقیاتی ٹولز کے محاذ پر ہیں۔

**آپ کی شرکت اور سیکھنے کے جذبے کا شکریہ!**

ہم امید کرتے ہیں کہ اس ورکشاپ نے آپ میں وہ خیالات جگائے ہوں گے جو آپ کے ترقیاتی سفر میں AI ٹولز کے ساتھ تعامل کو بدل دیں گے۔

**خوش کوڈنگ!**

---

**دستخط**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجموں میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں معتبر ماخذ سمجھا جانا چاہیے۔ اہم معلومات کے لیے پیشہ ورانہ انسانی ترجمہ تجویز کیا جاتا ہے۔ ہم اس ترجمہ کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔