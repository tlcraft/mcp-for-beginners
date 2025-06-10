<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2aa9dbc165e104764fa57e8a0d3f1c73",
  "translation_date": "2025-06-10T05:21:23+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab1/README.md",
  "language_code": "el"
}
-->
# 🚀 Module 1: Θεμελιώδεις Αρχές του AI Toolkit

[![Duration](https://img.shields.io/badge/Duration-15%20minutes-blue.svg)]()
[![Difficulty](https://img.shields.io/badge/Difficulty-Beginner-green.svg)]()
[![Prerequisites](https://img.shields.io/badge/Prerequisites-VS%20Code-orange.svg)]()

## 📋 Μαθησιακοί Στόχοι

Στο τέλος αυτού του module, θα μπορείτε να:
- ✅ Εγκαταστήσετε και να ρυθμίσετε το AI Toolkit για το Visual Studio Code
- ✅ Πλοηγηθείτε στον Κατάλογο Μοντέλων και να κατανοήσετε τις διάφορες πηγές μοντέλων
- ✅ Χρησιμοποιήσετε το Playground για δοκιμές και πειραματισμό με μοντέλα
- ✅ Δημιουργήσετε προσαρμοσμένους AI agents με το Agent Builder
- ✅ Συγκρίνετε την απόδοση μοντέλων από διαφορετικούς παρόχους
- ✅ Εφαρμόσετε βέλτιστες πρακτικές στην κατασκευή prompts

## 🧠 Εισαγωγή στο AI Toolkit (AITK)

Το **AI Toolkit για Visual Studio Code** είναι η κύρια επέκταση της Microsoft που μετατρέπει το VS Code σε ένα ολοκληρωμένο περιβάλλον ανάπτυξης AI. Γεφυρώνει το χάσμα μεταξύ της έρευνας AI και της πρακτικής ανάπτυξης εφαρμογών, καθιστώντας τη γενετική AI προσιτή σε προγραμματιστές κάθε επιπέδου.

### 🌟 Βασικές Δυνατότητες

| Χαρακτηριστικό | Περιγραφή | Περίπτωση Χρήσης |
|----------------|-----------|-----------------|
| **🗂️ Model Catalog** | Πρόσβαση σε πάνω από 100 μοντέλα από GitHub, ONNX, OpenAI, Anthropic, Google | Ανακάλυψη και επιλογή μοντέλων |
| **🔌 BYOM Support** | Ενσωμάτωση δικών σας μοντέλων (τοπικά/απομακρυσμένα) | Ανάπτυξη προσαρμοσμένων μοντέλων |
| **🎮 Interactive Playground** | Δοκιμές μοντέλων σε πραγματικό χρόνο με διεπαφή chat | Γρήγορη πρωτοτυποποίηση και δοκιμές |
| **📎 Multi-Modal Support** | Διαχείριση κειμένου, εικόνων και συνημμένων | Πολύπλοκες εφαρμογές AI |
| **⚡ Batch Processing** | Εκτέλεση πολλαπλών prompts ταυτόχρονα | Αποτελεσματικά workflows δοκιμών |
| **📊 Model Evaluation** | Ενσωματωμένα μετρικά (F1, συνάφεια, ομοιότητα, συνοχή) | Αξιολόγηση απόδοσης |

### 🎯 Γιατί το AI Toolkit είναι σημαντικό

- **🚀 Επιτάχυνση Ανάπτυξης**: Από την ιδέα στο πρωτότυπο μέσα σε λίγα λεπτά
- **🔄 Ενοποιημένο Workflow**: Μία διεπαφή για πολλούς παρόχους AI
- **🧪 Εύκολος Πειραματισμός**: Σύγκριση μοντέλων χωρίς πολύπλοκες ρυθμίσεις
- **📈 Έτοιμο για Παραγωγή**: Ομαλή μετάβαση από το πρωτότυπο στην ανάπτυξη

## 🛠️ Προαπαιτούμενα & Εγκατάσταση

### 📦 Εγκατάσταση της Επέκτασης AI Toolkit

**Βήμα 1: Πρόσβαση στο Marketplace Επεκτάσεων**
1. Ανοίξτε το Visual Studio Code
2. Μεταβείτε στην προβολή Επεκτάσεων (`Ctrl+Shift+X` ή `Cmd+Shift+X`)
3. Αναζητήστε "AI Toolkit"

**Βήμα 2: Επιλέξτε την Έκδοσή σας**
- **🟢 Release**: Συνιστάται για παραγωγική χρήση
- **🔶 Pre-release**: Πρόωρη πρόσβαση σε νέες δυνατότητες

**Βήμα 3: Εγκαταστήστε και Ενεργοποιήστε**

![AI Toolkit Extension](../../../../translated_images/aitkext.d28945a03eed003c39fc39bc96ae655af9b64b9b922e78e88b07214420ed7985.el.png)

### ✅ Λίστα Επαλήθευσης
- [ ] Το εικονίδιο AI Toolkit εμφανίζεται στην πλαϊνή μπάρα του VS Code
- [ ] Η επέκταση είναι ενεργοποιημένη και σε λειτουργία
- [ ] Δεν υπάρχουν σφάλματα εγκατάστασης στο πάνελ εξόδου

## 🧪 Πρακτική Άσκηση 1: Εξερεύνηση Μοντέλων GitHub

**🎯 Στόχος**: Εξοικείωση με τον Κατάλογο Μοντέλων και δοκιμή του πρώτου σας AI μοντέλου

### 📊 Βήμα 1: Πλοήγηση στον Κατάλογο Μοντέλων

Ο Κατάλογος Μοντέλων είναι η πύλη σας στον κόσμο του AI. Συγκεντρώνει μοντέλα από πολλούς παρόχους, καθιστώντας εύκολη την ανακάλυψη και τη σύγκριση επιλογών.

**🔍 Οδηγός Πλοήγησης:**

Κάντε κλικ στο **MODELS - Catalog** στην πλαϊνή μπάρα του AI Toolkit

![Model Catalog](../../../../translated_images/aimodel.263ed2be013d8fb0e2265c4f742cfe490f6f00eca5e132ec50438c8e826e34ed.el.png)

**💡 Συμβουλή**: Αναζητήστε μοντέλα με συγκεκριμένες δυνατότητες που ταιριάζουν στη χρήση σας (π.χ. παραγωγή κώδικα, δημιουργική γραφή, ανάλυση).

**⚠️ Σημείωση**: Τα μοντέλα που φιλοξενούνται στο GitHub (δηλαδή GitHub Models) είναι δωρεάν, αλλά υπόκεινται σε όρια αιτήσεων και tokens. Για πρόσβαση σε μη GitHub μοντέλα (π.χ. εξωτερικά μοντέλα μέσω Azure AI ή άλλων endpoints), θα χρειαστεί να παρέχετε το κατάλληλο API key ή πιστοποίηση.

### 🚀 Βήμα 2: Προσθήκη και Ρύθμιση του Πρώτου σας Μοντέλου

**Στρατηγική Επιλογής Μοντέλου:**
- **GPT-4.1**: Ιδανικό για σύνθετη λογική και ανάλυση
- **Phi-4-mini**: Ελαφρύ, γρήγορες απαντήσεις για απλές εργασίες

**🔧 Διαδικασία Ρύθμισης:**
1. Επιλέξτε **OpenAI GPT-4.1** από τον κατάλογο
2. Κάντε κλικ στο **Add to My Models** - καταχωρεί το μοντέλο για χρήση
3. Επιλέξτε **Try in Playground** για να ανοίξετε το περιβάλλον δοκιμών
4. Περιμένετε την αρχικοποίηση του μοντέλου (η πρώτη φορά μπορεί να πάρει λίγο χρόνο)

![Playground Setup](../../../../translated_images/playground.dd6f5141344878ca4d4f3de819775da7b113518941accf37c291117c602f85db.el.png)

**⚙️ Κατανόηση των Παραμέτρων Μοντέλου:**
- **Temperature**: Ελέγχει τη δημιουργικότητα (0 = σταθερό, 1 = δημιουργικό)
- **Max Tokens**: Μέγιστο μήκος απάντησης
- **Top-p**: Nucleus sampling για ποικιλία απαντήσεων

### 🎯 Βήμα 3: Εξοικείωση με τη Διεπαφή του Playground

Το Playground είναι το εργαστήριό σας για πειραματισμό με AI. Δείτε πώς να το αξιοποιήσετε στο έπακρο:

**🎨 Βέλτιστες Πρακτικές για Prompt Engineering:**
1. **Να είστε συγκεκριμένοι**: Σαφείς, λεπτομερείς οδηγίες φέρνουν καλύτερα αποτελέσματα
2. **Παρέχετε πλαίσιο**: Συμπεριλάβετε σχετικές πληροφορίες
3. **Χρησιμοποιήστε παραδείγματα**: Δείξτε στο μοντέλο τι θέλετε με παραδείγματα
4. **Επαναλάβετε**: Βελτιώστε τα prompts με βάση τα αρχικά αποτελέσματα

**🧪 Σενάρια Δοκιμών:**
```markdown
# Example 1: Code Generation
"Write a Python function that calculates the factorial of a number using recursion. Include error handling and docstrings."

# Example 2: Creative Writing
"Write a professional email to a client explaining a project delay, maintaining a positive tone while being transparent about challenges."

# Example 3: Data Analysis
"Analyze this sales data and provide insights: [paste your data]. Focus on trends, anomalies, and actionable recommendations."
```

![Testing Results](../../../../translated_images/result.1dfcf211fb359cf65902b09db191d3bfc65713ca15e279c1a30be213bb526949.el.png)

### 🏆 Πρόκληση: Σύγκριση Απόδοσης Μοντέλων

**🎯 Στόχος**: Συγκρίνετε διαφορετικά μοντέλα χρησιμοποιώντας τα ίδια prompts για να κατανοήσετε τα πλεονεκτήματά τους

**📋 Οδηγίες:**
1. Προσθέστε το **Phi-4-mini** στο workspace σας
2. Χρησιμοποιήστε το ίδιο prompt για GPT-4.1 και Phi-4-mini

![set](../../../../translated_images/set.88132df189ecde2cbbda256c1841db5aac8e9bdeba1a4e343dfa031b9545d6c9.el.png)

3. Συγκρίνετε ποιότητα απαντήσεων, ταχύτητα και ακρίβεια
4. Καταγράψτε τα ευρήματά σας στην ενότητα αποτελεσμάτων

![Model Comparison](../../../../translated_images/compare.97746cd0f907495503c1fc217739f3890dc76ea5f6fd92379a6db0cc331feb58.el.png)

**💡 Σημαντικά Σημεία για Ανακάλυψη:**
- Πότε να χρησιμοποιήσετε LLM έναντι SLM
- Ισορροπία κόστους και απόδοσης
- Εξειδικευμένες δυνατότητες διαφορετικών μοντέλων

## 🤖 Πρακτική Άσκηση 2: Δημιουργία Προσαρμοσμένων Agents με Agent Builder

**🎯 Στόχος**: Δημιουργήστε εξειδικευμένους AI agents προσαρμοσμένους σε συγκεκριμένες εργασίες και ροές εργασίας

### 🏗️ Βήμα 1: Κατανόηση του Agent Builder

Το Agent Builder είναι το σημείο όπου το AI Toolkit λάμπει πραγματικά. Σας επιτρέπει να δημιουργήσετε σκοποθετημένους AI βοηθούς που συνδυάζουν τη δύναμη μεγάλων γλωσσικών μοντέλων με προσαρμοσμένες οδηγίες, συγκεκριμένες παραμέτρους και εξειδικευμένη γνώση.

**🧠 Στοιχεία Αρχιτεκτονικής Agent:**
- **Core Model**: Το βασικό LLM (GPT-4, Groks, Phi, κ.ά.)
- **System Prompt**: Ορίζει την προσωπικότητα και τη συμπεριφορά του agent
- **Parameters**: Ρυθμίσεις για βέλτιστη απόδοση
- **Tools Integration**: Σύνδεση με εξωτερικά APIs και MCP υπηρεσίες
- **Memory**: Πλαίσιο συνομιλίας και διατήρηση συνεδρίας

![Agent Builder Interface](../../../../translated_images/agentbuilder.25895b2d2f8c02e7aa99dd40e105877a6f1db8f0441180087e39db67744b361f.el.png)

### ⚙️ Βήμα 2: Βαθιά Επισκόπηση Ρυθμίσεων Agent

**🎨 Δημιουργία Αποτελεσματικών System Prompts:**
```markdown
# Template Structure:
## Role Definition
You are a [specific role] with expertise in [domain].

## Capabilities
- List specific abilities
- Define scope of knowledge
- Clarify limitations

## Behavior Guidelines
- Response style (formal, casual, technical)
- Output format preferences
- Error handling approach

## Examples
Provide 2-3 examples of ideal interactions
```

*Φυσικά, μπορείτε επίσης να χρησιμοποιήσετε το Generate System Prompt για να βοηθηθείτε από AI στη δημιουργία και βελτιστοποίηση των prompts*

**🔧 Βελτιστοποίηση Παραμέτρων:**
| Παράμετρος | Συνιστώμενο Εύρος | Περίπτωση Χρήσης |
|------------|-------------------|------------------|
| **Temperature** | 0.1-0.3 | Τεχνικές/ακριβείς απαντήσεις |
| **Temperature** | 0.7-0.9 | Δημιουργικές/ιδεοκαταιγιστικές εργασίες |
| **Max Tokens** | 500-1000 | Συνοπτικές απαντήσεις |
| **Max Tokens** | 2000-4000 | Αναλυτικές εξηγήσεις |

### 🐍 Βήμα 3: Πρακτική Άσκηση - Agent Προγραμματισμού Python

**🎯 Αποστολή**: Δημιουργήστε έναν εξειδικευμένο βοηθό προγραμματισμού σε Python

**📋 Βήματα Ρύθμισης:**

1. **Επιλογή Μοντέλου**: Επιλέξτε **Claude 3.5 Sonnet** (εξαιρετικό για κώδικα)

2. **Σχεδίαση System Prompt**:
```markdown
# Python Programming Expert Agent

## Role
You are a senior Python developer with 10+ years of experience. You excel at writing clean, efficient, and well-documented Python code.

## Capabilities
- Write production-ready Python code
- Debug complex issues
- Explain code concepts clearly
- Suggest best practices and optimizations
- Provide complete working examples

## Response Format
- Always include docstrings
- Add inline comments for complex logic
- Suggest testing approaches
- Mention relevant libraries when applicable

## Code Quality Standards
- Follow PEP 8 style guidelines
- Use type hints where appropriate
- Handle exceptions gracefully
- Write readable, maintainable code
```

3. **Ρύθμιση Παραμέτρων**:
   - Temperature: 0.2 (για σταθερό, αξιόπιστο κώδικα)
   - Max Tokens: 2000 (λεπτομερείς εξηγήσεις)
   - Top-p: 0.9 (ισορροπημένη δημιουργικότητα)

![Python Agent Configuration](../../../../translated_images/pythonagent.5e51b406401c165fcabfd66f2d943c27f46b5fed0f9fb73abefc9e91ca3489d4.el.png)

### 🧪 Βήμα 4: Δοκιμή του Python Agent σας

**Σενάρια Δοκιμών:**
1. **Βασική Λειτουργία**: "Δημιουργήστε μια συνάρτηση για εύρεση πρώτων αριθμών"
2. **Σύνθετος Αλγόριθμος**: "Υλοποιήστε ένα δυαδικό δέντρο αναζήτησης με μεθόδους εισαγωγής, διαγραφής και αναζήτησης"
3. **Πραγματικό Πρόβλημα**: "Φτιάξτε έναν web scraper που διαχειρίζεται περιορισμούς ρυθμού και επαναλήψεις"
4. **Αποσφαλμάτωση**: "Διορθώστε αυτόν τον κώδικα [επικολλήστε προβληματικό κώδικα]"

**🏆 Κριτήρια Επιτυχίας:**
- ✅ Ο κώδικας τρέχει χωρίς σφάλματα
- ✅ Περιλαμβάνει σωστή τεκμηρίωση
- ✅ Ακολουθεί τις βέλτιστες πρακτικές Python
- ✅ Παρέχει σαφείς εξηγήσεις
- ✅ Προτείνει βελτιώσεις

## 🎓 Σύνοψη Module 1 & Επόμενα Βήματα

### 📊 Έλεγχος Γνώσεων

Ελέγξτε την κατανόησή σας:
- [ ] Μπορείτε να εξηγήσετε τη διαφορά μεταξύ των μοντέλων στον κατάλογο;
- [ ] Έχετε δημιουργήσει και δοκιμάσει επιτυχώς έναν προσαρμοσμένο agent;
- [ ] Κατανοείτε πώς να βελτιστοποιείτε παραμέτρους για διαφορετικές χρήσεις;
- [ ] Μπορείτε να σχεδιάσετε αποτελεσματικά system prompts;

### 📚 Επιπλέον Πόροι

- **AI Toolkit Documentation**: [Official Microsoft Docs](https://github.com/microsoft/vscode-ai-toolkit)
- **Prompt Engineering Guide**: [Best Practices](https://platform.openai.com/docs/guides/prompt-engineering)
- **Models in AI Toolkit**: [Models in Develpment](https://github.com/microsoft/vscode-ai-toolkit/blob/main/doc/models.md)

**🎉 Συγχαρητήρια!** Έχετε κατακτήσει τα βασικά του AI Toolkit και είστε έτοιμοι να δημιουργήσετε πιο προχωρημένες εφαρμογές AI!

### 🔜 Συνεχίστε στο Επόμενο Module

Έτοιμοι για πιο προχωρημένες δυνατότητες; Συνεχίστε στο **[Module 2: MCP with AI Toolkit Fundamentals](../lab2/README.md)** όπου θα μάθετε πώς να:
- Συνδέετε τους agents σας με εξωτερικά εργαλεία χρησιμοποιώντας το Model Context Protocol (MCP)
- Δημιουργείτε agents αυτοματισμού browser με Playwright
- Ενσωματώνετε MCP servers με τους AI Toolkit agents σας
- Ενισχύετε τους agents σας με εξωτερικά δεδομένα και δυνατότητες

**Αποποίηση Ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η επίσημη πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική μετάφραση από ανθρώπινο μεταφραστή. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.