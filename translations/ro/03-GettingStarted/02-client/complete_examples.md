<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:36:14+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "ro"
}
-->
# Exemple complete de clienți MCP

Acest director conține exemple complete și funcționale de clienți MCP în diferite limbaje de programare. Fiecare client demonstrează funcționalitatea completă descrisă în tutorialul principal README.md.

## Clienți disponibili

### 1. Client Java (`client_example_java.java`)
- **Transport**: SSE (Server-Sent Events) peste HTTP
- **Server țintă**: `http://localhost:8080`
- **Funcționalități**: 
  - Stabilirea conexiunii și ping
  - Listarea uneltelor
  - Operații calculator (adunare, scădere, înmulțire, împărțire, ajutor)
  - Gestionarea erorilor și extragerea rezultatelor

**Pentru rulare:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. Client C# (`client_example_csharp.cs`)
- **Transport**: Stdio (Intrare/Ieșire standard)
- **Server țintă**: Server MCP .NET local prin dotnet run
- **Funcționalități**:
  - Pornire automată a serverului prin transport stdio
  - Listarea uneltelor și resurselor
  - Operații calculator
  - Parsare rezultate JSON
  - Gestionare completă a erorilor

**Pentru rulare:**
```bash
dotnet run
```

### 3. Client TypeScript (`client_example_typescript.ts`)
- **Transport**: Stdio (Intrare/Ieșire standard)
- **Server țintă**: Server MCP Node.js local
- **Funcționalități**:
  - Suport complet pentru protocolul MCP
  - Operații cu unelte, resurse și prompturi
  - Operații calculator
  - Citirea resurselor și executarea prompturilor
  - Gestionare robustă a erorilor

**Pentru rulare:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Client Python (`client_example_python.py`)
- **Transport**: Stdio (Intrare/Ieșire standard)  
- **Server țintă**: Server MCP Python local
- **Funcționalități**:
  - Model async/await pentru operații
  - Descoperirea uneltelor și resurselor
  - Testarea operațiilor calculator
  - Citirea conținutului resurselor
  - Organizare bazată pe clase

**Pentru rulare:**
```bash
python client_example_python.py
```

## Funcționalități comune tuturor clienților

Fiecare implementare de client demonstrează:

1. **Gestionarea conexiunii**
   - Stabilirea conexiunii cu serverul MCP
   - Tratarea erorilor de conexiune
   - Curățare și gestionare corectă a resurselor

2. **Descoperirea serverului**
   - Listarea uneltelor disponibile
   - Listarea resurselor disponibile (unde este suportat)
   - Listarea prompturilor disponibile (unde este suportat)

3. **Invocarea uneltelor**
   - Operații de bază ale calculatorului (adunare, scădere, înmulțire, împărțire)
   - Comanda de ajutor pentru informații despre server
   - Transmiterea corectă a argumentelor și gestionarea rezultatelor

4. **Gestionarea erorilor**
   - Erori de conexiune
   - Erori la execuția uneltelor
   - Eșecuri elegante și feedback pentru utilizator

5. **Procesarea rezultatelor**
   - Extragerea conținutului text din răspunsuri
   - Formatarea ieșirii pentru lizibilitate
   - Tratarea diferitelor formate de răspuns

## Cerințe preliminare

Înainte de a rula acești clienți, asigură-te că:

1. **Serverul MCP corespunzător este pornit** (din `../01-first-server/`)
2. **Dependențele necesare sunt instalate** pentru limbajul ales
3. **Conectivitatea de rețea este funcțională** (pentru transporturile bazate pe HTTP)

## Diferențe cheie între implementări

| Limbaj    | Transport | Pornire server | Model Async | Biblioteci principale |
|-----------|-----------|----------------|-------------|-----------------------|
| Java      | SSE/HTTP  | Extern         | Sincron     | WebFlux, MCP SDK      |
| C#        | Stdio     | Automat        | Async/Await | .NET MCP SDK          |
| TypeScript| Stdio     | Automat        | Async/Await | Node MCP SDK          |
| Python    | Stdio     | Automat        | AsyncIO     | Python MCP SDK        |

## Pașii următori

După ce ai explorat aceste exemple de clienți:

1. **Modifică clienții** pentru a adăuga funcționalități sau operații noi
2. **Creează propriul server** și testează-l cu acești clienți
3. **Experimentează cu diferite transporturi** (SSE vs. Stdio)
4. **Construiește o aplicație mai complexă** care să integreze funcționalitatea MCP

## Depanare

### Probleme comune

1. **Conexiune refuzată**: Verifică dacă serverul MCP rulează pe portul/calea așteptată
2. **Modulul nu a fost găsit**: Instalează SDK-ul MCP necesar pentru limbajul tău
3. **Permisiune refuzată**: Verifică permisiunile fișierelor pentru transportul stdio
4. **Unealta nu a fost găsită**: Asigură-te că serverul implementează uneltele așteptate

### Sfaturi pentru depanare

1. **Activează logarea detaliată** în SDK-ul MCP
2. **Verifică jurnalele serverului** pentru mesaje de eroare
3. **Confirmă că numele și semnăturile uneltelor** corespund între client și server
4. **Testează mai întâi cu MCP Inspector** pentru a valida funcționalitatea serverului

## Documentație conexă

- [Tutorial principal pentru client](./README.md)
- [Exemple server MCP](../../../../03-GettingStarted/01-first-server)
- [MCP cu integrare LLM](../../../../03-GettingStarted/03-llm-client)
- [Documentația oficială MCP](https://modelcontextprotocol.io/)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.