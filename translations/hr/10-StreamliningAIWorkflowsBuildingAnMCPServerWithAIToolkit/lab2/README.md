<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a22b7dd11cd7690f99f9195877cafdc3",
  "translation_date": "2025-06-10T06:00:27+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab2/README.md",
  "language_code": "hr"
}
-->
# 🌐 Modul 2: Osnove MCP-a s AI Toolkit

[![Duration](https://img.shields.io/badge/Duration-20%20minutes-blue.svg)]()
[![Difficulty](https://img.shields.io/badge/Difficulty-Intermediate-yellow.svg)]()
[![Prerequisites](https://img.shields.io/badge/Prerequisites-Module%201%20Complete-orange.svg)]()

## 📋 Ciljevi učenja

Na kraju ovog modula moći ćete:
- ✅ Razumjeti arhitekturu i prednosti Model Context Protocola (MCP)
- ✅ Istražiti Microsoftov MCP server ekosustav
- ✅ Integrirati MCP servere s AI Toolkit Agent Builderom
- ✅ Izgraditi funkcionalnog agenta za automatizaciju preglednika koristeći Playwright MCP
- ✅ Konfigurirati i testirati MCP alate unutar svojih agenata
- ✅ Izvesti i implementirati agente pokretane MCP-om za produkcijsku upotrebu

## 🎯 Nadogradnja na Modul 1

U Modulu 1 savladali smo osnove AI Toolkita i stvorili našeg prvog Python agenta. Sada ćemo **pojačati** vaše agente povezivanjem s vanjskim alatima i uslugama putem revolucionarnog **Model Context Protocola (MCP)**.

Zamislite to kao nadogradnju s običnog kalkulatora na pravi računalo - vaši AI agenti dobit će mogućnost da:
- 🌐 Pregledavaju i komuniciraju s web stranicama
- 📁 Pristupaju i upravljaju datotekama
- 🔧 Integriraju se s poslovnim sustavima
- 📊 Obradjuju podatke u stvarnom vremenu iz API-ja

## 🧠 Razumijevanje Model Context Protocola (MCP)

### 🔍 Što je MCP?

Model Context Protocol (MCP) je **"USB-C za AI aplikacije"** - revolucionarni otvoreni standard koji povezuje velike jezične modele (LLM) s vanjskim alatima, izvorima podataka i uslugama. Kao što je USB-C eliminirao nered od kabela pružajući jedan univerzalni priključak, MCP uklanja složenost AI integracija jedinstvenim standardiziranim protokolom.

### 🎯 Problem koji MCP rješava

**Prije MCP-a:**
- 🔧 Prilagođene integracije za svaki alat
- 🔄 Zaključavanje kod dobavljača zbog vlasničkih rješenja
- 🔒 Sigurnosni propusti zbog ad-hoc veza
- ⏱️ Mjeseci razvoja za osnovne integracije

**S MCP-om:**
- ⚡ Integracija alata plug-and-play principom
- 🔄 Nezavisna arhitektura bez vezanosti uz dobavljače
- 🛡️ Ugrađene najbolje sigurnosne prakse
- 🚀 Dodavanje novih mogućnosti u nekoliko minuta

### 🏗️ Dubinski pregled MCP arhitekture

MCP koristi **klijent-server arhitekturu** koja stvara siguran i skalabilan ekosustav:

```mermaid
graph TB
    A[AI Application/Agent] --> B[MCP Client]
    B --> C[MCP Server 1: Files]
    B --> D[MCP Server 2: Web APIs]
    B --> E[MCP Server 3: Database]
    B --> F[MCP Server N: Custom Tools]
    
    C --> G[Local File System]
    D --> H[External APIs]
    E --> I[Database Systems]
    F --> J[Enterprise Systems]
```

**🔧 Glavne komponente:**

| Komponenta | Uloga | Primjeri |
|------------|-------|----------|
| **MCP Hosts** | Aplikacije koje koriste MCP usluge | Claude Desktop, VS Code, AI Toolkit |
| **MCP Clients** | Rukovatelji protokolom (1:1 sa serverima) | Ugrađeni u host aplikacije |
| **MCP Servers** | Izlažu mogućnosti putem standardnog protokola | Playwright, Files, Azure, GitHub |
| **Transport Layer** | Metode komunikacije | stdio, HTTP, WebSockets |


## 🏢 Microsoftov MCP server ekosustav

Microsoft predvodi MCP ekosustav s opsežnim paketom serverskih rješenja za poslovne potrebe.

### 🌟 Istaknuti Microsoft MCP serveri

#### 1. ☁️ Azure MCP Server
**🔗 Repository**: [azure/azure-mcp](https://github.com/azure/azure-mcp)
**🎯 Namjena**: Sveobuhvatno upravljanje Azure resursima s AI integracijom

**✨ Ključne značajke:**
- Deklarativno upravljanje infrastrukturom
- Praćenje resursa u stvarnom vremenu
- Preporuke za optimizaciju troškova
- Provjera usklađenosti sa sigurnosnim standardima

**🚀 Primjeri upotrebe:**
- Infrastructure-as-Code s AI podrškom
- Automatsko skaliranje resursa
- Optimizacija troškova u oblaku
- Automatizacija DevOps procesa

#### 2. 📊 Microsoft Dataverse MCP
**📚 Dokumentacija**: [Microsoft Dataverse Integration](https://go.microsoft.com/fwlink/?linkid=2320176)
**🎯 Namjena**: Sučelje za poslovne podatke na prirodnom jeziku

**✨ Ključne značajke:**
- Upiti baze podataka na prirodnom jeziku
- Razumijevanje poslovnog konteksta
- Prilagođeni predlošci za upite
- Upravljanje podacima u poduzeću

**🚀 Primjeri upotrebe:**
- Izvještavanje poslovne inteligencije
- Analiza podataka o korisnicima
- Pregled prodajnog procesa
- Upiti za usklađenost podataka

#### 3. 🌐 Playwright MCP Server
**🔗 Repository**: [microsoft/playwright-mcp](https://github.com/microsoft/playwright-mcp)
**🎯 Namjena**: Automatizacija preglednika i web interakcija

**✨ Ključne značajke:**
- Automatizacija za više preglednika (Chrome, Firefox, Safari)
- Inteligentno prepoznavanje elemenata
- Snimanje zaslona i generiranje PDF-a
- Praćenje mrežnog prometa

**🚀 Primjeri upotrebe:**
- Automatizirani testni tijekovi
- Web scraping i ekstrakcija podataka
- Praćenje UI/UX elemenata
- Automatizacija konkurentske analize

#### 4. 📁 Files MCP Server
**🔗 Repository**: [microsoft/files-mcp-server](https://github.com/microsoft/files-mcp-server)
**🎯 Namjena**: Inteligentno upravljanje datotekama

**✨ Ključne značajke:**
- Deklarativno upravljanje datotekama
- Sinkronizacija sadržaja
- Integracija s kontrolom verzija
- Ekstrakcija metapodataka

**🚀 Primjeri upotrebe:**
- Upravljanje dokumentacijom
- Organizacija repozitorija koda
- Radni tokovi za objavljivanje sadržaja
- Rukovanje datotekama u podatkovnim cjevovodima

#### 5. 📝 MarkItDown MCP Server
**🔗 Repository**: [microsoft/markitdown](https://github.com/microsoft/markitdown)
**🎯 Namjena**: Napredno procesiranje i manipulacija Markdown sadržajem

**✨ Ključne značajke:**
- Bogato parsiranje Markdowna
- Konverzija formata (MD ↔ HTML ↔ PDF)
- Analiza strukture sadržaja
- Obrada predložaka

**🚀 Primjeri upotrebe:**
- Radni tokovi tehničke dokumentacije
- Sustavi za upravljanje sadržajem
- Generiranje izvještaja
- Automatizacija baze znanja

#### 6. 📈 Clarity MCP Server
**📦 Paket**: [@microsoft/clarity-mcp-server](https://www.npmjs.com/package/@microsoft/clarity-mcp-server)
**🎯 Namjena**: Web analitika i uvidi u ponašanje korisnika

**✨ Ključne značajke:**
- Analiza heatmap podataka
- Snimke korisničkih sesija
- Metrike performansi
- Analiza konverzijskih tokova

**🚀 Primjeri upotrebe:**
- Optimizacija web stranica
- Istraživanje korisničkog iskustva
- Analiza A/B testiranja
- Poslovni inteligencijski dashboardi

### 🌍 Zajednički ekosustav

Osim Microsoftovih servera, MCP ekosustav uključuje:
- **🐙 GitHub MCP**: Upravljanje repozitorijima i analiza koda
- **🗄️ Database MCPs**: Integracije za PostgreSQL, MySQL, MongoDB
- **☁️ Cloud Provider MCPs**: Alati za AWS, GCP, Digital Ocean
- **📧 Communication MCPs**: Integracije za Slack, Teams, Email

## 🛠️ Praktična radionica: Izrada agenta za automatizaciju preglednika

**🎯 Cilj projekta**: Izraditi inteligentnog agenta za automatizaciju preglednika koristeći Playwright MCP server koji može pregledavati web stranice, izvlačiti informacije i izvoditi složene web interakcije.

### 🚀 Faza 1: Postavljanje temelja agenta

#### Korak 1: Inicijalizirajte svog agenta
1. **Otvorite AI Toolkit Agent Builder**
2. **Kreirajte novog agenta** s konfiguracijom:
   - **Ime**: `BrowserAgent`
   - **Model**: Choose GPT-4o 

![BrowserAgent](../../../../translated_images/BrowserAgent.09c1adde5e136573b64ab1baecd830049830e295eac66cb18bebb85fb386e00a.hr.png)


### 🔧 Phase 2: MCP Integration Workflow

#### Step 3: Add MCP Server Integration
1. **Navigate to Tools Section** in Agent Builder
2. **Click "Add Tool"** to open the integration menu
3. **Select "MCP Server"** from available options

![AddMCP](../../../../translated_images/AddMCP.afe3308ac20aa94469a5717b632d77b2197b9838a438b05d39aeb2db3ec47ef1.hr.png)

**🔍 Understanding Tool Types:**
- **Built-in Tools**: Pre-configured AI Toolkit functions
- **MCP Servers**: External service integrations
- **Custom APIs**: Your own service endpoints
- **Function Calling**: Direct model function access

#### Step 4: MCP Server Selection
1. **Choose "MCP Server"** option to proceed
![AddMCPServer](../../../../translated_images/AddMCPServer.69b911ccef872cbd0d0c0c2e6a00806916e1673e543b902a23dee23e6ff54b4c.hr.png)

2. **Browse MCP Catalog** to explore available integrations
![MCPCatalog](../../../../translated_images/MCPCatalog.a817d053145699006264f5a475f2b48fbd744e43633f656b6453c15a09ba5130.hr.png)


### 🎮 Phase 3: Playwright MCP Configuration

#### Step 5: Select and Configure Playwright
1. **Click "Use Featured MCP Servers"** to access Microsoft's verified servers
2. **Select "Playwright"** from the featured list
3. **Accept Default MCP ID** or customize for your environment

![MCPID](../../../../translated_images/MCPID.67d446052979e819c945ff7b6430196ef587f5217daadd3ca52fa9659c1245c9.hr.png)

#### Step 6: Enable Playwright Capabilities
**🔑 Critical Step**: Select **ALL** available Playwright methods for maximum functionality

![Tools](../../../../translated_images/Tools.3ea23c447b4d9feccbd7101e6dcf9e27cb0e5273f351995fde62c5abf9a78b4c.hr.png)

**🛠️ Essential Playwright Tools:**
- **Navigation**: `goto`, `goBack`, `goForward`, `reload`
- **Interaction**: `click`, `fill`, `press`, `hover`, `drag`
- **Extraction**: `textContent`, `innerHTML`, `getAttribute`
- **Validation**: `isVisible`, `isEnabled`, `waitForSelector`
- **Capture**: `screenshot`, `pdf`, `video`
- **Network**: `setExtraHTTPHeaders`, `route`, `waitForResponse`

#### Korak 7: Provjerite uspješnost integracije
**✅ Indikatori uspjeha:**
- Svi alati vidljivi u sučelju Agent Buildera
- Nema poruka o greškama u panelu za integraciju
- Status Playwright servera prikazuje "Connected"

![AgentTools](../../../../translated_images/AgentTools.053cfb96a17e02199dcc6563010d2b324d4fc3ebdd24889657a6950647a52f63.hr.png)

**🔧 Rješavanje uobičajenih problema:**
- **Neuspjela veza**: Provjerite internetsku vezu i postavke vatrozida
- **Nedostaju alati**: Provjerite jesu li sve mogućnosti odabrane tijekom postavljanja
- **Greške dozvola**: Provjerite ima li VS Code potrebne sistemske dozvole

### 🎯 Faza 4: Napredno oblikovanje promptova

#### Korak 8: Dizajnirajte inteligentne sistemske promptove
Kreirajte sofisticirane promptove koji koriste sve mogućnosti Playwrighta:

```markdown
# Web Automation Expert System Prompt

## Core Identity
You are an advanced web automation specialist with deep expertise in browser automation, web scraping, and user experience analysis. You have access to Playwright tools for comprehensive browser control.

## Capabilities & Approach
### Navigation Strategy
- Always start with screenshots to understand page layout
- Use semantic selectors (text content, labels) when possible
- Implement wait strategies for dynamic content
- Handle single-page applications (SPAs) effectively

### Error Handling
- Retry failed operations with exponential backoff
- Provide clear error descriptions and solutions
- Suggest alternative approaches when primary methods fail
- Always capture diagnostic screenshots on errors

### Data Extraction
- Extract structured data in JSON format when possible
- Provide confidence scores for extracted information
- Validate data completeness and accuracy
- Handle pagination and infinite scroll scenarios

### Reporting
- Include step-by-step execution logs
- Provide before/after screenshots for verification
- Suggest optimizations and alternative approaches
- Document any limitations or edge cases encountered

## Ethical Guidelines
- Respect robots.txt and rate limiting
- Avoid overloading target servers
- Only extract publicly available information
- Follow website terms of service
```

#### Korak 9: Kreirajte dinamične korisničke promptove
Dizajnirajte promptove koji demonstriraju različite funkcionalnosti:

**🌐 Primjer web analize:**
```markdown
Navigate to github.com/kinfey and provide a comprehensive analysis including:
1. Repository structure and organization
2. Recent activity and contribution patterns  
3. Documentation quality assessment
4. Technology stack identification
5. Community engagement metrics
6. Notable projects and their purposes

Include screenshots at key steps and provide actionable insights.
```

![Prompt](../../../../translated_images/Prompt.bfc846605db4999f4d9c1b09c710ef63cae7b3057444e68bf07240fb142d9f8f.hr.png)

### 🚀 Faza 5: Izvršavanje i testiranje

#### Korak 10: Pokrenite svoju prvu automatizaciju
1. **Kliknite "Run"** za pokretanje automatizacije
2. **Pratite izvršenje u stvarnom vremenu**:
   - Chrome preglednik se automatski pokreće
   - Agent navigira do ciljne web stranice
   - Snimke zaslona bilježe svaki važan korak
   - Rezultati analize stižu u stvarnom vremenu

![Browser](../../../../translated_images/Browser.ec011d0bd64d0d112c8a29bd8cc44c76d0bbfd0b019cb2983ef679328435ce5d.hr.png)

#### Korak 11: Analizirajte rezultate i uvide
Pregledajte detaljnu analizu u sučelju Agent Buildera:

![Result](../../../../translated_images/Result.8638f2b6703e9ea6d58d4e4475e39456b6a51d4c787f9bf481bae694d370a69a.hr.png)

### 🌟 Faza 6: Napredne mogućnosti i implementacija

#### Korak 12: Izvezite i implementirajte u produkciju
Agent Builder podržava više opcija za implementaciju:

![Code](../../../../translated_images/Code.d9eeeead0b96db0ca19c5b10ad64cfea8c1d0d1736584262970a4d43e1403d13.hr.png)

## 🎓 Sažetak modula 2 i sljedeći koraci

### 🏆 Postignuće otključano: Majstor integracije MCP-a

**✅ Savladane vještine:**
- [ ] Razumijevanje MCP arhitekture i prednosti
- [ ] Navigacija Microsoftovim MCP server ekosustavom
- [ ] Integracija Playwright MCP s AI Toolkitom
- [ ] Izrada sofisticiranih agenata za automatizaciju preglednika
- [ ] Napredno oblikovanje promptova za web automatizaciju

### 📚 Dodatni resursi

- **🔗 MCP specifikacija**: [Službena dokumentacija protokola](https://modelcontextprotocol.io/)
- **🛠️ Playwright API**: [Kompletan pregled metoda](https://playwright.dev/docs/api/class-playwright)
- **🏢 Microsoft MCP serveri**: [Vodič za poslovne integracije](https://github.com/microsoft/mcp-servers)
- **🌍 Primjeri zajednice**: [Galerija MCP servera](https://github.com/modelcontextprotocol/servers)

**🎉 Čestitamo!** Uspješno ste savladali integraciju MCP-a i sada možete graditi produkcijski spremne AI agente s mogućnostima vanjskih alata!

### 🔜 Nastavite na sljedeći modul

Spremni za podizanje MCP vještina na višu razinu? Krenite na **[Modul 3: Napredni razvoj MCP-a s AI Toolkitom](../lab3/README.md)** gdje ćete naučiti kako:
- Kreirati vlastite prilagođene MCP servere
- Konfigurirati i koristiti najnoviji MCP Python SDK
- Postaviti MCP Inspector za ispravljanje pogrešaka
- Ovladati naprednim radnim tokovima razvoja MCP servera
- Izgraditi Weather MCP Server od nule

**Odricanje od odgovornosti**:  
Ovaj je dokument preveden korištenjem AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za važne informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešne interpretacije koje proizlaze iz korištenja ovog prijevoda.