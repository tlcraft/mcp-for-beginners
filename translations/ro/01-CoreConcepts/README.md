<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T07:00:01+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "ro"
}
-->
# 📖 MCP Concepte de Bază: Stăpânirea Protocolului Contextual al Modelului pentru Integrarea AI

Protocolul Contextual al Modelului (MCP) este un cadru puternic și standardizat care optimizează comunicarea între Modelele de Limbaj de Mari Dimensiuni (LLMs) și instrumentele externe, aplicațiile și sursele de date. Acest ghid optimizat pentru SEO te va ghida prin conceptele de bază ale MCP, asigurându-te că înțelegi arhitectura client-server, componentele esențiale, mecanica de comunicare și cele mai bune practici de implementare.

## Prezentare Generală

Această lecție explorează arhitectura fundamentală și componentele care alcătuiesc ecosistemul Protocolului Contextual al Modelului (MCP). Vei învăța despre arhitectura client-server, componentele cheie și mecanismele de comunicare care alimentează interacțiunile MCP.

## 👩‍🎓 Obiective Cheie de Învățare

Până la sfârșitul acestei lecții, vei:

- Înțelege arhitectura client-server MCP.
- Identifica rolurile și responsabilitățile Gazdelor, Clienților și Serverelor.
- Analiza caracteristicile de bază care fac din MCP un strat de integrare flexibil.
- Învăța cum circulă informația în ecosistemul MCP.
- Obține perspective practice prin exemple de cod în .NET, Java, Python și JavaScript.

## 🔎 Arhitectura MCP: O Privire Mai Detaliată

Ecosistemul MCP este construit pe un model client-server. Această structură modulară permite aplicațiilor AI să interacționeze eficient cu instrumente, baze de date, API-uri și resurse contextuale. Să descompunem această arhitectură în componentele sale de bază.

### 1. Gazde

În Protocolul Contextual al Modelului (MCP), Gazdele joacă un rol crucial ca interfață principală prin care utilizatorii interacționează cu protocolul. Gazdele sunt aplicații sau medii care inițiază conexiuni cu serverele MCP pentru a accesa date, instrumente și solicitări. Exemple de Gazde includ medii de dezvoltare integrate (IDEs) precum Visual Studio Code, instrumente AI precum Claude Desktop, sau agenți personalizați proiectați pentru sarcini specifice.

**Gazdele** sunt aplicații LLM care inițiază conexiuni. Ele:

- Execută sau interacționează cu modelele AI pentru a genera răspunsuri.
- Inițiază conexiuni cu serverele MCP.
- Gestionează fluxul conversației și interfața cu utilizatorul.
- Controlează permisiunile și constrângerile de securitate.
- Se ocupă de consimțământul utilizatorului pentru partajarea datelor și executarea instrumentelor.

### 2. Clienți

Clienții sunt componente esențiale care facilitează interacțiunea între Gazde și serverele MCP. Clienții acționează ca intermediari, permițând Gazdelor să acceseze și să utilizeze funcționalitățile oferite de serverele MCP. Ei joacă un rol crucial în asigurarea unei comunicări fluente și a unui schimb de date eficient în cadrul arhitecturii MCP.

**Clienții** sunt conectori în cadrul aplicației gazdă. Ei:

- Trimit cereri către servere cu solicitări/instrucțiuni.
- Negociază capacitățile cu serverele.
- Gestionează cererile de executare a instrumentelor din modele.
- Procesează și afișează răspunsurile către utilizatori.

### 3. Servere

Serverele sunt responsabile de gestionarea cererilor de la clienții MCP și de furnizarea răspunsurilor corespunzătoare. Ele gestionează diverse operațiuni precum recuperarea datelor, executarea instrumentelor și generarea solicitărilor. Serverele asigură că comunicarea între clienți și Gazde este eficientă și fiabilă, menținând integritatea procesului de interacțiune.

**Serverele** sunt servicii care oferă context și capacități. Ele:

- Înregistrează funcționalitățile disponibile (resurse, solicitări, instrumente).
- Primesc și execută apeluri de instrumente de la client.
- Oferă informații contextuale pentru a îmbunătăți răspunsurile modelului.
- Returnează rezultate înapoi la client.
- Mențin starea pe parcursul interacțiunilor atunci când este necesar.

Serverele pot fi dezvoltate de oricine pentru a extinde capacitățile modelului cu funcționalități specializate.

### 4. Funcționalități ale Serverului

