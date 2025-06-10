<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f83bc722dc758efffd68667d6a1db470",
  "translation_date": "2025-06-10T06:58:14+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/README.md",
  "language_code": "sr"
}
-->
# 🐙 Modul 4: Praktični MCP razvoj - Prilagođeni GitHub Clone Server

![Duration](https://img.shields.io/badge/Duration-30_minutes-blue?style=flat-square)
![Difficulty](https://img.shields.io/badge/Difficulty-Intermediate-orange?style=flat-square)
![MCP](https://img.shields.io/badge/MCP-Custom%20Server-purple?style=flat-square&logo=github)
![VS Code](https://img.shields.io/badge/VS%20Code-Integration-blue?style=flat-square&logo=visualstudiocode)
![GitHub Copilot](https://img.shields.io/badge/GitHub%20Copilot-Agent%20Mode-green?style=flat-square&logo=github)

> **⚡ Brzi početak:** Izgradite proizvodni MCP server koji automatizuje kloniranje GitHub repozitorijuma i integraciju sa VS Code-om za samo 30 minuta!

## 🎯 Ciljevi učenja

Na kraju ovog laboratorijskog rada moći ćete da:

- ✅ Kreirate prilagođeni MCP server za stvarne razvojne tokove rada
- ✅ Implementirate funkcionalnost kloniranja GitHub repozitorijuma putem MCP-a
- ✅ Integrirate prilagođene MCP servere sa VS Code-om i Agent Builder-om
- ✅ Koristite GitHub Copilot Agent Mode sa prilagođenim MCP alatima
- ✅ Testirate i implementirate prilagođene MCP servere u produkcionim okruženjima

## 📋 Preduslovi

- Završeni laboratorijski radovi 1-3 (osnovni i napredni MCP razvoj)
- Pretplata na GitHub Copilot ([dostupna besplatna registracija](https://github.com/github-copilot/signup))
- VS Code sa AI Toolkit i GitHub Copilot ekstenzijama
- Instaliran i konfigurisani Git CLI

## 🏗️ Pregled projekta

### **Izazov iz stvarnog sveta razvoja**
Kao developeri često koristimo GitHub da kloniramo repozitorijume i otvorimo ih u VS Code-u ili VS Code Insiders. Ovaj ručni proces podrazumeva:
1. Otvaranje terminala/komandne linije
2. Navigaciju do željenog direktorijuma
3. Pokretanje `git clone` komande
4. Otvaranje VS Code-a u kloniranom direktorijumu

**Naše MCP rešenje pojednostavljuje ovaj proces u jednu pametnu komandu!**

### **Šta ćete napraviti**
**GitHub Clone MCP Server** (`git_mcp_server`) koji nudi:

| Funkcija | Opis | Prednost |
|---------|-------------|---------|
| 🔄 **Pametno kloniranje repozitorijuma** | Klonira GitHub repozitorijume sa validacijom | Automatska provera grešaka |
| 📁 **Pametno upravljanje direktorijumima** | Proverava i bezbedno kreira direktorijume | Sprečava prepisivanje |
| 🚀 **Višestruka integracija sa VS Code-om** | Otvara projekte u VS Code/Insiders | Neprimetan prelaz u radni tok |
| 🛡️ **Robusno upravljanje greškama** | Rukuje mrežnim, dozvolama i problemima sa putanjama | Pouzdanost spremna za produkciju |

---

## 📖 Implementacija korak po korak

### Korak 1: Kreirajte GitHub agenta u Agent Builder-u

1. **Pokrenite Agent Builder** preko AI Toolkit ekstenzije
2. **Kreirajte novog agenta** sa sledećom konfiguracijom:
   ```
   Agent Name: GitHubAgent
   ```

3. **Inicijalizujte prilagođeni MCP server:**
   - Idite na **Tools** → **Add Tool** → **MCP Server**
   - Izaberite **"Create A new MCP Server"**
   - Odaberite **Python šablon** za maksimalnu fleksibilnost
   - **Ime servera:** `git_mcp_server`

### Korak 2: Konfigurišite GitHub Copilot Agent Mode

1. **Otvorite GitHub Copilot** u VS Code-u (Ctrl/Cmd + Shift + P → "GitHub Copilot: Open")
2. **Izaberite Agent Model** u Copilot interfejsu
3. **Odaberite Claude 3.7 model** za unapređene sposobnosti rezonovanja
4. **Omogućite MCP integraciju** za pristup alatima

> **💡 Korisni savet:** Claude 3.7 pruža bolje razumevanje razvojnih tokova rada i obrazaca upravljanja greškama.

### Korak 3: Implementirajte osnovnu funkcionalnost MCP servera

**Koristite sledeći detaljni prompt sa GitHub Copilot Agent Mode-om:**

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

### Korak 4: Testirajte vaš MCP server

#### 4a. Testiranje u Agent Builder-u

1. **Pokrenite debug konfiguraciju** u Agent Builder-u
2. **Konfigurišite svog agenta sa ovim sistemskim promptom:**

```
SYSTEM_PROMPT:
You are my intelligent coding repository assistant. You help developers efficiently clone GitHub repositories and set up their development environment. Always provide clear feedback about operations and handle errors gracefully.
```

3. **Testirajte sa realnim korisničkim scenarijima:**

```
USER_PROMPT EXAMPLES:

Scenario : Basic Clone and Open
"Clone {Your GitHub Repo link such as https://github.com/kinfey/GHCAgentWorkshop
 } and save to {The global path you specify}, then open it with VS Code Insiders"
```

![Agent Builder Testing](../../../../translated_images/DebugAgent.81d152370c503241b3b39a251b8966f7f739286df19dd57f9147f6402214a012.sr.png)

**Očekivani rezultati:**
- ✅ Uspešno kloniranje sa potvrdom putanje
- ✅ Automatsko pokretanje VS Code-a
- ✅ Jasne poruke o greškama za nevažeće situacije
- ✅ Ispravno rukovanje ivicama slučajeva

#### 4b. Testiranje u MCP Inspector-u

![MCP Inspector Testing](../../../../translated_images/DebugInspector.eb5c95f94c69a8ba36944941b9a3588309a3a2fae101ace470ee09bde41d1667.sr.png)

---

**🎉 Čestitamo!** Uspešno ste kreirali praktični, proizvodni MCP server koji rešava stvarne izazove razvojnih tokova rada. Vaš prilagođeni GitHub clone server pokazuje snagu MCP-a za automatizaciju i unapređenje produktivnosti developera.

### 🏆 Osvajene veštine:
- ✅ **MCP Developer** - Kreirali prilagođeni MCP server
- ✅ **Workflow Automator** - Pojednostavili razvojne procese  
- ✅ **Integration Expert** - Povezali više razvojnih alata
- ✅ **Production Ready** - Izgradili rešenja spremna za produkciju

---

## 🎓 Završetak radionice: Vaše putovanje sa Model Context Protocol-om

**Dragi učesniče radionice,**

Čestitamo na završetku sva četiri modula Model Context Protocol radionice! Prešli ste dug put od razumevanja osnovnih koncepata AI Toolkit-a do izgradnje proizvodnih MCP servera koji rešavaju stvarne razvojne izazove.

### 🚀 Pregled vašeg puta učenja:

**[Modul 1](../lab1/README.md)**: Počeli ste istraživanjem osnova AI Toolkit-a, testiranjem modela i kreiranjem svog prvog AI agenta.

**[Modul 2](../lab2/README.md)**: Naučili ste MCP arhitekturu, integrisali Playwright MCP i napravili svoj prvi agent za automatizaciju pretraživača.

**[Modul 3](../lab3/README.md)**: Napredovali ste u razvoju prilagođenih MCP servera sa Weather MCP serverom i savladali alate za otklanjanje grešaka.

**[Modul 4](../lab4/README.md)**: Sada ste primenili sve naučeno da kreirate praktičan alat za automatizaciju rada sa GitHub repozitorijumima.

### 🌟 Šta ste savladali:

- ✅ **AI Toolkit ekosistem**: modeli, agenti i obrasci integracije
- ✅ **MCP arhitektura**: klijent-server dizajn, transportni protokoli i bezbednost
- ✅ **Razvojni alati**: od Playground-a do Inspectora i produkcionog puštanja
- ✅ **Prilagođeni razvoj**: izgradnja, testiranje i implementacija sopstvenih MCP servera
- ✅ **Praktične primene**: rešavanje stvarnih problema radnih tokova uz pomoć AI

### 🔮 Sledeći koraci:

1. **Izgradite sopstveni MCP server**: Primijenite ove veštine da automatizujete svoje jedinstvene tokove rada
2. **Pridružite se MCP zajednici**: Delite svoja rešenja i učite od drugih
3. **Istražite naprednu integraciju**: Povežite MCP servere sa enterprise sistemima
4. **Doprinesite open source-u**: Pomozite u unapređenju MCP alata i dokumentacije

Zapamtite, ova radionica je samo početak. Model Context Protocol ekosistem brzo se razvija, a sada ste opremljeni da budete na čelu AI-pokretanih razvojnih alata.

**Hvala vam na učešću i posvećenosti učenju!**

Nadamo se da vam je radionica dala ideje koje će promeniti način na koji gradite i koristite AI alate u svom razvoju.

**Srećno kodiranje!**

---

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде прецизан, молимо вас да имате у виду да аутоматизовани преводи могу садржати грешке или нетачности. Изворни документ на оригиналном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која произилазе из коришћења овог превода.