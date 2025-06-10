<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2aa9dbc165e104764fa57e8a0d3f1c73",
  "translation_date": "2025-06-10T05:31:56+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab1/README.md",
  "language_code": "sr"
}
-->
# 🚀 Modul 1: Osnove AI Toolkit-a

[![Duration](https://img.shields.io/badge/Duration-15%20minutes-blue.svg)]()
[![Difficulty](https://img.shields.io/badge/Difficulty-Beginner-green.svg)]()
[![Prerequisites](https://img.shields.io/badge/Prerequisites-VS%20Code-orange.svg)]()

## 📋 Ciljevi učenja

Do kraja ovog modula bićete u stanju da:
- ✅ Instalirate i konfigurišete AI Toolkit za Visual Studio Code
- ✅ Pregledate Model Catalog i razumete različite izvore modela
- ✅ Koristite Playground za testiranje i eksperimentisanje sa modelima
- ✅ Kreirate prilagođene AI agente koristeći Agent Builder
- ✅ Uporedite performanse modela kod različitih provajdera
- ✅ Primijenite najbolje prakse za prompt inženjering

## 🧠 Uvod u AI Toolkit (AITK)

**AI Toolkit za Visual Studio Code** je vodeći Microsoftov dodatak koji pretvara VS Code u sveobuhvatno razvojno okruženje za AI. On povezuje istraživanja u oblasti veštačke inteligencije sa praktičnim razvojem aplikacija, čineći generativnu AI dostupnom programerima svih nivoa znanja.

### 🌟 Ključne mogućnosti

| Funkcija | Opis | Upotreba |
|---------|-------------|----------|
| **🗂️ Model Catalog** | Pristup preko 100 modela sa GitHub, ONNX, OpenAI, Anthropic, Google | Pronalaženje i izbor modela |
| **🔌 BYOM Support** | Integracija sopstvenih modela (lokalnih ili udaljenih) | Prilagođeno postavljanje modela |
| **🎮 Interactive Playground** | Testiranje modela u realnom vremenu sa chat interfejsom | Brzi prototipovi i testiranje |
| **📎 Multi-Modal Support** | Rad sa tekstom, slikama i prilozima | Kompleksne AI aplikacije |
| **⚡ Batch Processing** | Pokretanje više promptova istovremeno | Efikasni testni tokovi rada |
| **📊 Model Evaluation** | Ugrađene metrike (F1, relevantnost, sličnost, koherentnost) | Procena performansi |

### 🎯 Zašto je AI Toolkit važan

- **🚀 Brži razvoj**: Od ideje do prototipa za nekoliko minuta
- **🔄 Jedinstveni radni tok**: Jedan interfejs za više AI provajdera
- **🧪 Jednostavno eksperimentisanje**: Uporedite modele bez komplikovanog podešavanja
- **📈 Spreman za produkciju**: Laka tranzicija od prototipa do implementacije

## 🛠️ Preduslovi i podešavanje

### 📦 Instalacija AI Toolkit ekstenzije

**Korak 1: Pristup Marketplace-u za ekstenzije**
1. Otvorite Visual Studio Code
2. Idite na prikaz Extensions (`Ctrl+Shift+X` ili `Cmd+Shift+X`)
3. Potražite "AI Toolkit"

**Korak 2: Izaberite verziju**
- **🟢 Release**: Preporučeno za produkciju
- **🔶 Pre-release**: Rani pristup najnovijim funkcijama

**Korak 3: Instalirajte i aktivirajte**

![AI Toolkit Extension](../../../../translated_images/aitkext.d28945a03eed003c39fc39bc96ae655af9b64b9b922e78e88b07214420ed7985.sr.png)

### ✅ Provera nakon instalacije
- [ ] Ikona AI Toolkit-a se pojavljuje u VS Code sidebar-u
- [ ] Ekstenzija je omogućena i aktivirana
- [ ] Nema grešaka prilikom instalacije u output panelu

## 🧪 Praktična vežba 1: Istraživanje GitHub modela

**🎯 Cilj**: Savladati Model Catalog i testirati prvi AI model

### 📊 Korak 1: Pregled Model Catalog-a

Model Catalog je vaša ulazna tačka u AI ekosistem. On okuplja modele od različitih provajdera, olakšavajući pronalaženje i poređenje opcija.

**🔍 Kako da se krećete:**

Kliknite na **MODELS - Catalog** u AI Toolkit sidebar-u

![Model Catalog](../../../../translated_images/aimodel.263ed2be013d8fb0e2265c4f742cfe490f6f00eca5e132ec50438c8e826e34ed.sr.png)

**💡 Koristan savet**: Tražite modele sa specifičnim sposobnostima koje odgovaraju vašem slučaju upotrebe (npr. generisanje koda, kreativno pisanje, analiza).

**⚠️ Napomena**: GitHub-hostovani modeli (tj. GitHub modeli) su besplatni za korišćenje, ali imaju ograničenja u broju zahteva i tokena. Ako želite da pristupite modelima van GitHub-a (npr. eksterni modeli preko Azure AI ili drugih krajnjih tačaka), moraćete da obezbedite odgovarajući API ključ ili autentifikaciju.

### 🚀 Korak 2: Dodajte i konfigurišite prvi model

**Strategija izbora modela:**
- **GPT-4.1**: Najbolji za složeno rezonovanje i analizu
- **Phi-4-mini**: Lagan, brz za jednostavne zadatke

**🔧 Proces podešavanja:**
1. Izaberite **OpenAI GPT-4.1** iz kataloga
2. Kliknite **Add to My Models** - time se model registruje za upotrebu
3. Izaberite **Try in Playground** da pokrenete testno okruženje
4. Sačekajte da se model inicijalizuje (prvo pokretanje može potrajati)

![Playground Setup](../../../../translated_images/playground.dd6f5141344878ca4d4f3de819775da7b113518941accf37c291117c602f85db.sr.png)

**⚙️ Razumevanje parametara modela:**
- **Temperature**: Kontroliše kreativnost (0 = deterministički, 1 = kreativan)
- **Max Tokens**: Maksimalna dužina odgovora
- **Top-p**: Nucleus sampling za raznovrsnost odgovora

### 🎯 Korak 3: Savladajte interfejs Playground-a

Playground je vaše laboratorijsko okruženje za AI eksperimentisanje. Evo kako da ga maksimalno iskoristite:

**🎨 Najbolje prakse za prompt inženjering:**
1. **Budite precizni**: Jasna i detaljna uputstva daju bolje rezultate
2. **Obezbedite kontekst**: Uključite relevantne informacije u pozadini
3. **Koristite primere**: Pokažite modelu šta želite preko primera
4. **Iterirajte**: Usavršavajte promptove na osnovu prvih rezultata

**🧪 Testni scenariji:**
```markdown
# Example 1: Code Generation
"Write a Python function that calculates the factorial of a number using recursion. Include error handling and docstrings."

# Example 2: Creative Writing
"Write a professional email to a client explaining a project delay, maintaining a positive tone while being transparent about challenges."

# Example 3: Data Analysis
"Analyze this sales data and provide insights: [paste your data]. Focus on trends, anomalies, and actionable recommendations."
```

![Testing Results](../../../../translated_images/result.1dfcf211fb359cf65902b09db191d3bfc65713ca15e279c1a30be213bb526949.sr.png)

### 🏆 Izazov: Poređenje performansi modela

**🎯 Cilj**: Uporedite različite modele koristeći iste promptove da biste razumeli njihove prednosti

**📋 Uputstvo:**
1. Dodajte **Phi-4-mini** u radni prostor
2. Koristite isti prompt za GPT-4.1 i Phi-4-mini

![set](../../../../translated_images/set.88132df189ecde2cbbda256c1841db5aac8e9bdeba1a4e343dfa031b9545d6c9.sr.png)

3. Uporedite kvalitet, brzinu i tačnost odgovora
4. Zabeležite svoja zapažanja u sekciji rezultata

![Model Comparison](../../../../translated_images/compare.97746cd0f907495503c1fc217739f3890dc76ea5f6fd92379a6db0cc331feb58.sr.png)

**💡 Ključne stvari za primetiti:**
- Kada koristiti LLM naspram SLM
- Odnos troškova i performansi
- Specijalizovane mogućnosti različitih modela

## 🤖 Praktična vežba 2: Kreiranje prilagođenih agenata sa Agent Builder-om

**🎯 Cilj**: Napravite specijalizovane AI agente prilagođene za određene zadatke i tokove rada

### 🏗️ Korak 1: Razumevanje Agent Builder-a

Agent Builder je mesto gde AI Toolkit zaista dolazi do izražaja. Omogućava kreiranje AI asistenata sa specifičnom namenom, koji kombinuju moć velikih jezičkih modela sa prilagođenim uputstvima, parametrima i specijalizovanim znanjem.

**🧠 Komponente arhitekture agenta:**
- **Core Model**: Osnovni LLM (GPT-4, Groks, Phi itd.)
- **System Prompt**: Definiše ličnost i ponašanje agenta
- **Parameters**: Podešavanja za optimalne performanse
- **Tools Integration**: Povezivanje sa eksternim API-jima i MCP servisima
- **Memory**: Kontekst konverzacije i trajanje sesije

![Agent Builder Interface](../../../../translated_images/agentbuilder.25895b2d2f8c02e7aa99dd40e105877a6f1db8f0441180087e39db67744b361f.sr.png)

### ⚙️ Korak 2: Detaljna konfiguracija agenta

**🎨 Kreiranje efektnih sistemskih promptova:**
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

*Naravno, možete koristiti i Generate System Prompt da vam AI pomogne u kreiranju i optimizaciji promptova*

**🔧 Optimizacija parametara:**
| Parametar | Preporučeni opseg | Upotreba |
|-----------|-------------------|----------|
| **Temperature** | 0.1-0.3 | Tehnički/faktički odgovori |
| **Temperature** | 0.7-0.9 | Kreativni/brainstorming zadaci |
| **Max Tokens** | 500-1000 | Sažeti odgovori |
| **Max Tokens** | 2000-4000 | Detaljna objašnjenja |

### 🐍 Korak 3: Praktična vežba - Python programerski agent

**🎯 Misija**: Napravite specijalizovanog asistenta za Python kodiranje

**📋 Koraci konfiguracije:**

1. **Izbor modela**: Izaberite **Claude 3.5 Sonnet** (odličan za kod)

2. **Dizajn sistemskog prompta**:
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

3. **Podešavanje parametara**:
   - Temperature: 0.2 (za konzistentan, pouzdan kod)
   - Max Tokens: 2000 (detaljna objašnjenja)
   - Top-p: 0.9 (uravnotežena kreativnost)

![Python Agent Configuration](../../../../translated_images/pythonagent.5e51b406401c165fcabfd66f2d943c27f46b5fed0f9fb73abefc9e91ca3489d4.sr.png)

### 🧪 Korak 4: Testiranje vašeg Python agenta

**Testni scenariji:**
1. **Osnovna funkcija**: "Napravi funkciju za pronalaženje prostih brojeva"
2. **Složeni algoritam**: "Implementiraj binarno stablo pretrage sa metodama za ubacivanje, brisanje i pretragu"
3. **Praktičan problem**: "Napravi web scraper koji se nosi sa ograničenjima broja zahteva i ponavljanjima"
4. **Debugging**: "Ispravi ovaj kod [nalepi neispravan kod]"

**🏆 Kriterijumi uspeha:**
- ✅ Kod se izvršava bez grešaka
- ✅ Sadrži adekvatnu dokumentaciju
- ✅ Prati najbolje prakse za Python
- ✅ Daje jasna objašnjenja
- ✅ Predlaže poboljšanja

## 🎓 Završetak modula 1 i naredni koraci

### 📊 Provera znanja

Testirajte svoje razumevanje:
- [ ] Možete li objasniti razliku između modela u katalogu?
- [ ] Da li ste uspešno kreirali i testirali prilagođenog agenta?
- [ ] Da li razumete kako optimizovati parametre za različite slučajeve upotrebe?
- [ ] Možete li dizajnirati efektne sistemske promptove?

### 📚 Dodatni resursi

- **AI Toolkit dokumentacija**: [Official Microsoft Docs](https://github.com/microsoft/vscode-ai-toolkit)
- **Vodič za prompt inženjering**: [Best Practices](https://platform.openai.com/docs/guides/prompt-engineering)
- **Modeli u AI Toolkit-u**: [Models in Develpment](https://github.com/microsoft/vscode-ai-toolkit/blob/main/doc/models.md)

**🎉 Čestitamo!** Savladali ste osnove AI Toolkit-a i spremni ste za razvoj naprednijih AI aplikacija!

### 🔜 Nastavite na sledeći modul

Spremni za naprednije funkcionalnosti? Pređite na **[Modul 2: MCP sa osnovama AI Toolkit-a](../lab2/README.md)** gde ćete naučiti kako da:
- Povežete svoje agente sa eksternim alatima koristeći Model Context Protocol (MCP)
- Kreirate agente za automatizaciju u pregledaču koristeći Playwright
- Integrirate MCP servere sa svojim AI Toolkit agentima
- Ojačate svoje agente eksternim podacima i mogućnostima

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI преводилачке услуге [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која могу настати коришћењем овог превода.