Serverele în Protocolul Contextual al Modelului (MCP) oferă blocuri fundamentale care permit interacțiuni bogate între clienți, gazde și modele de limbaj. Aceste funcționalități sunt concepute pentru a îmbunătăți capacitățile MCP prin oferirea de context structurat, instrumente și solicitări.

Serverele MCP pot oferi oricare dintre următoarele funcționalități:

#### 📑 Resurse

Resursele în Protocolul Contextual al Modelului (MCP) cuprind diverse tipuri de context și date care pot fi utilizate de utilizatori sau modele AI. Acestea includ:

- **Date Contextuale**: Informații și context pe care utilizatorii sau modelele AI le pot folosi pentru luarea deciziilor și executarea sarcinilor.
- **Baze de Cunoștințe și Repozitorii de Documente**: Colecții de date structurate și nestructurate, precum articole, manuale și lucrări de cercetare, care oferă perspective și informații valoroase.
- **Fișiere Locale și Baze de Date**: Date stocate local pe dispozitive sau în baze de date, accesibile pentru procesare și analiză.
- **API-uri și Servicii Web**: Interfețe externe și servicii care oferă date și funcționalități suplimentare, permițând integrarea cu diverse resurse și instrumente online.

Un exemplu de resursă poate fi un schema de bază de date sau un fișier care poate fi accesat astfel:

```text
file://log.txt
database://schema
```

### 🤖 Solicitări

Solicitările în Protocolul Contextual al Modelului (MCP) includ diverse șabloane predefinite și modele de interacțiune concepute pentru a eficientiza fluxurile de lucru ale utilizatorilor și a îmbunătăți comunicarea. Acestea includ:

- **Mesaje și Fluxuri de Lucru Șablonizate**: Mesaje și procese prestructurate care ghidează utilizatorii prin sarcini și interacțiuni specifice.
- **Modele de Interacțiune Predefinite**: Secvențe standardizate de acțiuni și răspunsuri care facilitează o comunicare consistentă și eficientă.
- **Șabloane de Conversație Specializate**: Șabloane personalizabile adaptate pentru tipuri specifice de conversații, asigurând interacțiuni relevante și adecvate contextual.

Un șablon de solicitare poate arăta astfel:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Instrumente

Instrumentele în Protocolul Contextual al Modelului (MCP) sunt funcții pe care modelul AI le poate executa pentru a îndeplini sarcini specifice. Aceste instrumente sunt concepute pentru a îmbunătăți capacitățile modelului AI prin oferirea de operațiuni structurate și fiabile. Aspectele cheie includ:

- **Funcții pentru Executarea de către Modelul AI**: Instrumentele sunt funcții executabile pe care modelul AI le poate invoca pentru a realiza diverse sarcini.
- **Nume Unic și Descriere**: Fiecare instrument are un nume distinct și o descriere detaliată care explică scopul și funcționalitatea sa.
- **Parametri și Rezultate**: Instrumentele acceptă parametri specifici și returnează rezultate structurate, asigurând rezultate consistente și previzibile.
- **Funcții Discrete**: Instrumentele realizează funcții discrete precum căutări web, calcule și interogări de baze de date.

Un exemplu de instrument ar putea arăta astfel:

