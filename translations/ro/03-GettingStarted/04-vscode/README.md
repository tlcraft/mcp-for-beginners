<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "54e9ffc5dba01afcb8880a9949fd1881",
  "translation_date": "2025-07-04T18:49:21+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "ro"
}
-->
Să discutăm mai mult despre cum folosim interfața vizuală în secțiunile următoare.

## Abordare

Iată cum trebuie să abordăm acest lucru la un nivel general:

- Configurăm un fișier pentru a găsi MCP Server-ul nostru.
- Pornim/Conectăm la serverul respectiv pentru a obține lista de capabilități.
- Folosim aceste capabilități prin interfața GitHub Copilot Chat.

Perfect, acum că înțelegem fluxul, să încercăm să folosim un MCP Server prin Visual Studio Code printr-un exercițiu.

## Exercițiu: Consumarea unui server

În acest exercițiu, vom configura Visual Studio Code să găsească MCP server-ul tău astfel încât să poată fi folosit din interfața GitHub Copilot Chat.

### -0- Pas preliminar, activarea descoperirii MCP Server

Este posibil să fie nevoie să activezi descoperirea MCP Server-elor.

1. Mergi la `File -> Preferences -> Settings` în Visual Studio Code.

1. Caută "MCP" și activează `chat.mcp.discovery.enabled` în fișierul settings.json.

### -1- Crearea fișierului de configurare

Începe prin a crea un fișier de configurare în rădăcina proiectului tău, vei avea nevoie de un fișier numit MCP.json pe care să-l plasezi într-un folder numit .vscode. Ar trebui să arate astfel:

```text
.vscode
|-- mcp.json
```

Următorul pas este să vedem cum putem adăuga o intrare pentru server.

### -2- Configurarea unui server

Adaugă următorul conținut în *mcp.json*:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

Mai sus este un exemplu simplu despre cum să pornești un server scris în Node.js, pentru alte medii de rulare indică comanda corectă pentru pornirea serverului folosind `command` și `args`.

### -3- Pornirea serverului

Acum că ai adăugat o intrare, să pornim serverul:

1. Găsește intrarea ta în *mcp.json* și asigură-te că vezi pictograma "play":

  ![Pornirea serverului în Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.ro.png)  

1. Apasă pe pictograma "play", ar trebui să vezi că pictograma de unelte din GitHub Copilot Chat crește numărul de unelte disponibile. Dacă apeși pe această pictogramă, vei vedea o listă cu uneltele înregistrate. Poți bifa/debifa fiecare unealtă în funcție de dacă vrei ca GitHub Copilot să le folosească ca context:

  ![Pornirea serverului în Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.ro.png)

1. Pentru a rula o unealtă, tastează un prompt despre care știi că se potrivește cu descrierea uneia dintre uneltele tale, de exemplu un prompt de genul "add 22 to 1":

  ![Rularea unei unelte din GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ro.png)

  Ar trebui să vezi un răspuns care spune 23.

## Tema

Încearcă să adaugi o intrare pentru server în fișierul tău *mcp.json* și asigură-te că poți porni/opri serverul. Asigură-te că poți comunica și cu uneltele de pe server prin interfața GitHub Copilot Chat.

## Soluție

[Soluție](./solution/README.md)

## Concluzii cheie

Concluziile din acest capitol sunt următoarele:

- Visual Studio Code este un client excelent care îți permite să consumi mai multe MCP Servere și uneltele lor.
- Interfața GitHub Copilot Chat este modul în care interacționezi cu serverele.
- Poți solicita utilizatorului să introducă date precum chei API care pot fi transmise MCP Server-ului atunci când configurezi intrarea serverului în fișierul *mcp.json*.

## Exemple

- [Calculator Java](../samples/java/calculator/README.md)
- [Calculator .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculator JavaScript](../samples/javascript/README.md)
- [Calculator TypeScript](../samples/typescript/README.md)
- [Calculator Python](../../../../03-GettingStarted/samples/python)

## Resurse suplimentare

- [Documentație Visual Studio](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Ce urmează

- Următorul: [Crearea unui SSE Server](../05-sse-server/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.