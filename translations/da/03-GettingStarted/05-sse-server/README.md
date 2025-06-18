<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1681ca3633aeb49ee03766abdbb94a93",
  "translation_date": "2025-06-17T22:15:36+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "da"
}
-->
Nu hvor vi ved lidt mere om SSE, lad os bygge en SSE-server næste gang.

## Øvelse: Oprette en SSE-server

For at oprette vores server skal vi huske to ting:

- Vi skal bruge en webserver til at eksponere endpoints for forbindelse og beskeder.
- Byg vores server som vi normalt gør med værktøjer, ressourcer og prompts, som vi gjorde, da vi brugte stdio.

### -1- Opret en serverinstans

For at oprette vores server bruger vi de samme typer som med stdio. Men til transporten skal vi vælge SSE.

---

Lad os tilføje de nødvendige ruter næste gang.

### -2- Tilføj ruter

Lad os tilføje ruter, der håndterer forbindelsen og indkommende beskeder:

---

Lad os tilføje funktionaliteter til serveren nu.

### -3- Tilføjelse af serverfunktionaliteter

Nu hvor vi har defineret alt det, der er specifikt for SSE, lad os tilføje serverfunktionaliteter som værktøjer, prompts og ressourcer.

---

Din fulde kode skulle se sådan ud:

---

Fint, vi har en server, der bruger SSE, lad os prøve den af nu.

## Øvelse: Debugging af en SSE-server med Inspector

Inspector er et fantastisk værktøj, som vi så i en tidligere lektion [Opret din første server](/03-GettingStarted/01-first-server/README.md). Lad os se, om vi kan bruge Inspector her også:

### -1- Køre inspector

For at køre inspector skal du først have en SSE-server kørende, så lad os gøre det nu:

1. Kør serveren

---

1. Kør inspector

    > ![NOTE]
    > Kør dette i et separat terminalvindue end det, hvor serveren kører. Bemærk også, at du skal tilpasse nedenstående kommando, så den passer til den URL, hvor din server kører.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Det ser ens ud at køre inspector i alle runtime-miljøer. Bemærk, hvordan vi i stedet for at angive en sti til vores server og en kommando til at starte serveren, i stedet angiver URL’en, hvor serveren kører, og vi specificerer også `/sse`-ruten.

### -2- Prøv værktøjet af

Forbind til serveren ved at vælge SSE i dropdown-menuen og udfyld url-feltet med, hvor din server kører, for eksempel http:localhost:4321/sse. Klik nu på "Connect"-knappen. Som før, vælg at liste værktøjer, vælg et værktøj og angiv inputværdier. Du skulle gerne se et resultat som nedenfor:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.da.png)

Fint, du kan arbejde med inspector, lad os se, hvordan vi kan arbejde med Visual Studio Code næste gang.

## Opgave

Prøv at udbygge din server med flere funktionaliteter. Se [denne side](https://api.chucknorris.io/) for eksempelvis at tilføje et værktøj, der kalder et API. Du bestemmer, hvordan serveren skal se ud. Hav det sjovt :)

## Løsning

[Løsning](./solution/README.md) Her er en mulig løsning med fungerende kode.

## Vigtige pointer

De vigtigste pointer fra dette kapitel er:

- SSE er den anden understøttede transporttype efter stdio.
- For at understøtte SSE skal du håndtere indkommende forbindelser og beskeder ved hjælp af et webframework.
- Du kan bruge både Inspector og Visual Studio Code til at forbruge en SSE-server, ligesom med stdio-servere. Bemærk, hvordan det adskiller sig lidt mellem stdio og SSE. For SSE skal du starte serveren separat og derefter køre dit inspector-værktøj. For inspector-værktøjet er der også nogle forskelle, idet du skal angive URL’en.

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Yderligere ressourcer

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Hvad er det næste

- Næste: [HTTP Streaming med MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.