```typescript
server.tool(
  "GetProducts"
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Funcționalități ale Clientului

În Protocolul Contextual al Modelului (MCP), clienții oferă mai multe funcționalități cheie serverelor, îmbunătățind funcționalitatea și interacțiunea generală în cadrul protocolului. Una dintre funcționalitățile notabile este Eșantionarea.

### 👉 Eșantionarea

- **Comportamente Agenționale Inițiate de Server**: Clienții permit serverelor să inițieze acțiuni sau comportamente specifice în mod autonom, îmbunătățind capacitățile dinamice ale sistemului.
- **Interacțiuni Recursive cu LLM**: Această funcționalitate permite interacțiuni recursive cu modelele de limbaj de mari dimensiuni (LLMs), permițând procesarea mai complexă și iterativă a sarcinilor.
- **Solicitarea Completărilor Suplimentare ale Modelului**: Serverele pot solicita completări suplimentare de la model, asigurându-se că răspunsurile sunt detaliate și relevante contextual.

## Fluxul de Informații în MCP

Protocolul Contextual al Modelului (MCP) definește un flux structurat de informații între gazde, clienți, servere și modele. Înțelegerea acestui flux ajută la clarificarea modului în care sunt procesate cererile utilizatorilor și cum sunt integrate instrumentele externe și datele în răspunsurile modelului.

- **Gazda Inițiază Conexiunea**  
  Aplicația gazdă (cum ar fi un IDE sau o interfață de chat) stabilește o conexiune la un server MCP, de obicei prin STDIO, WebSocket sau alt transport suportat.

- **Negocierea Capacităților**  
  Clientul (încorporat în gazdă) și serverul fac schimb de informații despre funcționalitățile, instrumentele, resursele și versiunile de protocol suportate. Acest lucru asigură că ambele părți înțeleg ce capacități sunt disponibile pentru sesiune.

- **Cererile Utilizatorului**  
  Utilizatorul interacționează cu gazda (de exemplu, introduce o solicitare sau un comandă). Gazda colectează această intrare și o transmite clientului pentru procesare.

- **Utilizarea Resurselor sau Instrumentelor**  
  - Clientul poate solicita context suplimentar sau resurse de la server (cum ar fi fișiere, înregistrări de baze de date sau articole din baza de cunoștințe) pentru a îmbogăți înțelegerea modelului.
  - Dacă modelul determină că este necesar un instrument (de exemplu, pentru a prelua date, a efectua un calcul sau a apela un API), clientul trimite o cerere de invocare a instrumentului către server, specificând numele și parametrii instrumentului.

- **Executarea Serverului**  
  Serverul primește cererea de resurse sau instrumente, execută operațiunile necesare (cum ar fi rularea unei funcții, interogarea unei baze de date sau recuperarea unui fișier) și returnează rezultatele către client într-un format structurat.

- **Generarea Răspunsului**  
  Clientul integrează răspunsurile serverului (datele resursei, rezultatele instrumentului etc.) în interacțiunea continuă a modelului. Modelul folosește aceste informații pentru a genera un răspuns cuprinzător și relevant contextual.

- **Prezentarea Rezultatelor**  
  Gazda primește rezultatul final de la client și îl prezintă utilizatorului, adesea incluzând atât textul generat de model, cât și orice rezultate din execuțiile instrumentelor sau căutările de resurse.

Acest flux permite MCP să sprijine aplicații AI avansate, interactive și conștiente de context prin conectarea fără probleme a modelelor cu instrumente și surse de date externe.

## Detalii ale Protocolului

MCP (Protocolul Contextual al Modelului) este construit pe [JSON-RPC 2.0](https://www.jsonrpc.org/), oferind un format de mesaj standardizat, agnostic față de limbaj, pentru comunicarea între gazde, clienți și servere. Această fundație permite interacțiuni fiabile, structurate și extensibile pe diverse platforme și limbaje de programare.

### Caracteristici Cheie ale Protocolului

MCP extinde JSON-RPC 2.0 cu convenții suplimentare pentru invocarea instrumentelor, accesul la resurse și gestionarea solicitărilor. Suportă mai multe straturi de transport (STDIO, WebSocket, SSE) și permite o comunicare sigură, extensibilă și agnostică față de limbaj între componente.

#### 🧢 Protocol de Bază

- **Formatul Mesajului JSON-RPC**: Toate cererile și răspunsurile folosesc specificația JSON-RPC 2.0, asigurând o structură consistentă pentru apelurile de metodă, parametrii, rezultate și gestionarea erorilor.
- **Conexiuni cu Stare**: Sesiunile MCP mențin starea pe parcursul mai multor cereri, sprijinind conversațiile continue, acumularea contextului și gestionarea resurselor.
- **Negocierea Capacităților**: În timpul configurării conexiunii, clienții și serverele fac schimb de informații despre funcționalitățile suportate, versiunile de protocol, instrumentele disponibile și resursele. Acest lucru asigură că ambele părți înțeleg capacitățile celuilalt și se pot adapta corespunzător.

#### ➕ Utilități Suplimentare

Mai jos sunt câteva utilități suplimentare și extensii de protocol pe care MCP le oferă pentru a îmbunătăți experiența dezvoltatorului și a permite scenarii avansate:

- **Opțiuni de Configurare**: MCP permite configurarea dinamică a parametrilor sesiunii, precum permisiunile instrumentelor, accesul la resurse și setările modelului, adaptate fiecărei interacțiuni.
- **Urmărirea Progresului**: Operațiunile de lungă durată pot raporta actualizări de progres, permițând interfețe de utilizator responsive și o experiență mai bună a utilizatorului în timpul sarcinilor complexe.
- **Anularea Cererilor**: Clienții pot anula cererile în curs de desfășurare, permițând utilizatorilor să întrerupă operațiunile care nu mai sunt necesare sau durează prea mult.
- **Raportarea Erorilor**: Mesaje și coduri de eroare standardizate ajută la diagnosticarea problemelor, gestionarea eșecurilor cu grație și oferirea de feedback acționabil utilizatorilor și dezvoltatorilor.
- **Jurnalizare**: Atât clienții, cât și serverele pot emite jurnale structurate pentru auditare, depanare și monitorizarea interacțiunilor protocolului.

Prin valorificarea acestor caracteristici ale protocolului, MCP asigură o comunicare robustă, sigură și flexibilă între modelele de limbaj și instrumentele sau sursele de date externe.

### 🔐 Considerații de Securitate

Implementările MCP ar trebui să adere la mai multe principii cheie de securitate pentru a asigura interacțiuni sigure și de încredere:

- **Consimțământul și Controlul Utilizatorului**: Utilizatorii trebuie să ofere consimțământ explicit înainte ca orice date să fie accesate sau operațiuni să fie efectuate. Ei ar trebui să aibă un control clar asupra datelor partajate și acțiunilor autorizate, susținut de interfețe de utilizator intuitive pentru revizuirea și aprobarea activităților.

- **Confidențialitatea Datelor**: Datele utilizatorului ar trebui să fie expuse doar cu consimțământ explicit și trebuie protejate prin controale de acces adecvate. Implementările MCP trebuie să se protejeze împotriva transmiterii neautorizate a datelor și să se asigure că confidențialitatea este menținută pe parcursul tuturor interacțiunilor.

- **Siguranța Instrumentelor**: Înainte de a invoca orice instrument, este necesar consimțământul explicit al utilizatorului. Utilizatorii ar trebui să aibă o înțelegere clară a funcționalității fiecărui instrument, iar limitele de securitate robuste trebuie să fie impuse pentru a preveni execuția neintenționată sau nesigură a instrumentelor.

Prin urmarea acestor principii, MCP asigură că încrederea, confidențialitatea și siguranța utilizatorului sunt menținute în toate interacțiunile protocolului.

## Exemple de Cod: Componente Cheie

Mai jos sunt exemple de cod în mai multe limbaje de programare populare care ilustrează cum să implementezi componentele cheie ale serverului MCP și instrumentele.

### Exemplu .NET: Crearea unui Server MCP Simplu cu Instrumente

Iată un exemplu practic de cod .NET care demonstrează cum să implementezi un server MCP simplu cu instrumente personalizate. Acest exemplu prezintă cum să definești și să înregistrezi instrumente, să gestionezi cererile și să conectezi serverul folosind Protocolul Contextual al Modelului.

```csharp
using System;
using System.Threading.Tasks;
using ModelContextProtocol.Server;
using ModelContextProtocol.Server.Transport;
using ModelContextProtocol.Server.Tools;

