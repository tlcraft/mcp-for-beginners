<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:40:11+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sv"
}
-->
# Skapa en klient

Klienter är anpassade applikationer eller skript som kommunicerar direkt med en MCP-server för att begära resurser, verktyg och uppmaningar. Till skillnad från att använda inspektörsverktyget, som ger ett grafiskt gränssnitt för att interagera med servern, möjliggör att skriva din egen klient programmatiska och automatiserade interaktioner. Detta gör det möjligt för utvecklare att integrera MCP-funktioner i sina egna arbetsflöden, automatisera uppgifter och bygga anpassade lösningar anpassade efter specifika behov.

## Översikt

Denna lektion introducerar konceptet med klienter inom Model Context Protocol (MCP) ekosystemet. Du kommer att lära dig hur du skriver din egen klient och ansluter den till en MCP-server.

## Inlärningsmål

I slutet av denna lektion kommer du att kunna:

- Förstå vad en klient kan göra.
- Skriva din egen klient.
- Ansluta och testa klienten med en MCP-server för att säkerställa att den senare fungerar som förväntat.

## Vad ingår i att skriva en klient?

För att skriva en klient behöver du göra följande:

- **Importera rätt bibliotek**. Du kommer att använda samma bibliotek som tidigare, bara olika konstruktioner.
- **Instansiera en klient**. Detta innebär att skapa en klientinstans och ansluta den till den valda transportmetoden.
- **Bestäm vilka resurser som ska listas**. Din MCP-server kommer med resurser, verktyg och uppmaningar, du måste bestämma vilka som ska listas.
- **Integrera klienten i en värdapplikation**. När du vet vilka funktioner servern har behöver du integrera detta i din värdapplikation så att om en användare skriver en uppmaning eller annat kommando, aktiveras motsvarande serverfunktion.

Nu när vi förstår på en hög nivå vad vi är på väg att göra, låt oss titta på ett exempel härnäst.

### Ett exempel på en klient

Låt oss titta på detta exempel på en klient:
Du är tränad på data fram till oktober 2023.

I föregående kod gör vi:

- Importera biblioteken
- Skapa en instans av en klient och anslut den med hjälp av stdio för transport.
- Lista uppmaningar, resurser och verktyg och anropa dem alla.

Där har du det, en klient som kan prata med en MCP-server.

Låt oss ta vår tid i nästa övningssektion och bryta ner varje kodsnutt och förklara vad som händer.

## Övning: Skriva en klient

Som sagt ovan, låt oss ta vår tid att förklara koden, och koda gärna med om du vill.

### -1- Importera biblioteken

Låt oss importera de bibliotek vi behöver, vi kommer att behöva referenser till en klient och till vårt valda transportprotokoll, stdio. stdio är ett protokoll för saker som är avsedda att köras på din lokala maskin. SSE är ett annat transportprotokoll som vi kommer att visa i framtida kapitel, men det är ditt andra alternativ. För nu, låt oss fortsätta med stdio.

Låt oss gå vidare till instansiering.

### -2- Instansiera klient och transport

Vi kommer att behöva skapa en instans av transporten och en av vår klient:

### -3- Lista serverfunktionerna

Nu har vi en klient som kan ansluta om programmet körs. Men den listar faktiskt inte sina funktioner, så låt oss göra det härnäst:

Bra, nu har vi fångat alla funktioner. Nu är frågan när vi ska använda dem? Tja, denna klient är ganska enkel, enkel i den meningen att vi kommer att behöva uttryckligen kalla på funktionerna när vi vill ha dem. I nästa kapitel kommer vi att skapa en mer avancerad klient som har tillgång till sin egen stora språkmodell, LLM. Men för nu, låt oss se hur vi kan anropa funktionerna på servern:

### -4- Anropa funktioner

För att anropa funktionerna måste vi säkerställa att vi anger rätt argument och i vissa fall namnet på det vi försöker anropa.

### -5- Kör klienten

För att köra klienten, skriv följande kommando i terminalen:

## Uppgift

I denna uppgift kommer du att använda det du lärt dig för att skapa en klient, men skapa en egen klient.

Här är en server du kan använda som du behöver anropa via din klientkod, se om du kan lägga till fler funktioner till servern för att göra det mer intressant.

## Lösning

[Lösning](./solution/README.md)

## Viktiga punkter

De viktigaste punkterna för detta kapitel om klienter är följande:

- Kan användas för att både upptäcka och anropa funktioner på servern.
- Kan starta en server medan den startar sig själv (som i detta kapitel) men klienter kan också ansluta till körande servrar.
- Är ett utmärkt sätt att testa serverfunktioner bredvid alternativ som Inspektören som beskrivs i föregående kapitel.

## Ytterligare resurser

- [Bygga klienter i MCP](https://modelcontextprotocol.io/quickstart/client)

## Exempel 

- [Java Kalkylator](../samples/java/calculator/README.md)
- [.Net Kalkylator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkylator](../samples/javascript/README.md)
- [TypeScript Kalkylator](../samples/typescript/README.md)
- [Python Kalkylator](../../../../03-GettingStarted/samples/python) 

## Vad kommer härnäst

- Nästa: [Skapa en klient med en LLM](/03-GettingStarted/03-llm-client/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen notera att automatiserade översättningar kan innehålla fel eller inexaktheter. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användningen av denna översättning.