public class WeatherServer
{
    public static async Task Main(string[] args)
    {
        // Create an MCP server
        var server = new McpServer(
            name: "Weather MCP Server",
            version: "1.0.0"
        );
        
        // Register our custom weather tool
        server.AddTool<string, WeatherData>("weatherTool", 
            description: "Gets current weather for a location",
            execute: async (location) => {
                // Call weather API (simplified)
                var weatherData = await GetWeatherDataAsync(location);
                return weatherData;
            });
        
        // Connect the server using stdio transport
        var transport = new StdioServerTransport();
        await server.ConnectAsync(transport);
        
        Console.WriteLine("Weather MCP Server started");
        
        // Keep the server running until process is terminated
        await Task.Delay(-1);
    }
    
    private static async Task<WeatherData> GetWeatherDataAsync(string location)
    {
        // This would normally call a weather API
        // Simplified for demonstration
        await Task.Delay(100); // Simulate API call
        return new WeatherData { 
            Temperature = 72.5,
            Conditions = "Sunny",
            Location = location
        };
    }
}

public class WeatherData
{
    public double Temperature { get; set; }
    public string Conditions { get; set; }
    public string Location { get; set; }
}
```

### Exemplu Java: Componente ale Serverului MCP

Acest exemplu demonstrează același server MCP și înregistrarea instrumentelor ca în exemplul .

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți de faptul că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa maternă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională umană. Nu suntem responsabili pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.